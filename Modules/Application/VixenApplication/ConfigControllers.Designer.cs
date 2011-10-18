﻿namespace VixenApplication
{
	partial class ConfigControllers
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
			this.listViewControllers = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonAddController = new System.Windows.Forms.Button();
			this.buttonDeleteController = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonConfigureOutputs = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownOutputCount = new System.Windows.Forms.NumericUpDown();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonGenerateChannels = new System.Windows.Forms.Button();
			this.buttonConfigureController = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputCount)).BeginInit();
			this.SuspendLayout();
			// 
			// listViewControllers
			// 
			this.listViewControllers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listViewControllers.FullRowSelect = true;
			listViewGroup1.Header = "ListViewGroup";
			listViewGroup1.Name = "listViewGroup1";
			this.listViewControllers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
			this.listViewControllers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewControllers.HideSelection = false;
			this.listViewControllers.Location = new System.Drawing.Point(12, 12);
			this.listViewControllers.Name = "listViewControllers";
			this.listViewControllers.ShowGroups = false;
			this.listViewControllers.Size = new System.Drawing.Size(395, 207);
			this.listViewControllers.TabIndex = 0;
			this.listViewControllers.UseCompatibleStateImageBehavior = false;
			this.listViewControllers.View = System.Windows.Forms.View.Details;
			this.listViewControllers.SelectedIndexChanged += new System.EventHandler(this.listViewControllers_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 160;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 153;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Channels";
			// 
			// buttonAddController
			// 
			this.buttonAddController.Location = new System.Drawing.Point(62, 234);
			this.buttonAddController.Name = "buttonAddController";
			this.buttonAddController.Size = new System.Drawing.Size(120, 30);
			this.buttonAddController.TabIndex = 17;
			this.buttonAddController.Text = "Add New Controller";
			this.buttonAddController.UseVisualStyleBackColor = true;
			this.buttonAddController.Click += new System.EventHandler(this.buttonAddController_Click);
			// 
			// buttonDeleteController
			// 
			this.buttonDeleteController.Location = new System.Drawing.Point(237, 234);
			this.buttonDeleteController.Name = "buttonDeleteController";
			this.buttonDeleteController.Size = new System.Drawing.Size(120, 30);
			this.buttonDeleteController.TabIndex = 19;
			this.buttonDeleteController.Text = "Delete Selected";
			this.buttonDeleteController.UseVisualStyleBackColor = true;
			this.buttonDeleteController.Click += new System.EventHandler(this.buttonDeleteController_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(317, 448);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(90, 30);
			this.buttonOk.TabIndex = 21;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.buttonConfigureOutputs);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numericUpDownOutputCount);
			this.groupBox1.Controls.Add(this.buttonUpdate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxName);
			this.groupBox1.Controls.Add(this.buttonGenerateChannels);
			this.groupBox1.Controls.Add(this.buttonConfigureController);
			this.groupBox1.Location = new System.Drawing.Point(12, 275);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(395, 158);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Controller";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(129, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(251, 13);
			this.label5.TabIndex = 35;
			this.label5.Text = "Automatically generate display channels for outputs.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(129, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(163, 13);
			this.label4.TabIndex = 34;
			this.label4.Text = "Configure details for each output.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(129, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(203, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Configure details specific to the controller.";
			// 
			// buttonConfigureOutputs
			// 
			this.buttonConfigureOutputs.Location = new System.Drawing.Point(13, 91);
			this.buttonConfigureOutputs.Name = "buttonConfigureOutputs";
			this.buttonConfigureOutputs.Size = new System.Drawing.Size(110, 25);
			this.buttonConfigureOutputs.TabIndex = 32;
			this.buttonConfigureOutputs.Text = "Configure Outputs";
			this.buttonConfigureOutputs.UseVisualStyleBackColor = true;
			this.buttonConfigureOutputs.Click += new System.EventHandler(this.buttonConfigureOutputs_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(202, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 31;
			this.label3.Text = "Outputs:";
			// 
			// numericUpDownOutputCount
			// 
			this.numericUpDownOutputCount.Location = new System.Drawing.Point(251, 24);
			this.numericUpDownOutputCount.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
			this.numericUpDownOutputCount.Name = "numericUpDownOutputCount";
			this.numericUpDownOutputCount.Size = new System.Drawing.Size(47, 20);
			this.numericUpDownOutputCount.TabIndex = 30;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(310, 21);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(64, 25);
			this.buttonUpdate.TabIndex = 27;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "Name:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(58, 24);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(136, 20);
			this.textBoxName.TabIndex = 25;
			// 
			// buttonGenerateChannels
			// 
			this.buttonGenerateChannels.Location = new System.Drawing.Point(13, 122);
			this.buttonGenerateChannels.Name = "buttonGenerateChannels";
			this.buttonGenerateChannels.Size = new System.Drawing.Size(110, 25);
			this.buttonGenerateChannels.TabIndex = 22;
			this.buttonGenerateChannels.Text = "Generate Channels";
			this.buttonGenerateChannels.UseVisualStyleBackColor = true;
			this.buttonGenerateChannels.Click += new System.EventHandler(this.buttonGenerateChannels_Click);
			// 
			// buttonConfigureController
			// 
			this.buttonConfigureController.Location = new System.Drawing.Point(13, 60);
			this.buttonConfigureController.Name = "buttonConfigureController";
			this.buttonConfigureController.Size = new System.Drawing.Size(110, 25);
			this.buttonConfigureController.TabIndex = 21;
			this.buttonConfigureController.Text = "Configure Controller";
			this.buttonConfigureController.UseVisualStyleBackColor = true;
			this.buttonConfigureController.Click += new System.EventHandler(this.buttonConfigureController_Click);
			// 
			// ConfigControllers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 490);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonDeleteController);
			this.Controls.Add(this.buttonAddController);
			this.Controls.Add(this.listViewControllers);
			this.Name = "ConfigControllers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Controllers Configuration";
			this.Load += new System.EventHandler(this.ConfigControllers_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutputCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewControllers;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button buttonAddController;
		private System.Windows.Forms.Button buttonDeleteController;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Button buttonGenerateChannels;
		private System.Windows.Forms.Button buttonConfigureController;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownOutputCount;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonConfigureOutputs;
	}
}