using System.Collections.Generic;
using VectorNewWAY.Figures;
using System.Windows.Forms;

namespace VectorNewWAY.FigureList
{
    public class SingletonData
    {
        private static SingletonData _data;
        public PictureBox PictureBox1 { get; set; }
        public Canvas Canvas { get; set; }
        public List<AFigure> FigureList { get; set; }
        protected SingletonData()
        {
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
