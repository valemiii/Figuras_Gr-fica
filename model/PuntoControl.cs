using System;
using System.Drawing;

namespace DeberGrupal
{
    public class PuntoControl
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PuntoControl(double x, double y) { X = x; Y = y; }
        public PuntoControl Copia() { return new PuntoControl(X, Y); }
        public PointF APointF() { return new PointF((float)X, (float)Y); }
        public static PuntoControl Interpolar(PuntoControl a, PuntoControl b, double t)
        { return new PuntoControl((1-t)*a.X+t*b.X, (1-t)*a.Y+t*b.Y); }
    }
}
