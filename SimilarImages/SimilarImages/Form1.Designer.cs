namespace SimilarImages
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Directory = new System.Windows.Forms.TextBox();
            this.btn_Directory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Process = new System.Windows.Forms.Button();
            this.cmb_Interpolation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Algorithm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Threshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Precision = new System.Windows.Forms.TextBox();
            this.lb_Count = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvw_Result = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lb_Image1 = new System.Windows.Forms.Label();
            this.lb_Image2 = new System.Windows.Forms.Label();
            this.btn_Delete1 = new System.Windows.Forms.Button();
            this.btn_Delete2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Open2 = new System.Windows.Forms.Button();
            this.btn_Open1 = new System.Windows.Forms.Button();
            this.lb_Resolution2 = new System.Windows.Forms.Label();
            this.lb_Resolution1 = new System.Windows.Forms.Label();
            this.bgw_Calculate = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_Empty = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Directory:";
            // 
            // tb_Directory
            // 
            this.tb_Directory.Location = new System.Drawing.Point(76, 12);
            this.tb_Directory.Name = "tb_Directory";
            this.tb_Directory.ReadOnly = true;
            this.tb_Directory.Size = new System.Drawing.Size(411, 21);
            this.tb_Directory.TabIndex = 2;
            // 
            // btn_Directory
            // 
            this.btn_Directory.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_Directory.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Directory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Directory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_Directory.Location = new System.Drawing.Point(493, 12);
            this.btn_Directory.Name = "btn_Directory";
            this.btn_Directory.Size = new System.Drawing.Size(26, 21);
            this.btn_Directory.TabIndex = 3;
            this.btn_Directory.Text = "...";
            this.btn_Directory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Directory.UseVisualStyleBackColor = false;
            this.btn_Directory.Click += new System.EventHandler(this.btn_Directory_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.btn_Process);
            this.panel1.Controls.Add(this.cmb_Interpolation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_Algorithm);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tb_Threshold);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tb_Precision);
            this.panel1.Controls.Add(this.lb_Count);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Directory);
            this.panel1.Controls.Add(this.tb_Directory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 68);
            this.panel1.TabIndex = 4;
            // 
            // btn_Process
            // 
            this.btn_Process.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Process.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Process.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Process.Location = new System.Drawing.Point(655, 9);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(79, 27);
            this.btn_Process.TabIndex = 12;
            this.btn_Process.Text = "Process";
            this.btn_Process.UseVisualStyleBackColor = false;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // cmb_Interpolation
            // 
            this.cmb_Interpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Interpolation.DropDownWidth = 120;
            this.cmb_Interpolation.FormattingEnabled = true;
            this.cmb_Interpolation.Items.AddRange(new object[] {
            "Default",
            "NearestNeighbor",
            "HighQualityBilinear",
            "HighQualityBicubic"});
            this.cmb_Interpolation.Location = new System.Drawing.Point(254, 43);
            this.cmb_Interpolation.Name = "cmb_Interpolation";
            this.cmb_Interpolation.Size = new System.Drawing.Size(97, 23);
            this.cmb_Interpolation.TabIndex = 11;
            this.cmb_Interpolation.SelectedIndexChanged += new System.EventHandler(this.cmb_Interpolation_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Interpolation Mode:";
            // 
            // cmb_Algorithm
            // 
            this.cmb_Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Algorithm.FormattingEnabled = true;
            this.cmb_Algorithm.Items.AddRange(new object[] {
            "Difference",
            "Mean",
            "Perceptual"});
            this.cmb_Algorithm.Location = new System.Drawing.Point(457, 43);
            this.cmb_Algorithm.Name = "cmb_Algorithm";
            this.cmb_Algorithm.Size = new System.Drawing.Size(97, 23);
            this.cmb_Algorithm.TabIndex = 11;
            this.cmb_Algorithm.SelectedIndexChanged += new System.EventHandler(this.cmb_Algorithm_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Hash Algorithm:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Similarity Threshold:";
            // 
            // tb_Threshold
            // 
            this.tb_Threshold.Location = new System.Drawing.Point(684, 43);
            this.tb_Threshold.Name = "tb_Threshold";
            this.tb_Threshold.Size = new System.Drawing.Size(50, 21);
            this.tb_Threshold.TabIndex = 8;
            this.tb_Threshold.Text = "0.8";
            this.tb_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Threshold_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Precision:";
            // 
            // tb_Precision
            // 
            this.tb_Precision.Location = new System.Drawing.Point(79, 43);
            this.tb_Precision.Name = "tb_Precision";
            this.tb_Precision.Size = new System.Drawing.Size(50, 21);
            this.tb_Precision.TabIndex = 6;
            this.tb_Precision.Text = "20";
            this.tb_Precision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Precision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Precision_KeyPress);
            // 
            // lb_Count
            // 
            this.lb_Count.Location = new System.Drawing.Point(612, 15);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(37, 15);
            this.lb_Count.TabIndex = 5;
            this.lb_Count.Text = "N/A";
            this.lb_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valid images:";
            // 
            // lvw_Result
            // 
            this.lvw_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvw_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvw_Result.FullRowSelect = true;
            this.lvw_Result.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_Result.HideSelection = false;
            this.lvw_Result.Location = new System.Drawing.Point(13, 10);
            this.lvw_Result.MultiSelect = false;
            this.lvw_Result.Name = "lvw_Result";
            this.lvw_Result.Size = new System.Drawing.Size(146, 521);
            this.lvw_Result.TabIndex = 5;
            this.lvw_Result.UseCompatibleStateImageBehavior = false;
            this.lvw_Result.View = System.Windows.Forms.View.Details;
            this.lvw_Result.SelectedIndexChanged += new System.EventHandler(this.lvw_Result_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 142;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(7, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 473);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(294, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(281, 473);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lb_Image1
            // 
            this.lb_Image1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Image1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Image1.Location = new System.Drawing.Point(6, 486);
            this.lb_Image1.Name = "lb_Image1";
            this.lb_Image1.Size = new System.Drawing.Size(281, 15);
            this.lb_Image1.TabIndex = 8;
            this.lb_Image1.Text = "Image 1";
            // 
            // lb_Image2
            // 
            this.lb_Image2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Image2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Image2.Location = new System.Drawing.Point(293, 486);
            this.lb_Image2.Name = "lb_Image2";
            this.lb_Image2.Size = new System.Drawing.Size(281, 15);
            this.lb_Image2.TabIndex = 9;
            this.lb_Image2.Text = "Image 2";
            // 
            // btn_Delete1
            // 
            this.btn_Delete1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Delete1.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Delete1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete1.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Delete1.Location = new System.Drawing.Point(99, 504);
            this.btn_Delete1.Name = "btn_Delete1";
            this.btn_Delete1.Size = new System.Drawing.Size(87, 27);
            this.btn_Delete1.TabIndex = 10;
            this.btn_Delete1.Text = "Delete";
            this.btn_Delete1.UseVisualStyleBackColor = false;
            this.btn_Delete1.Click += new System.EventHandler(this.btn_Delete1_Click);
            // 
            // btn_Delete2
            // 
            this.btn_Delete2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Delete2.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Delete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete2.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Delete2.Location = new System.Drawing.Point(386, 504);
            this.btn_Delete2.Name = "btn_Delete2";
            this.btn_Delete2.Size = new System.Drawing.Size(87, 27);
            this.btn_Delete2.TabIndex = 11;
            this.btn_Delete2.Text = "Delete";
            this.btn_Delete2.UseVisualStyleBackColor = false;
            this.btn_Delete2.Click += new System.EventHandler(this.btn_Delete2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.btn_Open2);
            this.panel2.Controls.Add(this.btn_Open1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lb_Image1);
            this.panel2.Controls.Add(this.btn_Delete2);
            this.panel2.Controls.Add(this.lb_Resolution2);
            this.panel2.Controls.Add(this.lb_Resolution1);
            this.panel2.Controls.Add(this.lb_Image2);
            this.panel2.Controls.Add(this.btn_Delete1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(159, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 538);
            this.panel2.TabIndex = 14;
            // 
            // btn_Open2
            // 
            this.btn_Open2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Open2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Open2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Open2.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Open2.Location = new System.Drawing.Point(293, 504);
            this.btn_Open2.Name = "btn_Open2";
            this.btn_Open2.Size = new System.Drawing.Size(87, 27);
            this.btn_Open2.TabIndex = 12;
            this.btn_Open2.Text = "Open";
            this.btn_Open2.UseVisualStyleBackColor = false;
            this.btn_Open2.Click += new System.EventHandler(this.btn_Open2_Click);
            // 
            // btn_Open1
            // 
            this.btn_Open1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Open1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Open1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Open1.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Open1.Location = new System.Drawing.Point(6, 504);
            this.btn_Open1.Name = "btn_Open1";
            this.btn_Open1.Size = new System.Drawing.Size(87, 27);
            this.btn_Open1.TabIndex = 12;
            this.btn_Open1.Text = "Open";
            this.btn_Open1.UseVisualStyleBackColor = false;
            this.btn_Open1.Click += new System.EventHandler(this.btn_Open1_Click);
            // 
            // lb_Resolution2
            // 
            this.lb_Resolution2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Resolution2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Resolution2.Location = new System.Drawing.Point(479, 510);
            this.lb_Resolution2.Name = "lb_Resolution2";
            this.lb_Resolution2.Size = new System.Drawing.Size(95, 15);
            this.lb_Resolution2.TabIndex = 9;
            this.lb_Resolution2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Resolution1
            // 
            this.lb_Resolution1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Resolution1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Resolution1.Location = new System.Drawing.Point(192, 510);
            this.lb_Resolution1.Name = "lb_Resolution1";
            this.lb_Resolution1.Size = new System.Drawing.Size(95, 15);
            this.lb_Resolution1.TabIndex = 9;
            this.lb_Resolution1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgw_Calculate
            // 
            this.bgw_Calculate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Calculate_DoWork);
            this.bgw_Calculate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Calculate_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(155, 328);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(441, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Value = 60;
            this.progressBar1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.lvw_Result);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 68);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(13, 10, 0, 7);
            this.panel3.Size = new System.Drawing.Size(159, 538);
            this.panel3.TabIndex = 13;
            // 
            // lb_Empty
            // 
            this.lb_Empty.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lb_Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic);
            this.lb_Empty.Location = new System.Drawing.Point(0, 75);
            this.lb_Empty.Name = "lb_Empty";
            this.lb_Empty.Size = new System.Drawing.Size(751, 531);
            this.lb_Empty.TabIndex = 13;
            this.lb_Empty.Text = "Empty";
            this.lb_Empty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Empty.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 606);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_Empty);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Similar Images";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Directory;
        private System.Windows.Forms.Button btn_Directory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvw_Result;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_Image1;
        private System.Windows.Forms.Label lb_Image2;
        private System.Windows.Forms.Button btn_Delete1;
        private System.Windows.Forms.Button btn_Delete2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgw_Calculate;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.ComboBox cmb_Algorithm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Threshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Precision;
        internal System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_Empty;
        private System.Windows.Forms.Button btn_Open2;
        private System.Windows.Forms.Button btn_Open1;
        private System.Windows.Forms.Label lb_Resolution2;
        private System.Windows.Forms.Label lb_Resolution1;
        private System.Windows.Forms.ComboBox cmb_Interpolation;
        private System.Windows.Forms.Label label2;
    }
}

