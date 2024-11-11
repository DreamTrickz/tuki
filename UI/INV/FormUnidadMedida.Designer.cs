namespace Demo.UI.INV
{
    partial class FormUnidadMedida
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
            textBoxSiglas = new TextBox();
            label2 = new Label();
            checkBoxEstado = new CheckBox();
            textBoxDescripcion = new TextBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            label3 = new Label();
            buttonFiltrar = new Button();
            textBoxFiltro = new TextBox();
            dataGridViewUnidadMedidas = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            buttonLimpiar = new Button();
            buttonCancelar = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUnidadMedidas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxSiglas);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkBoxEstado);
            groupBox1.Controls.Add(textBoxDescripcion);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(626, 157);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBoxSiglas
            // 
            textBoxSiglas.Location = new Point(118, 85);
            textBoxSiglas.Margin = new Padding(3, 4, 3, 4);
            textBoxSiglas.Name = "textBoxSiglas";
            textBoxSiglas.Size = new Size(132, 27);
            textBoxSiglas.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 88);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 6;
            label2.Text = "Siglas:";
            // 
            // checkBoxEstado
            // 
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Location = new Point(370, 40);
            checkBoxEstado.Margin = new Padding(3, 4, 3, 4);
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.Size = new Size(73, 24);
            checkBoxEstado.TabIndex = 3;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(118, 38);
            textBoxDescripcion.Margin = new Padding(3, 4, 3, 4);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(233, 27);
            textBoxDescripcion.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 42);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 0;
            label1.Text = "Descripción:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(buttonFiltrar);
            groupBox3.Controls.Add(textBoxFiltro);
            groupBox3.Location = new Point(14, 173);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(626, 116);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtros";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 53);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 9;
            label3.Text = "Descripción:";
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(390, 43);
            buttonFiltrar.Margin = new Padding(3, 4, 3, 4);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(114, 40);
            buttonFiltrar.TabIndex = 8;
            buttonFiltrar.Text = "Buscar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // textBoxFiltro
            // 
            textBoxFiltro.Location = new Point(107, 47);
            textBoxFiltro.Margin = new Padding(3, 4, 3, 4);
            textBoxFiltro.Name = "textBoxFiltro";
            textBoxFiltro.Size = new Size(275, 27);
            textBoxFiltro.TabIndex = 7;
            // 
            // dataGridViewUnidadMedidas
            // 
            dataGridViewUnidadMedidas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUnidadMedidas.Location = new Point(14, 299);
            dataGridViewUnidadMedidas.Margin = new Padding(3, 4, 3, 4);
            dataGridViewUnidadMedidas.Name = "dataGridViewUnidadMedidas";
            dataGridViewUnidadMedidas.RowHeadersWidth = 51;
            dataGridViewUnidadMedidas.Size = new Size(626, 315);
            dataGridViewUnidadMedidas.TabIndex = 25;
            dataGridViewUnidadMedidas.CellClick += dataGridViewUnidadMedida_CellClick;
            dataGridViewUnidadMedidas.CellContentClick += dataGridViewUnidadMedida_CellContentClick;
            dataGridViewUnidadMedidas.SelectionChanged += dataGridViewUnidadMedida_SelectionChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(19, 621);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(114, 40);
            btnAgregar.TabIndex = 28;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(141, 621);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(114, 40);
            btnActualizar.TabIndex = 29;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(262, 621);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(114, 40);
            btnEliminar.TabIndex = 30;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.Location = new Point(403, 621);
            buttonLimpiar.Margin = new Padding(3, 4, 3, 4);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(114, 40);
            buttonLimpiar.TabIndex = 26;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = true;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(525, 621);
            buttonCancelar.Margin = new Padding(3, 4, 3, 4);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(115, 40);
            buttonCancelar.TabIndex = 5;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // FormUnidadMedida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 667);
            Controls.Add(groupBox3);
            Controls.Add(buttonCancelar);
            Controls.Add(dataGridViewUnidadMedidas);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(buttonLimpiar);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormUnidadMedida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Creación de unidades de medida";
            Load += FormUnidadMedida_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUnidadMedidas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxSiglas;
        private Label label2;
        private CheckBox checkBoxEstado;
        private TextBox textBoxDescripcion;
        private Label label1;
        private Button buttonGuardar;
        private GroupBox groupBox3;
        private Label label3;
        private Button buttonFiltrar;
        private TextBox textBoxFiltro;
        private DataGridView dataGridViewUnidadMedidas;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button buttonLimpiar;
        private Button buttonCancelar;
    }
}