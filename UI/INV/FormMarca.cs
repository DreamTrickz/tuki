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
    public partial class FormMarca : Form
    {
        private readonly MarcaBL _marcaBl;
        private int Id;
        private DateTime FechaCreacion;
        private string UsuarioCrea = string.Empty;

        public FormMarca()
        {
            InitializeComponent();
            _marcaBl = new MarcaBL();
        }

        // Método para cargar los ítems en el DataGridView
        private void CargarMarcas()
        {
            var marcas = _marcaBl.ObtenerMarcas();
            dataGridViewMarcas.DataSource = marcas.Select(i => new
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
            dataGridViewMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewMarcas.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewMarcas.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewMarcas.Columns["Id"].HeaderText = "Id";
            dataGridViewMarcas.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridViewMarcas.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewMarcas.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewMarcas.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewMarcas.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewMarcas.Columns["Estado"].HeaderText = "Estado";

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewMarcas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewMarcas.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewMarcas.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewMarcas.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewMarcas.Rows.Count > 0) // Verificar que haya filas en el DataGridView
            {
                dataGridViewMarcas.ClearSelection(); // Limpiar cualquier selección previa
                dataGridViewMarcas.Rows[0].Selected = true; // Seleccionar la primera fila

                // Llamar al método que maneja la carga de datos en los controles
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewMarcas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewMarcas.SelectedRows[0]; // Obtener la primera fila seleccionada

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

        private void FormMarca_Load(object sender, EventArgs e)
        {
            // Cargar las marcas en el DataGridView
            CargarMarcas();

            // Asegurarse de que el DataGridView permita el enfoque mediante el tabulador
            dataGridViewMarcas.TabStop = true;
            dataGridViewMarcas.TabIndex = 0;

            // Usar BeginInvoke para asegurar que el foco se establece correctamente
            this.BeginInvoke(new Action(() =>
            {
                // Establecer el foco en el DataGridView
                dataGridViewMarcas.Focus();

                // Seleccionar la primera celda automáticamente
                if (dataGridViewMarcas.Rows.Count > 0)
                {
                    dataGridViewMarcas.ClearSelection();
                    dataGridViewMarcas.Rows[0].Selected = true;
                    dataGridViewMarcas.CurrentCell = dataGridViewMarcas.Rows[0].Cells[0]; // Seleccionar la primera celda

                    // Para asegurarte de que el grid esté enfocado y listo para navegar
                    dataGridViewMarcas.Focus(); // Foco final en el grid
                }
            }));
        }

        private void dataGridViewMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener el ítem seleccionado
                DataGridViewRow row = dataGridViewMarcas.Rows[e.RowIndex];

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

        private void dataGridViewMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMarcas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewMarcas.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                FechaCreacion = Convert.ToDateTime(row.Cells["FechaCreacion"].Value);

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

            // Guardar la marca usando la capa de lógica de negocio
            _marcaBl.GuardarMarca(descripcion, fechaCreacion, usuarioCrea, estado);
            CargarMarcas();
            MessageBox.Show("Marca guardada correctamente.");

            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var marca = new MarcaDTO
            {
                Id = this.Id,
                Descripcion = textBoxDescripcion.Text,
                FechaCreacion = this.FechaCreacion,
                UsuarioCrea = this.UsuarioCrea,
                FechaModificacion = DateTime.Now,
                UsuarioModifica = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _marcaBl.ActualizarMarca(marca);
            CargarMarcas();
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Marca actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _marcaBl.EliminarMarca(id);
            CargarMarcas();
            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Marca eliminada correctamente.");
        }

        private void CargarDataGridConFiltro(string filtro)
        {
            var marcasFiltradas = _marcaBl.ObtenerMarcasConFiltro(filtro);

            dataGridViewMarcas.DataSource = marcasFiltradas
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
    }
}