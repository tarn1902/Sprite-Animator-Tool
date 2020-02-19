namespace ToolsProject
{
    partial class SpriteSelector
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
            this.gridSpacingLbl = new System.Windows.Forms.Label();
            this.gridHeightLbl = new System.Windows.Forms.Label();
            this.gridWidthLbl = new System.Windows.Forms.Label();
            this.gridSpacingTxtBox = new System.Windows.Forms.TextBox();
            this.gridHeightTxtbx = new System.Windows.Forms.TextBox();
            this.gridWidthTxtbox = new System.Windows.Forms.TextBox();
            this.spriteImageLbl = new System.Windows.Forms.Label();
            this.imagePbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagePbx)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSpacingLbl
            // 
            this.gridSpacingLbl.AutoSize = true;
            this.gridSpacingLbl.Location = new System.Drawing.Point(527, 427);
            this.gridSpacingLbl.Name = "gridSpacingLbl";
            this.gridSpacingLbl.Size = new System.Drawing.Size(71, 13);
            this.gridSpacingLbl.TabIndex = 19;
            this.gridSpacingLbl.Text = "Grid Spacing:";
            // 
            // gridHeightLbl
            // 
            this.gridHeightLbl.AutoSize = true;
            this.gridHeightLbl.Location = new System.Drawing.Point(270, 427);
            this.gridHeightLbl.Name = "gridHeightLbl";
            this.gridHeightLbl.Size = new System.Drawing.Size(63, 13);
            this.gridHeightLbl.TabIndex = 18;
            this.gridHeightLbl.Text = "Grid Height:";
            // 
            // gridWidthLbl
            // 
            this.gridWidthLbl.AutoSize = true;
            this.gridWidthLbl.Location = new System.Drawing.Point(19, 427);
            this.gridWidthLbl.Name = "gridWidthLbl";
            this.gridWidthLbl.Size = new System.Drawing.Size(60, 13);
            this.gridWidthLbl.TabIndex = 17;
            this.gridWidthLbl.Text = "Grid Width:";
            // 
            // gridSpacingTxtBox
            // 
            this.gridSpacingTxtBox.Location = new System.Drawing.Point(600, 424);
            this.gridSpacingTxtBox.Name = "gridSpacingTxtBox";
            this.gridSpacingTxtBox.Size = new System.Drawing.Size(188, 20);
            this.gridSpacingTxtBox.TabIndex = 16;
            this.gridSpacingTxtBox.TextChanged += new System.EventHandler(this.GridSpacingTxtbx_TextChanged);
            // 
            // gridHeightTxtbx
            // 
            this.gridHeightTxtbx.Location = new System.Drawing.Point(333, 424);
            this.gridHeightTxtbx.Name = "gridHeightTxtbx";
            this.gridHeightTxtbx.Size = new System.Drawing.Size(188, 20);
            this.gridHeightTxtbx.TabIndex = 15;
            this.gridHeightTxtbx.TextChanged += new System.EventHandler(this.GridHeightTxtbx_TextChanged);
            // 
            // gridWidthTxtbox
            // 
            this.gridWidthTxtbox.Location = new System.Drawing.Point(80, 424);
            this.gridWidthTxtbox.Name = "gridWidthTxtbox";
            this.gridWidthTxtbox.Size = new System.Drawing.Size(188, 20);
            this.gridWidthTxtbox.TabIndex = 14;
            this.gridWidthTxtbox.TextChanged += new System.EventHandler(this.GridWidthTxtbx_TextChanged);
            // 
            // spriteImageLbl
            // 
            this.spriteImageLbl.AutoSize = true;
            this.spriteImageLbl.Location = new System.Drawing.Point(352, 17);
            this.spriteImageLbl.Name = "spriteImageLbl";
            this.spriteImageLbl.Size = new System.Drawing.Size(36, 13);
            this.spriteImageLbl.TabIndex = 13;
            this.spriteImageLbl.Text = "Image";
            // 
            // imagePbx
            // 
            this.imagePbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imagePbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePbx.Location = new System.Drawing.Point(12, 33);
            this.imagePbx.Name = "imagePbx";
            this.imagePbx.Size = new System.Drawing.Size(776, 385);
            this.imagePbx.TabIndex = 12;
            this.imagePbx.TabStop = false;
            this.imagePbx.Click += new System.EventHandler(this.ImagePbx_Click);
            this.imagePbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImagePbx_MouseDown);
            // 
            // SpriteSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridSpacingLbl);
            this.Controls.Add(this.gridHeightLbl);
            this.Controls.Add(this.gridWidthLbl);
            this.Controls.Add(this.gridSpacingTxtBox);
            this.Controls.Add(this.gridHeightTxtbx);
            this.Controls.Add(this.gridWidthTxtbox);
            this.Controls.Add(this.spriteImageLbl);
            this.Controls.Add(this.imagePbx);
            this.Name = "SpriteSelector";
            this.Text = "Sprite Selector";
            ((System.ComponentModel.ISupportInitialize)(this.imagePbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gridSpacingLbl;
        private System.Windows.Forms.Label gridHeightLbl;
        private System.Windows.Forms.Label gridWidthLbl;
        private System.Windows.Forms.TextBox gridSpacingTxtBox;
        private System.Windows.Forms.TextBox gridHeightTxtbx;
        private System.Windows.Forms.TextBox gridWidthTxtbox;
        private System.Windows.Forms.Label spriteImageLbl;
        private System.Windows.Forms.PictureBox imagePbx;
    }
}