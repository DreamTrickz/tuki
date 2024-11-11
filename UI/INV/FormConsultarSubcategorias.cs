using Demo.BL.INV;
using Demo.DAL.INV;
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
    public partial class FormConsultarSubcategorias : Form
    {
        private SubcategoriaBL _subcategoriaBl;
        public FormConsultarSubcategorias()
        {
            InitializeComponent();
            _subcategoriaBl = new SubcategoriaBL();
            CargarSubcategorias();
        }

        private void CargarSubcategorias()
        {
            var subcategorias = _subcategoriaBl.ObtenerSubcategoriasConCategoria();

            // Asigna la lista al DataGridView
            dataGridViewSubcategorias.DataSource = subcategorias
                .Select(s => new
                {
                    s.Id,
                    s.Descripcion,
                    Categoria = s.Categoria?.Descripcion ?? "Sin categoría", // Nombre de la categoría
                    Estado = s.Estado ? "Activo" : "Inactivo"  // Cambiar visualización del estado
                })
                .ToList();

            FormateaDataGridView();
        }

        private void FormateaDataGridView()
        {
            // Configurar el DataGridView para seleccionar la fila completa al hacer clic en una celda
            dataGridViewSubcategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewSubcategorias.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewSubcategorias.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewSubcategorias.Columns["Id"].HeaderText = "ID";               // Cambiar encabezado de la columna
            dataGridViewSubcategorias.Columns["Descripcion"].HeaderText = "Subcategoría"; // Cambiar encabezado de la columna
            dataGridViewSubcategorias.Columns["Categoria"].HeaderText = "Categoría";  // Cambiar encabezado de la columna
            dataGridViewSubcategorias.Columns["Estado"].HeaderText = "Estado";        // Cambiar encabezado de la columna

            // Ajustar el ancho de las columnas
            dataGridViewSubcategorias.Columns["Id"].Width = 50;
            dataGridViewSubcategorias.Columns["Descripcion"].Width = 200;
            dataGridViewSubcategorias.Columns["Categoria"].Width = 150;
            dataGridViewSubcategorias.Columns["Estado"].Width = 100;

            // Opcional: Ocultar columnas si no deseas mostrar ciertos datos
            // dataGridViewSubcategorias.Columns["Id"].Visible = false; // Si no quieres mostrar el ID

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewSubcategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewSubcategorias.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewSubcategorias.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewSubcategorias.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewSubcategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDataGridConFiltro(string filtro)
        {
            var subcategoriasFiltradas = _subcategoriaBl.ObtenerSubcategoriasConFiltro(filtro);

            dataGridViewSubcategorias.DataSource = subcategoriasFiltradas
                .Select(s => new
                {
                    s.Id,
                    s.Descripcion,
                    Categoria = s.Categoria?.Descripcion ?? "Sin categoría", // Nombre de la categoría
                    Estado = s.Estado ? "Activo" : "Inactivo"  // Cambiar visualización del estado
                })
                .ToList();

            FormateaDataGridView();
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = textBoxFiltro.Text;
            CargarDataGridConFiltro(filtro); // O FiltrarDataGridView(filtro) si es filtrado en memoria
        }

        private void dataGridViewSubcategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
