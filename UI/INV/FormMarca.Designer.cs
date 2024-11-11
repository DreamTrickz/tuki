namespace Demo.UI.INV
{
    partial class FormMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            groupBox1 = new GroupBox();
            checkBoxEstado = new CheckBox();
            textBoxDescripcion = new TextBox();
            label1 = new Label();
            buttonLimpiar = new Button();
            buttonCancelar = new Button();
            groupBox2 = new GroupBox();
            dataGridViewMarcas = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            groupBox3 = new GroupBox();
            label2 = new Label();
            buttonFiltrar = new Button();
            textBoxFiltro = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarcas).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxEstado);
            groupBox1.Controls.Add(textBoxDescripcion);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(542, 77);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // checkBoxEstado
            // 
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Location = new Point(387, 36);
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.Size = new Size(60, 19);
            checkBoxEstado.TabIndex = 5;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(94, 32);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(287, 23);
            textBoxDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 35);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Descripción:";
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.Location = new Point(350, 458);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(100, 30);
            buttonLimpiar.TabIndex = 1;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = true;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(456, 458);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(100, 30);
            buttonCancelar.TabIndex = 2;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewMarcas);
            groupBox2.Location = new Point(14, 188);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(542, 264);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Listado de marcas";
            // 
            // dataGridViewMarcas
            // 
            dataGridViewMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarcas.Location = new Point(6, 20);
            dataGridViewMarcas.Name = "dataGridViewMarcas";
            dataGridViewMarcas.Size = new Size(530, 236);
            dataGridViewMarcas.TabIndex = 0;
            dataGridViewMarcas.CellClick += dataGridViewMarcas_CellClick;
            dataGridViewMarcas.SelectionChanged += dataGridViewMarcas_SelectionChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(14, 458);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(120, 458);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 15;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(226, 458);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(buttonFiltrar);
            groupBox3.Controls.Add(textBoxFiltro);
            groupBox3.Location = new Point(14, 95);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(542, 87);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 40);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 9;
            label2.Text = "Descripción:";
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(341, 32);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(100, 30);
            buttonFiltrar.TabIndex = 8;
            buttonFiltrar.Text = "Buscar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // textBoxFiltro
            // 
            textBoxFiltro.Location = new Point(94, 35);
            textBoxFiltro.Name = "textBoxFiltro";
            textBoxFiltro.Size = new Size(241, 23);
            textBoxFiltro.TabIndex = 7;
            // 
            // FormMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 500);
            Controls.Add(groupBox3);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox2);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonLimpiar);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "FormMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Creación de marca";
            Load += FormMarca_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarcas).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxDescripcion;
        private Label label1;
        private Button buttonLimpiar;
        private Button buttonCancelar;
        private CheckBox checkBoxEstado;
        private GroupBox groupBox2;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private GroupBox groupBox3;
        private DataGridView dataGridViewMarcas;
        private Label label2;
        private Button buttonFiltrar;
        private TextBox textBoxFiltro;
    }
}