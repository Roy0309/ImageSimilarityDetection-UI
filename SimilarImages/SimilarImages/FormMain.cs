using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class FormMain : Form
    {
        private int precision;
        private int threshold;
        private ImageHash.HashEnum hashEnum;
        private InterpolationMode interpolationMode;

        private List<string> folderPathes = new List<string>();
        private List<Tuple<string, string, double>> tuples = null;

        public FormMain()
        {
            //CultureInfo.CurrentUICulture = new CultureInfo("zh-CN"); // Test zh-CN
            InitializeComponent();
            toolTipHelp.ToolTipTitle = Message.Help;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pnl_Image1.Width = pnl_Main.Width / 2;
        }

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
            toolTipMisc.SetToolTip((Control)sender, tkb_Precision.Value.ToString());
        }

        private void tkb_Precision_MouseHover(object sender, EventArgs e)
        {
            toolTipHelp.SetToolTip((Control)sender, 
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
            toolTipHelp.SetToolTip((Control)sender, Message.InterpolationHelp);
        }

        private void cmb_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashEnum = (ImageHash.HashEnum)cmb_Algorithm.SelectedIndex;
        }

        private void cmb_Algorithm_MouseHover(object sender, EventArgs e)
        {
            toolTipHelp.SetToolTip((Control)sender, Message.AlgorithmHelp);
        }

        private void tkb_Threshold_ValueChanged(object sender, EventArgs e)
        {
            toolTipMisc.SetToolTip((Control)sender, $"{tkb_Threshold.Value}%");
        }

        private void tkb_Threshold_MouseHover(object sender, EventArgs e)
        {
            toolTipHelp.SetToolTip((Control)sender, 
                Message.CurrentValue + tkb_Threshold.Value + Message.ThresholdHelp);
        }
    }
}
