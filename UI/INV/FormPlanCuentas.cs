using Demo.BL.INV;
using Demo.DTO.INV;
using System;
using System.Drawing;
using System.Linq;
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
                Estado = i.Estado ? "Activo" : "Inactivo"
            }).ToList();
            FormateaDataGridView();
        }

        private void FormateaDataGridView()
        {
            dataGridViewPlanCuentass.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPlanCuentass.MultiSelect = false;
            dataGridViewPlanCuentass.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridViewPlanCuentass.Columns["Id"].HeaderText = "Id";
            dataGridViewPlanCuentass.Columns["CodigoCuenta"].HeaderText = "CodigoCuenta";
            dataGridViewPlanCuentass.Columns["NombreCuenta"].HeaderText = "NombreCuenta";
            dataGridViewPlanCuentass.Columns["TipoCuenta"].HeaderText = "TipoCuenta";
            dataGridViewPlanCuentass.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewPlanCuentass.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewPlanCuentass.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewPlanCuentass.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewPlanCuentass.Columns["Estado"].HeaderText = "Estado";

            dataGridViewPlanCuentass.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridViewPlanCuentass.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewPlanCuentass.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewPlanCuentass.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewPlanCuentass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewPlanCuentass.Rows.Count > 0)
            {
                dataGridViewPlanCuentass.ClearSelection();
                dataGridViewPlanCuentass.Rows[0].Selected = true;
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewPlanCuentass.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewPlanCuentass.SelectedRows[0];
                Id = (int)row.Cells["Id"].Value;
                textBoxNombreCuenta.Text = row.Cells["NombreCuenta"].Value?.ToString();
                textBoxTipoCuenta.Text = row.Cells["TipoCuenta"].Value?.ToString();
                UsuarioCrea = row.Cells["UsuarioCrea"].Value?.ToString() ?? string.Empty;
                checkBoxEstado.Checked = row.Cells["Estado"].Value.ToString() == "Activo";
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textBoxNombreCuenta.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            checkBoxEstado.Checked = false;
            textBoxFiltro.Text = string.Empty;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void FormPlanCuentas_Load(object sender, EventArgs e)
        {
            CargarPlanCuentass();
            dataGridViewPlanCuentass.TabStop = true;
            dataGridViewPlanCuentass.TabIndex = 0;
            this.BeginInvoke(new Action(() =>
            {
                dataGridViewPlanCuentass.Focus();
                if (dataGridViewPlanCuentass.Rows.Count > 0)
                {
                    dataGridViewPlanCuentass.ClearSelection();
                    dataGridViewPlanCuentass.Rows[0].Selected = true;
                    dataGridViewPlanCuentass.CurrentCell = dataGridViewPlanCuentass.Rows[0].Cells[0];
                    dataGridViewPlanCuentass.Focus();
                }
            }));
        }

        private void dataGridViewPlanCuentass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarDatosDeFilaSeleccionada();
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNombreCuenta.Text) ||
                string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            var nombreCuenta = textBoxNombreCuenta.Text;
            var codigoCuenta = int.Parse(textBox1.Text);
            var tipoCuenta = textBox2.Text;
            var fechaCreacion = DateTime.Now;
            var usuarioCrea = "UsuarioDemo";
            var estado = checkBoxEstado.Checked;

            _planCuentasBl.GuardarPlanCuentas(codigoCuenta, nombreCuenta, tipoCuenta, fechaCreacion, usuarioCrea, estado);
            CargarPlanCuentass();
            LimpiarCampos();
            MessageBox.Show("Registro agregado correctamente.");
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
            LimpiarCampos();
            MessageBox.Show("PlanCuentas actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _planCuentasBl.EliminarPlanCuentas(id);
            CargarPlanCuentass();
            LimpiarCampos();
            MessageBox.Show("PlanCuentas eliminada correctamente.");
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = textBoxFiltro.Text;
            CargarDataGridConFiltro(filtro);
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
                    Estado = s.Estado ? "Activo" : "Inactivo"
                })
                .ToList();

            FormateaDataGridView();
        }
    }
}