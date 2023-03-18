using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Collections.Generic;
using System.Drawing;
using Font = Cosmos.System.Graphics.Fonts.Font;
using Pen = Cosmos.System.Graphics.Pen;
namespace NanOS.GUI
{
    public class StartPanel
    {
        private readonly Canvas _canvas;
        private readonly int _x;
        private readonly int _y;
        private readonly int _width;
        private readonly int _height;
        private readonly uint _color;
        private readonly Pen _pen;
        private readonly Pen _blackpen;

        public StartPanel(Canvas canvas, int x, int y, int width, int height, uint color, Pen pen, Pen blackPen)
        {
            _canvas = canvas;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _color = color;
            _pen = pen;
            _blackpen = blackPen;
        }

        public void Draw()
        {
            _canvas.DrawFilledRectangle(_pen,_x, _y, _width, _height);
            Button ShutDownStartButton = new Button(_canvas, 260, 430, 30, 30, new Pen(Color.Red));
            Button RebootStartButton = new Button(_canvas, 220, 430, 30, 30, new Pen(Color.Yellow));
            _canvas.DrawString("NanOS", Cosmos.System.Graphics.Fonts.PCScreenFont.Default, _blackpen, 135, 85);
            if (ShutDownStartButton.IsPressed((int)MouseManager.X, (int)MouseManager.Y))
            {
                if (Cosmos.System.MouseManager.MouseState == Cosmos.System.MouseState.Left)
                {
                    Power.Shutdown(); 
                }
            }
            if (RebootStartButton.IsPressed((int)MouseManager.X, (int)MouseManager.Y))
            {
                if (Cosmos.System.MouseManager.MouseState == Cosmos.System.MouseState.Left)
                {
                    Power.Reboot();
                }
            }
        }
    }
}
