namespace Demo.UI.INV
{
    partial class FormPlanCuentas
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
            textBoxNombreCuenta = new TextBox();
            label1 = new Label();
            buttonLimpiar = new Button();
            buttonCancelar = new Button();
            groupBox2 = new GroupBox();
            dataGridViewPlanCuentass = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            groupBox3 = new GroupBox();
            label2 = new Label();
            buttonFiltrar = new Button();
            textBoxFiltro = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlanCuentass).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxEstado);
            groupBox1.Controls.Add(textBoxNombreCuenta);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(619, 103);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // checkBoxEstado
            // 
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Location = new Point(438, 48);
            checkBoxEstado.Margin = new Padding(3, 4, 3, 4);
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.Size = new Size(73, 24);
            checkBoxEstado.TabIndex = 5;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // textBoxNombreCuenta
            // 
            textBoxNombreCuenta.Location = new Point(139, 45);
            textBoxNombreCuenta.Margin = new Padding(3, 4, 3, 4);
            textBoxNombreCuenta.Name = "textBoxNombreCuenta";
            textBoxNombreCuenta.Size = new Size(270, 27);
            textBoxNombreCuenta.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 47);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre cuenta:";
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.Location = new Point(400, 611);
            buttonLimpiar.Margin = new Padding(3, 4, 3, 4);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(114, 40);
            buttonLimpiar.TabIndex = 1;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = true;
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(521, 611);
            buttonCancelar.Margin = new Padding(3, 4, 3, 4);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(114, 40);
            buttonCancelar.TabIndex = 2;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewPlanCuentass);
            groupBox2.Location = new Point(16, 251);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(619, 352);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Listado de cuentas";
            // 
            // dataGridViewPlanCuentass
            // 
            dataGridViewPlanCuentass.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlanCuentass.Location = new Point(7, 27);
            dataGridViewPlanCuentass.Margin = new Padding(3, 4, 3, 4);
            dataGridViewPlanCuentass.Name = "dataGridViewPlanCuentass";
            dataGridViewPlanCuentass.RowHeadersWidth = 51;
            dataGridViewPlanCuentass.Size = new Size(606, 315);
            dataGridViewPlanCuentass.TabIndex = 0;
            dataGridViewPlanCuentass.CellClick += dataGridViewPlanCuentass_CellClick;
            dataGridViewPlanCuentass.SelectionChanged += dataGridViewPlanCuentass_SelectionChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(16, 611);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(114, 40);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(137, 611);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(114, 40);
            btnActualizar.TabIndex = 15;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(258, 611);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(114, 40);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(buttonFiltrar);
            groupBox3.Controls.Add(textBoxFiltro);
            groupBox3.Location = new Point(16, 127);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(619, 116);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 53);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 9;
            label2.Text = "Nombre cuenta:";
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(438, 43);
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
            textBoxFiltro.Location = new Point(139, 46);
            textBoxFiltro.Margin = new Padding(3, 4, 3, 4);
            textBoxFiltro.Name = "textBoxFiltro";
            textBoxFiltro.Size = new Size(275, 27);
            textBoxFiltro.TabIndex = 7;
            // 
            // FormPlanCuentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 667);
            Controls.Add(groupBox3);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox2);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonLimpiar);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormPlanCuentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plan de cuentas";
            Load += FormPlanCuentas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlanCuentass).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxNombreCuenta;
        private TextBox textBoxTipoCuenta;
        private Label label1;
        private Button buttonLimpiar;
        private Button buttonCancelar;
        private CheckBox checkBoxEstado;
        private GroupBox groupBox2;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private GroupBox groupBox3;
        private DataGridView dataGridViewPlanCuentass;  
        private Label label2;
        private Button buttonFiltrar;
        private TextBox textBoxFiltro;
    }
}