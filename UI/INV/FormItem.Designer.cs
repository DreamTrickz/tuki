namespace Demo.UI.INV
{
    partial class FormItem
    {
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.TextBox textboxCodigo;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxSubcategoria;
        private System.Windows.Forms.ComboBox comboBoxUnidadMedida;
        private System.Windows.Forms.TextBox textboxStockGeneral;
        private System.Windows.Forms.TextBox textboxCosto;
        private System.Windows.Forms.TextBox textboxPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;

        private void InitializeComponent()
        {
            dataGridViewItems = new DataGridView();
            textboxCodigo = new TextBox();
            textBoxDescripcion = new TextBox();
            comboBoxMarca = new ComboBox();
            comboBoxCategoria = new ComboBox();
            comboBoxSubcategoria = new ComboBox();
            comboBoxUnidadMedida = new ComboBox();
            textboxStockGeneral = new TextBox();
            textboxCosto = new TextBox();
            textboxPrecio = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            checkBoxEstado = new CheckBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            buttonLimpiar = new Button();
            buttonCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Location = new Point(11, 22);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.Size = new Size(1160, 315);
            dataGridViewItems.TabIndex = 0;
            dataGridViewItems.CellClick += dataGridViewItems_CellClick;
            dataGridViewItems.SelectionChanged += dataGridViewItems_SelectionChanged;
            // 
            // textboxCodigo
            // 
            textboxCodigo.Location = new Point(81, 29);
            textboxCodigo.Name = "textboxCodigo";
            textboxCodigo.Size = new Size(204, 23);
            textboxCodigo.TabIndex = 1;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(385, 29);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(336, 23);
            textBoxDescripcion.TabIndex = 2;
            // 
            // comboBoxMarca
            // 
            comboBoxMarca.Location = new Point(977, 29);
            comboBoxMarca.Name = "comboBoxMarca";
            comboBoxMarca.Size = new Size(186, 23);
            comboBoxMarca.TabIndex = 4;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Location = new Point(81, 62);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(204, 23);
            comboBoxCategoria.TabIndex = 5;
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            // 
            // comboBoxSubcategoria
            // 
            comboBoxSubcategoria.Location = new Point(385, 62);
            comboBoxSubcategoria.Name = "comboBoxSubcategoria";
            comboBoxSubcategoria.Size = new Size(214, 23);
            comboBoxSubcategoria.TabIndex = 6;
            // 
            // comboBoxUnidadMedida
            // 
            comboBoxUnidadMedida.Location = new Point(840, 29);
            comboBoxUnidadMedida.Name = "comboBoxUnidadMedida";
            comboBoxUnidadMedida.Size = new Size(73, 23);
            comboBoxUnidadMedida.TabIndex = 3;
            // 
            // textboxStockGeneral
            // 
            textboxStockGeneral.BackColor = SystemColors.Window;
            textboxStockGeneral.Location = new Point(662, 62);
            textboxStockGeneral.Name = "textboxStockGeneral";
            textboxStockGeneral.ReadOnly = true;
            textboxStockGeneral.Size = new Size(91, 23);
            textboxStockGeneral.TabIndex = 7;
            // 
            // textboxCosto
            // 
            textboxCosto.Location = new Point(816, 62);
            textboxCosto.Name = "textboxCosto";
            textboxCosto.Size = new Size(97, 23);
            textboxCosto.TabIndex = 8;
            // 
            // textboxPrecio
            // 
            textboxPrecio.Location = new Point(977, 62);
            textboxPrecio.Name = "textboxPrecio";
            textboxPrecio.Size = new Size(100, 23);
            textboxPrecio.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 467);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Enabled = false;
            btnActualizar.Location = new Point(129, 467);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 30);
            btnActualizar.TabIndex = 12;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(235, 467);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewItems);
            groupBox1.Location = new Point(12, 114);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1182, 346);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Listado de ítems";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxEstado);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textboxPrecio);
            groupBox2.Controls.Add(textboxCosto);
            groupBox2.Controls.Add(textboxStockGeneral);
            groupBox2.Controls.Add(comboBoxSubcategoria);
            groupBox2.Controls.Add(comboBoxCategoria);
            groupBox2.Controls.Add(comboBoxMarca);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxDescripcion);
            groupBox2.Controls.Add(comboBoxUnidadMedida);
            groupBox2.Controls.Add(textboxCodigo);
            groupBox2.Location = new Point(12, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1182, 104);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Información";
            // 
            // checkBoxEstado
            // 
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Location = new Point(1103, 64);
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.Size = new Size(60, 19);
            checkBoxEstado.TabIndex = 10;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(929, 66);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 20;
            label10.Text = "Precio:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(769, 65);
            label9.Name = "label9";
            label9.Size = new Size(41, 15);
            label9.TabIndex = 19;
            label9.Text = "Costo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(617, 66);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 18;
            label8.Text = "Stock:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(300, 65);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 17;
            label7.Text = "Subcategoría:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 65);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 16;
            label6.Text = "Categoría:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(929, 32);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 15;
            label5.Text = "Marca:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(727, 32);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 14;
            label4.Text = "Unidad de medida:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 32);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 13;
            label3.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 32);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 12;
            label2.Text = "Código:";
            // 
            // buttonLimpiar
            // 
            buttonLimpiar.Location = new Point(977, 467);
            buttonLimpiar.Name = "buttonLimpiar";
            buttonLimpiar.Size = new Size(100, 30);
            buttonLimpiar.TabIndex = 14;
            buttonLimpiar.Text = "Limpiar";
            buttonLimpiar.Click += buttonLimpiar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(1083, 467);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(100, 30);
            buttonCancelar.TabIndex = 15;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // FormItem
            // 
            ClientSize = new Size(1207, 506);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonLimpiar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            MaximizeBox = false;
            Name = "FormItem";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormItem_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private CheckBox checkBoxEstado;
        private Button buttonLimpiar;
        private Button buttonCancelar;
    }
}