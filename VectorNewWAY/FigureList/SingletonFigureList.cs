﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;

namespace VectorNewWAY.FigureList
{
    class SingletonFigureList
    {
        private static SingletonFigureList _figureList;
        public List<AFigure> FigureList { get; set; }
        private SingletonFigureList()
        {
            _figureList = new SingletonFigureList();
            FigureList = new List<AFigure> { };
        }

        public static SingletonFigureList GetFigureList()
        {
            if (_figureList == null)
            {
                _figureList = new SingletonFigureList();
            }
            return _figureList;
        }
    }
}
