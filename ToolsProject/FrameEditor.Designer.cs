namespace ToolsProject
{
    partial class FrameEditor
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
            this.components = new System.ComponentModel.Container();
            this.ToolStrip = new System.Windows.Forms.MenuStrip();
            this.editorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.newEditorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.openEditorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEditorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.selectorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.newSelectorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.openSelectorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectorMi = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMi = new System.Windows.Forms.ToolStripMenuItem();
            this.animationExportMi = new System.Windows.Forms.ToolStripMenuItem();
            this.FramesPbx = new System.Windows.Forms.PictureBox();
            this.addFrameBtn = new System.Windows.Forms.Button();
            this.deleteFrameBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.playerLbl = new System.Windows.Forms.Label();
            this.playerPbx = new System.Windows.Forms.PictureBox();
            this.SequenceTime = new System.Windows.Forms.Timer(this.components);
            this.timeBx = new System.Windows.Forms.TextBox();
            this.frameBox = new System.Windows.Forms.TextBox();
            this.framesLbl = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FramesPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorMi,
            this.selectorMi,
            this.exportMi});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(826, 24);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "menuStrip1";
            // 
            // editorMi
            // 
            this.editorMi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEditorMi,
            this.openEditorMi,
            this.saveEditorMi});
            this.editorMi.Name = "editorMi";
            this.editorMi.Size = new System.Drawing.Size(50, 20);
            this.editorMi.Text = "Editor";
            // 
            // newEditorMi
            // 
            this.newEditorMi.Name = "newEditorMi";
            this.newEditorMi.Size = new System.Drawing.Size(180, 22);
            this.newEditorMi.Text = "New";
            this.newEditorMi.Click += new System.EventHandler(this.NewEditorMi_Click);
            // 
            // openEditorMi
            // 
            this.openEditorMi.Name = "openEditorMi";
            this.openEditorMi.Size = new System.Drawing.Size(180, 22);
            this.openEditorMi.Text = "Open";
            this.openEditorMi.Click += new System.EventHandler(this.OpenEditorMi_Click);
            // 
            // saveEditorMi
            // 
            this.saveEditorMi.Name = "saveEditorMi";
            this.saveEditorMi.Size = new System.Drawing.Size(180, 22);
            this.saveEditorMi.Text = "Save";
            this.saveEditorMi.Click += new System.EventHandler(this.SaveEditorMi_Click);
            // 
            // selectorMi
            // 
            this.selectorMi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSelectorMi,
            this.openSelectorMi,
            this.saveSelectorMi});
            this.selectorMi.Name = "selectorMi";
            this.selectorMi.Size = new System.Drawing.Size(61, 20);
            this.selectorMi.Text = "Selector";
            // 
            // newSelectorMi
            // 
            this.newSelectorMi.Name = "newSelectorMi";
            this.newSelectorMi.Size = new System.Drawing.Size(103, 22);
            this.newSelectorMi.Text = "New";
            this.newSelectorMi.Click += new System.EventHandler(this.NewSelectorMi_Click);
            // 
            // openSelectorMi
            // 
            this.openSelectorMi.Name = "openSelectorMi";
            this.openSelectorMi.Size = new System.Drawing.Size(103, 22);
            this.openSelectorMi.Text = "Open";
            this.openSelectorMi.Click += new System.EventHandler(this.OpenSelectorMi_Click);
            // 
            // saveSelectorMi
            // 
            this.saveSelectorMi.Name = "saveSelectorMi";
            this.saveSelectorMi.Size = new System.Drawing.Size(103, 22);
            this.saveSelectorMi.Text = "Save";
            this.saveSelectorMi.Click += new System.EventHandler(this.SaveSelectorMi_Click);
            // 
            // exportMi
            // 
            this.exportMi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animationExportMi});
            this.exportMi.Name = "exportMi";
            this.exportMi.Size = new System.Drawing.Size(52, 20);
            this.exportMi.Text = "Export";
            // 
            // animationExportMi
            // 
            this.animationExportMi.Name = "animationExportMi";
            this.animationExportMi.Size = new System.Drawing.Size(130, 22);
            this.animationExportMi.Text = "Animation";
            this.animationExportMi.Click += new System.EventHandler(this.AnimationExportMi_Click);
            // 
            // FramesPbx
            // 
            this.FramesPbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FramesPbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FramesPbx.Location = new System.Drawing.Point(12, 450);
            this.FramesPbx.Name = "FramesPbx";
            this.FramesPbx.Size = new System.Drawing.Size(475, 50);
            this.FramesPbx.TabIndex = 12;
            this.FramesPbx.TabStop = false;
            this.FramesPbx.Click += new System.EventHandler(this.FramesPbx_Click);
            // 
            // addFrameBtn
            // 
            this.addFrameBtn.Location = new System.Drawing.Point(494, 450);
            this.addFrameBtn.Name = "addFrameBtn";
            this.addFrameBtn.Size = new System.Drawing.Size(100, 25);
            this.addFrameBtn.TabIndex = 13;
            this.addFrameBtn.Text = "Add Frame";
            this.addFrameBtn.UseVisualStyleBackColor = true;
            this.addFrameBtn.Click += new System.EventHandler(this.AddFrameBtn_Click);
            // 
            // deleteFrameBtn
            // 
            this.deleteFrameBtn.Location = new System.Drawing.Point(600, 450);
            this.deleteFrameBtn.Name = "deleteFrameBtn";
            this.deleteFrameBtn.Size = new System.Drawing.Size(100, 25);
            this.deleteFrameBtn.TabIndex = 14;
            this.deleteFrameBtn.Text = "Delete Frame";
            this.deleteFrameBtn.UseVisualStyleBackColor = true;
            this.deleteFrameBtn.Click += new System.EventHandler(this.DeleteFrameBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(706, 450);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(100, 25);
            this.playBtn.TabIndex = 15;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // playerLbl
            // 
            this.playerLbl.AutoSize = true;
            this.playerLbl.Location = new System.Drawing.Point(379, 24);
            this.playerLbl.Name = "playerLbl";
            this.playerLbl.Size = new System.Drawing.Size(36, 13);
            this.playerLbl.TabIndex = 17;
            this.playerLbl.Text = "Player";
            // 
            // playerPbx
            // 
            this.playerPbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerPbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerPbx.Location = new System.Drawing.Point(12, 42);
            this.playerPbx.Name = "playerPbx";
            this.playerPbx.Size = new System.Drawing.Size(794, 402);
            this.playerPbx.TabIndex = 16;
            this.playerPbx.TabStop = false;
            this.playerPbx.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlayerPbx_DragDrop);
            this.playerPbx.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlayerPbx_DragEnter);
            // 
            // SequenceTime
            // 
            this.SequenceTime.Tick += new System.EventHandler(this.SequenceTime_Tick);
            // 
            // timeBx
            // 
            this.timeBx.Location = new System.Drawing.Point(706, 477);
            this.timeBx.Name = "timeBx";
            this.timeBx.Size = new System.Drawing.Size(100, 20);
            this.timeBx.TabIndex = 18;
            this.timeBx.TextChanged += new System.EventHandler(this.TimeBx_TextChanged);
            // 
            // frameBox
            // 
            this.frameBox.Location = new System.Drawing.Point(561, 477);
            this.frameBox.Name = "frameBox";
            this.frameBox.Size = new System.Drawing.Size(100, 20);
            this.frameBox.TabIndex = 19;
            this.frameBox.TextChanged += new System.EventHandler(this.FrameTxtBx_TextChanged);
            // 
            // framesLbl
            // 
            this.framesLbl.AutoSize = true;
            this.framesLbl.Location = new System.Drawing.Point(511, 480);
            this.framesLbl.Name = "framesLbl";
            this.framesLbl.Size = new System.Drawing.Size(44, 13);
            this.framesLbl.TabIndex = 20;
            this.framesLbl.Text = "Frames:";
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(667, 480);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(33, 13);
            this.timeLbl.TabIndex = 21;
            this.timeLbl.Text = "Time:";
            // 
            // FrameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 512);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.framesLbl);
            this.Controls.Add(this.frameBox);
            this.Controls.Add(this.timeBx);
            this.Controls.Add(this.playerLbl);
            this.Controls.Add(this.playerPbx);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.deleteFrameBtn);
            this.Controls.Add(this.addFrameBtn);
            this.Controls.Add(this.FramesPbx);
            this.Controls.Add(this.ToolStrip);
            this.Name = "FrameEditor";
            this.Text = "Animated Sprite Editor";
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FramesPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem editorMi;
        private System.Windows.Forms.ToolStripMenuItem selectorMi;
        private System.Windows.Forms.ToolStripMenuItem newEditorMi;
        private System.Windows.Forms.ToolStripMenuItem openEditorMi;
        private System.Windows.Forms.ToolStripMenuItem saveEditorMi;
        private System.Windows.Forms.ToolStripMenuItem newSelectorMi;
        private System.Windows.Forms.PictureBox FramesPbx;
        private System.Windows.Forms.Button addFrameBtn;
        private System.Windows.Forms.Button deleteFrameBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Label playerLbl;
        private System.Windows.Forms.PictureBox playerPbx;
        private System.Windows.Forms.Timer SequenceTime;
        private System.Windows.Forms.TextBox timeBx;
        private System.Windows.Forms.TextBox frameBox;
        private System.Windows.Forms.Label framesLbl;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.ToolStripMenuItem openSelectorMi;
        private System.Windows.Forms.ToolStripMenuItem saveSelectorMi;
        private System.Windows.Forms.ToolStripMenuItem exportMi;
        private System.Windows.Forms.ToolStripMenuItem animationExportMi;
    }
}

