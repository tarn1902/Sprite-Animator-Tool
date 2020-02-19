/*----------------------------------------
File Name: SpriteSelector.cs
Purpose: Creates and controls a form for
sprite selection
Author: Tarn Cooper
Modified: 27 August 2019
------------------------------------------
Copyright 2019 Tarn Cooper.
-----------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToolsProject
{
    public partial class SpriteSelector : Form
    {
        public int gridWidth = 10;
        public int gridHeight = 10;
        public int gridSpacing = 1;
        public Point currentSpriteLocation = new Point();
        private Image spriteImage = null;
        private string spriteImagePath = null;
        private Bitmap spriteImageArea = null;

        //-----------------------------------------------------------
        // Constructor used when creating a new sprite selector.
        // inSpriteImagePath (string): used to get image to display.
        //-----------------------------------------------------------
        public SpriteSelector(string inSpriteImagePath)
        {
            InitializeComponent();
            spriteImageArea = new Bitmap(imagePbx.Width, imagePbx.Height);
            gridHeightTxtbx.Text = gridHeight.ToString();
            gridWidthTxtbox.Text = gridWidth.ToString();
            gridSpacingTxtBox.Text = gridSpacing.ToString();
            spriteImagePath = inSpriteImagePath;
            spriteImage = Image.FromFile(spriteImagePath);
            DrawSpriteImageGrid();
        }
        //-----------------------------------------------------------
        // Constructor used when opening a sprite selector
        // inGridWidth (int): used to set grid width.
        // inGridHeight (int): used to set grid height.
        // inGridSpacing (int): used to set grid spacing. 
        // inSpriteImagePath (string): used to get image to display.
        // inCurrentSpriteLocation (Point): used to get current sprite Location
        //-----------------------------------------------------------
        public SpriteSelector(int inGridWidth, int inGridHeight, int inGridSpacing, string inSpriteImagePath, Point inCurrentSpriteLocation)
        {
            InitializeComponent();
            spriteImageArea = new Bitmap(imagePbx.Width, imagePbx.Height);
            gridHeightTxtbx.Text = inGridHeight.ToString() ;
            gridWidthTxtbox.Text = inGridWidth.ToString();
            gridSpacingTxtBox.Text = inGridSpacing.ToString();
            currentSpriteLocation = inCurrentSpriteLocation;
            spriteImagePath = inSpriteImagePath;
            spriteImage = Image.FromFile(spriteImagePath);
            DrawSpriteImageGrid();
        }

        //-----------------------------------------------------------
        // Draws sprite image and grid.
        //-----------------------------------------------------------
        private void DrawSpriteImageGrid()
        {
            imagePbx.DrawToBitmap(spriteImageArea, imagePbx.Bounds);

            Graphics g = Graphics.FromImage(spriteImageArea);
            g.Clear(Color.White);

            if (spriteImage != null)
            {
                g.DrawImage(spriteImage, 0, 0);
            }
            Pen pen = new Pen(Brushes.Black);

            int height = imagePbx.Height;
            int width = imagePbx.Width;

            for (int y = 0; y < height; y += gridHeight + gridSpacing)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x < width; x += gridWidth + gridSpacing)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight, currentSpriteLocation.X * (gridWidth + gridSpacing), currentSpriteLocation.Y * (gridHeight + gridSpacing), gridWidth + gridSpacing, gridHeight + gridSpacing);

            g.Dispose();

            imagePbx.Image = spriteImageArea;
        }

        //-----------------------------------------------------------
        // Checks text if can be accepted whenever it is changed.
        // Changes value of gridWidth and updates grid
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void GridWidthTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(gridWidthTxtbox.Text, out int width) == true)
            {
                gridWidth = width;
                DrawSpriteImageGrid();
            }
        }

        //-----------------------------------------------------------
        // Checks text if can be accepted whenever it is changed.
        // Changes value of gridHeight and updates grid if accepted
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void GridHeightTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(gridHeightTxtbx.Text, out int height) == true)
            {
                gridHeight = height;
                DrawSpriteImageGrid();
            }
        }

        //-----------------------------------------------------------
        // Checks text if can be accepted whenever it is changed.
        // Changes value of gridSpacing and updates grid if accepted
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void GridSpacingTxtbx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(gridSpacingTxtBox.Text, out int spacingOut) == true)
            {
                gridSpacing = spacingOut;
                DrawSpriteImageGrid();
            }
        }

        //-----------------------------------------------------------
        // Sets current sprite location to clicked mouse location
        // sender (object): (Unused)
        // e (EventArgs): used to get location of mouse
        //-----------------------------------------------------------
        private void ImagePbx_Click(object sender, EventArgs e)
        {
            if (imagePbx == null)
            {
                return;
            }

            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;
                currentSpriteLocation = new Point(
                    mouse.X / (gridWidth + gridSpacing),
                    mouse.Y / (gridHeight + gridSpacing));
                DrawSpriteImageGrid();
            }
        }

        //-----------------------------------------------------------
        // Sets current sprite location to clicked mouse location
        // sender (object): (Unused)
        // e (MouseEventArgs): used to get location of mouse
        //-----------------------------------------------------------
        private void ImagePbx_MouseDown(object sender, MouseEventArgs e)
        {
            var img = imagePbx.Image;
            if (img == null)
                return;
            currentSpriteLocation = new Point(
            e.X / (gridWidth + gridSpacing),
            e.Y / (gridHeight + gridSpacing));
            DrawSpriteImageGrid();
            DoDragDrop(img, DragDropEffects.Copy);
        }
    }
}
