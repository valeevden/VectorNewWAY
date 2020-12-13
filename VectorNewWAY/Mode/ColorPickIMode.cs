using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorNewWAY.Fabrics;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;

namespace VectorNewWAY.Mode
{
    class ColorPickIMode : IMode
    {
        SingletonData _sigletone;
        Color _pickedColor;
        public void MouseDown(Pen p, MouseEventArgs e, AFigure figure, IFigureFabric fabric)
        {
            if (_sigletone.PictureBox1.Image != null)
            {
                _pickedColor = _sigletone.Canvas._mainBitmap.GetPixel(e.X, e.Y);
                if (_pickedColor.A == 0)
                {
                    p.Color = _sigletone.PictureBox1.BackColor;
                    colorPalete.BackColor = _sigletone.PictureBox1.BackColor;
                }
                else
                {
                    _sigletone.PictureBox1.BackColor = _pickedColor;
                    p.Color = _pickedColor;
                }
            }
            else
            {
                p.Color = _sigletone.PictureBox1.BackColor;
                colorPalete.BackColor = _sigletone.PictureBox1.BackColor;
            }
        }

        public void MouseMove(Pen pen, MouseEventArgs e)
        {
            
        }

        public void MouseUp(Pen pen, MouseEventArgs e, IFigureFabric fabric)
        {
            radioButtonPaintMode.Checked = true;
            colorPicker.Checked = false;
        }
    }
}
