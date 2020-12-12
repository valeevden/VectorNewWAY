using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorNewWAY.Mode;
using VectorNewWAY.Figures;
using VectorNewWAY.Fabrics;
using VectorNewWAY.FigureList;

namespace VectorNewWAY
{
    public partial class Form1 : Form
    {
        IMode _mouseMode;
        AFigure _figure;
        Pen _pen = new Pen(Color.Red, 6);
        Canvas canvas;
        bool mouseDown = false;
        IFigureFabric fabric;
        SingletonData _data;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _data = SingletonData.GetData();
            _data.PictureBox1 = pictureBox1;
            _data.Canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);
            _figure = new EllipseFigure(_pen);
            _mouseMode = new PaintIMode();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            _mouseMode.MouseDown(_pen, e, _figure, fabric);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                _figure =_mouseMode.MouseMove(_pen, e);
                pictureBox1.Image = _data.PictureBox1.Image;
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
              
            _figure = _mouseMode.MouseUp(_pen, e);

            _data.Canvas.Save();
        }


        private void ClearAll_Click(object sender, EventArgs e)
        {

        }

        private void Brush_Click(object sender, EventArgs e)
        {
        }

        private void Rectangle_2d_Click(object sender, EventArgs e)
        {

        }

        private void Square_Click(object sender, EventArgs e)
        {

        }
        private void Circle_Click(object sender, EventArgs e)
        {


        }

        private void Line2D_Click(object sender, EventArgs e)
        {

        }

        private void LineND_Click(object sender, EventArgs e)
        {

        }

        private void FigureND_Click(object sender, EventArgs e)
        {

        }
        private void Ellipse_Click(object sender, EventArgs e)
        {
            fabric = new EllipseIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void Triangle3D_Click(object sender, EventArgs e)
        {

            radioButtonPaintMode.Checked = true;
        }

        private void NanglesFigure_Click(object sender, EventArgs e)
        {

        }

        private void _anglesNumber_ValueChanged(object sender, EventArgs e)
        {


        }

        private void IsoscelesTriangle_Click(object sender, EventArgs e)
        {


            radioButtonPaintMode.Checked = true;
        }

        private void RectTriangleButton_Click(object sender, EventArgs e)
        {

        }

        private void trackPenWidth_Scroll(object sender, EventArgs e)
        {

        }

        private void colorPalete_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorPalete.BackColor = colorDialog1.Color;

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            {
                if (pictureBox1 != null)
                {
                    SaveFileDialog tpm = new SaveFileDialog();
                    tpm.Title = "Сохранить картинку как..";
                    tpm.OverwritePrompt = true;
                    tpm.Filter = "Image Files (*.BMP)|*.BMP| Image Files(*.JPG)|*.JPG|; Image Files(*.PNG)|*.PNG|; All Files (*.*)|*.*";

                    if (tpm.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pictureBox1.Image.Save(tpm.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка, MessageBoxButtons.OK");
                        }
                    }
                }
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog F = new OpenFileDialog();
                F.Filter = "All Files (*.*)|*.*";
                if (F.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = new Bitmap(F.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void radioButtonMoveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMoveMode.Checked)
            {
                _mouseMode = new MoveIMode();
            }
        }

        private void radioButtonPaintMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPaintMode.Checked)
            {
                _mouseMode = new PaintIMode();
            }
        }

        private void radioButtonRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRotate.Checked)
            {

            }
        }


        private void radioButtonZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonZoom.Checked)
            {

            }
        }

        private void radioButtonPeak_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPeak.Checked)
            {

            }
        }
        private void FILL_CheckedChanged(object sender, EventArgs e)
        {
            if (FILL.Checked)
            {

            }
        }


        public void DrawAll()
        {

        }

        private void colorPicker_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
