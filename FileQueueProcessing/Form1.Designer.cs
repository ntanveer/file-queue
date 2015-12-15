using System.ComponentModel;
using System.Messaging;
using System.Windows.Forms;

namespace FileQueueProcessing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fileQueue = new System.Messaging.MessageQueue();
            this.logLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // folderDialog
            //
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderDialog.SelectedPath = "C:\\";
            this.folderDialog.ShowNewFolderButton = false;
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = " Build Queue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1031, 391);
            this.dataGridView1.TabIndex = 1;
            //
            // progressBar1
            //
            this.progressBar1.Location = new System.Drawing.Point(166, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(806, 45);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            //
            // fileQueue
            //
            this.fileQueue.DefaultPropertiesToSend.Label = "FileQueueItem";
            this.fileQueue.MessageReadPropertyFilter.Label = false;
            this.fileQueue.MessageReadPropertyFilter.LookupId = true;
            this.fileQueue.Path = global::FileQueueProcessing.Properties.Settings.Default.File;
            this.fileQueue.SynchronizingObject = this;
            //
            // logLabel
            //
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(978, 40);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(65, 17);
            this.logLabel.TabIndex = 3;
            this.logLabel.TabStop = true;
            this.logLabel.Text = "View Log";
            this.logLabel.Visible = false;
            this.logLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 499);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "File Queue Processing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderBrowserDialog folderDialog;
        private Button button1;
        private DataGridView dataGridView1;
        private ProgressBar progressBar1;
        public MessageQueue fileQueue;
        private LinkLabel logLabel;

    }
}

