using Demo.BL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.UI.INV
{
    public partial class FormSubcategoria: Form
    {
        private readonly SubcategoriaBL _subcategoriaBL;
        private readonly CategoriaBL _categoriaBL;

        public FormSubcategoria()
        {
            InitializeComponent();
            _categoriaBL = new CategoriaBL();
            _subcategoriaBL = new SubcategoriaBL();
        }

        private void FormSubcategoria_Load(object sender, EventArgs e)
        {
            // Carga las categorías en el ComboBox (necesitas implementar ObtenerCategorias en BL)
            var categorias = _categoriaBL.ObtenerCategorias();
            comboBoxCategoria.DataSource = categorias;
            comboBoxCategoria.DisplayMember = "Descripcion";  // El campo que deseas mostrar
            comboBoxCategoria.ValueMember = "Id";  // El valor que representa cada categoría
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {                
                var Descripcion = textBoxDescripcion.Text;
                var CategoriaId = 0;

                if (comboBoxCategoria.SelectedValue != null)
                {             
                    CategoriaId = (int)comboBoxCategoria.SelectedValue;                    
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una categoría.");
                }
                
                var Estado = checkBoxEstado.Checked;                

                // Guardar la subcategoría a través de la capa BL
                _subcategoriaBL.GuardarSubcategoria(Descripcion, CategoriaId, Estado);                
                MessageBox.Show("Subcategoría guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los controles
                textBoxDescripcion.Clear();
                comboBoxCategoria.SelectedIndex = -1;
                checkBoxEstado.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
