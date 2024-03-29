﻿namespace SimilarImages
{
    partial class FormMain
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Directory = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.pnl_Config = new System.Windows.Forms.Panel();
            this.lb_Similarity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tkb_Threshold = new System.Windows.Forms.TrackBar();
            this.tkb_Precision = new System.Windows.Forms.TrackBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btn_Process = new System.Windows.Forms.Button();
            this.cmb_Interpolation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Algorithm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvw_Result = new System.Windows.Forms.ListView();
            this.pic_Image1 = new System.Windows.Forms.PictureBox();
            this.pic_Image2 = new System.Windows.Forms.PictureBox();
            this.lb_Image1 = new System.Windows.Forms.Label();
            this.lb_Image2 = new System.Windows.Forms.Label();
            this.btn_Delete1 = new System.Windows.Forms.Button();
            this.btn_Delete2 = new System.Windows.Forms.Button();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.pnl_Image2 = new System.Windows.Forms.Panel();
            this.btn_Open2 = new System.Windows.Forms.Button();
            this.pnl_Image1 = new System.Windows.Forms.Panel();
            this.btn_Open1 = new System.Windows.Forms.Button();
            this.lb_Resolution2 = new System.Windows.Forms.Label();
            this.lb_Resolution1 = new System.Windows.Forms.Label();
            this.bgw_Calculate = new System.ComponentModel.BackgroundWorker();
            this.pnl_List = new System.Windows.Forms.Panel();
            this.tip_Help = new System.Windows.Forms.ToolTip(this.components);
            this.tip_Misc = new System.Windows.Forms.ToolTip(this.components);
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_Config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_Precision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image2)).BeginInit();
            this.pnl_Main.SuspendLayout();
            this.pnl_Image2.SuspendLayout();
            this.pnl_Image1.SuspendLayout();
            this.pnl_List.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tb_Directory
            // 
            this.tb_Directory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tb_Directory, "tb_Directory");
            this.tb_Directory.Name = "tb_Directory";
            this.tb_Directory.ReadOnly = true;
            this.tb_Directory.TabStop = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btn_Clear.BackgroundImage = global::SimilarImages.Properties.Resources.delete;
            resources.ApplyResources(this.btn_Clear, "btn_Clear");
            this.btn_Clear.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // pnl_Config
            // 
            this.pnl_Config.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_Config.Controls.Add(this.lb_Similarity);
            this.pnl_Config.Controls.Add(this.label3);
            this.pnl_Config.Controls.Add(this.tkb_Threshold);
            this.pnl_Config.Controls.Add(this.tkb_Precision);
            this.pnl_Config.Controls.Add(this.progressBar);
            this.pnl_Config.Controls.Add(this.btn_Process);
            this.pnl_Config.Controls.Add(this.cmb_Interpolation);
            this.pnl_Config.Controls.Add(this.label2);
            this.pnl_Config.Controls.Add(this.cmb_Algorithm);
            this.pnl_Config.Controls.Add(this.label7);
            this.pnl_Config.Controls.Add(this.label6);
            this.pnl_Config.Controls.Add(this.label5);
            this.pnl_Config.Controls.Add(this.label1);
            this.pnl_Config.Controls.Add(this.btn_Clear);
            this.pnl_Config.Controls.Add(this.tb_Directory);
            resources.ApplyResources(this.pnl_Config, "pnl_Config");
            this.pnl_Config.Name = "pnl_Config";
            // 
            // lb_Similarity
            // 
            resources.ApplyResources(this.lb_Similarity, "lb_Similarity");
            this.lb_Similarity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Similarity.Name = "lb_Similarity";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Name = "label3";
            // 
            // tkb_Threshold
            // 
            resources.ApplyResources(this.tkb_Threshold, "tkb_Threshold");
            this.tkb_Threshold.Maximum = 99;
            this.tkb_Threshold.Name = "tkb_Threshold";
            this.tkb_Threshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_Threshold.Value = 80;
            this.tkb_Threshold.ValueChanged += new System.EventHandler(this.tkb_Threshold_ValueChanged);
            // 
            // tkb_Precision
            // 
            resources.ApplyResources(this.tkb_Precision, "tkb_Precision");
            this.tkb_Precision.Maximum = 40;
            this.tkb_Precision.Minimum = 10;
            this.tkb_Precision.Name = "tkb_Precision";
            this.tkb_Precision.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkb_Precision.Value = 20;
            this.tkb_Precision.ValueChanged += new System.EventHandler(this.tkb_Precision_ValueChanged);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Value = 60;
            // 
            // btn_Process
            // 
            this.btn_Process.BackColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.btn_Process, "btn_Process");
            this.btn_Process.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.UseVisualStyleBackColor = false;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // cmb_Interpolation
            // 
            this.cmb_Interpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Interpolation.DropDownWidth = 120;
            this.cmb_Interpolation.FormattingEnabled = true;
            this.cmb_Interpolation.Items.AddRange(new object[] {
            resources.GetString("cmb_Interpolation.Items"),
            resources.GetString("cmb_Interpolation.Items1"),
            resources.GetString("cmb_Interpolation.Items2"),
            resources.GetString("cmb_Interpolation.Items3")});
            resources.ApplyResources(this.cmb_Interpolation, "cmb_Interpolation");
            this.cmb_Interpolation.Name = "cmb_Interpolation";
            this.cmb_Interpolation.SelectedIndexChanged += new System.EventHandler(this.cmb_Interpolation_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmb_Algorithm
            // 
            this.cmb_Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Algorithm.FormattingEnabled = true;
            this.cmb_Algorithm.Items.AddRange(new object[] {
            resources.GetString("cmb_Algorithm.Items"),
            resources.GetString("cmb_Algorithm.Items1"),
            resources.GetString("cmb_Algorithm.Items2")});
            resources.ApplyResources(this.cmb_Algorithm, "cmb_Algorithm");
            this.cmb_Algorithm.Name = "cmb_Algorithm";
            this.cmb_Algorithm.SelectedIndexChanged += new System.EventHandler(this.cmb_Algorithm_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lvw_Result
            // 
            this.lvw_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1});
            resources.ApplyResources(this.lvw_Result, "lvw_Result");
            this.lvw_Result.FullRowSelect = true;
            this.lvw_Result.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_Result.HideSelection = false;
            this.lvw_Result.MultiSelect = false;
            this.lvw_Result.Name = "lvw_Result";
            this.lvw_Result.UseCompatibleStateImageBehavior = false;
            this.lvw_Result.View = System.Windows.Forms.View.Details;
            this.lvw_Result.SelectedIndexChanged += new System.EventHandler(this.lvw_Result_SelectedIndexChanged);
            // 
            // pic_Image1
            // 
            resources.ApplyResources(this.pic_Image1, "pic_Image1");
            this.pic_Image1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Image1.Name = "pic_Image1";
            this.pic_Image1.TabStop = false;
            // 
            // pic_Image2
            // 
            resources.ApplyResources(this.pic_Image2, "pic_Image2");
            this.pic_Image2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Image2.Name = "pic_Image2";
            this.pic_Image2.TabStop = false;
            // 
            // lb_Image1
            // 
            resources.ApplyResources(this.lb_Image1, "lb_Image1");
            this.lb_Image1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Image1.Name = "lb_Image1";
            this.lb_Image1.MouseHover += new System.EventHandler(this.lb_Image1_MouseHover);
            // 
            // lb_Image2
            // 
            resources.ApplyResources(this.lb_Image2, "lb_Image2");
            this.lb_Image2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Image2.Name = "lb_Image2";
            this.lb_Image2.MouseHover += new System.EventHandler(this.lb_Image2_MouseHover);
            // 
            // btn_Delete1
            // 
            resources.ApplyResources(this.btn_Delete1, "btn_Delete1");
            this.btn_Delete1.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Delete1.FlatAppearance.BorderSize = 0;
            this.btn_Delete1.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Delete1.Name = "btn_Delete1";
            this.btn_Delete1.UseVisualStyleBackColor = false;
            this.btn_Delete1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Delete1_MouseDown);
            // 
            // btn_Delete2
            // 
            resources.ApplyResources(this.btn_Delete2, "btn_Delete2");
            this.btn_Delete2.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Delete2.FlatAppearance.BorderSize = 0;
            this.btn_Delete2.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Delete2.Name = "btn_Delete2";
            this.btn_Delete2.UseVisualStyleBackColor = false;
            this.btn_Delete2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Delete2_MouseDown);
            // 
            // pnl_Main
            // 
            this.pnl_Main.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_Main.Controls.Add(this.pnl_Image2);
            this.pnl_Main.Controls.Add(this.pnl_Image1);
            this.pnl_Main.Controls.Add(this.lb_Resolution2);
            this.pnl_Main.Controls.Add(this.lb_Resolution1);
            resources.ApplyResources(this.pnl_Main, "pnl_Main");
            this.pnl_Main.Name = "pnl_Main";
            // 
            // pnl_Image2
            // 
            this.pnl_Image2.Controls.Add(this.lb_Image2);
            this.pnl_Image2.Controls.Add(this.btn_Open2);
            this.pnl_Image2.Controls.Add(this.pic_Image2);
            this.pnl_Image2.Controls.Add(this.btn_Delete2);
            resources.ApplyResources(this.pnl_Image2, "pnl_Image2");
            this.pnl_Image2.Name = "pnl_Image2";
            // 
            // btn_Open2
            // 
            resources.ApplyResources(this.btn_Open2, "btn_Open2");
            this.btn_Open2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Open2.FlatAppearance.BorderSize = 0;
            this.btn_Open2.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Open2.Name = "btn_Open2";
            this.btn_Open2.UseVisualStyleBackColor = false;
            this.btn_Open2.Click += new System.EventHandler(this.btn_Open2_Click);
            // 
            // pnl_Image1
            // 
            this.pnl_Image1.Controls.Add(this.pic_Image1);
            this.pnl_Image1.Controls.Add(this.btn_Open1);
            this.pnl_Image1.Controls.Add(this.btn_Delete1);
            this.pnl_Image1.Controls.Add(this.lb_Image1);
            resources.ApplyResources(this.pnl_Image1, "pnl_Image1");
            this.pnl_Image1.Name = "pnl_Image1";
            // 
            // btn_Open1
            // 
            resources.ApplyResources(this.btn_Open1, "btn_Open1");
            this.btn_Open1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Open1.FlatAppearance.BorderSize = 0;
            this.btn_Open1.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Open1.Name = "btn_Open1";
            this.btn_Open1.UseVisualStyleBackColor = false;
            this.btn_Open1.Click += new System.EventHandler(this.btn_Open1_Click);
            // 
            // lb_Resolution2
            // 
            resources.ApplyResources(this.lb_Resolution2, "lb_Resolution2");
            this.lb_Resolution2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Resolution2.Name = "lb_Resolution2";
            // 
            // lb_Resolution1
            // 
            resources.ApplyResources(this.lb_Resolution1, "lb_Resolution1");
            this.lb_Resolution1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lb_Resolution1.Name = "lb_Resolution1";
            // 
            // bgw_Calculate
            // 
            this.bgw_Calculate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Calculate_DoWork);
            this.bgw_Calculate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Calculate_RunWorkerCompleted);
            // 
            // pnl_List
            // 
            this.pnl_List.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_List.Controls.Add(this.lvw_Result);
            resources.ApplyResources(this.pnl_List, "pnl_List");
            this.pnl_List.Name = "pnl_List";
            // 
            // tip_Help
            // 
            this.tip_Help.AutoPopDelay = 8000;
            this.tip_Help.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tip_Help.InitialDelay = 500;
            this.tip_Help.ReshowDelay = 100;
            this.tip_Help.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.pnl_List);
            this.Controls.Add(this.pnl_Config);
            this.DoubleBuffered = true;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.pnl_Config.ResumeLayout(false);
            this.pnl_Config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkb_Precision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image2)).EndInit();
            this.pnl_Main.ResumeLayout(false);
            this.pnl_Image2.ResumeLayout(false);
            this.pnl_Image1.ResumeLayout(false);
            this.pnl_List.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Directory;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel pnl_Config;
        private System.Windows.Forms.ListView lvw_Result;
        private System.Windows.Forms.PictureBox pic_Image1;
        private System.Windows.Forms.PictureBox pic_Image2;
        private System.Windows.Forms.Label lb_Image1;
        private System.Windows.Forms.Label lb_Image2;
        private System.Windows.Forms.Button btn_Delete1;
        private System.Windows.Forms.Button btn_Delete2;
        private System.Windows.Forms.Panel pnl_Main;
        private System.ComponentModel.BackgroundWorker bgw_Calculate;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.ComboBox cmb_Algorithm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel pnl_List;
        private System.Windows.Forms.Button btn_Open2;
        private System.Windows.Forms.Button btn_Open1;
        private System.Windows.Forms.Label lb_Resolution2;
        private System.Windows.Forms.Label lb_Resolution1;
        private System.Windows.Forms.ComboBox cmb_Interpolation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip tip_Help;
        private System.Windows.Forms.ToolTip tip_Misc;
        private System.Windows.Forms.Panel pnl_Image1;
        private System.Windows.Forms.Panel pnl_Image2;
        private System.Windows.Forms.TrackBar tkb_Precision;
        private System.Windows.Forms.TrackBar tkb_Threshold;
        private System.Windows.Forms.Label lb_Similarity;
        private System.Windows.Forms.Label label3;
    }
}

