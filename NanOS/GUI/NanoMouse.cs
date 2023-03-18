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
using Bitmap = Cosmos.System.Graphics.Bitmap;
using IL2CPU.API.Attribs;

namespace NanOS.GUI
{
    public class NanoMouse
    {
        private readonly Canvas _canvas;
        private readonly Pen _pen = new Pen(Color.Black);
        private Bitmap _cursor;
        [ManifestResourceStream(ResourceName = "NanOS.resources.nanoscur.bmp")]
        static byte[] cursorbyte;

        public NanoMouse(Canvas canvas)
        {
            _canvas = canvas;
            _cursor = new Bitmap(cursorbyte);
        }

        public void DrawCursor()
        {
            Sys.MouseManager.ScreenWidth = (uint)_canvas.Mode.Columns;
            Sys.MouseManager.ScreenHeight = (uint)_canvas.Mode.Rows;
            int X = (int)Sys.MouseManager.X;
            int Y = (int)Sys.MouseManager.Y;
            _canvas.DrawImageAlpha(_cursor, X, Y);
                
        }

    }
}
