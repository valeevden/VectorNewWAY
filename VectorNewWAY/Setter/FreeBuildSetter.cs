using VectorNewWAY.Figures;

namespace VectorNewWAY.Setter
{
    public class FreeBuildSetter: ISetter
    {
        public void Set(AFigure figure)
        {
            figure.AnglesNumber++;
        }
}
}
