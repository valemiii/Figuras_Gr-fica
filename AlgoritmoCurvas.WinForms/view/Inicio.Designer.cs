namespace DeberGrupal
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private System.Windows.Forms.FlowLayoutPanel barra;
        private System.Windows.Forms.Label lblMuestras;
        private System.Windows.Forms.NumericUpDown numMuestras;
        private System.Windows.Forms.Label lblRepeticiones;
        private System.Windows.Forms.NumericUpDown numReps;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnMedir;
        private System.Windows.Forms.Button btnExperimento;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.CheckBox chkNiveles;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.TrackBar barraT;
        private System.Windows.Forms.Panel lienzo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn i;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;

        private void InitializeComponent()
        {
            this.barra = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMuestras = new System.Windows.Forms.Label();
            this.numMuestras = new System.Windows.Forms.NumericUpDown();
            this.lblRepeticiones = new System.Windows.Forms.Label();
            this.numReps = new System.Windows.Forms.NumericUpDown();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnMedir = new System.Windows.Forms.Button();
            this.btnExperimento = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.chkNiveles = new System.Windows.Forms.CheckBox();
            this.lblT = new System.Windows.Forms.Label();
            this.barraT = new System.Windows.Forms.TrackBar();
            this.lienzo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.i = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMuestras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barraT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // barra
            // 
            this.barra.Controls.Add(this.lblMuestras);
            this.barra.Controls.Add(this.numMuestras);
            this.barra.Controls.Add(this.lblRepeticiones);
            this.barra.Controls.Add(this.numReps);
            this.barra.Controls.Add(this.btnActualizar);
            this.barra.Controls.Add(this.btnAgregar);
            this.barra.Controls.Add(this.btnEliminar);
            this.barra.Controls.Add(this.btnModificar);
            this.barra.Controls.Add(this.btnMedir);
            this.barra.Controls.Add(this.btnExperimento);
            this.barra.Controls.Add(this.btnExportar);
            this.barra.Controls.Add(this.chkNiveles);
            this.barra.Controls.Add(this.lblT);
            this.barra.Controls.Add(this.barraT);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Name = "barra";
            this.barra.Padding = new System.Windows.Forms.Padding(8);
            this.barra.Size = new System.Drawing.Size(1134, 100);
            this.barra.TabIndex = 1;
            // 
            // lblMuestras
            // 
            this.lblMuestras.AutoSize = true;
            this.lblMuestras.Location = new System.Drawing.Point(12, 20);
            this.lblMuestras.Margin = new System.Windows.Forms.Padding(4, 12, 0, 0);
            this.lblMuestras.Name = "lblMuestras";
            this.lblMuestras.Size = new System.Drawing.Size(53, 13);
            this.lblMuestras.TabIndex = 0;
            this.lblMuestras.Text = "Muestras:";
            // 
            // numMuestras
            // 
            this.numMuestras.Location = new System.Drawing.Point(68, 11);
            this.numMuestras.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMuestras.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMuestras.Name = "numMuestras";
            this.numMuestras.Size = new System.Drawing.Size(100, 20);
            this.numMuestras.TabIndex = 1;
            this.numMuestras.ThousandsSeparator = true;
            this.numMuestras.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblRepeticiones
            // 
            this.lblRepeticiones.AutoSize = true;
            this.lblRepeticiones.Location = new System.Drawing.Point(179, 20);
            this.lblRepeticiones.Margin = new System.Windows.Forms.Padding(8, 12, 0, 0);
            this.lblRepeticiones.Name = "lblRepeticiones";
            this.lblRepeticiones.Size = new System.Drawing.Size(72, 13);
            this.lblRepeticiones.TabIndex = 2;
            this.lblRepeticiones.Text = "Repeticiones:";
            // 
            // numReps
            // 
            this.numReps.Location = new System.Drawing.Point(254, 11);
            this.numReps.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numReps.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numReps.Name = "numReps";
            this.numReps.Size = new System.Drawing.Size(70, 20);
            this.numReps.TabIndex = 3;
            this.numReps.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnActualizar
            // 
            this.btnActualizar.AutoSize = true;
            this.btnActualizar.Location = new System.Drawing.Point(330, 11);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(98, 23);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar curvas";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.Location = new System.Drawing.Point(434, 11);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar punto";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.Location = new System.Drawing.Point(524, 11);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar seleccionado";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = true;
            this.btnModificar.Location = new System.Drawing.Point(649, 11);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(126, 23);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar seleccionado";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnMedir
            // 
            this.btnMedir.AutoSize = true;
            this.btnMedir.Location = new System.Drawing.Point(781, 11);
            this.btnMedir.Name = "btnMedir";
            this.btnMedir.Size = new System.Drawing.Size(77, 23);
            this.btnMedir.TabIndex = 8;
            this.btnMedir.Text = "Medir tiempo";
            this.btnMedir.Click += new System.EventHandler(this.btnMedir_Click);
            // 
            // btnExperimento
            // 
            this.btnExperimento.AutoSize = true;
            this.btnExperimento.Location = new System.Drawing.Point(864, 11);
            this.btnExperimento.Name = "btnExperimento";
            this.btnExperimento.Size = new System.Drawing.Size(123, 23);
            this.btnExperimento.TabIndex = 9;
            this.btnExperimento.Text = "Prueba de rendimiento";
            this.btnExperimento.Click += new System.EventHandler(this.btnExperimento_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AutoSize = true;
            this.btnExportar.Location = new System.Drawing.Point(993, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(80, 23);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar CSV";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // chkNiveles
            // 
            this.chkNiveles.AutoSize = true;
            this.chkNiveles.Checked = true;
            this.chkNiveles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNiveles.Location = new System.Drawing.Point(16, 47);
            this.chkNiveles.Margin = new System.Windows.Forms.Padding(8, 10, 0, 0);
            this.chkNiveles.Name = "chkNiveles";
            this.chkNiveles.Size = new System.Drawing.Size(175, 17);
            this.chkNiveles.TabIndex = 11;
            this.chkNiveles.Text = "Mostrar niveles de De Casteljau";
            this.chkNiveles.CheckedChanged += new System.EventHandler(this.RefrescarLienzo);
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(199, 49);
            this.lblT.Margin = new System.Windows.Forms.Padding(8, 12, 0, 0);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(43, 13);
            this.lblT.TabIndex = 12;
            this.lblT.Text = "t = 0.50";
            // 
            // barraT
            // 
            this.barraT.Location = new System.Drawing.Point(245, 40);
            this.barraT.Maximum = 100;
            this.barraT.Name = "barraT";
            this.barraT.Size = new System.Drawing.Size(130, 45);
            this.barraT.TabIndex = 13;
            this.barraT.TickFrequency = 10;
            this.barraT.Value = 50;
            this.barraT.ValueChanged += new System.EventHandler(this.CambiarParametro);
            // 
            // lienzo
            // 
            this.lienzo.BackColor = System.Drawing.Color.White;
            this.lienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lienzo.Location = new System.Drawing.Point(0, 100);
            this.lienzo.Margin = new System.Windows.Forms.Padding(8);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(1134, 433);
            this.lienzo.TabIndex = 0;
            this.lienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.Dibujar);
            this.lienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseAbajo);
            this.lienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMover);
            this.lienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseArriba);
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Location = new System.Drawing.Point(0, 533);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(10);
            this.lblInfo.Size = new System.Drawing.Size(1134, 58);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.i,
            this.x,
            this.y});
            this.tabla.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabla.Location = new System.Drawing.Point(0, 591);
            this.tabla.Name = "tabla";
            this.tabla.ReadOnly = true;
            this.tabla.Size = new System.Drawing.Size(1134, 130);
            this.tabla.TabIndex = 3;
            this.tabla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditarCelda);
            this.tabla.SelectionChanged += new System.EventHandler(this.RefrescarLienzo);
            // 
            // i
            // 
            this.i.HeaderText = "Punto";
            this.i.Name = "i";
            this.i.ReadOnly = true;
            this.i.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // x
            // 
            this.x.HeaderText = "X";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // y
            // 
            this.y.HeaderText = "Y";
            this.y.Name = "y";
            this.y.ReadOnly = true;
            this.y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 721);
            this.Controls.Add(this.lienzo);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.tabla);
            this.MinimumSize = new System.Drawing.Size(950, 650);
            this.Name = "Inicio";
            this.Text = "Bézier vs De Casteljau";
            this.barra.ResumeLayout(false);
            this.barra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMuestras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barraT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
