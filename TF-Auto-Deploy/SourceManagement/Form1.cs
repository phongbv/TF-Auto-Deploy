using FindWorkItemChangesetDetails;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceManagement
{
    public partial class Form1 : Form
    {
        Workspace currentWorkspace = null;
        SourceUtil sourceUtil = new SourceUtil();
        string targetServerPath;
        string sourceServerPath;
        BranchObject targetBranch;
        BranchObject sourceBranch;
        public Form1()
        {
            InitializeComponent();
            ResetControl();
            txtLocalPath.Focus();
            txtLocalPath.Text = @"C:\LOS_SIT";
            txtSourceBranch.Text = "LOSRestruct2019";
        }

        private void btnGetWorkspace_Click(object sender, EventArgs e)
        {
            currentWorkspace = sourceUtil.GetWorkspace(txtLocalPath.Text);
            lbWorkspaceName.Text = currentWorkspace?.DisplayName;
            if (currentWorkspace == null)
            {
                MessageBox.Show("Không thể tìm thấy workspace");

                return;
            }
            targetServerPath = currentWorkspace.GetServerItemForLocalItem(txtLocalPath.Text);
            targetBranch = sourceUtil.GetBranch(targetServerPath);
            lbTargetBranchName.Text = targetBranch.Properties.RootItem.Item;
            txtSourceBranch.Enabled = true;
            btnGetBranchPath.Enabled = true;
        }

        private void ResetControl()
        {
            targetServerPath = null;
            targetBranch = null;
            sourceBranch = null;
            lbTargetBranchName.Text = null;
            lbSourceBranchPath.Text = null;
            btnGetBranchPath.Enabled = false;
            txtSourceBranch.Enabled = false;
            txtChangesetId.Enabled = false;
            txtChangesetId.Enabled = false;
            btnMerge.Enabled = false;
            lbMergeResult.Text = null;
        }

        private void btnGetBranchPath_Click(object sender, EventArgs e)
        {
            sourceBranch = sourceUtil.FindBranchByName(targetBranch, txtSourceBranch.Text);
            sourceServerPath = lbSourceBranchPath.Text = sourceBranch?.Properties?.RootItem?.Item;
            if (sourceBranch == null)
            {
                MessageBox.Show($"Không thể tìm thấy branch {txtSourceBranch.Text}");
                txtChangesetId.Text = null;
                txtChangesetId.Enabled = false;
                btnMerge.Enabled = false;
                return;
            }
            txtChangesetId.Enabled = true;
            btnMerge.Enabled = true;
            lbMergeResult.Text = null;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            ChangeEnabled(false);
            int changesetId;
            if (int.TryParse(txtChangesetId.Text, out changesetId))
            {
                lbMergeResult.Text = sourceUtil.MergeBranch(currentWorkspace, sourceServerPath, targetServerPath, changesetId);
                ChangeEnabled(true);
            }
            else
            {
                MessageBox.Show("Changeset phải là số");
            }

        }
        void ChangeEnabled(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = enabled;
            }
        }
    }
}
