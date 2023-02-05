using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mashUp
{
    public class Figure
    {
        public List<PointF> Pts;
        public PointF Centroid, Last;

        public Figure()
        {
            Pts = new List<PointF>();
        }

        public void Add(PointF point)
        {
            Centroid = new PointF();
            Pts.Add(point);

            for (int p = 0; p < Pts.Count; p++)
            {
                Centroid.X += Pts[p].X;
                Centroid.Y += Pts[p].Y;
            }
            Last = point;

            Centroid.X /= Pts.Count;
            Centroid.Y /= Pts.Count;
        }

        public void Scale(float value)
        {
            for (int p = 0; p < Pts.Count; p++)
            {
                Pts[p] = new PointF(Pts[p].X * value, Pts[p].Y * value);
            }
        }

        public void Follow(PointF a, PointF b, float value)
        {
            PointF pos = Util.Ins.NextStep(a, b, value);
            //Centroid = Util.Ins.NextStep(a, b, value);
            TranslateToOrigin();
            TranslatePoints(pos);
            UpdateAttributes();
        }

        public void TranslatePoints(PointF a)
        {
            for (int p = 0; p < Pts.Count; p++)
            {
                Pts[p] = new PointF(Pts[p].X + a.X, Pts[p].Y + a.Y);
            }
        }

        public void TranslateToOrigin()
        {
            for (int p = 0; p < Pts.Count; p++)
            {
                Pts[p] = new PointF(Pts[p].X - Centroid.X, Pts[p].Y - Centroid.Y);
            }
        }

        public void Rotate(float angle)
        {
            for (int p = 0; p < Pts.Count; p++)
                Pts[p] = Util.Ins.Rotate(Pts[p], angle);
        }

        public void UpdateAttributes()
        {
            Centroid = new PointF();

            for (int p = 0; p < Pts.Count; p++)
            {
                Centroid.X += Pts[p].X;
                Centroid.Y += Pts[p].Y;
            }
            Last = Pts[Pts.Count - 1];

            Centroid.X /= Pts.Count;
            Centroid.Y /= Pts.Count;
        }
    }
}
