using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VectorNewWAY.Figures;
using VectorNewWAY.Painters;

namespace VectorNewWAY
{
    public class Canvas
    {
        public Bitmap _mainBitmap { get; protected set; } //Объект Bitmap используется для работы с изображениями, определяемыми данными пикселей
        Bitmap _tmpBitmap;
        Graphics _graphics; //класс с методами для рисования

        public Canvas(int width, int height)
        {
            _mainBitmap = new Bitmap(width, height);
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            _graphics = Graphics.FromImage(_mainBitmap);
        }



        public Bitmap DrawIt(AFigure figure, Pen pen)
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            _graphics = Graphics.FromImage(_tmpBitmap); //графикс рисует на временном битмапе
            figure.Painter.DrawFigure(pen, _graphics, figure.GetPoints());

            //if (figure.IsFilled == true)
            //{
            //    figure.Filler.FillFigure(pen, _graphics, figure.GetPoints());
            //}

            return _tmpBitmap;
        }

        public void Save()
        {
            _mainBitmap = _tmpBitmap;
        }

        public Bitmap Clear() // ХЗ как это работает точно, должно заливать графику цветом фона и возвращать битмап
        {
            _graphics.Clear(Color.White);

            return _mainBitmap;

        }
    }
}

