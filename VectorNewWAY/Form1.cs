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
            if (e.Button != MouseButtons.Right)
            {
                _mouseMode.MouseDown(_pen, e, _figure, fabric);

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.Button != MouseButtons.Right)
            {
                _mouseMode.MouseMove(_pen, e);
                pictureBox1.Image = _data.PictureBox1.Image;
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
              
            _mouseMode.MouseUp(_pen, e, fabric);

            _data.Canvas.Save();
        }


        private void ClearAll_Click(object sender, EventArgs e)
        {

        }

        private void Brush_Click(object sender, EventArgs e)
        {
            fabric = new BrushFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void Rectangle_2d_Click(object sender, EventArgs e)
        {
            fabric = new RectangleIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void Square_Click(object sender, EventArgs e)
        {
            fabric = new SquareIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }
        private void Circle_Click(object sender, EventArgs e)
        {
            fabric = new CircleIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void Line2D_Click(object sender, EventArgs e)
        {
            fabric = new Line2DIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void LineND_Click(object sender, EventArgs e)
        {
            fabric = new LineNDIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void FigureND_Click(object sender, EventArgs e)
        {
            fabric = new FigureNDIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }
        private void Ellipse_Click(object sender, EventArgs e)
        {
            fabric = new EllipseIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void Triangle3D_Click(object sender, EventArgs e)
        {
            fabric = new Triangle3DIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void NanglesFigure_Click(object sender, EventArgs e)
        {
            fabric = new NAngleIFabric((int)_anglesNumber.Value);
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void _anglesNumber_ValueChanged(object sender, EventArgs e)
        {
            fabric = new NAngleIFabric((int)_anglesNumber.Value);
            _figure = fabric.CreateFigure(_pen);
        }

        private void IsoscelesTriangle_Click(object sender, EventArgs e)
        {
            fabric = new IsoscelesTriangleIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void RectTriangleButton_Click(object sender, EventArgs e)
        {
            fabric = new RectTriangleIFabric();
            _figure = fabric.CreateFigure(_pen);
            radioButtonPaintMode.Checked = true;
        }

        private void trackPenWidth_Scroll(object sender, EventArgs e)
        {
            _pen = new Pen(colorDialog1.Color, trackPenWidth.Value);
            radioButtonPaintMode.Checked = true;
        }

        private void colorPalete_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorPalete.BackColor = colorDialog1.Color;
                _pen = new Pen(colorDialog1.Color, trackPenWidth.Value);
                radioButtonPaintMode.Checked = true;
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
                _mouseMode = new RotateIMode();
            }
        }

        private void radioButtonScale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonScale.Checked)
            {
                _mouseMode = new ScaleIMode();
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
                _mouseMode = new FillIMode();
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
