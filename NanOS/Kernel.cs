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

namespace NanOS
{
    public class Kernel : Sys.Kernel
    {
        ConsoleKeyInfo cki;
        private static Canvas _canvas;
        private Point _point;
        private Pen _pen;
        private Pen _blackpen;
        public static Mouse m = new Mouse();
        private NanoMouse _nanoMouse;
        private PCScreenFont _font;
        private Bitmap walpperImg;
        [ManifestResourceStream(ResourceName = "NanOS.Wallpapers.wallpaper1.bmp")]
        static byte[] wallpaper;
        protected override void BeforeRun()
        {
                walpperImg = new Bitmap(wallpaper);
                _canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32));
                _pen = new Pen(Color.White);
                _point = new Point(0, 0);
                _nanoMouse = new NanoMouse(_canvas);
        }

        protected override void Run()
        {
                _blackpen = new Pen(Color.Black);
                _canvas.DrawImage(walpperImg, _point);
                var taskbar = new Taskbar(_canvas, 1920, 60, _blackpen);
                taskbar.DrawTaskbar(_pen, _blackpen, _point);
                Pen pen = new Pen(Color.Black);
               // _canvas.DrawString(DateTime.Now.ToString("HH:mm"), Cosmos.System.Graphics.Fonts.PCScreenFont.Default, _blackpen, 1840, 24);
                _nanoMouse.DrawCursor();
                _canvas.Display();
                _canvas.Clear(Color.FromArgb(54, 82, 128));
                int mouseX = (int)Sys.MouseManager.X;
                int mouseY = (int)Sys.MouseManager.Y;
        }

    }
}
