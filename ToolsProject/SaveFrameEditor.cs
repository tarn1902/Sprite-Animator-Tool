/*----------------------------------------
File Name: SaveFrameEditor.cs
Purpose: Saves data from frame editor
Author: Tarn Cooper
Modified: 27 August 2019
------------------------------------------
Copyright 2019 Tarn Cooper.
-----------------------------------*/
using System.Collections.Generic;
using System.Drawing;

namespace ToolsProject
{
    public class SaveFrameEditor
    {
        public Point currentFrameS = new Point();
        public int timeS = 1000;
        public List<Frame> framesS = new List<Frame>();
        public int frameAmountS = 1;
    }
}
