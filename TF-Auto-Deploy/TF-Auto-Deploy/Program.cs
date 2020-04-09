using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TF_Auto_Deploy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                WriteLine("Arg[1]: Local Path, Arg[2]: Team Project");
                return;
            }
            Workspace currentWorkspace = null;
            //string localPath = @"C:\LOS_DEV";
            //string URL = "http://sptserver.ists.com.vn:8080/tfs/iLendingPro";
            string localPath = args[0];
            WriteLine($"Local Path: {localPath}");
            string URL = args[1];
            WriteLine($"Project Url: {URL}");
            TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(URL));
            VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
            vcs.Getting += Vcs_Getting;
            var latestChangesetId = vcs.GetLatestChangesetId();
            WriteLine($"Lastest changeset {latestChangesetId}");
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
                WriteLine($"Không thể tìm được workspace tương ứng với folder {localPath}");
                return;
            }
            var allPendingChanges = currentWorkspace.GetPendingChanges();
            if (allPendingChanges.Length > 0)
            {

                WriteLine($"Undo pending changes");
                currentWorkspace.Undo(currentWorkspace.GetPendingChanges());
            }
            var getStatus = currentWorkspace.Get(new GetRequest(null, latestChangesetId), GetOptions.None);
            WriteLine($"Total item: {getStatus.NumFiles}");
        }

        private static void Vcs_Getting(object sender, GettingEventArgs e)
        {
            WriteLine($"Getting {e.ServerItem}");
        }
    }
}
