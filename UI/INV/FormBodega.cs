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
    public partial class FormBodega : Form
    {
        private readonly BodegaBL _bodegaBl;
        private int Id;
        private int IdTipoBodega;
        private DateTime FechaCreacion;
        private string UsuarioCrea = string.Empty;

        public FormBodega()
        {
            InitializeComponent();
            _bodegaBl = new BodegaBL();
        }

        // Método para cargar los ítems en el DataGridView
        private void CargarBodegas()
        {
            var bodegas = _bodegaBl.ObtenerBodegas();
            dataGridViewBodegas.DataSource = bodegas.Select(i => new
            {
                i.Id,
                i.Codigo,
                i.Descripcion,
                i.IdTipoBodega,
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
            dataGridViewBodegas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewBodegas.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewBodegas.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewBodegas.Columns["Id"].HeaderText = "Id";
            dataGridViewBodegas.Columns["Codigo"].HeaderText = "Codigo";
            dataGridViewBodegas.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridViewBodegas.Columns["IdTipoBodega"].HeaderText = "IdTipoBodega";
            dataGridViewBodegas.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewBodegas.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewBodegas.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewBodegas.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewBodegas.Columns["Estado"].HeaderText = "Estado";

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewBodegas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewBodegas.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewBodegas.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewBodegas.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewBodegas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewBodegas.Rows.Count > 0) // Verificar que haya filas en el DataGridView
            {
                dataGridViewBodegas.ClearSelection(); // Limpiar cualquier selección previa
                dataGridViewBodegas.Rows[0].Selected = true; // Seleccionar la primera fila

                // Llamar al método que maneja la carga de datos en los controles
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewBodegas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewBodegas.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                textBoxCodigo.Text = row.Cells["Codigo"].Value?.ToString();

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
            textBoxCodigo.Text = string.Empty;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            textBoxDescripcion.Focus();
        }

        private void FormBodega_Load(object sender, EventArgs e)
        {
            // Cargar las bodegas en el DataGridView
            CargarBodegas();

            // Asegurarse de que el DataGridView permita el enfoque mediante el tabulador
            dataGridViewBodegas.TabStop = true;
            dataGridViewBodegas.TabIndex = 0;

            // Usar BeginInvoke para asegurar que el foco se establece correctamente
            this.BeginInvoke(new Action(() =>
            {
                // Establecer el foco en el DataGridView
                dataGridViewBodegas.Focus();

                // Seleccionar la primera celda automáticamente
                if (dataGridViewBodegas.Rows.Count > 0)
                {
                    dataGridViewBodegas.ClearSelection();
                    dataGridViewBodegas.Rows[0].Selected = true;
                    dataGridViewBodegas.CurrentCell = dataGridViewBodegas.Rows[0].Cells[0]; // Seleccionar la primera celda

                    // Para asegurarte de que el grid esté enfocado y listo para navegar
                    dataGridViewBodegas.Focus(); // Foco final en el grid
                }
            }));
        }

        private void dataGridViewBodegas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewBodegas.Rows[e.RowIndex];

                Id = row.Cells["Id"].Value != null ? Convert.ToInt32(row.Cells["Id"].Value) : 0;
                IdTipoBodega = row.Cells["IdTipoBodega"].Value != null ? (int)row.Cells["IdTipoBodega"].Value : 0;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
                textBoxCodigo.Text = row.Cells["Codigo"].Value?.ToString() ?? string.Empty;
                FechaCreacion = row.Cells["FechaCreacion"].Value != null ?
                Convert.ToDateTime(row.Cells["FechaCreacion"].Value) : DateTime.MinValue;

                UsuarioCrea = row.Cells["UsuarioCrea"].Value?.ToString() ?? string.Empty;

                checkBoxEstado.Checked = row.Cells["Estado"].Value != null && row.Cells["Estado"].Value.ToString() == "Activo";

                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }


        private void dataGridViewBodegas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBodegas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewBodegas.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                IdTipoBodega = (int)row.Cells["IdTipoBodega"].Value;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                textBoxCodigo.Text = row.Cells["Codigo"].Value?.ToString() ?? string.Empty;
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
            var codigo = textBoxCodigo.Text;
            var fechaCreacion = DateTime.Now;
            var usuarioCrea = "UsuarioDemo";
            var estado = checkBoxEstado.Checked;

            // Guardar la bodega usando la capa de lógica de negocio
            _bodegaBl.GuardarBodega(codigo, descripcion, fechaCreacion, usuarioCrea, estado);
            CargarBodegas();
            MessageBox.Show("Bodega guardada correctamente.");

            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            textBoxCodigo.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var bodega = new BodegaDTO
            {
                Id = this.Id,
                IdTipoBodega = this.IdTipoBodega,
                Descripcion = textBoxDescripcion.Text,
                Codigo = this.textBoxCodigo.Text,
                FechaCreacion = this.FechaCreacion,
                UsuarioCrea = this.UsuarioCrea,
                FechaModificacion = DateTime.Now,
                UsuarioModifica = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _bodegaBl.ActualizarBodega(bodega);
            CargarBodegas();
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxCodigo.Text = string.Empty;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Bodega actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _bodegaBl.EliminarBodega(id);
            CargarBodegas();
            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            textBoxCodigo.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Bodega eliminada correctamente.");
        }

        private void CargarDataGridConFiltro(string filtro)
        {
            var bodegasFiltradas = _bodegaBl.ObtenerBodegasConFiltro(filtro);

            dataGridViewBodegas.DataSource = bodegasFiltradas
                .Select(s => new
                {
                    s.Id,
                    s.Codigo,
                    s.Descripcion,
                    s.IdTipoBodega,
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}