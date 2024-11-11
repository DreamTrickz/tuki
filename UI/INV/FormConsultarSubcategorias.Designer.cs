namespace Demo.UI.INV
{
    partial class FormConsultarSubcategorias
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
            dataGridViewSubcategorias = new DataGridView();
            buttonCancelar = new Button();
            groupBox2 = new GroupBox();
            label1 = new Label();
            buttonFiltrar = new Button();
            textBoxFiltro = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubcategorias).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewSubcategorias);
            groupBox1.Location = new Point(16, 124);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(592, 393);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // dataGridViewSubcategorias
            // 
            dataGridViewSubcategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubcategorias.Location = new Point(18, 41);
            dataGridViewSubcategorias.Margin = new Padding(3, 4, 3, 4);
            dataGridViewSubcategorias.Name = "dataGridViewSubcategorias";
            dataGridViewSubcategorias.RowHeadersWidth = 51;
            dataGridViewSubcategorias.Size = new Size(552, 324);
            dataGridViewSubcategorias.TabIndex = 0;
            dataGridViewSubcategorias.CellContentClick += dataGridViewSubcategorias_CellContentClick;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(470, 525);
            buttonCancelar.Margin = new Padding(3, 4, 3, 4);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(114, 40);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(buttonFiltrar);
            groupBox2.Controls.Add(textBoxFiltro);
            groupBox2.Location = new Point(13, 11);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(595, 105);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 47);
            label1.Name = "label1";
            label1.Size = new Size(161, 20);
            label1.TabIndex = 6;
            label1.Text = "Descripción/Categoría:";
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(457, 39);
            buttonFiltrar.Margin = new Padding(3, 4, 3, 4);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(114, 40);
            buttonFiltrar.TabIndex = 5;
            buttonFiltrar.Text = "Buscar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // textBoxFiltro
            // 
            textBoxFiltro.Location = new Point(175, 43);
            textBoxFiltro.Margin = new Padding(3, 4, 3, 4);
            textBoxFiltro.Name = "textBoxFiltro";
            textBoxFiltro.Size = new Size(275, 27);
            textBoxFiltro.TabIndex = 0;
            // 
            // FormConsultarSubcategorias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 577);
            Controls.Add(groupBox2);
            Controls.Add(buttonCancelar);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormConsultarSubcategorias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar subcategorias";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubcategorias).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridViewSubcategorias;
        private Button buttonCancelar;
        private GroupBox groupBox2;
        private Button buttonFiltrar;
        private TextBox textBoxFiltro;
        private Label label1;
    }
}