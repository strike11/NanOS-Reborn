using Cosmos.System.Graphics;
using NanOS.GUI;
using System.Drawing;
using Sys = Cosmos.System;
using static Cosmos.System.MouseManager;
using Point = Cosmos.System.Graphics.Point;
using Cosmos.System;
using Cosmos.Core.IOGroup;
using Cosmos.System.Graphics.Fonts;
using Pen = Cosmos.System.Graphics.Pen;
using IL2CPU.API.Attribs;
using Bitmap = Cosmos.System.Graphics.Bitmap;
using System;

namespace NanOS.GUI
{
    public class Taskbar
    {
        private readonly Canvas _canvas;
        private readonly int _screenWidth;
        private readonly int _screenHeight;
        private readonly Pen _blackpen;
        private Bitmap startnano;
        [ManifestResourceStream(ResourceName = "NanOS.resources.nanoStart.bmp")]
        static byte[] nanostart;
        private Bitmap TimeArea;
        [ManifestResourceStream(ResourceName = "NanOS.resources.TimePan.bmp")]
        static byte[] timeareabyte;

        public Taskbar(Canvas canvas, int screenWidth, int screenHeight, Pen blackpen)
        {
            _canvas = canvas;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            startnano = new Bitmap(nanostart);
            TimeArea = new Bitmap(timeareabyte);
            _blackpen = blackpen;

        }

        public void DrawTaskbar(Pen pen,Pen blackpen, Point point)
        {
            var startPanel = new StartPanel(_canvas,5,70,300,400, 0xFF0000, pen, blackpen);
            _canvas.DrawFilledRectangle(pen, point.X, point.Y, _screenWidth, _screenHeight);
            _canvas.DrawImageAlpha(TimeArea, 1820, 13);
            
            Button StartButton = new Button(_canvas, 10, 8, startnano);
            if (StartButton.IsPressed((int)MouseManager.X, (int)MouseManager.Y))
            {
                if (Cosmos.System.MouseManager.MouseState == Cosmos.System.MouseState.Left)
                {
                    startPanel.Draw();
                }
            }
        }

    }
}
