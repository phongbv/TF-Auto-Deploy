﻿using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace FindWorkItemChangesetDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            GetChangesForWorkItem();
        }

        private static void V1()
        {
            //Initialize TFS Server object
            TfsConfigurationServer configurationServer = TfsConfigurationServerFactory.GetConfigurationServer(new Uri(ConfigurationManager.AppSettings["TfsServer"]));

            //Get the catalog of team project collections
            CatalogNode catalogNode = configurationServer.CatalogNode;
            //Get all CatalogNodes which are ProjectCollection
            ReadOnlyCollection<CatalogNode> tpcNodes = catalogNode.QueryChildren(new Guid[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

            //Get InstanceId of a ProjectCollection
            Guid tpcId = Guid.Empty;
            foreach (CatalogNode tpcNode in tpcNodes)
            {
                tpcId = new Guid(tpcNode.Resource.Properties["InstanceId"]);
                break;
            }
            Workspace currentWorkspace = null;
            //string localPath = @"C:\LOS_DEV";
            string URL = "http://sptserver.ists.com.vn:8080/tfs/iLendingPro";
            //WriteLine($"Local Path: {localPath}");
            System.Diagnostics.Debug.WriteLine($"Project Url: {URL}");
            TfsTeamProjectCollection projectCollection = new TfsTeamProjectCollection(new Uri(URL));
            //Fill list of projects in a local variable
            //TfsTeamProjectCollection projectCollection = configurationServer.GetTeamProjectCollection(tpcId);
            projectCollection.Authenticate();

            //Get WorkItem Tracking client for workitem collection for selected ProjectCollection
            WorkItemStore workItemStore = projectCollection.GetService<WorkItemStore>();
            //Get Project from Tracking client
            Project project = workItemStore.Projects[ConfigurationManager.AppSettings["TfsProjectName"]];

            //List<int> changesetIds = new List<int>();
            //foreach (var item in File.ReadAllLines("list_item.txt"))
            //{
            //    int tmp = 0;
            //    if (int.TryParse(item, out tmp))
            //    {
            //        changesetIds.Add(tmp);
            //    }
            //}

            //
            QueryFolder teamQueryFolder = project.QueryHierarchy[ConfigurationManager.AppSettings["TfsQueryGroup"]] as QueryFolder;
            QueryItem queryItem = teamQueryFolder[ConfigurationManager.AppSettings["TfsQueryName"]];
            QueryDefinition queryDefinition = workItemStore.GetQueryDefinition(queryItem.Id);

            Dictionary<string, string> variables = new Dictionary<string, string> { { "@project", queryItem.Project.Name } };

            WorkItemCollection workItemCollection = workItemStore.Query(queryDefinition.QueryText, variables);

            DataTable dt = CreateDataTable();

            //Get Source Control/Version Control repository for selected project collection
            VersionControlServer versionControlServer = projectCollection.GetService<VersionControlServer>();
            //Get Details of Version Control using artifact provider
            VersionControlArtifactProvider artifactProvider = versionControlServer.ArtifactProvider;

            //Iterate through each item to get its details
            foreach (WorkItem workItem in workItemCollection)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = workItem.Id;
                dr["Title"] = workItem.Title;

                //use linq to get the linked changesets to a workitem
                IEnumerable<Changeset> changesets = workItem.Links.OfType<ExternalLink>().Select(link => artifactProvider.GetChangeset(new Uri(link.LinkedArtifactUri)));

                //iterate through changesets' to get each changeset details
                foreach (Changeset changeset in changesets)
                {
                    dr["ChangesetId"] = changeset.ChangesetId;
                    foreach (Change changes in changeset.Changes)
                    {
                        //ServerItem is the full path of a source control file associated to changeset
                        if (changes.Item.ServerItem.Contains(ConfigurationManager.AppSettings["DevBranchName"]))
                        {
                            dr["Fix in DevBranch"] = "Yes";
                            break;
                        }
                        else if (changes.Item.ServerItem.Contains(ConfigurationManager.AppSettings["ReleaseBranchName"]))
                        {
                            dr["Fix in ReleaseBranch"] = "Yes";
                            break;
                        }
                    }
                }

                dt.Rows.Add(dr);
            }
            //Write datable to excel file using StreamWriter
            WriteToExcel(dt);
        }
        private class ChangesetInfo : IComparable<ChangesetInfo>
        {
            public int ChangesetId { get; set; }
            public int WorkItemId { get; set; }
            public string Owner { get; set; }
            public int CompareTo(ChangesetInfo other)
            {
                return ChangesetId.CompareTo(other.ChangesetId);
            }

            public override string ToString()
            {
                return $"Changeset { ChangesetId} - WorkItem { WorkItemId } - Owner {Owner}";
            }
        }
        private static void GetChangesForWorkItem()
        {
            List<ChangesetInfo> allChangeset = new List<ChangesetInfo>();
            string URL = "http://sptserver.ists.com.vn:8080/tfs/iLendingPro";
            //WriteLine($"Local Path: {localPath}");
            System.Diagnostics.Debug.WriteLine($"Project Url: {URL}");
            TfsTeamProjectCollection collection = new TfsTeamProjectCollection(new Uri(URL));
            collection.Authenticate();
            //TfsTeamProjectCollection collection = configurationServer.GetTeamProjectCollection(collectionId);
            //Get Source Control/Version Control repository for selected project collection
            VersionControlServer versionControlServer = collection.GetService<VersionControlServer>();
            //Get Details of Version Control using artifact provider
            VersionControlArtifactProvider artifactProvider = versionControlServer.ArtifactProvider;
            var vcs = collection.GetService<VersionControlServer>();
            var store = new WorkItemStore(collection);
            var workItems = new List<WorkItem>();
            foreach (var item in File.ReadAllLines("list_item.txt"))
            {
                int tmp = 0;
                if (int.TryParse(item, out tmp))
                {
                    workItems.Add(store.GetWorkItem(tmp));
                }
            }

            DataTable dt = CreateDataTable();

            var associatedChangesets = new List<Changeset>();
            foreach (var workItem in workItems)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = workItem.Id;
                dr["Title"] = workItem.Title;
                IEnumerable<Changeset> changesets = workItem.Links.OfType<ExternalLink>().Select(link => artifactProvider.GetChangeset(new Uri(link.LinkedArtifactUri)));

                //iterate through changesets' to get each changeset details
                foreach (Changeset changeset in changesets)
                {
                    dr["ChangesetId"] = changeset.ChangesetId;
                    foreach (Change changes in changeset.Changes)
                    {
                        //ServerItem is the full path of a source control file associated to changeset
                        if (changes.Item.ServerItem.Contains(ConfigurationManager.AppSettings["DevBranchName"]))
                        {
                            dr["Fix in DevBranch"] = "Yes";
                            allChangeset.Add(new ChangesetInfo()
                            {
                                ChangesetId = changeset.ChangesetId,
                                WorkItemId = workItem.Id,
                                Owner = changeset.OwnerDisplayName
                            });
                            break;
                        }
                        else if (changes.Item.ServerItem.Contains(ConfigurationManager.AppSettings["ReleaseBranchName"]))
                        {
                            dr["Fix in ReleaseBranch"] = "Yes";
                            break;
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            File.WriteAllLines("AllChangeset.txt", allChangeset.Distinct().OrderBy(e => e).Select(e => e.ToString()));
            WriteToExcel(dt);
            Console.WriteLine(associatedChangesets.Select(x => x.ChangesetId).OrderBy(x => x));
        }

        public static DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("ChangesetId");

            dt.Columns.Add("Fix in DevBranch");
            dt.Columns.Add("Fix in ReleaseBranch");
            return dt;
        }

        public static void WriteToExcel(DataTable dataTable)
        {
            StreamWriter streamWriter = new StreamWriter(ConfigurationManager.AppSettings["ExcelFile"], false);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                streamWriter.Write(dataTable.Columns[i].ToString().ToUpper() + "\t");
            }
            streamWriter.WriteLine();

            for (int i = 0; i < (dataTable.Rows.Count); i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i][j] != null)
                    {
                        streamWriter.Write(Convert.ToString(dataTable.Rows[i][j]) + "\t");
                    }
                    else
                    {
                        streamWriter.Write("\t");
                    }
                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
        }
    }
}
