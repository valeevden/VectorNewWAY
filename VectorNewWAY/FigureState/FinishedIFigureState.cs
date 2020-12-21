﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorNewWAY.Figures;
using VectorNewWAY.FigureList;
using System.Drawing;

namespace VectorNewWAY.FigureState
{
    public class FinishedIFigureState: IFigureState
    {
        SingletonData _singletone;
        public FinishedIFigureState()
        {
            _singletone = SingletonData.GetData();
        }
        public void Set(PointF firstMouseDown, AFigure figure)
        {
            figure.PointsList[0] = firstMouseDown;
            figure.State = new InProgressIFigureState();
        }
        public void FinalizeFigure(AFigure figure)
        {
            _singletone.FigureList.Add(figure);
        }
    }
}