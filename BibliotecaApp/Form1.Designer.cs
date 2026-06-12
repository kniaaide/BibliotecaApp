namespace BibliotecaApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblAutor = new Label();
            txtAutor = new TextBox();
            lblAnio = new Label();
            numAnio = new NumericUpDown();
            chkDisponible = new CheckBox();

            btnAgregar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();

            lstLibros = new ListBox();

            grpTexto = new GroupBox();
            btnGuardarTexto = new Button();
            btnCargarTexto = new Button();

            grpBinario = new GroupBox();
            btnGuardarBinario = new Button();
            btnCargarBinario = new Button();

            lblEstado = new Label();
            txtLog = new TextBox();

            ((System.ComponentModel.ISupportInitialize)(numAnio)).BeginInit();
            grpTexto.SuspendLayout();
            grpBinario.SuspendLayout();
            SuspendLayout();

            // ---------------- lblTitulo ----------------
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(40, 15);
            lblTitulo.Text = "Título:";

            // ---------------- txtTitulo ----------------
            txtTitulo.Location = new Point(90, 17);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(250, 23);

            // ---------------- lblAutor ----------------
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(20, 55);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(38, 15);
            lblAutor.Text = "Autor:";

            // ---------------- txtAutor ----------------
            txtAutor.Location = new Point(90, 52);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(250, 23);

            // ---------------- lblAnio ----------------
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(20, 90);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(34, 15);
            lblAnio.Text = "Año:";

            // ---------------- numAnio ----------------
            numAnio.Location = new Point(90, 88);
            numAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(100, 23);
            numAnio.Value = new decimal(new int[] { 2024, 0, 0, 0 });

            // ---------------- chkDisponible ----------------
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Location = new Point(220, 89);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(86, 19);
            chkDisponible.Text = "Disponible";

            // ---------------- btnAgregar ----------------
            btnAgregar.Location = new Point(360, 17);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 30);
            btnAgregar.Text = "Agregar libro";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;

            // ---------------- btnEliminar ----------------
            btnEliminar.Location = new Point(360, 52);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 30);
            btnEliminar.Text = "Eliminar selección";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;

            // ---------------- btnLimpiar ----------------
            btnLimpiar.Location = new Point(360, 87);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 30);
            btnLimpiar.Text = "Limpiar lista";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;

            // ---------------- lstLibros ----------------
            lstLibros.FormattingEnabled = true;
            lstLibros.ItemHeight = 15;
            lstLibros.Location = new Point(20, 130);
            lstLibros.Name = "lstLibros";
            lstLibros.Size = new Size(450, 169);

            // ---------------- grpTexto ----------------
            grpTexto.Controls.Add(btnGuardarTexto);
            grpTexto.Controls.Add(btnCargarTexto);
            grpTexto.Location = new Point(490, 20);
            grpTexto.Name = "grpTexto";
            grpTexto.Size = new Size(200, 110);
            grpTexto.Text = "Archivo de TEXTO (libros.txt)";

            // ---------------- btnGuardarTexto ----------------
            btnGuardarTexto.Location = new Point(20, 30);
            btnGuardarTexto.Name = "btnGuardarTexto";
            btnGuardarTexto.Size = new Size(160, 30);
            btnGuardarTexto.Text = "Guardar en texto";
            btnGuardarTexto.UseVisualStyleBackColor = true;
            btnGuardarTexto.Click += btnGuardarTexto_Click;

            // ---------------- btnCargarTexto ----------------
            btnCargarTexto.Location = new Point(20, 65);
            btnCargarTexto.Name = "btnCargarTexto";
            btnCargarTexto.Size = new Size(160, 30);
            btnCargarTexto.Text = "Cargar desde texto";
            btnCargarTexto.UseVisualStyleBackColor = true;
            btnCargarTexto.Click += btnCargarTexto_Click;

            // ---------------- grpBinario ----------------
            grpBinario.Controls.Add(btnGuardarBinario);
            grpBinario.Controls.Add(btnCargarBinario);
            grpBinario.Location = new Point(490, 140);
            grpBinario.Name = "grpBinario";
            grpBinario.Size = new Size(200, 110);
            grpBinario.Text = "Archivo BINARIO (libros.dat)";

            // ---------------- btnGuardarBinario ----------------
            btnGuardarBinario.Location = new Point(20, 30);
            btnGuardarBinario.Name = "btnGuardarBinario";
            btnGuardarBinario.Size = new Size(160, 30);
            btnGuardarBinario.Text = "Guardar en binario";
            btnGuardarBinario.UseVisualStyleBackColor = true;
            btnGuardarBinario.Click += btnGuardarBinario_Click;

            // ---------------- btnCargarBinario ----------------
            btnCargarBinario.Location = new Point(20, 65);
            btnCargarBinario.Name = "btnCargarBinario";
            btnCargarBinario.Size = new Size(160, 30);
            btnCargarBinario.Text = "Cargar desde binario";
            btnCargarBinario.UseVisualStyleBackColor = true;
            btnCargarBinario.Click += btnCargarBinario_Click;

            // ---------------- lblEstado ----------------
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(20, 310);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(100, 15);
            lblEstado.Text = "Registro de eventos:";

            // ---------------- txtLog ----------------
            txtLog.Location = new Point(20, 330);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(670, 130);
            txtLog.TabIndex = 20;

            // ---------------- Form1 ----------------
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 481);
            Controls.Add(lblTitulo);
            Controls.Add(txtTitulo);
            Controls.Add(lblAutor);
            Controls.Add(txtAutor);
            Controls.Add(lblAnio);
            Controls.Add(numAnio);
            Controls.Add(chkDisponible);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lstLibros);
            Controls.Add(grpTexto);
            Controls.Add(grpBinario);
            Controls.Add(lblEstado);
            Controls.Add(txtLog);
            Name = "Form1";
            Text = "Biblioteca - Archivos de Texto y Binarios (C# .NET 8)";

            ((System.ComponentModel.ISupportInitialize)(numAnio)).EndInit();
            grpTexto.ResumeLayout(false);
            grpBinario.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblAutor;
        private TextBox txtAutor;
        private Label lblAnio;
        private NumericUpDown numAnio;
        private CheckBox chkDisponible;

        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnLimpiar;

        private ListBox lstLibros;

        private GroupBox grpTexto;
        private Button btnGuardarTexto;
        private Button btnCargarTexto;

        private GroupBox grpBinario;
        private Button btnGuardarBinario;
        private Button btnCargarBinario;

        private Label lblEstado;
        private TextBox txtLog;
    }
}