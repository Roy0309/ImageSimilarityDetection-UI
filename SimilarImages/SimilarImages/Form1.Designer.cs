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
            this.components = new System.ComponentModel.Container();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // tb_Directory
            // 
            resources.ApplyResources(this.tb_Directory, "tb_Directory");
            this.tb_Directory.Name = "tb_Directory";
            this.tb_Directory.ReadOnly = true;
            this.toolTip1.SetToolTip(this.tb_Directory, resources.GetString("tb_Directory.ToolTip"));
            // 
            // btn_Directory
            // 
            resources.ApplyResources(this.btn_Directory, "btn_Directory");
            this.btn_Directory.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_Directory.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Directory.Name = "btn_Directory";
            this.toolTip1.SetToolTip(this.btn_Directory, resources.GetString("btn_Directory.ToolTip"));
            this.btn_Directory.UseVisualStyleBackColor = false;
            this.btn_Directory.Click += new System.EventHandler(this.btn_Directory_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
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
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // btn_Process
            // 
            resources.ApplyResources(this.btn_Process, "btn_Process");
            this.btn_Process.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Process.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Process.Name = "btn_Process";
            this.toolTip1.SetToolTip(this.btn_Process, resources.GetString("btn_Process.ToolTip"));
            this.btn_Process.UseVisualStyleBackColor = false;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // cmb_Interpolation
            // 
            resources.ApplyResources(this.cmb_Interpolation, "cmb_Interpolation");
            this.cmb_Interpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Interpolation.DropDownWidth = 120;
            this.cmb_Interpolation.FormattingEnabled = true;
            this.cmb_Interpolation.Items.AddRange(new object[] {
            resources.GetString("cmb_Interpolation.Items"),
            resources.GetString("cmb_Interpolation.Items1"),
            resources.GetString("cmb_Interpolation.Items2"),
            resources.GetString("cmb_Interpolation.Items3")});
            this.cmb_Interpolation.Name = "cmb_Interpolation";
            this.toolTip1.SetToolTip(this.cmb_Interpolation, resources.GetString("cmb_Interpolation.ToolTip"));
            this.cmb_Interpolation.SelectedIndexChanged += new System.EventHandler(this.cmb_Interpolation_SelectedIndexChanged);
            this.cmb_Interpolation.Click += new System.EventHandler(this.cmb_Interpolation_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // cmb_Algorithm
            // 
            resources.ApplyResources(this.cmb_Algorithm, "cmb_Algorithm");
            this.cmb_Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Algorithm.FormattingEnabled = true;
            this.cmb_Algorithm.Items.AddRange(new object[] {
            resources.GetString("cmb_Algorithm.Items"),
            resources.GetString("cmb_Algorithm.Items1"),
            resources.GetString("cmb_Algorithm.Items2")});
            this.cmb_Algorithm.Name = "cmb_Algorithm";
            this.toolTip1.SetToolTip(this.cmb_Algorithm, resources.GetString("cmb_Algorithm.ToolTip"));
            this.cmb_Algorithm.SelectedIndexChanged += new System.EventHandler(this.cmb_Algorithm_SelectedIndexChanged);
            this.cmb_Algorithm.Click += new System.EventHandler(this.cmb_Algorithm_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            this.toolTip1.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip1.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // tb_Threshold
            // 
            resources.ApplyResources(this.tb_Threshold, "tb_Threshold");
            this.tb_Threshold.Name = "tb_Threshold";
            this.toolTip1.SetToolTip(this.tb_Threshold, resources.GetString("tb_Threshold.ToolTip"));
            this.tb_Threshold.Click += new System.EventHandler(this.tb_Threshold_Click);
            this.tb_Threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Threshold_KeyPress);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // tb_Precision
            // 
            resources.ApplyResources(this.tb_Precision, "tb_Precision");
            this.tb_Precision.Name = "tb_Precision";
            this.toolTip1.SetToolTip(this.tb_Precision, resources.GetString("tb_Precision.ToolTip"));
            this.tb_Precision.Click += new System.EventHandler(this.tb_Precision_Click);
            this.tb_Precision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Precision_KeyPress);
            // 
            // lb_Count
            // 
            resources.ApplyResources(this.lb_Count, "lb_Count");
            this.lb_Count.Name = "lb_Count";
            this.toolTip1.SetToolTip(this.lb_Count, resources.GetString("lb_Count.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // lvw_Result
            // 
            resources.ApplyResources(this.lvw_Result, "lvw_Result");
            this.lvw_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvw_Result.FullRowSelect = true;
            this.lvw_Result.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_Result.HideSelection = false;
            this.lvw_Result.MultiSelect = false;
            this.lvw_Result.Name = "lvw_Result";
            this.toolTip1.SetToolTip(this.lvw_Result, resources.GetString("lvw_Result.ToolTip"));
            this.lvw_Result.UseCompatibleStateImageBehavior = false;
            this.lvw_Result.View = System.Windows.Forms.View.Details;
            this.lvw_Result.SelectedIndexChanged += new System.EventHandler(this.lvw_Result_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // lb_Image1
            // 
            resources.ApplyResources(this.lb_Image1, "lb_Image1");
            this.lb_Image1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Image1.Name = "lb_Image1";
            this.toolTip1.SetToolTip(this.lb_Image1, resources.GetString("lb_Image1.ToolTip"));
            // 
            // lb_Image2
            // 
            resources.ApplyResources(this.lb_Image2, "lb_Image2");
            this.lb_Image2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Image2.Name = "lb_Image2";
            this.toolTip1.SetToolTip(this.lb_Image2, resources.GetString("lb_Image2.ToolTip"));
            // 
            // btn_Delete1
            // 
            resources.ApplyResources(this.btn_Delete1, "btn_Delete1");
            this.btn_Delete1.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Delete1.FlatAppearance.BorderSize = 0;
            this.btn_Delete1.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Delete1.Name = "btn_Delete1";
            this.toolTip1.SetToolTip(this.btn_Delete1, resources.GetString("btn_Delete1.ToolTip"));
            this.btn_Delete1.UseVisualStyleBackColor = false;
            this.btn_Delete1.Click += new System.EventHandler(this.btn_Delete1_Click);
            // 
            // btn_Delete2
            // 
            resources.ApplyResources(this.btn_Delete2, "btn_Delete2");
            this.btn_Delete2.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Delete2.FlatAppearance.BorderSize = 0;
            this.btn_Delete2.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Delete2.Name = "btn_Delete2";
            this.toolTip1.SetToolTip(this.btn_Delete2, resources.GetString("btn_Delete2.ToolTip"));
            this.btn_Delete2.UseVisualStyleBackColor = false;
            this.btn_Delete2.Click += new System.EventHandler(this.btn_Delete2_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
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
            this.panel2.Name = "panel2";
            this.toolTip1.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // btn_Open2
            // 
            resources.ApplyResources(this.btn_Open2, "btn_Open2");
            this.btn_Open2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Open2.FlatAppearance.BorderSize = 0;
            this.btn_Open2.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Open2.Name = "btn_Open2";
            this.toolTip1.SetToolTip(this.btn_Open2, resources.GetString("btn_Open2.ToolTip"));
            this.btn_Open2.UseVisualStyleBackColor = false;
            this.btn_Open2.Click += new System.EventHandler(this.btn_Open2_Click);
            // 
            // btn_Open1
            // 
            resources.ApplyResources(this.btn_Open1, "btn_Open1");
            this.btn_Open1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Open1.FlatAppearance.BorderSize = 0;
            this.btn_Open1.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Open1.Name = "btn_Open1";
            this.toolTip1.SetToolTip(this.btn_Open1, resources.GetString("btn_Open1.ToolTip"));
            this.btn_Open1.UseVisualStyleBackColor = false;
            this.btn_Open1.Click += new System.EventHandler(this.btn_Open1_Click);
            // 
            // lb_Resolution2
            // 
            resources.ApplyResources(this.lb_Resolution2, "lb_Resolution2");
            this.lb_Resolution2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Resolution2.Name = "lb_Resolution2";
            this.toolTip1.SetToolTip(this.lb_Resolution2, resources.GetString("lb_Resolution2.ToolTip"));
            // 
            // lb_Resolution1
            // 
            resources.ApplyResources(this.lb_Resolution1, "lb_Resolution1");
            this.lb_Resolution1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Resolution1.Name = "lb_Resolution1";
            this.toolTip1.SetToolTip(this.lb_Resolution1, resources.GetString("lb_Resolution1.ToolTip"));
            // 
            // bgw_Calculate
            // 
            this.bgw_Calculate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Calculate_DoWork);
            this.bgw_Calculate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Calculate_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolTip1.SetToolTip(this.progressBar1, resources.GetString("progressBar1.ToolTip"));
            this.progressBar1.Value = 60;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.lvw_Result);
            this.panel3.Name = "panel3";
            this.toolTip1.SetToolTip(this.panel3, resources.GetString("panel3.ToolTip"));
            // 
            // lb_Empty
            // 
            resources.ApplyResources(this.lb_Empty, "lb_Empty");
            this.lb_Empty.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lb_Empty.Name = "lb_Empty";
            this.toolTip1.SetToolTip(this.lb_Empty, resources.GetString("lb_Empty.ToolTip"));
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示信息";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_Empty);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

