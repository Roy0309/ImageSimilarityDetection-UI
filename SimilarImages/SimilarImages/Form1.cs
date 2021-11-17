using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class Form1 : Form
    {
        private int precision;
        private int threshold;
        private ImageHash.HashEnum hashEnum;
        private InterpolationMode interpolationMode;

        private List<string> folderPathes = new List<string>();
        private List<Tuple<string, string, double>> tuples = null;

        public Form1()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("zh-CN");
            InitializeComponent();
            toolTip1.ToolTipTitle = Message.Help;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pnl_Image1.Width = pnl_Main.Width / 2;
        }

        #region Config

        private void Form1_Load(object sender, EventArgs e)
        {
            tkb_Precision.Value = 20;
            tkb_Threshold.Value = 80;
            cmb_Algorithm.SelectedIndex = 0;
            cmb_Interpolation.SelectedIndex = 0;
            tb_Directory.Text = Message.DragHere;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            folderPathes.Clear();
            tb_Directory.Text = Message.DragHere;
            ClearResult();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] pathes = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string path in pathes)
                {
                    if (Directory.Exists(path))
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }

            e.Effect = DragDropEffects.None;
            MessageBox.Show(Message.FolderOnly, Message.Notice,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                folderPathes.AddRange((string[])e.Data.GetData(DataFormats.FileDrop));
                tb_Directory.Text = string.Join("; ", folderPathes);
            }
        }

        private void tkb_Precision_ValueChanged(object sender, EventArgs e)
        {
            toolTip2.SetToolTip((Control)sender, tkb_Precision.Value.ToString());
        }

        private void tkb_Precision_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, 
                Message.CurrentValue + tkb_Precision.Value + Message.PresionHelp);
        }

        private void cmb_Interpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_Interpolation.SelectedIndex)
            {
                case 0: interpolationMode = InterpolationMode.Default; break;
                case 1: interpolationMode = InterpolationMode.NearestNeighbor; break;
                case 2: interpolationMode = InterpolationMode.HighQualityBilinear; break;
                case 3: interpolationMode = InterpolationMode.HighQualityBicubic; break;
                default: break;
            }
        }

        private void cmb_Interpolation_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, Message.InterpolationHelp);
        }

        private void cmb_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashEnum = (ImageHash.HashEnum)cmb_Algorithm.SelectedIndex;
        }

        private void cmb_Algorithm_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, Message.AlgorithmHelp);
        }

        private void tkb_Threshold_ValueChanged(object sender, EventArgs e)
        {
            toolTip2.SetToolTip((Control)sender, $"{tkb_Threshold.Value}%");
        }

        private void tkb_Threshold_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((Control)sender, 
                Message.CurrentValue + tkb_Threshold.Value + Message.ThresholdHelp);
        }

        #endregion Config

        #region Process

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
            progressBar1.Visible = true;
            btn_Process.Enabled = false;
            bgw_Calculate.RunWorkerAsync();
        }

        private void ClearResult()
        {
            lvw_Result.Items.Clear();
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = null;
            lb_Image1.Text = Message.Image1;
            lb_Image1.Tag = null;
            lb_Resolution1.Text = null;
            pictureBox2.Image?.Dispose();
            pictureBox2.Image = null;
            lb_Image2.Text = Message.Image2;
            lb_Image2.Tag = null;
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
            Debug.WriteLine("ElapsedTime: " + watch.ElapsedMilliseconds + " ms");
        }

        private void bgw_Calculate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lvw_Result.Items.Clear();
            progressBar1.Visible = false;
            btn_Process.Enabled = true;
            if (tuples == null || tuples.Count == 0)
            {
                lvw_Result.Items.Add(Message.NoResult);
                return;
            }

            // Generate result list
            lvw_Result.BeginUpdate();
            for (int i = 0; i < tuples.Count; i++)
            {
                lvw_Result.Items.Add($"{Message.Result} {i + 1} - {tuples[i].Item3:P1}");
            }
            lvw_Result.EndUpdate();
            if (lvw_Result.Items.Count > 0)
            {
                lvw_Result.Items[0].Selected = true;
            }
            lvw_Result.Select();
        }

        #endregion Process

        #region Comparison

        private void lvw_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_Result.SelectedItems.Count < 1 ||
                lvw_Result.SelectedItems[0].Text == Message.NoResult)
            { return; }

            // Dispose previous images
            pictureBox1.Image?.Dispose();
            pictureBox2.Image?.Dispose();

            // Show images
            var selectedTuple = tuples[lvw_Result.SelectedIndices[0]];
            try
            {
                pictureBox1.Image = new Bitmap(selectedTuple.Item1);
                lb_Image1.Text = selectedTuple.Item1.Substring(selectedTuple.Item1.LastIndexOf('\\') + 1);
                lb_Image1.Tag = selectedTuple.Item1;
                lb_Resolution1.Text = $"{pictureBox1.Image.Width}*{pictureBox1.Image.Height}";
            }
            catch (ArgumentException)
            {
                pictureBox1.Image = null;
                lb_Image1.Text = Message.Deleted;
                lb_Image1.Tag = null;
                lb_Resolution1.Text = null;
            }
            try
            {
                pictureBox2.Image = new Bitmap(selectedTuple.Item2);
                lb_Image2.Text = selectedTuple.Item2.Substring(selectedTuple.Item2.LastIndexOf('\\') + 1);
                lb_Image2.Tag = selectedTuple.Item2;
                lb_Resolution2.Text = $"{pictureBox2.Image.Width}*{pictureBox2.Image.Height}";
            }
            catch (ArgumentException)
            {
                pictureBox2.Image = null;
                lb_Image2.Text = Message.Deleted;
                lb_Image2.Tag = null;
                lb_Resolution2.Text = null;
            }

            if (pictureBox1.Image != null && 
                pictureBox2.Image != null &&
                pictureBox1.Image.Width * pictureBox1.Image.Height >= 
                pictureBox2.Image.Width * pictureBox2.Image.Height)
            {
                lb_Resolution1.ForeColor = Color.Green;
                lb_Resolution2.ForeColor = Color.Black;
            }
            else
            {
                lb_Resolution1.ForeColor = Color.Black;
                lb_Resolution2.ForeColor = Color.Green;
            }
        }

        private void btn_Delete1_Click(object sender, EventArgs e)
        {
            DeleteImage(pictureBox1, lb_Image1);
        }

        private void btn_Delete2_Click(object sender, EventArgs e)
        {
            DeleteImage(pictureBox2, lb_Image2);
        }

        private void DeleteImage(PictureBox pictureBox, Label label)
        {
            if (pictureBox.Image == null) { return; }

            DialogResult dr = MessageBox.Show(
                Message.DeleteImage_1 + label.Text + Message.DeleteImage_2,
                Message.Confirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
                FileSystem.DeleteFile(label.Tag.ToString(),
                    UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                label.Text = Message.Deleted;
            }
        }

        private void btn_Open1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) { return; }
            Process.Start(lb_Image1.Tag.ToString());
        }

        private void btn_Open2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null) { return; }
            Process.Start(lb_Image2.Tag.ToString());
        }

        private void lb_Image1_MouseHover(object sender, EventArgs e)
        {
            if (lb_Image1.Tag != null)
            {
                toolTip2.SetToolTip((Control)sender, lb_Image1.Tag.ToString());
            }
        }

        private void lb_Image2_MouseHover(object sender, EventArgs e)
        {
            if (lb_Image1.Tag != null)
            {
                toolTip2.SetToolTip((Control)sender, lb_Image2.Tag.ToString());
            }
        }

        #endregion Comparison
    }
}
