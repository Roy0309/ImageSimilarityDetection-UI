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
        private List<Tuple<string, string, double>> similarityTuples = null;
        private Stopwatch watch = new Stopwatch();

        private void btn_Process_Click(object sender, EventArgs e)
        {
            // Check config
            hashConfig.Precision = tkb_Precision.Value;
            hashConfig.Threshold = tkb_Threshold.Value;
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

            pic_Image1.Image?.Dispose();
            pic_Image2.Image?.Dispose();
            pic_Image1.Image = null;
            pic_Image2.Image = null;
            lb_Image1.Text = Message.Image1;
            lb_Image2.Text = Message.Image2;
            lb_Resolution1.Text = null;
            lb_Resolution2.Text = null;

            currentImagePathPair[0] = null;
            currentImagePathPair[1] = null;
        }

        private void bgw_Calculate_DoWork(object sender, DoWorkEventArgs e)
        {
            watch.Restart();

            similarityTuples = null;
            similarityTuples = ImageHash.GetSimilarity(ref folderPathes, hashConfig, 
                out int validCount, out int similarCount);
            lb_Similarity.Invoke((Action)(()=> {
                lb_Similarity.Text = $"{(double)similarCount / validCount:P0}";
                tip_Misc.SetToolTip(lb_Similarity, $"{Message.SimilarityHelp} {similarCount}/{validCount}");
            }));

            watch.Stop();
            Debug.WriteLine($"GetSimilarity: {watch.ElapsedMilliseconds}ms");
        }

        private void bgw_Calculate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // No result 
            if (similarityTuples == null || similarityTuples.Count == 0)
            {
                lvw_Result.Items.Add(Message.NoResult);
                return;
            }

            lvw_Result.BeginInvoke(new UpdateListViewDelegate(UpdateListView));
        }

        private delegate void UpdateListViewDelegate();

        private void UpdateListView()
        {
            watch.Restart();

            // Generate result list
            List<ListViewItem> items = new List<ListViewItem>(similarityTuples.Count);
            for (int i = 0; i < similarityTuples.Count; i++)
            {
                items.Add(new ListViewItem($"{Message.Result} {i + 1} - {similarityTuples[i].Item3:P1}"));
            }

            lvw_Result.BeginUpdate();
            lvw_Result.Items.AddRange(items.ToArray());
            lvw_Result.EndUpdate();

            watch.Stop();
            Debug.WriteLine($"UpdateListView: {watch.ElapsedMilliseconds}ms");

            // Select the first one
            if (lvw_Result.Items.Count > 0)
            {
                lvw_Result.Items[0].Selected = true;
            }

            progressBar.Visible = false;
            btn_Process.Enabled = true;
        }
    }
}
