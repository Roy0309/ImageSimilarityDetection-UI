using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimilarImages
{
    public partial class FormMain
    {
        private string[] currentImagePathPair = new string[2];

        private void lvw_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvw_Result.SelectedItems.Count < 1 ||
                lvw_Result.SelectedItems[0].Text == Message.NoResult)
            { return; }

            // Dispose previous images
            pic_Image1.Image?.Dispose();
            pic_Image2.Image?.Dispose();

            // Show images
            var selectedTuple = similarityTuples[lvw_Result.SelectedIndices[0]];
            if (File.Exists(selectedTuple.Item1))
            {
                pic_Image1.Image = new Bitmap(selectedTuple.Item1);
                lb_Image1.Text = selectedTuple.Item1.Substring(selectedTuple.Item1.LastIndexOf('\\') + 1);
                currentImagePathPair[0] = selectedTuple.Item1;
                lb_Resolution1.Text = $"{pic_Image1.Image.Width}*{pic_Image1.Image.Height}";
            }
            else
            {
                pic_Image1.Image = null;
                lb_Image1.Text = Message.Deleted;
                currentImagePathPair[0] = null;
                lb_Resolution1.Text = null;
            }

            if (File.Exists(selectedTuple.Item2))
            {
                pic_Image2.Image = new Bitmap(selectedTuple.Item2);
                lb_Image2.Text = selectedTuple.Item2.Substring(selectedTuple.Item2.LastIndexOf('\\') + 1);
                currentImagePathPair[1] = selectedTuple.Item2;
                lb_Resolution2.Text = $"{pic_Image2.Image.Width}*{pic_Image2.Image.Height}";
            }
            else
            {
                pic_Image2.Image = null;
                lb_Image2.Text = Message.Deleted;
                currentImagePathPair[1] = null;
                lb_Resolution2.Text = null;
            }

            // Compare resolution
            if (pic_Image1.Image != null && pic_Image2.Image != null &&
                pic_Image1.Image.Width * pic_Image1.Image.Height >=
                pic_Image2.Image.Width * pic_Image2.Image.Height)
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
            if (currentImagePathPair[0] != null)
            {
                tip_Misc.SetToolTip((Control)sender, currentImagePathPair[0]);
            }
        }

        private void lb_Image2_MouseHover(object sender, EventArgs e)
        {
            if (currentImagePathPair[1] != null)
            {
                tip_Misc.SetToolTip((Control)sender, currentImagePathPair[1]);
            }
        }

        private void btn_Open1_Click(object sender, EventArgs e)
        {
            if (pic_Image1.Image != null && currentImagePathPair[0] != null)
            {
                Process.Start(currentImagePathPair[0]);
            }
        }

        private void btn_Open2_Click(object sender, EventArgs e)
        {
            if (pic_Image2.Image != null && currentImagePathPair[1] != null)
            {
                Process.Start(currentImagePathPair[1]);
            }
        }

        private void btn_Delete1_MouseDown(object sender, MouseEventArgs e)
        {
            if (DeleteImage(pic_Image1, lb_Image1, currentImagePathPair[0], e.Button == MouseButtons.Right))
            {
                UpdateSelectedIndex();
            }
        }

        private void btn_Delete2_MouseDown(object sender, MouseEventArgs e)
        {
            if (DeleteImage(pic_Image2, lb_Image2, currentImagePathPair[1], e.Button == MouseButtons.Right))
            {
                UpdateSelectedIndex();
            }
        }

        private bool DeleteImage(PictureBox pictureBox, Label label, string imagePath, bool force)
        {
            if (pictureBox.Image == null) { return false; }

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
                FileSystem.DeleteFile(imagePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                label.Text = Message.Deleted;
                return true;
            }
            return false;
        }

        private void UpdateSelectedIndex()
        {
            // Unselect current
            int currentIndex = lvw_Result.SelectedIndices[0];
            lvw_Result.Items[currentIndex].Selected = false;
            // Select new
            lvw_Result.Items[currentIndex < lvw_Result.Items.Count - 1 ? currentIndex + 1 : 0].Selected = true;
            // Scroll to new
            lvw_Result.EnsureVisible(lvw_Result.SelectedIndices[0]);
        }
    }
}
