using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class Form1 : Form
    {
        private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private int precision = 20;
        private double threshold = 0.8;
        private ImageHash.HashEnum hashEnum = ImageHash.HashEnum.Difference;
        private InterpolationMode interpolationMode = InterpolationMode.Default;
        private List<Tuple<string, string, double>> tuples = null;

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
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = "Choose a folder to find similar images.",
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
            // Allow 0-9, backspace and '.'
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
                e.KeyChar != '\b' && e.KeyChar != '.')
            { e.Handled = true; }
            // Only one '.'
            if (tb_Threshold.Text.Contains('.') && e.KeyChar == '.') { e.Handled = true; }
            // '.' can only come after '0'
            if (tb_Threshold.Text == "0" && e.KeyChar != '.') { e.Handled = true; }
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

        #endregion Config

        #region Process

        private void btn_Process_Click(object sender, EventArgs e)
        {
            bool validPrecision = int.TryParse(tb_Precision.Text, out precision);
            bool validThreshold = double.TryParse(tb_Threshold.Text, out threshold);
            bool validFolderPath = !string.IsNullOrEmpty(tb_Directory.Text);

            if (!AssertConfig(validPrecision, "Please input valid precision.")) { return; }
            if (!AssertConfig(precision >= 8, "Precision should be greater than 8.")) { return; }
            if (!AssertConfig(validThreshold,"Please input valid threshold [0,1).")) { return; }
            if (!AssertConfig(validFolderPath, "Please input valid folder path.")) { return; }

            progressBar1.Visible = true;
            lb_Empty.Visible = true;
            btn_Process.Enabled = false;
            bgw_Calculate.RunWorkerAsync();
        }

        private bool AssertConfig(bool successCondition, string failureTip)
        {
            if (!successCondition)
            {
                MessageBox.Show(failureTip, "Notice", 
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
