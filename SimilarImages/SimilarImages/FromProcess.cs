using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class FormMain
    {
        private void btn_Process_Click(object sender, EventArgs e)
        {
            // Check config
            precision = tkb_Precision.Value;
            threshold = tkb_Threshold.Value;
            if (folderPathes.Count == 0)
            {
                MessageBox.Show(Message.NoFolder, Message.Notice,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!folderPathes.TrueForAll((path) => Directory.Exists(path)))
            {
                MessageBox.Show(Message.FolderNotExist, Message.Notice,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Dispose previous items
            ClearResult();

            // Process
            progressBar.Visible = true;
            btn_Process.Enabled = false;
            bgw_Calculate.RunWorkerAsync();
        }

        private void ClearResult()
        {
            lvw_Result.Items.Clear();

            pictureBox1.Image?.Dispose();
            pictureBox2.Image?.Dispose();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            lb_Image1.Text = Message.Image1;
            lb_Image2.Text = Message.Image2;
            lb_Image1.Tag = null;
            lb_Image2.Tag = null;
            lb_Resolution1.Text = null;
            lb_Resolution2.Text = null;
        }

        private void bgw_Calculate_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            tuples = null;
            tuples = ImageHash.GetSimilarity(folderPathes, out int count,
                precision, interpolationMode, hashEnum, threshold);
            lb_Count.Invoke((Action)(() => { lb_Count.Text = count.ToString(); }));

            watch.Stop();
            Debug.WriteLine("GetSimilarity ElapsedTime: " + watch.ElapsedMilliseconds + " ms");
        }

        private void bgw_Calculate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // No result 
            if (tuples == null || tuples.Count == 0)
            {
                lvw_Result.Items.Add(Message.NoResult);
                return;
            }

            // Generate result list
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<ListViewItem> items = new List<ListViewItem>(tuples.Count);
            for (int i = 0; i < tuples.Count; i++)
            {
                items.Add(new ListViewItem($"{Message.Result} {i + 1} - {tuples[i].Item3:P1}"));
            }
            lvw_Result.BeginUpdate();
            lvw_Result.Items.AddRange(items.ToArray());
            lvw_Result.EndUpdate();
            watch.Stop();
            Debug.WriteLine("UpdateListView ElapsedTime: " + watch.ElapsedMilliseconds + " ms");

            // Select the first one
            if (lvw_Result.Items.Count > 0)
            {
                lvw_Result.Items[0].Selected = true;
            }
            lvw_Result.Select();

            progressBar.Visible = false;
            btn_Process.Enabled = true;
        }
    }
}
