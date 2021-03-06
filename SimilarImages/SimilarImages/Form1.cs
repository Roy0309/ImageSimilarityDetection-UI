﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class Form1 : Form
    {
        private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private int precision = 20;
        private int threshold = 80;
        private ImageHash.HashEnum hashEnum = ImageHash.HashEnum.Difference;
        private InterpolationMode interpolationMode = InterpolationMode.Default;
        private List<Tuple<string, string, double>> tuples = null;
        private readonly bool isSimplifiedChinese = CultureInfo.CurrentUICulture.Name == "zh-CN";

        public Form1()
        {
            InitializeComponent();
        }

        #region Config

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_Algorithm.SelectedIndex = 0;
            cmb_Interpolation.SelectedIndex = 0;
            tb_Directory.Text = folderPath;
        }

        private void btn_Directory_Click(object sender, EventArgs e)
        {
            string description = "Choose a folder to find similar images.";
            if (isSimplifiedChinese) { description = "选择一个文件夹来寻找相似的图片。"; }
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = description,
                ShowNewFolderButton = false
            };
            fbd.ShowDialog();
            if (string.IsNullOrEmpty(fbd.SelectedPath)) { return; }
            tb_Directory.Text = fbd.SelectedPath;
            folderPath = fbd.SelectedPath;
        }

        private void tb_Precision_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Alow 0-9 and backspace
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            { e.Handled = true; }
        }

        private void tb_Threshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow 0-9, backspace
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            { e.Handled = true; }
        }

        private void cmb_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashEnum = (ImageHash.HashEnum)cmb_Algorithm.SelectedIndex;
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

        private void tb_Precision_Click(object sender, EventArgs e)
        {
            string tip = "Range: Greater than 8.\n" +
             "Usage: When sampling, resize images to \"Precision * Precision\".\n" +
             "Notice: Don't set it too large to run out of memory.";
            if (isSimplifiedChinese)
            {
                tip = "范围：大于 8。\n" +
                      "用途：采样时将图片缩放至 “精度 * 精度”。\n" +
                      "注意：不要设置得太大以免耗尽内存。";
            }
            toolTip1.SetToolTip((Control)sender, tip);
        }

        private void cmb_Interpolation_Click(object sender, EventArgs e)
        {
            string tip = "The interpolation mode when resizing images";
            if (isSimplifiedChinese)
            {
                tip = "图片缩放时的插值模式";
            }
            toolTip1.SetToolTip((Control)sender, tip);
        }

        private void cmb_Algorithm_Click(object sender, EventArgs e)
        {
            string tip = "The algorithm when calculating image hashes";
            if (isSimplifiedChinese)
            {
                tip = "计算图片哈希时使用的算法";
            }
            toolTip1.SetToolTip((Control)sender, tip);
        }

        private void tb_Threshold_Click(object sender, EventArgs e)
        {
            string tip = "Range: 0-99%.\n" +
                         "Usage: Return results greater than the threshold.\n" +
                         "Notice: Don't set a low threshold when processing mass images, " +
                                 "as the operation will take too long.";
            if (isSimplifiedChinese)
            {
                tip = "范围：0-99%。\n" +
                      "用途：返回大于阈值的结果。\n" +
                      "注意：当图片数量较多时，不要使用低阈值，以免耗时太长。";
            }
            toolTip1.SetToolTip((Control)sender, tip);
        }

        #endregion Config

        #region Process

        private void btn_Process_Click(object sender, EventArgs e)
        {
            bool validPrecision = int.TryParse(tb_Precision.Text, out precision);
            bool validThreshold = int.TryParse(tb_Threshold.Text, out threshold);
            bool validFolderPath = !string.IsNullOrEmpty(tb_Directory.Text) && Directory.Exists(tb_Directory.Text);

            string tip1 = "Please input valid precision.";
            string tip2 = "Precision should be greater than 8.";
            string tip3 = "Please input valid threshold (0,99).";
            string tip4 = "Please input valid folder path.";
            if (isSimplifiedChinese)
            {
                tip1 = "请输入合适的精度值。";
                tip2 = "精度值需要大于 8。";
                tip3 = "请输入合适的阈值 (0,99)。";
                tip4 = "请输入合适的文件夹路径。";
            }

            if (!AssertConfig(validPrecision, tip1)) { tb_Precision.Text = "20"; return; }
            if (!AssertConfig(precision >= 8, tip2)) { tb_Precision.Text = "20"; return; }
            if (!AssertConfig(validThreshold, tip3)) { tb_Threshold.Text = "80"; return; }
            if (!AssertConfig(threshold > 0 && threshold < 100, tip3)) { tb_Threshold.Text = "80"; return; }
            if (!AssertConfig(validFolderPath, tip4)) { return; }

            progressBar1.Visible = true;
            lb_Empty.Visible = true;
            btn_Process.Enabled = false;
            bgw_Calculate.RunWorkerAsync();
        }

        private bool AssertConfig(bool successCondition, string failureTip)
        {
            if (!successCondition)
            {
                MessageBox.Show(failureTip, isSimplifiedChinese ? "提示" : "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return successCondition;
        }

        private void bgw_Calculate_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            tuples = ImageHash.GetSimilarity(folderPath, out int count,
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
            if (tuples != null) { lb_Empty.Visible = false; }
            else { lb_Empty.Visible = true; return; }

            // Generate result list
            lvw_Result.BeginUpdate();
            for (int i = 0; i < tuples.Count; i++)
            {
                lvw_Result.Items.Add($"Result {i + 1} - {tuples[i].Item3:P1}");
            }
            lvw_Result.EndUpdate();
            lvw_Result.Items[0].Selected = true;
            lvw_Result.Select();
        }

        #endregion Process

        #region Comparison

        private void lvw_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_Result.SelectedItems.Count < 1) { return; }

            // Dispose previous images
            pictureBox1.Image?.Dispose();
            pictureBox2.Image?.Dispose();

            // Show images
            var selectedTuple = tuples[lvw_Result.SelectedIndices[0]];
            try
            {
                pictureBox1.Image = new Bitmap(Path.Combine(folderPath, selectedTuple.Item1));
                lb_Image1.Text = selectedTuple.Item1;
                lb_Resolution1.Text = $"{pictureBox1.Image.Width}*{pictureBox1.Image.Height}";
            }
            catch (ArgumentException)
            {
                pictureBox1.Image = null;
                lb_Image1.Text = "Deleted";
                lb_Resolution1.Text = "";
            }
            try
            {
                pictureBox2.Image = new Bitmap(Path.Combine(folderPath, selectedTuple.Item2));
                lb_Image2.Text = selectedTuple.Item2;
                lb_Resolution2.Text = $"{pictureBox2.Image.Width}*{pictureBox2.Image.Height}";
            }
            catch (ArgumentException)
            {
                pictureBox2.Image = null;
                lb_Image2.Text = "Deleted";
                lb_Resolution2.Text = "";
            }

            if (pictureBox1.Image.Width * pictureBox1.Image.Height >= 
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

            DialogResult dr = MessageBox.Show($"Move this image [{label.Text}] to recycle bin?",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
                FileSystem.DeleteFile(Path.Combine(folderPath, label.Text),
                    UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                label.Text = "Deleted";
            }
        }

        private void btn_Open1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) { return; }
            Process.Start(Path.Combine(folderPath, lb_Image1.Text));
        }

        private void btn_Open2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null) { return; }
            Process.Start(Path.Combine(folderPath, lb_Image2.Text));
        }

        #endregion Comparison
    }
}
