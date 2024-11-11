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
    public partial class FormPlanCuentas : Form
    {
        private readonly PlanCuentasBL _planCuentasBl;
        private int Id;
        private int CodigoCuenta;
        private string NombreCuenta = string.Empty;
        private string TipoCuenta = string.Empty;
        private DateTime FechaCreacion;    
        private string UsuarioCrea = string.Empty;

        public FormPlanCuentas()
        {
            InitializeComponent();
            _planCuentasBl = new PlanCuentasBL();
        }

        // Método para cargar los ítems en el DataGridView
        private void CargarPlanCuentass()
        {
            var planCuentass = _planCuentasBl.ObtenerPlanCuentass();
            dataGridViewPlanCuentass.DataSource = planCuentass.Select(i => new
            {
                i.Id,
                i.CodigoCuenta,
                i.NombreCuenta,
                i.TipoCuenta,
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
            dataGridViewPlanCuentass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewPlanCuentass.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewPlanCuentass.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewPlanCuentass.Columns["Id"].HeaderText = "Id";
            dataGridViewPlanCuentass.Columns["CodigoCuenta"].HeaderText = "CodigoCuenta";
            dataGridViewPlanCuentass.Columns["NombreCuenta"].HeaderText = "NombreCuenta";
            dataGridViewPlanCuentass.Columns["TipoCuenta"].HeaderText = "TipoCuenta";
            dataGridViewPlanCuentass.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewPlanCuentass.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewPlanCuentass.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewPlanCuentass.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewPlanCuentass.Columns["Estado"].HeaderText = "Estado";

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewPlanCuentass.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewPlanCuentass.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewPlanCuentass.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewPlanCuentass.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewPlanCuentass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewPlanCuentass.Rows.Count > 0) // Verificar que haya filas en el DataGridView
            {
                dataGridViewPlanCuentass.ClearSelection(); // Limpiar cualquier selección previa
                dataGridViewPlanCuentass.Rows[0].Selected = true; // Seleccionar la primera fila

                // Llamar al método que maneja la carga de datos en los controles
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewPlanCuentass.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewPlanCuentass.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textBoxNombreCuenta.Text = row.Cells["NombreCuenta"].Value?.ToString();
                textBoxTipoCuenta.Text = row.Cells["TipoCuenta"].Value?.ToString();

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
            textBoxNombreCuenta.Text = string.Empty;

            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            textBoxTipoCuenta.Text = string.Empty;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            textBoxNombreCuenta.Focus();
        }

        private void FormPlanCuentas_Load(object sender, EventArgs e)
        {
            // Cargar las planCuentass en el DataGridView
            CargarPlanCuentass();

            // Asegurarse de que el DataGridView permita el enfoque mediante el tabulador
            dataGridViewPlanCuentass.TabStop = true;
            dataGridViewPlanCuentass.TabIndex = 0;

            // Usar BeginInvoke para asegurar que el foco se establece correctamente
            this.BeginInvoke(new Action(() =>
            {
                // Establecer el foco en el DataGridView
                dataGridViewPlanCuentass.Focus();

                // Seleccionar la primera celda automáticamente
                if (dataGridViewPlanCuentass.Rows.Count > 0)
                {
                    dataGridViewPlanCuentass.ClearSelection();
                    dataGridViewPlanCuentass.Rows[0].Selected = true;
                    dataGridViewPlanCuentass.CurrentCell = dataGridViewPlanCuentass.Rows[0].Cells[0]; // Seleccionar la primera celda

                    // Para asegurarte de que el grid esté enfocado y listo para navegar
                    dataGridViewPlanCuentass.Focus(); // Foco final en el grid
                }
            }));
        }

        private void dataGridViewPlanCuentass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPlanCuentass.Rows[e.RowIndex];

                Id = row.Cells["Id"].Value != null ? Convert.ToInt32(row.Cells["Id"].Value) : 0;
                CodigoCuenta = row.Cells["CodigoCuenta"].Value != null ? (int)row.Cells["IdTipoPlanCuenta"].Value : 0;
                textBoxNombreCuenta.Text = row.Cells["NombreCuenta"].Value?.ToString() ?? string.Empty;
                textBoxTipoCuenta.Text = row.Cells["Codigo"].Value?.ToString() ?? string.Empty;
                FechaCreacion = row.Cells["FechaCreacion"].Value != null ?
                Convert.ToDateTime(row.Cells["FechaCreacion"].Value) : DateTime.MinValue;

                UsuarioCrea = row.Cells["UsuarioCrea"].Value?.ToString() ?? string.Empty;

                checkBoxEstado.Checked = row.Cells["Estado"].Value != null && row.Cells["Estado"].Value.ToString() == "Activo";

                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }


        private void dataGridViewPlanCuentass_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPlanCuentass.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewPlanCuentass.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;  
                CodigoCuenta = (int)row.Cells["IdTipoPlanCuentas"].Value;
                textBoxNombreCuenta.Text = row.Cells["NombreCuenta"].Value?.ToString();
                textBoxTipoCuenta.Text = row.Cells["Codigo"].Value?.ToString() ?? string.Empty;
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
            if (string.IsNullOrEmpty(textBoxNombreCuenta.Text))
            {
                MessageBox.Show("La descripción es requerida.");
                return;
            }

            var nombreCuenta = textBoxNombreCuenta.Text;
            var tipoCuenta = textBoxTipoCuenta.Text;   
            var fechaCreacion = DateTime.Now;
            var usuarioCrea = "UsuarioDemo";
            var estado = checkBoxEstado.Checked;

            // Guardar la planCuentas usando la capa de lógica de negocio
            _planCuentasBl.GuardarPlanCuentas(nombreCuenta, fechaCreacion, usuarioCrea, estado);
            CargarPlanCuentass();
            MessageBox.Show("PlanCuentas guardada correctamente.");

            // Limpiar los campos
            textBoxNombreCuenta.Text = string.Empty;
            textBoxTipoCuenta.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var planCuentas = new PlanCuentasDTO
            {
                Id = this.Id,
                CodigoCuenta = this.CodigoCuenta,
                NombreCuenta = textBoxNombreCuenta.Text,
                TipoCuenta = this.textBoxTipoCuenta.Text,
                FechaCreacion = this.FechaCreacion,
                UsuarioCrea = this.UsuarioCrea,
                FechaModificacion = DateTime.Now,
                UsuarioModifica = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _planCuentasBl.ActualizarPlanCuentas(planCuentas);
            CargarPlanCuentass();
            textBoxNombreCuenta.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxTipoCuenta.Text = string.Empty;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("PlanCuentas actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _planCuentasBl.EliminarPlanCuentas(id);
            CargarPlanCuentass();
            // Limpiar los campos
            textBoxNombreCuenta.Text = string.Empty;
            textBoxTipoCuenta.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("PlanCuentas eliminada correctamente.");
        }

        private void CargarDataGridConFiltro(string filtro)
        {
            var planCuentassFiltradas = _planCuentasBl.ObtenerPlanCuentassConFiltro(filtro);

            dataGridViewPlanCuentass.DataSource = planCuentassFiltradas
                .Select(s => new
                {
                    s.Id,
                    s.CodigoCuenta,
                    s.NombreCuenta,
                    s.TipoCuenta,
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