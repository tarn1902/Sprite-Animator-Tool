/*----------------------------------------
File Name: Program.cs
Purpose: stores Main function to run application
Author: Tarn Cooper
Modified: 27 August 2019
------------------------------------------
Copyright 2019 Tarn Cooper.
-----------------------------------*/
using System;
using System.Windows.Forms;

namespace ToolsProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrameEditor());
        }
    }
}
