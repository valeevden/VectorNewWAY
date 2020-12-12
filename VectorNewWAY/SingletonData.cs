using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using System.Windows.Forms;

namespace VectorNewWAY.FigureList
{
    class SingletonData
    {
        private static SingletonData _data;
        public PictureBox PictureBox1 { get; set; }
        public Canvas Canvas { get; set; }
        public List<AFigure> FigureList { get; set; }
        protected SingletonData()
        {
            //_figureList = new SingletonFigureList();//зачем мы это написали?? вызов конструктора в конструкторе
            FigureList = new List<AFigure> { };

        }

        public static SingletonData GetData()
        {
            if (_data == null)
            {
                _data = new SingletonData();
            }
            return _data;
        }
    }
}
