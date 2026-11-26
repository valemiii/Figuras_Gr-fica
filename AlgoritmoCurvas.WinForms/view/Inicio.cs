using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace DeberGrupal
{
    public partial class Inicio : Form
    {
        private readonly List<PuntoControl> puntos = new List<PuntoControl>();
        private int arrastrando = -1;
        private double origenX, origenY, anchoVista, altoVista;
        private string resumen;
        private List<PuntoControl> curvaB=new List<PuntoControl>(), curvaD=new List<PuntoControl>();

        public Inicio()
        {
            InitializeComponent();
            puntos.AddRange(new[]{new PuntoControl(80,430),new PuntoControl(210,100),new PuntoControl(480,120),new PuntoControl(650,430)});
            AjustarVista();
            ActualizarTodo();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarTodo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            puntos.Add(new PuntoControl(350, 250));
            AjustarVista();
            ActualizarTodo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarSeleccionado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarSeleccionado();
        }

        private void btnMedir_Click(object sender, EventArgs e)
        {
            MedirActual();
        }

        private void btnExperimento_Click(object sender, EventArgs e)
        {
            Experimento();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void RefrescarLienzo(object sender, EventArgs e)
        {
            lienzo.Invalidate();
        }

        private void CambiarParametro(object sender, EventArgs e)
        {
            ActualizarEvaluaciones();
            lblT.Text = "t = " + (barraT.Value / 100.0).ToString("0.00");
            lienzo.Invalidate();
        }

        private void MouseArriba(object sender, MouseEventArgs e)
        {
            arrastrando = -1;
            lienzo.Capture = false;
        }

        private void EditarCelda(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ModificarSeleccionado();
        }

        private void ActualizarTodo()
        {
            if(puntos.Count<2)return;
            int m=(int)numMuestras.Value;
            curvaB=CalculadorBezier.Curva(puntos,m,false); curvaD=CalculadorBezier.Curva(puntos,m,true);
            double diff=CalculadorBezier.DiferenciaMax(curvaB,curvaD);
            resumen=String.Format("Grado: {0} | Puntos de control: {1} | Muestras: {2} | Diferencia máxima: {3:E3} | Pulsa 'Medir tiempo' para comparar (sin dibujo).",puntos.Count-1,puntos.Count,m,diff);
            ActualizarEvaluaciones();
            btnEliminar.Enabled = puntos.Count > 2;
            tabla.Rows.Clear();
            for(int i=0;i<puntos.Count;i++) tabla.Rows.Add(i,puntos[i].X.ToString("F1"),puntos[i].Y.ToString("F1"));
            lienzo.Invalidate();
        }
        private void MedirActual()
        {
            int m=Math.Min((int)numMuestras.Value,5000);
            int reps=(int)numReps.Value;
            double tb=CalculadorBezier.Medir(puntos,m,false,reps);
            double td=CalculadorBezier.Medir(puntos,m,true,reps);
            resumen=String.Format("Grado: {0} | Muestras medidas: {1} | Bernstein: {2:F4} ms | De Casteljau: {3:F4} ms | {4} repeticiones, sin dibujo.",puntos.Count-1,m,tb,td,reps);
            ActualizarEvaluaciones();
        }
        private void ActualizarEvaluaciones()
        {
            if (puntos.Count < 2) return;
            double t = barraT.Value / 100.0;
            var b = CalculadorBezier.Bernstein(puntos, t);
            var d = CalculadorBezier.DeCasteljau(puntos, t);
            lblInfo.Text = string.Format("{0}\r\nt = {1:F2}    Bernstein ({2:F2}, {3:F2})    De Casteljau ({4:F2}, {5:F2})",
                resumen, t, b.X, b.Y, d.X, d.Y);
        }

        private void AjustarVista()
        {
            origenX = puntos.Min(p => p.X) - 40;
            origenY = puntos.Min(p => p.Y) - 40;
            anchoVista = puntos.Max(p => p.X) + 40 - origenX;
            altoVista = puntos.Max(p => p.Y) + 40 - origenY;
        }

        private double Escala(RectangleF area)
        {
            return Math.Min(area.Width / anchoVista, area.Height / altoVista);
        }

        private RectangleF Area(){return new RectangleF(45,25,Math.Max(100,lienzo.Width-80),Math.Max(100,lienzo.Height-55));}
        private PointF ACanvas(PuntoControl p)
        {
            var area = Area();
            double escala = Escala(area);
            return new PointF((float)(area.Left + (p.X - origenX) * escala),
                              (float)(area.Bottom - (p.Y - origenY) * escala));
        }

        private PuntoControl DesdeCanvas(PointF pt)
        {
            var area = Area();
            double escala = Escala(area);
            return new PuntoControl(origenX + (pt.X - area.Left) / escala,
                                    origenY + (area.Bottom - pt.Y) / escala);
        }
        private void Dibujar(object sender,PaintEventArgs e)
        {
            if(puntos.Count<2)return;
            var g=e.Graphics; g.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var pol=puntos.Select(ACanvas).ToArray();
            using(var pen=new Pen(Color.LightGray,1.5f)){for(int i=0;i<pol.Length-1;i++)g.DrawLine(pen,pol[i],pol[i+1]);}
            using(var pen=new Pen(Color.RoyalBlue,3)){DibujarCurva(g,pen,curvaB);}
            using (var pen = new Pen(Color.DarkOrange, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                DibujarCurva(g, pen, curvaD);
            }
            for(int i=0;i<pol.Length;i++)
            {
                var r=new RectangleF(pol[i].X-6,pol[i].Y-6,12,12);
                using(var b=new SolidBrush(Color.MidnightBlue))g.FillEllipse(b,r);
                g.DrawString("P"+i,Font,Brushes.Black,pol[i].X+8,pol[i].Y-16);
            }
            if(chkNiveles.Checked)
            {
                double t=barraT.Value/100.0; var niveles=CalculadorBezier.Niveles(puntos,t);
                int offset=0; int n=puntos.Count;
                for(int level=1;level<n;level++)
                {
                    int count=n-level;
                    using(var pen=new Pen(Color.FromArgb(90,Color.MediumVioletRed),1.5f))
                    {
                        var pts=new List<PointF>();for(int j=0;j<count;j++)pts.Add(ACanvas(niveles[offset+j]));
                        for(int j=0;j<pts.Count-1;j++)g.DrawLine(pen,pts[j],pts[j+1]);
                        foreach(var p in pts)g.FillEllipse(Brushes.MediumVioletRed,p.X-3,p.Y-3,6,6);
                    }
                    offset+=count;
                }
                var final=ACanvas(niveles[niveles.Count-1]);g.FillEllipse(Brushes.Black,final.X-5,final.Y-5,10,10);
            }
            g.DrawString("Bernstein (azul)   De Casteljau (naranja)   |   Clic: agregar · Arrastrar: mover · Clic derecho: eliminar",Font,Brushes.DimGray,10,lienzo.Height-22);
        }
        private void DibujarCurva(Graphics g,Pen pen,List<PuntoControl> curva)
        {
            if (curva == null || curva.Count < 2) return;
            g.DrawLines(pen, curva.Select(ACanvas).ToArray());
        }
        private int Cerca(Point p)
        { for(int i=0;i<puntos.Count;i++){var q=ACanvas(puntos[i]);if(Math.Abs(q.X-p.X)<12&&Math.Abs(q.Y-p.Y)<12)return i;}return -1; }
        private void MouseAbajo(object s,MouseEventArgs e)
        {
            int i=Cerca(e.Location);
            if(e.Button==MouseButtons.Right){EliminarPunto(i);return;}
            if(i>=0 && e.Button==MouseButtons.Left){arrastrando=i;lienzo.Capture=true;return;}
            if(e.Button==MouseButtons.Left){puntos.Add(DesdeCanvas(e.Location));ActualizarTodo();}
        }
        private void MouseMover(object s,MouseEventArgs e)
        {if(arrastrando>=0&&e.Button==MouseButtons.Left){if (!lienzo.ClientRectangle.Contains(e.Location)) return; puntos[arrastrando]=DesdeCanvas(e.Location);ActualizarTodo();}}
        private int Seleccionado(){return tabla.CurrentRow==null?-1:tabla.CurrentRow.Index;}
        private void EliminarSeleccionado()
        {
            EliminarPunto(Seleccionado());
        }

        private void EliminarPunto(int indice)
        {
            if (puntos.Count <= 2 || indice < 0 || indice >= puntos.Count) return;
            puntos.RemoveAt(indice);
            ActualizarTodo();
        }
        private void ModificarSeleccionado()
        {
            int i=Seleccionado();if(i<0)return;
            using(var f=new Form{Text="Modificar punto P"+i,Width=260,Height=160,StartPosition=FormStartPosition.CenterParent})
            {
                var x=new NumericUpDown{DecimalPlaces=2,Minimum=-100000,Maximum=100000,Value=(decimal)puntos[i].X,Left=70,Top=15,Width=150};
                var y=new NumericUpDown{DecimalPlaces=2,Minimum=-100000,Maximum=100000,Value=(decimal)puntos[i].Y,Left=70,Top=45,Width=150};
                f.Controls.Add(new Label{Text="X",Left=20,Top=18});f.Controls.Add(x);f.Controls.Add(new Label{Text="Y",Left=20,Top=48});f.Controls.Add(y);
                var ok=new Button{Text="Aceptar",Left=70,Top=80,DialogResult=DialogResult.OK};f.Controls.Add(ok);f.AcceptButton=ok;
                if(f.ShowDialog(this)==DialogResult.OK){puntos[i]=new PuntoControl((double)x.Value,(double)y.Value);AjustarVista();ActualizarTodo();}
            }
        }
        private void Experimento()
        {
            var grados=new[]{3,5,10,20,50,100};
            var filas=new List<string>{"Grado;Muestras;Bernstein_ms;DeCasteljau_ms;Diferencia_max"};
            foreach(int grado in grados)
            {
                int[] muestras = grado<=20 ? new[]{100,1000,10000} : new[]{100,1000};
                foreach(int m in muestras)
                {
                var p=new List<PuntoControl>();for(int i=0;i<=grado;i++)p.Add(new PuntoControl(i*10,100+Math.Sin(i*0.7)*80));
                double b=CalculadorBezier.Medir(p,m,false,10),d=CalculadorBezier.Medir(p,m,true,10);
                var cb=CalculadorBezier.Curva(p,m,false);var cd=CalculadorBezier.Curva(p,m,true);
                filas.Add(grado+";"+m+";"+b.ToString("G8")+";"+d.ToString("G8")+";"+CalculadorBezier.DiferenciaMax(cb,cd).ToString("E8"));
                }
            }
            string path=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),"ExperimentoBezier.csv");
            File.WriteAllLines(path,filas);MessageBox.Show("Experimento terminado (10 repeticiones por caso, sin dibujo).\nCSV: "+path,"Experimentos");
        }
        private void Exportar()
        {
            using(var s=new SaveFileDialog{Filter="CSV|*.csv",FileName="ComparacionBezier.csv"})
            if(s.ShowDialog()==DialogResult.OK)
            {
                var lines=new List<string>{"indice;t;x_bernstein;y_bernstein;x_casteljau;y_casteljau;diferencia"};
                for(int i=0;i<curvaB.Count;i++){double t=(double)i/(curvaB.Count-1);lines.Add(i+";"+t.ToString("G17")+";"+curvaB[i].X.ToString("G17")+";"+curvaB[i].Y.ToString("G17")+";"+curvaD[i].X.ToString("G17")+";"+curvaD[i].Y.ToString("G17")+";"+CalculadorBezier.Distancia(curvaB[i],curvaD[i]).ToString("E10"));}
                File.WriteAllLines(s.FileName,lines);
            }
        }
    }
}
