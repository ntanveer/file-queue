using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace FileQueueProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FileName",
                HeaderText = "File Name"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Path",
                HeaderText = "Path"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Size",
                HeaderText = "Size"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Date",
                HeaderText = "Date"
            });

            InitializeFileQueue();
        }

        private void PerformProgress()
        {
            progressBar1.PerformStep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var selectedPath = folderDialog.SelectedPath;
                var filesInPath = ProcessDirectory(new DirectoryInfo(selectedPath));

                SetupProgressBar(filesInPath);
                PushFilesToQueue(filesInPath);

                LogHelper.LogMessage("Total Files Processed: " + filesInPath.Count);
                logLabel.Visible = true;
            }
        }

        private void InitializeFileQueue()
        {
            fileQueue.Purge();
            AttachFileQueueEvents();
        }

        private void AttachFileQueueEvents()
        {
            fileQueue.ReceiveCompleted += fileQueue_ReceiveCompleted;
        }

        private void SetupProgressBar(List<FileInfo> filesInPath)
        {
            progressBar1.Maximum = filesInPath.Count;
        }

        private async void PushFilesToQueue(List<FileInfo> filesInPath)
        {
            foreach (var queueItem in filesInPath.Select(file => new QueueItem()
            {
                FileName = file.Name, LastTouched = file.LastAccessTime, Size = file.Length, Path = file.FullName
            }))
            {
                fileQueue.BeginReceive();
                var item = queueItem;
                await Task.Run(() => fileQueue.Send(item));
            }
        }

        void fileQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue message = sender as MessageQueue;

            var queueItem = e.Message.Body as QueueItem;

            dataGridView1.Rows.AddRange(new DataGridViewRow()
            {
                Cells = {
                    new DataGridViewTextBoxCell()
                    {
                        Value = queueItem.FileName
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = queueItem.Path
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = queueItem.Size
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = queueItem.LastTouched
                    }}
            });

            PerformProgress();
            message.EndReceive(e.AsyncResult);
        }

        private List<FileInfo> ProcessDirectory(DirectoryInfo directory, List<FileInfo> files = null)
        {
            var filesList = files ?? new List<FileInfo>();
            if (directory.Parent != null)
            {
                filesList = ProcessDirectory(directory.Parent, filesList);
            }
            filesList.AddRange(directory.GetFiles());

            return filesList;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("notepad.exe", LogHelper.LogFileName);
        }
    }
}
