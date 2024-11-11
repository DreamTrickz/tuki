namespace Demo.UI.INV
{
    partial class FormPlanCuentas
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos que se están utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados deben ser eliminados; de lo contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

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
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();

            // groupBox1
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(checkBoxEstado);
            groupBox1.Controls.Add(textBoxNombreCuenta);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(16, 13);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(619, 128);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";

            // checkBoxEstado
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Location = new System.Drawing.Point(441, 56);
            checkBoxEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.Size = new System.Drawing.Size(73, 24);
            checkBoxEstado.TabIndex = 5;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;

            // textBoxNombreCuenta
            textBoxNombreCuenta.Location = new System.Drawing.Point(139, 21);
            textBoxNombreCuenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxNombreCuenta.Name = "textBoxNombreCuenta";
            textBoxNombreCuenta.Size = new System.Drawing.Size(249, 27);
            textBoxNombreCuenta.TabIndex = 1;

            // label1
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre cuenta:";

            // buttonLimpiar
            buttonLimpiar.Location = new System.Drawing.Point(400, 611);
            buttonLimpiar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new System.Drawing.Size(114, 40);
            buttonLimpiar.TabIndex = 1;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.UseVisualStyleBackColor = true;
            buttonLimpiar.Click += buttonLimpiar_Click;

            // buttonCancelar
            buttonCancelar.Location = new System.Drawing.Point(521, 611);
            buttonCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new System.Drawing.Size(114, 40);
            buttonCancelar.TabIndex = 2;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;

            // groupBox2
            groupBox2.Controls.Add(dataGridViewPlanCuentass);
            groupBox2.Location = new System.Drawing.Point(16, 251);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Size = new System.Drawing.Size(619, 352);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Listado de cuentas";

            // dataGridViewPlanCuentass
            dataGridViewPlanCuentass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlanCuentass.Location = new System.Drawing.Point(7, 27);
            dataGridViewPlanCuentass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dataGridViewPlanCuentass.Name = "dataGridViewPlanCuentass";
            dataGridViewPlanCuentass.RowHeadersWidth = 51;
            dataGridViewPlanCuentass.Size = new System.Drawing.Size(606, 315);
            dataGridViewPlanCuentass.TabIndex = 0;
            dataGridViewPlanCuentass.CellClick += dataGridViewPlanCuentass_CellClick;

            // btnAgregar
            btnAgregar.Location = new System.Drawing.Point(16, 611);
            btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(114, 40);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;

            // btnActualizar
            btnActualizar.Enabled = false;
            btnActualizar.Location = new System.Drawing.Point(137, 611);
            btnActualizar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new System.Drawing.Size(114, 40);
            btnActualizar.TabIndex = 15;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;

            // btnEliminar
            btnEliminar.Enabled = false;
            btnEliminar.Location = new System.Drawing.Point(258, 611);
            btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(114, 40);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;

            // groupBox3
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(buttonFiltrar);
            groupBox3.Controls.Add(textBoxFiltro);
            groupBox3.Location = new System.Drawing.Point(16, 149);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Size = new System.Drawing.Size(619, 94);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtros";

            // label2
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 46);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(115, 20);
            label2.TabIndex = 9;
            label2.Text = "Nombre cuenta:";

            // buttonFiltrar
            buttonFiltrar.Location = new System.Drawing.Point(441, 36);
            buttonFiltrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new System.Drawing.Size(114, 40);
            buttonFiltrar.TabIndex = 8;
            buttonFiltrar.Text = "Buscar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;

            // textBoxFiltro
            textBoxFiltro.Location = new System.Drawing.Point(139, 43);
            textBoxFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBoxFiltro.Name = "textBoxFiltro";
            textBoxFiltro.Size = new System.Drawing.Size(275, 27);
            textBoxFiltro.TabIndex = 7;

            // textBox1
            textBox1.Location = new System.Drawing.Point(139, 56);
            textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(166, 27);
            textBox1.TabIndex = 7;

            // label3
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(18, 59);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 20);
            label3.TabIndex = 6;
            label3.Text = "Codigo cuenta:";

            // textBox2
            textBox2.Location = new System.Drawing.Point(139, 88);
            textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(249, 27);
            textBox2.TabIndex = 9;

            // label4
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(18, 91);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(90, 20);
            label4.TabIndex = 8;
            label4.Text = "Tipo cuenta:";

            // FormPlanCuentas
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(654, 667);
            Controls.Add(groupBox3);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox2);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonLimpiar);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormPlanCuentas";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
    }
}
