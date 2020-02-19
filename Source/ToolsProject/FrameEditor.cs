/*----------------------------------------
File Name: FrameEditor.cs
Purpose: Creates and controls a form for
Frame Editor
Author: Tarn Cooper
Modified: 27 August 2019
------------------------------------------
Copyright 2019 Tarn Cooper.
-----------------------------------*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToolsProject
{
    public partial class FrameEditor : Form
    {
        int frameAmount = 5;
        int frameSizeX = 10;
        const int frameSizeY = 47;
        Point currentFrame = new Point();
        Bitmap framesArea = null;
        Bitmap animationArea = null;
        List<Frame> frames = null;
        SpriteSelector spriteSelector = null;
        string spriteImagePath;

        //-----------------------------------------------------------
        // Constructor used when creating a new frame editor.
        //-----------------------------------------------------------
        public FrameEditor()
        {
            InitializeComponent();
            framesArea = new Bitmap(FramesPbx.Width, FramesPbx.Height);
            animationArea = new Bitmap(playerPbx.Width, playerPbx.Height);
            frames = new List<Frame>();
            frameBox.Text = frameAmount.ToString();
            timeBx.Text = SequenceTime.Interval.ToString();
            playerPbx.AllowDrop = true;
            DrawFrameGrid();
            DrawAnimation();
        }

        //-----------------------------------------------------------
        // Start to create new sprite selector when clicked
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void NewSelectorMi_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    if (spriteSelector != null)
                    {
                        spriteSelector.Dispose();
                    }
                    spriteSelector = new SpriteSelector(dlg.FileName);
                    spriteImagePath = dlg.FileName;
                    spriteSelector.Show();
                }
            }
        }


        //-----------------------------------------------------------
        // Draws new sprite image based on prevously selected input
        // and adds grid on top
        //-----------------------------------------------------------
        private void DrawFrameGrid()
        {
            FramesPbx.DrawToBitmap(framesArea, FramesPbx.Bounds);
            frameSizeX = (FramesPbx.Width - 3) / frameAmount;
            Graphics g = Graphics.FromImage(framesArea);
            g.Clear(Color.White);
            Rectangle source;
            foreach (Frame frame in frames)
            {
                source = new Rectangle(
                frame.tileCoord.X * (frame.gridWidth + frame.gridSpacing),
                frame.tileCoord.Y * (frame.gridHeight + frame.gridSpacing),
                frame.gridWidth + frame.gridSpacing,
                frame.gridHeight + frame.gridSpacing);
                Rectangle dest = new Rectangle(frames.IndexOf(frame) * frameSizeX, 0, frameSizeX, frameSizeY);
                Image image = Image.FromFile(frame.imagePath);
                g.DrawImage(image, dest, source, GraphicsUnit.Pixel);
                image.Dispose();
            }

            Pen pen = new Pen(Brushes.Black);
            int height = frameSizeY;
            int width = frameSizeX * frameAmount;
            for (int y = 0; y <= height; y += frameSizeY)
            {
                g.DrawLine(pen, 0, y, width, y);
            }

            for (int x = 0; x <= width; x += frameSizeX)
            {
                g.DrawLine(pen, x, 0, x, height);
            }

            Pen highlight = new Pen(Brushes.Red);
            g.DrawRectangle(highlight, currentFrame.X * (frameSizeX), currentFrame.Y * (FramesPbx.Height), frameSizeX, frameSizeY);

            g.Dispose();

            FramesPbx.Image = framesArea;
            DrawAnimation();

        }

        //-----------------------------------------------------------
        // Adds new frame to editor when clicked
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void AddFrameBtn_Click(object sender, EventArgs e)
        {

            if (spriteSelector != null)
            {

                Frame addFrame = new Frame()
                {
                    gridWidth = spriteSelector.gridWidth,
                    gridHeight = spriteSelector.gridHeight,
                    gridSpacing = spriteSelector.gridSpacing,
                    imagePath = spriteImagePath,
                    tileCoord = spriteSelector.currentSpriteLocation
                };

                //Replaces frame
                if (frames.Count > currentFrame.X)
                {

                    foreach (Frame frame in frames)
                    {
                        if (frames.IndexOf(frame) == currentFrame.X)
                        {
                            frames.Insert(frames.IndexOf(frame), addFrame);
                            frames.RemoveAt(frames.IndexOf(frame));
                            break;
                        }
                    }
                }
                //New frame
                else
                {
                    frames.Add(addFrame);
                    currentFrame.X++;
                }

                DrawFrameGrid();
            }
        }

        //-----------------------------------------------------------
        // Selects frame depending on loaction when clicked
        // sender (object): (Unused)
        // e (EventArgs): used to get mouse location
        //-----------------------------------------------------------
        private void FramesPbx_Click(object sender, EventArgs e)
        {
            if (FramesPbx == null)
            {
                return;
            }

            if (e.GetType() == typeof(MouseEventArgs))
            {
                MouseEventArgs mouse = e as MouseEventArgs;
                if (mouse.X / (frameSizeX) < frameAmount)
                {
                    currentFrame = new Point(
                        mouse.X / (frameSizeX),
                        mouse.Y / (frameSizeY));
                }
                else
                {
                    currentFrame = new Point(
                        frameAmount - 1,
                        mouse.Y / (frameSizeY));
                }
                DrawFrameGrid();
            }
        }

        //-----------------------------------------------------------
        // deletes selected frame when clicked
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void DeleteFrameBtn_Click(object sender, EventArgs e)
        {
            foreach (Frame frame in frames)
            {
                if (frames.IndexOf(frame) == currentFrame.X)
                {
                    frames.Remove(frame);
                    break;
                }
            }
            DrawFrameGrid();
        }

        //-----------------------------------------------------------
        // Activates timer when clicked. Plays animation
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            SequenceTime.Enabled = !SequenceTime.Enabled;
            if (SequenceTime.Enabled)
                playBtn.Text = "Pause";
            else
            {
                playBtn.Text = "Play";
            }
        }

        //-----------------------------------------------------------
        // Each tick changes the frame selected
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void SequenceTime_Tick(object sender, EventArgs e)
        {
            currentFrame.X++;
            if (currentFrame.X >= frameAmount)
            {
                currentFrame.X = 0;
            }
            DrawFrameGrid();
        }

        //-----------------------------------------------------------
        // Draws new sprite image based on prevously selected frame
        //-----------------------------------------------------------
        public void DrawAnimation()
        {
            playerPbx.DrawToBitmap(animationArea, playerPbx.Bounds);

            Graphics g = Graphics.FromImage(animationArea);
            g.Clear(Color.White);

            foreach (Frame frame in frames)
            {
                if (frames.IndexOf(frame) == currentFrame.X)
                {
                    Rectangle source = new Rectangle(
                        frame.tileCoord.X * (frame.gridWidth + frame.gridSpacing),
                        frame.tileCoord.Y * (frame.gridHeight + frame.gridSpacing),
                        frame.gridWidth + frame.gridSpacing,
                        frame.gridHeight + frame.gridSpacing);
                    Rectangle dest = new Rectangle(playerPbx.Width / 2 - frame.gridWidth / 2, playerPbx.Height / 2 - frame.gridHeight / 2, source.Width, source.Height);
                    Image image = Image.FromFile(frame.imagePath);
                    g.DrawImage(image, dest, source, GraphicsUnit.Pixel);
                    image.Dispose();
                    break;
                }
            }
            g.Dispose();

            playerPbx.Image = animationArea;
        }

        //-----------------------------------------------------------
        // Checks if value is usable and changes timer intervals
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void TimeBx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(timeBx.Text, out int timeOut) == true)
            {
                if (timeOut != 0)
                {
                    SequenceTime.Interval = timeOut;
                }
            }
        }

        //-----------------------------------------------------------
        // Resets Editor when clicked
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void NewEditorMi_Click(object sender, EventArgs e)
        {
            frameAmount = 5;
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

        //-----------------------------------------------------------
        // If image from sprite selector is dragged over player. That
        // image becomes the frame selected on Frame Editor
        // sender (object): (Unused)
        // e (DragEventArgs): (Unused)
        //-----------------------------------------------------------
        private void PlayerPbx_DragDrop(object sender, DragEventArgs e)
        {
            if (spriteSelector != null)
            {
                Frame addFrame = new Frame()
                {
                    gridWidth = spriteSelector.gridWidth,
                    gridHeight = spriteSelector.gridHeight,
                    gridSpacing = spriteSelector.gridSpacing,
                    imagePath = spriteImagePath,
                    tileCoord = spriteSelector.currentSpriteLocation,
                };
                if (frames.Count > currentFrame.X)
                {

                    foreach (Frame frame in frames)
                    {
                        if (frames.IndexOf(frame) == currentFrame.X)
                        {
                            frames.Insert(frames.IndexOf(frame), addFrame);
                            frames.RemoveAt(frames.IndexOf(frame));
                            break;
                        }
                    }
                }
                else
                {
                    frames.Add(addFrame);
                    currentFrame.X++;
                }

                DrawFrameGrid();
            }
        }

        //-----------------------------------------------------------
        // Adds effect to mouse of being copied
        // sender (object): (Unused)
        // e (dragEventArgs): used to add effect
        //-----------------------------------------------------------
        private void PlayerPbx_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
        }

        //-----------------------------------------------------------
        // Opens a SS file when opening sprite selector
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void OpenSelectorMi_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Sprite Selector Image|*.SS"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    System.IO.Stream stream = System.IO.File.Open(dlg.FileName, System.IO.FileMode.Open);
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SaveSpriteSelector));
                    SaveSpriteSelector save = (SaveSpriteSelector)xmlSerializer.Deserialize(stream);
                    stream.Close();
                    if (spriteSelector != null)
                    {
                        spriteSelector.Dispose();
                    }
                    spriteSelector = new SpriteSelector(save.gridWidthS, save.gridHeightS, save.spacingS, save.spriteImagePathS, save.currentSpriteS);
                    spriteImagePath = save.spriteImagePathS;
                    spriteSelector.Show();
                    DrawFrameGrid();
                }
            }
        }

        //-----------------------------------------------------------
        // Save a FE file to be used when opening a new frame editor
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void SaveEditorMi_Click(object sender, EventArgs e)
        {
            SaveFrameEditor save = new SaveFrameEditor()
            {
                timeS = int.Parse(timeBx.Text),
                currentFrameS = currentFrame,
                framesS = frames,
                frameAmountS = frameAmount,
            };
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = "Frames.FE",
                Filter = "Frame Editor Project|*.FE",
                Title = "Save a Frame Editor"
            };
            
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SaveFrameEditor));
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                xmlSerializer.Serialize(fs, save);
                fs.Close();
            }
        }

        //-----------------------------------------------------------
        // Opens a FE file when opening new frame editor
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void OpenEditorMi_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Frame Editor Project|*.FE"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    System.IO.Stream stream = System.IO.File.Open(dlg.FileName, System.IO.FileMode.Open);
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SaveFrameEditor));
                    SaveFrameEditor save = (SaveFrameEditor)xmlSerializer.Deserialize(stream);
                    stream.Close();
                    timeBx.Text = save.timeS.ToString();
                    currentFrame = save.currentFrameS;
                    frames = save.framesS;
                    frameBox.Text = save.frameAmountS.ToString();
                    DrawFrameGrid();
                }
            }
        }

        //-----------------------------------------------------------
        // Used to save new png file based on sequence of frames
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void AnimationExportMi_Click(object sender, EventArgs e)
        {
            Bitmap export = null;
            //Set bit map based on sprite to use reduce empty space
            if (frames.Count != 0)
            {

                if (frameAmount <= 10)
                {
                    export = new Bitmap((frames[0].gridWidth + 1) * frameAmount, (frames[0].gridHeight + 1) * (frameAmount / 10 + 1));
                }
                else
                {
                    export = new Bitmap((frames[0].gridWidth + 1) * 10, (frames[0].gridHeight + 1) * (frameAmount / 10 + 1));
                }

                Graphics g = Graphics.FromImage(export);
                g.Clear(Color.White);
                Rectangle source;
                int rowCount = 0;
                foreach (Frame frame in frames)
                {
                    //Stops if hit end of frame editor
                    if (frames.IndexOf(frame) == frameAmount)
                    {
                        break;
                    }
                    rowCount++;
                    source = new Rectangle(
                        frame.tileCoord.X * (frame.gridWidth + frame.gridSpacing),
                        frame.tileCoord.Y * (frame.gridHeight + frame.gridSpacing),
                        frame.gridWidth + frame.gridSpacing,
                        frame.gridHeight + frame.gridSpacing);
                    //makes new row for every 10 sprites
                    if (frames.IndexOf(frame) % 10 == 0)
                    {
                        rowCount = 0;
                    }
                    Rectangle dest = new Rectangle(rowCount * (frame.gridWidth + 1), frames.IndexOf(frame) / 10 * (frame.gridHeight + 1), frame.gridWidth, frame.gridHeight);
                    Image image = Image.FromFile(frame.imagePath);
                    g.DrawImage(image, dest, source, GraphicsUnit.Pixel);
                    image.Dispose();
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = "Image.png",
                    Filter = "Portable Network Graphic|*.png",
                    Title = "Save a Image"
                };
                saveFileDialog.ShowDialog();
                export.Save(saveFileDialog.FileName);
            }
        }

        //-----------------------------------------------------------
        // Save a SS file to be used when opening a new sprite selector
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void SaveSelectorMi_Click(object sender, EventArgs e)
        {
            if (spriteSelector != null)
            {
                SaveSpriteSelector save = new SaveSpriteSelector()
                {
                    gridWidthS = spriteSelector.gridWidth,
                    gridHeightS = spriteSelector.gridHeight,
                    spacingS = spriteSelector.gridSpacing,
                    currentSpriteS = spriteSelector.currentSpriteLocation,
                    spriteImagePathS = spriteImagePath
                };
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = "Sprite.SS",
                    Filter = "Sprite Selector Image|*.SS",
                    Title = "Save a Sprite Selector"
                };
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(SaveSpriteSelector));
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    xmlSerializer.Serialize(fs, save);
                    fs.Close();
                }
            }
        }

        //-----------------------------------------------------------
        // Checks if input is valid and updates text box
        // sender (object): (Unused)
        // e (EventArgs): (Unused)
        //-----------------------------------------------------------
        private void FrameTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(frameBox.Text, out int frameSizeOut) == true)
            {
                frameAmount = frameSizeOut;
                frameSizeX = FramesPbx.Width / frameAmount;
                DrawFrameGrid();
            }
        }
    }
}
