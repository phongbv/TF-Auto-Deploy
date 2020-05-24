namespace SourceManagement
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetWorkspace = new System.Windows.Forms.Button();
            this.txtSourceBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbWorkspaceName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTargetBranchName = new System.Windows.Forms.Label();
            this.btnGetBranchPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSourceBranchPath = new System.Windows.Forms.Label();
            this.txtChangesetId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbMergeResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalPath.Location = new System.Drawing.Point(252, 52);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(500, 26);
            this.txtLocalPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Branch Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Workspace Name";
            // 
            // btnGetWorkspace
            // 
            this.btnGetWorkspace.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetWorkspace.Location = new System.Drawing.Point(775, 52);
            this.btnGetWorkspace.Name = "btnGetWorkspace";
            this.btnGetWorkspace.Size = new System.Drawing.Size(132, 26);
            this.btnGetWorkspace.TabIndex = 2;
            this.btnGetWorkspace.Text = "Get Workspace";
            this.btnGetWorkspace.UseVisualStyleBackColor = true;
            this.btnGetWorkspace.Click += new System.EventHandler(this.btnGetWorkspace_Click);
            // 
            // txtSourceBranch
            // 
            this.txtSourceBranch.Enabled = false;
            this.txtSourceBranch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceBranch.Location = new System.Drawing.Point(252, 214);
            this.txtSourceBranch.Name = "txtSourceBranch";
            this.txtSourceBranch.Size = new System.Drawing.Size(500, 26);
            this.txtSourceBranch.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Source Branch Name";
            // 
            // lbWorkspaceName
            // 
            this.lbWorkspaceName.AutoSize = true;
            this.lbWorkspaceName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWorkspaceName.Location = new System.Drawing.Point(249, 107);
            this.lbWorkspaceName.Name = "lbWorkspaceName";
            this.lbWorkspaceName.Size = new System.Drawing.Size(71, 18);
            this.lbWorkspaceName.TabIndex = 1;
            this.lbWorkspaceName.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Target Branch Name";
            // 
            // lbTargetBranchName
            // 
            this.lbTargetBranchName.AutoSize = true;
            this.lbTargetBranchName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTargetBranchName.Location = new System.Drawing.Point(249, 154);
            this.lbTargetBranchName.Name = "lbTargetBranchName";
            this.lbTargetBranchName.Size = new System.Drawing.Size(71, 18);
            this.lbTargetBranchName.TabIndex = 1;
            this.lbTargetBranchName.Text = "Unknown";
            // 
            // btnGetBranchPath
            // 
            this.btnGetBranchPath.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetBranchPath.Location = new System.Drawing.Point(775, 213);
            this.btnGetBranchPath.Name = "btnGetBranchPath";
            this.btnGetBranchPath.Size = new System.Drawing.Size(132, 26);
            this.btnGetBranchPath.TabIndex = 2;
            this.btnGetBranchPath.Text = "Get Branch Path";
            this.btnGetBranchPath.UseVisualStyleBackColor = true;
            this.btnGetBranchPath.Click += new System.EventHandler(this.btnGetBranchPath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Source Branch Path";
            // 
            // lbSourceBranchPath
            // 
            this.lbSourceBranchPath.AutoSize = true;
            this.lbSourceBranchPath.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceBranchPath.Location = new System.Drawing.Point(249, 277);
            this.lbSourceBranchPath.Name = "lbSourceBranchPath";
            this.lbSourceBranchPath.Size = new System.Drawing.Size(71, 18);
            this.lbSourceBranchPath.TabIndex = 1;
            this.lbSourceBranchPath.Text = "Unknown";
            // 
            // txtChangesetId
            // 
            this.txtChangesetId.Enabled = false;
            this.txtChangesetId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangesetId.Location = new System.Drawing.Point(252, 331);
            this.txtChangesetId.Name = "txtChangesetId";
            this.txtChangesetId.Size = new System.Drawing.Size(500, 26);
            this.txtChangesetId.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Changeset Id";
            // 
            // btnMerge
            // 
            this.btnMerge.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(775, 330);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(132, 26);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(126, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Merge Result";
            // 
            // lbMergeResult
            // 
            this.lbMergeResult.AutoSize = true;
            this.lbMergeResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMergeResult.Location = new System.Drawing.Point(249, 393);
            this.lbMergeResult.Name = "lbMergeResult";
            this.lbMergeResult.Size = new System.Drawing.Size(0, 18);
            this.lbMergeResult.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 491);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnGetBranchPath);
            this.Controls.Add(this.btnGetWorkspace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMergeResult);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbSourceBranchPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTargetBranchName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbWorkspaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChangesetId);
            this.Controls.Add(this.txtSourceBranch);
            this.Controls.Add(this.txtLocalPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetWorkspace;
        private System.Windows.Forms.TextBox txtSourceBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbWorkspaceName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTargetBranchName;
        private System.Windows.Forms.Button btnGetBranchPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSourceBranchPath;
        private System.Windows.Forms.TextBox txtChangesetId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbMergeResult;
    }
}

