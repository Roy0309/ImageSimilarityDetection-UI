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
        private HashConfig hashConfig;
        private List<string> folderPathes = new List<string>();

        public FormMain()
        {
            //CultureInfo.CurrentUICulture = new CultureInfo("zh-CN"); // Test zh-CN
            InitializeComponent();
            InitMouseHoverTip();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            pnl_Image1.Width = pnl_Main.Width / 2;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
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

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                bool allExist = true;
                string[] pathes = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string path in pathes)
                {
                    if (!Directory.Exists(path))
                    {
                        allExist = false;
                        break;
                    }
                }
                if (allExist)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
            MessageBox.Show(Message.FolderOnly, Message.Notice,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                folderPathes.AddRange((string[])e.Data.GetData(DataFormats.FileDrop));
                tb_Directory.Text = string.Join("; ", folderPathes);
            }
        }

        private void tkb_Precision_ValueChanged(object sender, EventArgs e)
        {
            tip_Misc.SetToolTip((Control)sender, tkb_Precision.Value.ToString());
        }

        private void cmb_Interpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_Interpolation.SelectedIndex)
            {
                case 0: hashConfig.InterpolationMode = InterpolationMode.Default; break;
                case 1: hashConfig.InterpolationMode = InterpolationMode.NearestNeighbor; break;
                case 2: hashConfig.InterpolationMode = InterpolationMode.HighQualityBilinear; break;
                case 3: hashConfig.InterpolationMode = InterpolationMode.HighQualityBicubic; break;
                default: break;
            }
        }

        private void cmb_Algorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashConfig.HashMethod = (HashEnum)cmb_Algorithm.SelectedIndex;
        }

        private void tkb_Threshold_ValueChanged(object sender, EventArgs e)
        {
            tip_Misc.SetToolTip((Control)sender, $"{tkb_Threshold.Value}%");
        }

        private void InitMouseHoverTip()
        {
            tip_Help.ToolTipTitle = Message.Help;
            tip_Help.SetToolTip(cmb_Algorithm, Message.AlgorithmHelp);
            tip_Help.SetToolTip(tkb_Threshold, Message.ThresholdHelp);
            tip_Help.SetToolTip(cmb_Interpolation, Message.InterpolationHelp);
            tip_Help.SetToolTip(tkb_Precision, Message.PrecisionHelp);

            tip_Misc.SetToolTip(btn_Delete1, Message.DeleteHelp);
            tip_Misc.SetToolTip(btn_Delete2, Message.DeleteHelp);
        }
    }
}
