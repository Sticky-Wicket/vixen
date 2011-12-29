﻿namespace VixenModules.Editor.TimedSequenceEditor
{
	partial class TimedSequenceEditorForm
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
			if (disposing && (components != null)) {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimedSequenceEditorForm));
			this.toolStripOperations = new CommonElements.ToolStripEx();
			this.toolStripButton_Start = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Play = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Stop = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Pause = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_End = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.undoButton = new CommonElements.UndoButton();
			this.redoButton = new CommonElements.UndoButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_Cut = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Copy = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_Paste = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_AssociateAudio = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_MarkManager = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_ZoomTimeIn = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_ZoomTimeOut = new System.Windows.Forms.ToolStripButton();
			this.menuStrip = new CommonElements.MenuStripEx();
			this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_EditEffect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_Cut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_deleteElements = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_zoomTimeIn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_zoomTimeOut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_zoomRowsIn = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_zoomRowsOut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_associateAudio = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_MarkManager = new System.Windows.Forms.ToolStripMenuItem();
			this.modifySequenceLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerPlaying = new System.Windows.Forms.Timer(this.components);
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_currentTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_sequenceLength = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.timelineControl = new CommonElements.Timeline.TimelineControl();
			this.toolStripEffects = new CommonElements.ToolStripEx();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripOperations.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.toolStripEffects.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripOperations
			// 
			this.toolStripOperations.ClickThrough = true;
			this.toolStripOperations.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStripOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Start,
            this.toolStripButton_Play,
            this.toolStripButton_Stop,
            this.toolStripButton_Pause,
            this.toolStripButton_End,
            this.toolStripSeparator4,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator5,
            this.toolStripButton_Cut,
            this.toolStripButton_Copy,
            this.toolStripButton_Paste,
            this.toolStripSeparator8,
            this.toolStripButton_AssociateAudio,
            this.toolStripButton_MarkManager,
            this.toolStripSeparator7,
            this.toolStripButton_ZoomTimeIn,
            this.toolStripButton_ZoomTimeOut});
			this.toolStripOperations.Location = new System.Drawing.Point(3, 25);
			this.toolStripOperations.Name = "toolStripOperations";
			this.toolStripOperations.Size = new System.Drawing.Size(376, 25);
			this.toolStripOperations.TabIndex = 1;
			this.toolStripOperations.Text = "Operations";
			// 
			// toolStripButton_Start
			// 
			this.toolStripButton_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Start.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.MoveFirstHS;
			this.toolStripButton_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Start.Name = "toolStripButton_Start";
			this.toolStripButton_Start.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Start.Text = "Start";
			this.toolStripButton_Start.Click += new System.EventHandler(this.toolStripButton_Start_Click);
			// 
			// toolStripButton_Play
			// 
			this.toolStripButton_Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Play.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.PlayHS;
			this.toolStripButton_Play.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Play.Name = "toolStripButton_Play";
			this.toolStripButton_Play.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Play.Text = "Play";
			this.toolStripButton_Play.Click += new System.EventHandler(this.toolStripButton_Play_Click);
			// 
			// toolStripButton_Stop
			// 
			this.toolStripButton_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Stop.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.StopHS;
			this.toolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Stop.Name = "toolStripButton_Stop";
			this.toolStripButton_Stop.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Stop.Text = "Stop";
			this.toolStripButton_Stop.Click += new System.EventHandler(this.toolStripButton_Stop_Click);
			// 
			// toolStripButton_Pause
			// 
			this.toolStripButton_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Pause.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.PauseHS;
			this.toolStripButton_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_Pause.Name = "toolStripButton_Pause";
			this.toolStripButton_Pause.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Pause.Text = "Pause";
			this.toolStripButton_Pause.Click += new System.EventHandler(this.toolStripButton_Pause_Click);
			// 
			// toolStripButton_End
			// 
			this.toolStripButton_End.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_End.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.MoveLastHS;
			this.toolStripButton_End.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_End.Name = "toolStripButton_End";
			this.toolStripButton_End.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_End.Text = "End";
			this.toolStripButton_End.Click += new System.EventHandler(this.toolStripButton_End_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// undoButton
			// 
			this.undoButton.ButtonType = CommonElements.UndoButtonType.UndoButton;
			this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
			this.undoButton.Name = "undoButton";
			this.undoButton.Size = new System.Drawing.Size(32, 22);
			this.undoButton.Text = "Undo";
			this.undoButton.ButtonClick += new System.EventHandler(this.undoButton_ButtonClick);
			// 
			// redoButton
			// 
			this.redoButton.ButtonType = CommonElements.UndoButtonType.RedoButton;
			this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
			this.redoButton.Name = "redoButton";
			this.redoButton.Size = new System.Drawing.Size(32, 22);
			this.redoButton.Text = "Redo";
			this.redoButton.ButtonClick += new System.EventHandler(this.redoButton_ButtonClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_Cut
			// 
			this.toolStripButton_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Cut.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.CutHS;
			this.toolStripButton_Cut.Name = "toolStripButton_Cut";
			this.toolStripButton_Cut.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Cut.Text = "Cut";
			this.toolStripButton_Cut.Click += new System.EventHandler(this.toolStripMenuItem_Cut_Click);
			// 
			// toolStripButton_Copy
			// 
			this.toolStripButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Copy.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.CopyHS;
			this.toolStripButton_Copy.Name = "toolStripButton_Copy";
			this.toolStripButton_Copy.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Copy.Text = "Copy";
			this.toolStripButton_Copy.Click += new System.EventHandler(this.toolStripMenuItem_Copy_Click);
			// 
			// toolStripButton_Paste
			// 
			this.toolStripButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_Paste.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.PasteHS;
			this.toolStripButton_Paste.Name = "toolStripButton_Paste";
			this.toolStripButton_Paste.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_Paste.Text = "Paste";
			this.toolStripButton_Paste.Click += new System.EventHandler(this.toolStripMenuItem_Paste_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_AssociateAudio
			// 
			this.toolStripButton_AssociateAudio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_AssociateAudio.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.base_speaker_32;
			this.toolStripButton_AssociateAudio.Name = "toolStripButton_AssociateAudio";
			this.toolStripButton_AssociateAudio.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_AssociateAudio.Text = "Associate Audio";
			this.toolStripButton_AssociateAudio.Click += new System.EventHandler(this.toolStripMenuItem_associateAudio_Click);
			// 
			// toolStripButton_MarkManager
			// 
			this.toolStripButton_MarkManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_MarkManager.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.pencil_32;
			this.toolStripButton_MarkManager.Name = "toolStripButton_MarkManager";
			this.toolStripButton_MarkManager.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_MarkManager.Text = "Mark Manager";
			this.toolStripButton_MarkManager.Click += new System.EventHandler(this.toolStripMenuItem_MarkManager_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton_ZoomTimeIn
			// 
			this.toolStripButton_ZoomTimeIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_ZoomTimeIn.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.Zoom_In;
			this.toolStripButton_ZoomTimeIn.Name = "toolStripButton_ZoomTimeIn";
			this.toolStripButton_ZoomTimeIn.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_ZoomTimeIn.Text = "Zoom Time In";
			this.toolStripButton_ZoomTimeIn.Click += new System.EventHandler(this.toolStripMenuItem_zoomTimeIn_Click);
			// 
			// toolStripButton_ZoomTimeOut
			// 
			this.toolStripButton_ZoomTimeOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_ZoomTimeOut.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.Zoom_Out;
			this.toolStripButton_ZoomTimeOut.Name = "toolStripButton_ZoomTimeOut";
			this.toolStripButton_ZoomTimeOut.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_ZoomTimeOut.Text = "Zoom Time Out";
			this.toolStripButton_ZoomTimeOut.Click += new System.EventHandler(this.toolStripMenuItem_zoomTimeOut_Click);
			// 
			// menuStrip
			// 
			this.menuStrip.ClickThrough = true;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sequenceToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1181, 28);
			this.menuStrip.TabIndex = 2;
			this.menuStrip.Text = "Menu";
			// 
			// sequenceToolStripMenuItem
			// 
			this.sequenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Save,
            this.toolStripMenuItem_SaveAs,
            this.toolStripSeparator1,
            this.playbackToolStripMenuItem,
            this.toolStripSeparator6,
            this.toolStripMenuItem_Close});
			this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
			this.sequenceToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
			this.sequenceToolStripMenuItem.Text = "Sequence";
			// 
			// toolStripMenuItem_Save
			// 
			this.toolStripMenuItem_Save.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.saveHS;
			this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
			this.toolStripMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.toolStripMenuItem_Save.Size = new System.Drawing.Size(217, 24);
			this.toolStripMenuItem_Save.Text = "Save";
			this.toolStripMenuItem_Save.Click += new System.EventHandler(this.toolStripMenuItem_Save_Click);
			// 
			// toolStripMenuItem_SaveAs
			// 
			this.toolStripMenuItem_SaveAs.Name = "toolStripMenuItem_SaveAs";
			this.toolStripMenuItem_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
						| System.Windows.Forms.Keys.S)));
			this.toolStripMenuItem_SaveAs.Size = new System.Drawing.Size(217, 24);
			this.toolStripMenuItem_SaveAs.Text = "Save As...";
			this.toolStripMenuItem_SaveAs.Click += new System.EventHandler(this.toolStripMenuItem_SaveAs_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
			// 
			// playbackToolStripMenuItem
			// 
			this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
			this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
			this.playbackToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
			this.playbackToolStripMenuItem.Text = "Playback";
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.playToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
			this.playToolStripMenuItem.Text = "Play";
			this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
			this.pauseToolStripMenuItem.Text = "Pause";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(214, 6);
			// 
			// toolStripMenuItem_Close
			// 
			this.toolStripMenuItem_Close.Name = "toolStripMenuItem_Close";
			this.toolStripMenuItem_Close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.toolStripMenuItem_Close.Size = new System.Drawing.Size(217, 24);
			this.toolStripMenuItem_Close.Text = "Close";
			this.toolStripMenuItem_Close.Click += new System.EventHandler(this.toolStripMenuItem_Close_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEffectToolStripMenuItem,
            this.toolStripMenuItem_EditEffect,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Cut,
            this.toolStripMenuItem_Copy,
            this.toolStripMenuItem_Paste,
            this.toolStripSeparator3,
            this.selectAllElementsToolStripMenuItem,
            this.toolStripMenuItem_deleteElements});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// addEffectToolStripMenuItem
			// 
			this.addEffectToolStripMenuItem.Name = "addEffectToolStripMenuItem";
			this.addEffectToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
			this.addEffectToolStripMenuItem.Text = "Add Effect";
			// 
			// toolStripMenuItem_EditEffect
			// 
			this.toolStripMenuItem_EditEffect.Name = "toolStripMenuItem_EditEffect";
			this.toolStripMenuItem_EditEffect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.toolStripMenuItem_EditEffect.Size = new System.Drawing.Size(256, 24);
			this.toolStripMenuItem_EditEffect.Text = "Edit Effect...";
			this.toolStripMenuItem_EditEffect.Click += new System.EventHandler(this.toolStripMenuItem_EditEffect_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(253, 6);
			// 
			// toolStripMenuItem_Cut
			// 
			this.toolStripMenuItem_Cut.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.CutHS;
			this.toolStripMenuItem_Cut.Name = "toolStripMenuItem_Cut";
			this.toolStripMenuItem_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.toolStripMenuItem_Cut.Size = new System.Drawing.Size(256, 24);
			this.toolStripMenuItem_Cut.Text = "Cut";
			this.toolStripMenuItem_Cut.Click += new System.EventHandler(this.toolStripMenuItem_Cut_Click);
			// 
			// toolStripMenuItem_Copy
			// 
			this.toolStripMenuItem_Copy.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.CopyHS;
			this.toolStripMenuItem_Copy.Name = "toolStripMenuItem_Copy";
			this.toolStripMenuItem_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.toolStripMenuItem_Copy.Size = new System.Drawing.Size(256, 24);
			this.toolStripMenuItem_Copy.Text = "Copy";
			this.toolStripMenuItem_Copy.Click += new System.EventHandler(this.toolStripMenuItem_Copy_Click);
			// 
			// toolStripMenuItem_Paste
			// 
			this.toolStripMenuItem_Paste.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.PasteHS;
			this.toolStripMenuItem_Paste.Name = "toolStripMenuItem_Paste";
			this.toolStripMenuItem_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.toolStripMenuItem_Paste.Size = new System.Drawing.Size(256, 24);
			this.toolStripMenuItem_Paste.Text = "Paste";
			this.toolStripMenuItem_Paste.Click += new System.EventHandler(this.toolStripMenuItem_Paste_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(253, 6);
			// 
			// selectAllElementsToolStripMenuItem
			// 
			this.selectAllElementsToolStripMenuItem.Name = "selectAllElementsToolStripMenuItem";
			this.selectAllElementsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllElementsToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
			this.selectAllElementsToolStripMenuItem.Text = "Select All Elements";
			this.selectAllElementsToolStripMenuItem.Click += new System.EventHandler(this.selectAllElementsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem_deleteElements
			// 
			this.toolStripMenuItem_deleteElements.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.DeleteHS;
			this.toolStripMenuItem_deleteElements.Name = "toolStripMenuItem_deleteElements";
			this.toolStripMenuItem_deleteElements.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.toolStripMenuItem_deleteElements.Size = new System.Drawing.Size(256, 24);
			this.toolStripMenuItem_deleteElements.Text = "Delete Element(s)";
			this.toolStripMenuItem_deleteElements.Click += new System.EventHandler(this.toolStripMenuItem_deleteElements_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_zoomTimeIn,
            this.toolStripMenuItem_zoomTimeOut,
            this.toolStripMenuItem_zoomRowsIn,
            this.toolStripMenuItem_zoomRowsOut});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// toolStripMenuItem_zoomTimeIn
			// 
			this.toolStripMenuItem_zoomTimeIn.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.Zoom_In;
			this.toolStripMenuItem_zoomTimeIn.Name = "toolStripMenuItem_zoomTimeIn";
			this.toolStripMenuItem_zoomTimeIn.ShortcutKeyDisplayString = "Ctrl+ +";
			this.toolStripMenuItem_zoomTimeIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add)));
			this.toolStripMenuItem_zoomTimeIn.Size = new System.Drawing.Size(277, 24);
			this.toolStripMenuItem_zoomTimeIn.Text = "Zoom Time In";
			this.toolStripMenuItem_zoomTimeIn.Click += new System.EventHandler(this.toolStripMenuItem_zoomTimeIn_Click);
			// 
			// toolStripMenuItem_zoomTimeOut
			// 
			this.toolStripMenuItem_zoomTimeOut.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.Zoom_Out;
			this.toolStripMenuItem_zoomTimeOut.Name = "toolStripMenuItem_zoomTimeOut";
			this.toolStripMenuItem_zoomTimeOut.ShortcutKeyDisplayString = "Ctrl+ -";
			this.toolStripMenuItem_zoomTimeOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract)));
			this.toolStripMenuItem_zoomTimeOut.Size = new System.Drawing.Size(277, 24);
			this.toolStripMenuItem_zoomTimeOut.Text = "Zoom Time Out";
			this.toolStripMenuItem_zoomTimeOut.Click += new System.EventHandler(this.toolStripMenuItem_zoomTimeOut_Click);
			// 
			// toolStripMenuItem_zoomRowsIn
			// 
			this.toolStripMenuItem_zoomRowsIn.Name = "toolStripMenuItem_zoomRowsIn";
			this.toolStripMenuItem_zoomRowsIn.ShortcutKeyDisplayString = "Ctrl+Shift+ +";
			this.toolStripMenuItem_zoomRowsIn.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
						| System.Windows.Forms.Keys.Add)));
			this.toolStripMenuItem_zoomRowsIn.Size = new System.Drawing.Size(277, 24);
			this.toolStripMenuItem_zoomRowsIn.Text = "Zoom Rows In";
			this.toolStripMenuItem_zoomRowsIn.Click += new System.EventHandler(this.toolStripMenuItem_zoomRowsIn_Click);
			// 
			// toolStripMenuItem_zoomRowsOut
			// 
			this.toolStripMenuItem_zoomRowsOut.Name = "toolStripMenuItem_zoomRowsOut";
			this.toolStripMenuItem_zoomRowsOut.ShortcutKeyDisplayString = "Ctrl+Shift+ -";
			this.toolStripMenuItem_zoomRowsOut.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
						| System.Windows.Forms.Keys.Subtract)));
			this.toolStripMenuItem_zoomRowsOut.Size = new System.Drawing.Size(277, 24);
			this.toolStripMenuItem_zoomRowsOut.Text = "Zoom Rows Out";
			this.toolStripMenuItem_zoomRowsOut.Click += new System.EventHandler(this.toolStripMenuItem_zoomRowsOut_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_associateAudio,
            this.toolStripMenuItem_MarkManager,
            this.modifySequenceLengthToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// toolStripMenuItem_associateAudio
			// 
			this.toolStripMenuItem_associateAudio.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.base_speaker_32;
			this.toolStripMenuItem_associateAudio.Name = "toolStripMenuItem_associateAudio";
			this.toolStripMenuItem_associateAudio.Size = new System.Drawing.Size(200, 24);
			this.toolStripMenuItem_associateAudio.Text = "Associate Audio...";
			this.toolStripMenuItem_associateAudio.Click += new System.EventHandler(this.toolStripMenuItem_associateAudio_Click);
			// 
			// toolStripMenuItem_MarkManager
			// 
			this.toolStripMenuItem_MarkManager.Image = global::VixenModules.Editor.TimedSequenceEditor.TimedSequenceEditorResources.pencil_32;
			this.toolStripMenuItem_MarkManager.Name = "toolStripMenuItem_MarkManager";
			this.toolStripMenuItem_MarkManager.Size = new System.Drawing.Size(200, 24);
			this.toolStripMenuItem_MarkManager.Text = "Mark Manager...";
			this.toolStripMenuItem_MarkManager.Click += new System.EventHandler(this.toolStripMenuItem_MarkManager_Click);
			// 
			// modifySequenceLengthToolStripMenuItem
			// 
			this.modifySequenceLengthToolStripMenuItem.Name = "modifySequenceLengthToolStripMenuItem";
			this.modifySequenceLengthToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
			this.modifySequenceLengthToolStripMenuItem.Text = "Sequence Length...";
			this.modifySequenceLengthToolStripMenuItem.Click += new System.EventHandler(this.modifySequenceLengthToolStripMenuItem_Click);
			// 
			// timerPlaying
			// 
			this.timerPlaying.Interval = 40;
			this.timerPlaying.Tick += new System.EventHandler(this.timerPlaying_Tick);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_currentTime,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_sequenceLength});
			this.statusStrip.Location = new System.Drawing.Point(0, 766);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip.Size = new System.Drawing.Size(1181, 24);
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.AutoSize = false;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(120, 19);
			this.toolStripStatusLabel2.Text = "Current Position:";
			this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabel_currentTime
			// 
			this.toolStripStatusLabel_currentTime.AutoSize = false;
			this.toolStripStatusLabel_currentTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.toolStripStatusLabel_currentTime.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
			this.toolStripStatusLabel_currentTime.Name = "toolStripStatusLabel_currentTime";
			this.toolStripStatusLabel_currentTime.Size = new System.Drawing.Size(70, 19);
			this.toolStripStatusLabel_currentTime.Text = "0:00.000";
			this.toolStripStatusLabel_currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.AutoSize = false;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(140, 19);
			this.toolStripStatusLabel1.Text = "Sequence Length:";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabel_sequenceLength
			// 
			this.toolStripStatusLabel_sequenceLength.AutoSize = false;
			this.toolStripStatusLabel_sequenceLength.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.toolStripStatusLabel_sequenceLength.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
			this.toolStripStatusLabel_sequenceLength.Name = "toolStripStatusLabel_sequenceLength";
			this.toolStripStatusLabel_sequenceLength.Size = new System.Drawing.Size(70, 19);
			this.toolStripStatusLabel_sequenceLength.Text = "0:00.000";
			this.toolStripStatusLabel_sequenceLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "All files (*.*)|*.*";
			// 
			// toolStripContainer
			// 
			this.toolStripContainer.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.timelineControl);
			this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1181, 688);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.LeftToolStripPanelVisible = false;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 28);
			this.toolStripContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.RightToolStripPanelVisible = false;
			this.toolStripContainer.Size = new System.Drawing.Size(1181, 738);
			this.toolStripContainer.TabIndex = 5;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripEffects);
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripOperations);
			// 
			// timelineControl
			// 
			this.timelineControl.AutoSize = true;
			this.timelineControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.timelineControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.timelineControl.Location = new System.Drawing.Point(0, 0);
			this.timelineControl.Margin = new System.Windows.Forms.Padding(0);
			this.timelineControl.Name = "timelineControl";
			this.timelineControl.Size = new System.Drawing.Size(1181, 688);
			this.timelineControl.TabIndex = 2;
			// 
			// toolStripEffects
			// 
			this.toolStripEffects.ClickThrough = true;
			this.toolStripEffects.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStripEffects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
			this.toolStripEffects.Location = new System.Drawing.Point(9, 0);
			this.toolStripEffects.Name = "toolStripEffects";
			this.toolStripEffects.Size = new System.Drawing.Size(141, 25);
			this.toolStripEffects.TabIndex = 5;
			this.toolStripEffects.Text = "Effects";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(129, 22);
			this.toolStripLabel1.Text = "Available Effects:";
			// 
			// TimedSequenceEditorForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1181, 790);
			this.Controls.Add(this.toolStripContainer);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.DoubleBuffered = true;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "TimedSequenceEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Timed Sequence Editor";
			this.toolStripOperations.ResumeLayout(false);
			this.toolStripOperations.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.ContentPanel.PerformLayout();
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.toolStripEffects.ResumeLayout(false);
			this.toolStripEffects.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonElements.ToolStripEx toolStripOperations;
		private CommonElements.MenuStripEx menuStrip;
		private System.Windows.Forms.ToolStripMenuItem sequenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Save;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SaveAs;
		private System.Windows.Forms.ToolStripButton toolStripButton_Play;
		private System.Windows.Forms.ToolStripButton toolStripButton_Stop;
		private System.Windows.Forms.ToolStripButton toolStripButton_Pause;
		private System.Windows.Forms.Timer timerPlaying;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_currentTime;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Close;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_associateAudio;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_MarkManager;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditEffect;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Cut;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Copy;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Paste;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_zoomTimeIn;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_zoomTimeOut;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_zoomRowsIn;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_zoomRowsOut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_deleteElements;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private CommonElements.UndoButton undoButton;
        private CommonElements.UndoButton redoButton;
		private System.Windows.Forms.ToolStripButton toolStripButton_Start;
		private System.Windows.Forms.ToolStripButton toolStripButton_End;
		private System.Windows.Forms.ToolStripMenuItem selectAllElementsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_sequenceLength;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private CommonElements.ToolStripEx toolStripEffects;
		private CommonElements.Timeline.TimelineControl timelineControl;
		private System.Windows.Forms.ToolStripMenuItem addEffectToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton_Cut;
		private System.Windows.Forms.ToolStripButton toolStripButton_Copy;
		private System.Windows.Forms.ToolStripButton toolStripButton_Paste;
		private System.Windows.Forms.ToolStripButton toolStripButton_AssociateAudio;
		private System.Windows.Forms.ToolStripButton toolStripButton_MarkManager;
		private System.Windows.Forms.ToolStripButton toolStripButton_ZoomTimeIn;
		private System.Windows.Forms.ToolStripButton toolStripButton_ZoomTimeOut;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripMenuItem modifySequenceLengthToolStripMenuItem;
	}
}