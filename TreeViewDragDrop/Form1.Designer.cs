namespace TreeViewDragDrop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sourceTree = new TreeViewDragDrop.TreeViewMultiSelect();
            this.destinationTree = new System.Windows.Forms.TreeView();
            this.btnProcess = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.folderPath = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceTree
            // 
            this.sourceTree.HideSelection = false;
            this.sourceTree.Location = new System.Drawing.Point(13, 65);
            this.sourceTree.Name = "sourceTree";
            this.sourceTree.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("sourceTree.SelectedNodes")));
            this.sourceTree.Size = new System.Drawing.Size(279, 392);
            this.sourceTree.TabIndex = 0;
            this.sourceTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sourceTree_MouseDown);
            // 
            // destinationTree
            // 
            this.destinationTree.AllowDrop = true;
            this.destinationTree.Location = new System.Drawing.Point(298, 65);
            this.destinationTree.Name = "destinationTree";
            this.destinationTree.Size = new System.Drawing.Size(286, 392);
            this.destinationTree.TabIndex = 1;
            this.destinationTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.destinationTree_DragDrop);
            this.destinationTree.DragOver += new System.Windows.Forms.DragEventHandler(this.destinationTree_DragOver);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(474, 463);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(110, 34);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // folderDialog
            // 
            this.folderDialog.ShowNewFolderButton = false;
            this.folderDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Select Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // folderPath
            // 
            this.folderPath.AutoSize = true;
            this.folderPath.Location = new System.Drawing.Point(128, 24);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(0, 13);
            this.folderPath.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(509, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 509);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.folderPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.destinationTree);
            this.Controls.Add(this.sourceTree);
            this.Name = "Form1";
            this.Text = "Tree View Drag Drop Prototype";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewMultiSelect sourceTree;
        private System.Windows.Forms.TreeView destinationTree;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label folderPath;
        private System.Windows.Forms.Button btnClear;
    }
}

