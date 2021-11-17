using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class FormMain
    {
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

            // Compare resolution
            if (pictureBox1.Image != null && pictureBox2.Image != null &&
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

        private void lb_Image1_MouseHover(object sender, EventArgs e)
        {
            if (lb_Image1.Tag != null)
            {
                toolTipMisc.SetToolTip((Control)sender, lb_Image1.Tag.ToString());
            }
        }

        private void lb_Image2_MouseHover(object sender, EventArgs e)
        {
            if (lb_Image2.Tag != null)
            {
                toolTipMisc.SetToolTip((Control)sender, lb_Image2.Tag.ToString());
            }
        }

        private void btn_Open1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Process.Start(lb_Image1.Tag.ToString());
            }
        }

        private void btn_Open2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                Process.Start(lb_Image2.Tag.ToString());
            }
        }

        private void btn_Delete1_MouseDown(object sender, MouseEventArgs e)
        {
            DeleteImage(pictureBox1, lb_Image1, e.Button == MouseButtons.Right);
        }

        private void btn_Delete2_MouseDown(object sender, MouseEventArgs e)
        {
            DeleteImage(pictureBox2, lb_Image2, e.Button == MouseButtons.Right);
        }

        private void DeleteImage(PictureBox pictureBox, Label label, bool force)
        {
            if (pictureBox.Image == null) { return; }

            DialogResult dr = DialogResult.Cancel;

            if (!force)
            {
                dr = MessageBox.Show(
                    Message.DeleteImage_1 + label.Text + Message.DeleteImage_2,
                    Message.Confirm, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            if (force || dr == DialogResult.OK)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
                FileSystem.DeleteFile(label.Tag.ToString(),
                    UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                label.Text = Message.Deleted;
            }
        }

        private void btn_Delete1_MouseHover(object sender, EventArgs e)
        {
            toolTipMisc.SetToolTip((Control)sender, Message.DeleteHelp);
        }

        private void btn_Delete2_MouseHover(object sender, EventArgs e)
        {
            toolTipMisc.SetToolTip((Control)sender, Message.DeleteHelp);
        }
    }
}
