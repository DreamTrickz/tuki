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
    public partial class FormCategoria : Form
    {
        private readonly CategoriaBL _categoriaBl;
        private int Id;
        private DateTime FechaCreacion;
        private string UsuarioCrea = string.Empty;
        public FormCategoria()
        {
            InitializeComponent();
            _categoriaBl = new CategoriaBL();
        }

        private void CargarCategorias()
        {
            var Categorias = _categoriaBl.ObtenerCategorias();
            dataGridViewCategorias.DataSource = Categorias.Select(i => new
            {
                i.Id,
                i.Descripcion,
                i.FechaCreacion,
                i.UsuarioCrea,
                i.FechaModificacion,
                i.UsuarioModifica,
                Estado = i.Estado ? "Activo" : "Inactivo"  // Cambiar visualización del estado
            }).ToList();
            FormateaDataGridView();
        }

        private void FormateaDataGridView()
        {
            // Configurar el DataGridView para seleccionar la fila completa al hacer clic en una celda
            dataGridViewCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewCategorias.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewCategorias.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewCategorias.Columns["Id"].HeaderText = "Id";
            dataGridViewCategorias.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridViewCategorias.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewCategorias.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewCategorias.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewCategorias.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewCategorias.Columns["Estado"].HeaderText = "Estado";

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewCategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewCategorias.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewCategorias.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewCategorias.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewCategorias.Rows.Count > 0) // Verificar que haya filas en el DataGridView
            {
                dataGridViewCategorias.ClearSelection(); // Limpiar cualquier selección previa
                dataGridViewCategorias.Rows[0].Selected = true; // Seleccionar la primera fila

                // Llamar al método que maneja la carga de datos en los controles
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewCategorias.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();

                // Asignar otros valores como el estado o el usuario creador
                UsuarioCrea = row.Cells["UsuarioCrea"].Value?.ToString() ?? string.Empty;

                if (row.Cells["Estado"].Value.ToString() == "Activo")
                {
                    checkBoxEstado.Checked = true;
                }
                else
                {
                    checkBoxEstado.Checked = false; // Valor predeterminado si no se puede convertir
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            SeleccionarPrimeraFila();
            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;

            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            textBoxDescripcion.Focus();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            // Cargar las Categorias en el DataGridView
            CargarCategorias();

            // Asegurarse de que el DataGridView permita el enfoque mediante el tabulador
            dataGridViewCategorias.TabStop = true;
            dataGridViewCategorias.TabIndex = 0;

            // Usar BeginInvoke para asegurar que el foco se establece correctamente
            this.BeginInvoke(new Action(() =>
            {
                // Establecer el foco en el DataGridView
                dataGridViewCategorias.Focus();

                // Seleccionar la primera celda automáticamente
                if (dataGridViewCategorias.Rows.Count > 0)
                {
                    dataGridViewCategorias.ClearSelection();
                    dataGridViewCategorias.Rows[0].Selected = true;
                    dataGridViewCategorias.CurrentCell = dataGridViewCategorias.Rows[0].Cells[0]; // Seleccionar la primera celda

                    // Para asegurarte de que el grid esté enfocado y listo para navegar
                    dataGridViewCategorias.Focus(); // Foco final en el grid
                }
            }));
        }

        private void dataGridViewCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener el ítem seleccionado
                DataGridViewRow row = dataGridViewCategorias.Rows[e.RowIndex];

                // Cargar los valores en los controles del formulario                
                Id = Convert.ToInt32(row.Cells["Id"].Value);
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();

                FechaCreacion = Convert.ToDateTime(row.Cells["FechaCreacion"].Value);
                UsuarioCrea = row.Cells["UsuarioCrea"].Value?.ToString() ?? string.Empty;

                if (row.Cells["Estado"].Value.ToString() == "Activo")
                {
                    checkBoxEstado.Checked = true;
                }
                else
                {
                    checkBoxEstado.Checked = false; // Valor predeterminado si no se puede convertir
                }

                // Habilitar los botones de actualización y eliminación
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void dataGridViewCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewCategorias.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();

                // Asignar otros valores como el estado o el usuario creador
                UsuarioCrea = row.Cells["UsuarioCrea"].Value?.ToString() ?? string.Empty;

                if (row.Cells["Estado"].Value.ToString() == "Activo")
                {
                    checkBoxEstado.Checked = true;
                }
                else
                {
                    checkBoxEstado.Checked = false; // Valor predeterminado si no se puede convertir
                }

                // Habilitar los botones de actualización y eliminación
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de guardar
            if (string.IsNullOrEmpty(textBoxDescripcion.Text))
            {
                MessageBox.Show("La descripción es requerida.");
                return;
            }

            var descripcion = textBoxDescripcion.Text;
            var fechaCreacion = DateTime.Now;
            var usuarioCrea = "UsuarioDemo";
            var estado = checkBoxEstado.Checked;

            // Guardar la categoria usando la capa de lógica de negocio
            _categoriaBl.GuardarCategoria(descripcion, fechaCreacion, usuarioCrea, estado);
            CargarCategorias();
            MessageBox.Show("categoria guardada correctamente.");

            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var categoria = new CategoriaDTO
            {
                Id = this.Id,
                Descripcion = textBoxDescripcion.Text,
                FechaCreacion = this.FechaCreacion,
                UsuarioCrea = this.UsuarioCrea,
                FechaModificacion = DateTime.Now,
                UsuarioModifica = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _categoriaBl.ActualizarCategoria(categoria);
            CargarCategorias();
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("categoria actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _categoriaBl.EliminarCategoria(id);
            CargarCategorias();
            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("categoria eliminada correctamente.");
        }

        private void CargarDataGridConFiltro(string filtro)
        {
            var CategoriasFiltradas = _categoriaBl.ObtenerCategoriasConFiltro(filtro);

            dataGridViewCategorias.DataSource = CategoriasFiltradas
                .Select(s => new
                {
                    s.Id,
                    s.Descripcion,
                    s.FechaCreacion,
                    s.UsuarioCrea,
                    s.FechaModificacion,
                    s.UsuarioModifica,
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

        private void FormCategoria_Load_1(object sender, EventArgs e)
        {

        }
    }
}
