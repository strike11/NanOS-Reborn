using Cosmos.System;
using Cosmos.System.Graphics;
using System.Diagnostics;

namespace NanOS.GUI
{
    public class Button
    {
        private readonly Canvas _canvas;
        private readonly int _x;
        private readonly int _y;
        private readonly int _width;
        private readonly int _height;
        private readonly Pen _pen;
        private readonly Image _image;

        public Button(Canvas canvas, int x, int y, int width, int height, Pen pen)
        {
            _canvas = canvas;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _pen = pen;
        }

        public Button(Canvas canvas, int x, int y, Image image)
        {
            _canvas = canvas;
            _x = x;
            _y = y;
            _image = image;
        }

        public bool IsPressed(int mouseX, int mouseY)
        {
            if (_image != null)
            {
                if (mouseX >= _x && mouseX <= _x + _image.Width &&
                    mouseY >= _y && mouseY <= _y + _image.Height)
                {
                    _canvas.DrawImageAlpha(_image, _x, _y);
                    return true;
                }

                _canvas.DrawImageAlpha(_image, _x, _y);
                return false;
            }
            else
            {
                if (mouseX >= _x && mouseX <= _x + _width &&
                    mouseY >= _y && mouseY <= _y + _height)
                {
                    _canvas.DrawFilledRectangle(_pen, _x, _y, _width, _height);
                    return true;
                }

                _canvas.DrawFilledRectangle(_pen, _x, _y, _width, _height);
                return false;
            }
        }

    }
}