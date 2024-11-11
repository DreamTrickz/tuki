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
    public partial class FormUnidadMedida : Form
    {
        private readonly UnidadMedidaBL _unidadmedidaBl;
        private int Id;
        private DateTime FechaCreacion;
        private string UsuarioCrea = string.Empty;

        public FormUnidadMedida()
        {
            InitializeComponent();
            _unidadmedidaBl = new UnidadMedidaBL();
        }

        // Método para cargar los ítems en el DataGridView
        private void CargarUnidadMedidas()
        {
            var unidadMedidas = _unidadmedidaBl.ObtenerUnidadMedidas();
            dataGridViewUnidadMedidas.DataSource = unidadMedidas.Select(i => new
            {
                i.Id,
                i.Siglas,
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
            dataGridViewUnidadMedidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewUnidadMedidas.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewUnidadMedidas.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewUnidadMedidas.Columns["Id"].HeaderText = "Id";
            dataGridViewUnidadMedidas.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridViewUnidadMedidas.Columns["Siglas"].HeaderText = "Siglas";
            dataGridViewUnidadMedidas.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewUnidadMedidas.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewUnidadMedidas.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewUnidadMedidas.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewUnidadMedidas.Columns["Estado"].HeaderText = "Estado";

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewUnidadMedidas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewUnidadMedidas.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewUnidadMedidas.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewUnidadMedidas.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewUnidadMedidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewUnidadMedidas.Rows.Count > 0) // Verificar que haya filas en el DataGridView
            {
                dataGridViewUnidadMedidas.ClearSelection(); // Limpiar cualquier selección previa
                dataGridViewUnidadMedidas.Rows[0].Selected = true; // Seleccionar la primera fila

                // Llamar al método que maneja la carga de datos en los controles
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewUnidadMedidas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewUnidadMedidas.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                textBoxSiglas.Text = row.Cells["Siglas"].Value?.ToString();

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
            textBoxSiglas.Text = string.Empty;
            textBoxFiltro.Text = string.Empty;

            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            textBoxDescripcion.Focus();
        }

        private void FormUnidadMedida_Load(object sender, EventArgs e)
        {
            // Cargar las UnidadMedidas en el DataGridView
            CargarUnidadMedidas();

            // Asegurarse de que el DataGridView permita el enfoque mediante el tabulador
            dataGridViewUnidadMedidas.TabStop = true;
            dataGridViewUnidadMedidas.TabIndex = 0;

            // Usar BeginInvoke para asegurar que el foco se establece correctamente
            this.BeginInvoke(new Action(() =>
            {
                // Establecer el foco en el DataGridView
                dataGridViewUnidadMedidas.Focus();

                // Seleccionar la primera celda automáticamente
                if (dataGridViewUnidadMedidas.Rows.Count > 0)
                {
                    dataGridViewUnidadMedidas.ClearSelection();
                    dataGridViewUnidadMedidas.Rows[0].Selected = true;
                    dataGridViewUnidadMedidas.CurrentCell = dataGridViewUnidadMedidas.Rows[0].Cells[0]; // Seleccionar la primera celda

                    // Para asegurarte de que el grid esté enfocado y listo para navegar
                    dataGridViewUnidadMedidas.Focus(); // Foco final en el grid
                }
            }));
        }

        private void dataGridViewUnidadMedidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener el ítem seleccionado
                DataGridViewRow row = dataGridViewUnidadMedidas.Rows[e.RowIndex];

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

        private void dataGridViewUnidadMedidas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUnidadMedidas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewUnidadMedidas.SelectedRows[0]; // Obtener la primera fila seleccionada

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
            var siglas = textBoxSiglas.Text;
            var fechaCreacion = DateTime.Now;
            var usuarioCrea = "UsuarioDemo";
            var estado = checkBoxEstado.Checked;

            // Guardar la UnidadMedida usando la capa de lógica de negocio
            _unidadmedidaBl.GuardarUnidadMedida(descripcion, siglas, fechaCreacion, usuarioCrea, estado);
            CargarUnidadMedidas();
            MessageBox.Show("Unidad de Medida guardada correctamente.");

            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxSiglas.Text = string.Empty;
            textBoxFiltro.Text = string.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var UnidadMedida = new UnidadMedidaDTO
            {
                Id = this.Id,
                Descripcion = textBoxDescripcion.Text,
                Siglas = textBoxSiglas.Text,
                FechaCreacion = this.FechaCreacion,
                UsuarioCrea = this.UsuarioCrea,
                FechaModificacion = DateTime.Now,
                UsuarioModifica = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _unidadmedidaBl.ActualizarUnidadMedida(UnidadMedida);
            CargarUnidadMedidas();
            textBoxDescripcion.Text = string.Empty;
            textBoxSiglas.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Unidad de Medida actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _unidadmedidaBl.EliminarUnidadMedida(id);
            CargarUnidadMedidas();
            // Limpiar los campos
            textBoxDescripcion.Text = string.Empty;
            textBoxSiglas.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila(); 
            MessageBox.Show("UnidadMedida eliminada correctamente.");
        }

        private void CargarDataGridConFiltro(string filtro)
        {
            var UnidadMedidasFiltradas = _unidadmedidaBl.ObtenerUnidadMedidasConFiltro(filtro);

            dataGridViewUnidadMedidas.DataSource = UnidadMedidasFiltradas
                .Select(s => new
                {
                    s.Id,
                    s.Descripcion,
                    s.Siglas,
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de guardar
            if (string.IsNullOrEmpty(textBoxSiglas.Text))
            {
                MessageBox.Show("La sigla es requerida.");
                return;
            }

            if (string.IsNullOrEmpty(textBoxDescripcion.Text))
            {
                MessageBox.Show("La descripción es requerida.");
                return;
            }

            var siglas = textBoxSiglas.Text;
            var descripcion = textBoxDescripcion.Text;
            var estado = checkBoxEstado.Checked;
            var fechaCreacion = DateTime.Now;
            var usuarioCrea = "UsuarioDemo";

            // Guardar la marca usando la capa de lógica de negocio
            _unidadmedidaBl.GuardarUnidadMedida(descripcion, siglas, fechaCreacion, usuarioCrea, estado);

            MessageBox.Show("Unidad de medida guardada correctamente.");

            // Limpiar los campos
            textBoxSiglas.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
        }

        /* private void FormUnidadMedida_Load(object sender, EventArgs e)
         {

         }*/

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewUnidadMedida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener el ítem seleccionado
                DataGridViewRow row = dataGridViewUnidadMedidas.Rows[e.RowIndex];

                // Cargar los valores en los controles del formulario                
                Id = Convert.ToInt32(row.Cells["Id"].Value);
                textBoxSiglas.Text = row.Cells["Siglas"].Value?.ToString();
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

        private void dataGridViewUnidadMedida_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUnidadMedidas.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewUnidadMedidas.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxSiglas.Text = row.Cells["Siglas"].Value?.ToString();
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

        private void dataGridViewUnidadMedida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}