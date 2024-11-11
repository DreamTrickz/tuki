using System;

namespace Demo.UI.INV
{
    partial class FormSubcategoria
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.CheckBox checkBoxEstado;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelDescripcion = new Label();
            textBoxDescripcion = new TextBox();
            comboBoxCategoria = new ComboBox();
            labelCategoria = new Label();
            checkBoxEstado = new CheckBox();
            buttonGuardar = new Button();
            buttonCancelar = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(13, 38);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(69, 15);
            labelDescripcion.TabIndex = 0;
            labelDescripcion.Text = "Descripción";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(110, 35);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(250, 23);
            textBoxDescripcion.TabIndex = 1;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Location = new Point(110, 64);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(250, 23);
            comboBoxCategoria.TabIndex = 2;
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(13, 67);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(58, 15);
            labelCategoria.TabIndex = 3;
            labelCategoria.Text = "Categoría";
            // 
            // checkBoxEstado
            // 
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Location = new Point(110, 93);
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.Size = new Size(60, 19);
            checkBoxEstado.TabIndex = 4;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(163, 137);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(100, 30);
            buttonGuardar.TabIndex = 5;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(269, 137);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(100, 30);
            buttonCancelar.TabIndex = 6;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxDescripcion);
            groupBox1.Controls.Add(labelDescripcion);
            groupBox1.Controls.Add(comboBoxCategoria);
            groupBox1.Controls.Add(checkBoxEstado);
            groupBox1.Controls.Add(labelCategoria);
            groupBox1.Location = new Point(9, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(378, 122);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // FormSubcategoria
            // 
            ClientSize = new Size(397, 173);
            Controls.Add(groupBox1);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonGuardar);
            MaximizeBox = false;
            Name = "FormSubcategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Creación de subcategoría";
            Load += FormSubcategoria_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /*private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FormSubcategoria";
        }*/

        #endregion

        private GroupBox groupBox1;
    }
}