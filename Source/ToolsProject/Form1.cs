using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsProject
{
    public partial class mainForm : Form
    {
        int frameSize = 1;
        int frameWidth = 1;
        int frameHeight = 1;
        Point currentFrame = new Point();
        Bitmap framesArea = null;
        Bitmap animationArea = null;
        List<Frame> frames = null;
        SpriteSelector spriteSelector = null;
        public mainForm()
        {
            InitializeComponent();
            framesArea = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            animationArea = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            frameWidth = pictureBox3.Width/frameSize;
            frameHeight = pictureBox3.Height;
            frames = new List<Frame>();
            frameBox.Text = frameSize.ToString();
            timeBx.Text = timer1.Interval.ToString();
        }

        private void AddNewSpriteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spriteSelector = new SpriteSelector();
            spriteSelector.Show();
        }


        private void DrawFrameGrid()
        {
            pictureBox3.DrawToBitmap(framesArea, pictureBox3.Bounds);

            Graphics g = Graphics.FromImage(framesArea);
            g.Clear(Color.White);

            if (spriteSelector == null || spriteSelector.spriteImage == null)
            {
                return;
            }

            Pen pen = new Pen(Brushes.Black);
            int height = pictureBox3.Height;
            int width = pictureBox3.Width;
            Rectangle source;
            foreach (Frame frame in frames)
            {
                source = new Rectangle(
                    frame.tileCoord.X * (spriteSelector.gridWidth + spriteSelector.spacing),
                    frame.tileCoord.Y * (spriteSelector.gridHeight + spriteSelector.spacing),
                    spriteSelector.gridWidth,
                    spriteSelector.gridHeight);
                Rectangle dest = new Rectangle(frame.order * frameWidth, 0, frameWidth, frameHeight);
                g.DrawImage(spriteSelector.spriteImage, dest, source, GraphicsUnit.Pixel);
            }
            
            for (int y = 0; y < height; y += frameHeight)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x < width; x += frameWidth)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight, currentFrame.X * (frameWidth), currentFrame.Y * (frameHeight), frameWidth, frameHeight);

            g.Dispose();

            pictureBox3.Image = framesArea;
            DrawAnimation();

        }


        private void AddFrameBtn_Click(object sender, EventArgs e)
        {
            foreach (Frame frame in frames)
            {
                if (frame.order == currentFrame.X)
                {
                    frames.Remove(frame);
                    break;
                }
            }
            Frame addFrame = new Frame()
            {
                tileCoord = spriteSelector.currentSprite,
                order = currentFrame.X
            };
            frames.Add(addFrame);
            currentFrame.X++;
            DrawFrameGrid();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3 == null)
            {
                return;
            }

            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;
                currentFrame = new Point(
                    mouse.X / (frameWidth),
                    mouse.Y / (frameHeight));
                DrawFrameGrid();
            }
        }

        private void DeleteFrameBtn_Click(object sender, EventArgs e)
        {
            foreach (Frame frame in frames)
            {
                if (frame.order == currentFrame.X)
                {
                    frames.Remove(frame);
                    break;
                }
            }
            DrawFrameGrid();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            currentFrame.X++;
            if (currentFrame.X >= frameSize)
            {
                currentFrame.X = 0;
            }
            DrawFrameGrid();
        }

        public void DrawAnimation()
        {
            pictureBox2.DrawToBitmap(animationArea, pictureBox2.Bounds);

            Graphics g = Graphics.FromImage(animationArea);
            g.Clear(Color.White);

            if (spriteSelector.spriteImage == null)
            {
                return;
            }
            foreach (Frame frame in frames)
            {
                if (frame.order == currentFrame.X)
                {
                    Rectangle source = new Rectangle(
                        frame.tileCoord.X * (spriteSelector.gridWidth + spriteSelector.spacing),
                        frame.tileCoord.Y * (spriteSelector.gridHeight + spriteSelector.spacing),
                        spriteSelector.gridWidth,
                        spriteSelector.gridHeight);
                    Rectangle dest = new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height);
                    g.DrawImage(spriteSelector.spriteImage, dest, source, GraphicsUnit.Pixel);
                    break;
                }
            }
            g.Dispose();

            pictureBox2.Image = animationArea;
        }

        private void FrameBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(frameBox.Text, out int frameSizeOut) == true)
            {
                if(frameSizeOut != 0 && frameSizeOut <= 30)
                {
                    frameSize = frameSizeOut;
                    frameWidth = pictureBox3.Width / frameSize;
                    DrawFrameGrid();
                }
                
            }
        }

        private void TimeBx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(timeBx.Text, out int timeOut) == true)
            {
                if (timeOut != 0)
                {
                    timer1.Interval = timeOut;
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frameSize = 5;
            currentFrame = new Point();
            frames.Clear();
            if (spriteSelector != null)
            {
                spriteSelector.Close();
            }
            
            timeBx.Text = 100.ToString();
            frameBox.Text = 5.ToString();
            DrawFrameGrid();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Tarn Cooper");
        }

        private void PictureBox3_DragOver(object sender, DragEventArgs e)
        {

        }
    }
}
