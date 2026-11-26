using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DeberGrupal
{
    public static class CalculadorBezier
    {
        private static double[] Coeficientes(int n)
        {
            var c=new double[n+1]; c[0]=1;
            for(int i=1;i<=n;i++) c[i]=c[i-1]*(n-i+1)/i;
            return c;
        }
        public static PuntoControl Bernstein(IList<PuntoControl> p, double t)
        { return Bernstein(p,t,Coeficientes(p.Count-1)); }
        private static PuntoControl Bernstein(IList<PuntoControl> p,double t,double[] coef)
        {
            int n=p.Count-1; double x=0,y=0;
            for(int i=0;i<=n;i++)
            {
                double b=coef[i]*Math.Pow(t,i)*Math.Pow(1-t,n-i);
                x+=b*p[i].X; y+=b*p[i].Y;
            }
            return new PuntoControl(x,y);
        }
        public static PuntoControl DeCasteljau(IList<PuntoControl> p,double t)
        {
            var q=p.Select(a=>a.Copia()).ToArray();
            for(int nivel=1;nivel<p.Count;nivel++)
                for(int i=0;i<p.Count-nivel;i++) q[i]=PuntoControl.Interpolar(q[i],q[i+1],t);
            return q[0];
        }
        public static List<PuntoControl> Niveles(IList<PuntoControl> p,double t)
        {
            var nivel=p.Select(a=>a.Copia()).ToList();
            var salida=new List<PuntoControl>();
            while(nivel.Count>1)
            {
                var sig=new List<PuntoControl>();
                for(int i=0;i<nivel.Count-1;i++) sig.Add(PuntoControl.Interpolar(nivel[i],nivel[i+1],t));
                salida.AddRange(sig); nivel=sig;
            }
            salida.Add(nivel[0]); return salida;
        }
        public static List<PuntoControl> Curva(IList<PuntoControl> p,int muestras,bool casteljau)
        {
            var r=new List<PuntoControl>(muestras);
            double[] coef=casteljau?null:Coeficientes(p.Count-1);
            for(int i=0;i<muestras;i++)
            {
                double t=(double)i/(muestras-1);
                r.Add(casteljau?DeCasteljau(p,t):Bernstein(p,t,coef));
            }
            return r;
        }
        public static double Distancia(PuntoControl a,PuntoControl b)
        { double dx=a.X-b.X,dy=a.Y-b.Y; return Math.Sqrt(dx*dx+dy*dy); }
        public static double DiferenciaMax(List<PuntoControl> a,List<PuntoControl> b)
        {
            double d=0; for(int i=0;i<Math.Min(a.Count,b.Count);i++) d=Math.Max(d,Distancia(a[i],b[i])); return d;
        }
        public static double Medir(IList<PuntoControl> p,int muestras,bool casteljau,int repeticiones)
        {
            for(int w=0;w<2;w++) Curva(p,muestras,casteljau);
            var tiempos=new List<double>();
            for(int r=0;r<Math.Max(10,repeticiones);r++)
            {
                var sw=Stopwatch.StartNew(); var curva=Curva(p,muestras,casteljau); sw.Stop();
                tiempos.Add(sw.Elapsed.TotalMilliseconds);
            }
            return tiempos.Average();
        }
    }
}
