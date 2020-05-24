using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TFS
{
    public class SourceUtil
    {
        public static int GetLatestSource(string[] args)
        {
            int latestChangesetId = -1;
            if (args == null || args.Length != 2)
            {
                System.Diagnostics.Debug.WriteLine("Arg[1]: Local Path, Arg[2]: Team Project");
                Write(latestChangesetId);
                return latestChangesetId;
            }
            Workspace currentWorkspace = null;
            //string localPath = @"C:\LOS_DEV";
            //string URL = "http://sptserver.ists.com.vn:8080/tfs/iLendingPro";
            string localPath = args[0];
            //WriteLine($"Local Path: {localPath}");
            string URL = args[1];
            System.Diagnostics.Debug.WriteLine($"Project Url: {URL}");
            TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(URL));
            VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
            vcs.Getting += Vcs_Getting;
            latestChangesetId = vcs.GetLatestChangesetId();
            System.Diagnostics.Debug.WriteLine($"Lastest changeset {latestChangesetId}");
            // Lấy ra thông tin workspace hiện tại
            var workspaces = vcs.QueryWorkspaces(null, vcs.AuthorizedUser, Environment.MachineName);
            foreach (var workspace in workspaces)
            {
                if (workspace.Folders.Any(e => e.IsCloaked == false && e.LocalItem == localPath))
                {
                    currentWorkspace = workspace;
                    break;
                }
            }
            if (currentWorkspace == null)
            {
                System.Diagnostics.Debug.WriteLine($"Không thể tìm được workspace tương ứng với folder {localPath}");
                Write(latestChangesetId);
                return latestChangesetId;
            }

            var allPendingChanges = currentWorkspace.GetPendingChanges();
            if (allPendingChanges.Length > 0)
            {

                System.Diagnostics.Debug.WriteLine($"Undo pending changes");
                currentWorkspace.Undo(currentWorkspace.GetPendingChanges());
            }
            var getStatus = currentWorkspace.Get(new GetRequest(null, latestChangesetId), GetOptions.None);
            System.Diagnostics.Debug.WriteLine($"Total item: {getStatus.NumFiles}");
            Write(latestChangesetId);
            return latestChangesetId;
        }

        private static void Vcs_Getting(object sender, GettingEventArgs e)
        {
            WriteLine($"Getting {e.ServerItem}");
        }
    }
}
