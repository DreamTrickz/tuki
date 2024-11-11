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
    public partial class FormItem : Form
    {
        private readonly ItemBL _itemBl;
        private readonly CategoriaBL _categoriaBl;
        private readonly SubcategoriaBL _subcategoriaBl;
        private readonly MarcaBL _marcaBl;
        private readonly UnidadMedidaBL _unidadMedidaBL;
        private int Id;
        private DateTime FechaCreacion;
        private string UsuarioCrea = string.Empty;
        public FormItem()
        {
            InitializeComponent();
            _itemBl = new ItemBL();
            _categoriaBl = new CategoriaBL();
            _subcategoriaBl = new SubcategoriaBL();
            _marcaBl = new MarcaBL();
            _unidadMedidaBL = new UnidadMedidaBL();

            CargaUnidadMedida();
            CargarMarcas();
            CargarCategorias();                                           
        }

        private void CargaUnidadMedida()
        {
            var unidadMedida = _unidadMedidaBL.ObtenerUnidadMedidas();
            comboBoxUnidadMedida.DataSource = unidadMedida;
            comboBoxUnidadMedida.DisplayMember = "Siglas"; // Propiedad que muestra el nombre de la subcategoría
            comboBoxUnidadMedida.ValueMember = "Id";            // Propiedad que representa el Id de la subcategoría
            comboBoxUnidadMedida.SelectedIndex = -1;
        }

        private void CargarMarcas()
        {            
            MarcaBL marcaBL = new MarcaBL();
            var marcas = marcaBL.ObtenerMarcas()
                                .Select(m => new { Id = m.Id, Descripcion = m.Descripcion.Trim() }) // Aplica Trim a la descripción
                                .ToList();

            comboBoxMarca.DataSource = marcas;
            comboBoxMarca.DisplayMember = "Descripcion"; // Lo que se muestra en el ComboBox
            comboBoxMarca.ValueMember = "Id"; // El valor que se asocia internamente

            // Establecer el índice seleccionado en -1 para que no haya selección inicial
            comboBoxMarca.SelectedIndex = -1;
        }

        private void CargarCategorias()
        {            
            // Desconectar el evento temporalmente para evitar que se dispare durante la carga
            comboBoxCategoria.SelectedIndexChanged -= comboBoxCategoria_SelectedIndexChanged;

            CategoriaBL categoriaBL = new CategoriaBL();
            var categorias = categoriaBL.ObtenerCategorias();

            comboBoxCategoria.DataSource = categorias;
            comboBoxCategoria.DisplayMember = "Descripcion"; // Lo que se muestra en el ComboBox
            comboBoxCategoria.ValueMember = "Id"; // El valor que se asocia internamente

            // Conectar nuevamente el evento
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;
            comboBoxCategoria.SelectedIndex = -1;
        }

        private void CargarSubcategorias(int categoriaId)
        {
            var subcategorias = _subcategoriaBl.ObtenerSubcategoriasPorCategoria(categoriaId);
            comboBoxSubcategoria.DataSource = subcategorias;
            comboBoxSubcategoria.DisplayMember = "Descripcion"; // Propiedad que muestra el nombre de la subcategoría
            comboBoxSubcategoria.ValueMember = "Id";            // Propiedad que representa el Id de la subcategoría
            comboBoxSubcategoria.SelectedIndex = -1;
        }

        // Método para cargar los ítems en el DataGridView
        private void CargarItems()
        {
            var items = _itemBl.ObtenerItems();
            dataGridViewItems.DataSource = items.Select(i => new
            {
                i.Id,
                i.Codigo,
                i.Descripcion,
                MarcaId = i.Marca?.Id,
                Marca = i.Marca?.Descripcion,
                CategoriaId = i.Categoria?.Id,
                Categoria = i.Categoria?.Descripcion,
                SubcategoriaId = i.Subcategoria?.Id,
                Subcategoria = i.Subcategoria?.Descripcion,
                UnidadMedidaId = i.UnidadMedida?.Id,
                UnidadMedida = i.UnidadMedida?.Descripcion,
                i.StockGeneral,
                i.Costo,
                i.Precio,
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
            dataGridViewItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Deshabilitar la selección de múltiples filas (opcional)
            dataGridViewItems.MultiSelect = false;

            // Deshabilitar la selección de celdas individuales (opcional)
            dataGridViewItems.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Personalizar las columnas
            dataGridViewItems.Columns["Id"].HeaderText = "Id";
            dataGridViewItems.Columns["Codigo"].HeaderText = "Código";
            dataGridViewItems.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridViewItems.Columns["Marca"].HeaderText = "Marca";
            dataGridViewItems.Columns["Categoria"].HeaderText = "Categoría";
            dataGridViewItems.Columns["Subcategoria"].HeaderText = "Subcategoría";
            dataGridViewItems.Columns["UnidadMedida"].HeaderText = "Unidad de medida";
            dataGridViewItems.Columns["StockGeneral"].HeaderText = "Stock general";
            dataGridViewItems.Columns["Costo"].HeaderText = "Costo";
            dataGridViewItems.Columns["Precio"].HeaderText = "Precio";
            dataGridViewItems.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dataGridViewItems.Columns["UsuarioCrea"].HeaderText = "Usuario crea";
            dataGridViewItems.Columns["FechaModificacion"].HeaderText = "Fecha de modificación";
            dataGridViewItems.Columns["UsuarioModifica"].HeaderText = "Usuario modifica";
            dataGridViewItems.Columns["Estado"].HeaderText = "Estado";

            // Opcional: Ocultar columnas si no deseas mostrar ciertos datos
            dataGridViewItems.Columns["MarcaId"].Visible = false; // Si no quieres mostrar el ID
            dataGridViewItems.Columns["CategoriaId"].Visible = false; // Si no quieres mostrar el ID
            dataGridViewItems.Columns["SubcategoriaId"].Visible = false; // Si no quieres mostrar el ID
            dataGridViewItems.Columns["UnidadMedidaId"].Visible = false; // Si no quieres mostrar el ID

            // Configura las filas alternas para que se vean con un fondo diferente
            dataGridViewItems.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de la fila seleccionada
            dataGridViewItems.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridViewItems.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajustar el estilo de la fuente en las celdas
            dataGridViewItems.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Cambiar el modo de ajuste de las columnas
            dataGridViewItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Botón para agregar un nuevo ítem
        private void btnAgregar_Click(object sender, EventArgs e)
        {         
            var item = new ItemDTO
            {
                Codigo = textboxCodigo.Text,
                Descripcion = textBoxDescripcion.Text,
                MarcaId = (int)(comboBoxMarca.SelectedValue ?? 0),
                CategoriaId = (int)(comboBoxCategoria.SelectedValue ?? 0),
                SubcategoriaId = (int)(comboBoxSubcategoria.SelectedValue ?? 0),
                UnidadMedidaId = (int)(comboBoxUnidadMedida.SelectedValue ?? 0),
                StockGeneral = string.IsNullOrWhiteSpace(textboxStockGeneral.Text) ? 0 : int.Parse(textboxStockGeneral.Text),
                Costo = decimal.Parse(textboxCosto.Text),
                Precio = decimal.Parse(textboxPrecio.Text),
                FechaCreacion = DateTime.Now,
                UsuarioCrea = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _itemBl.AgregarItem(item);
            CargarItems();
            MessageBox.Show("Ítem guardado correctamente.");

            // Limpiar los campos
            textboxCodigo.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            textboxStockGeneral.Text = string.Empty;
            textboxCosto.Text = string.Empty;
            textboxPrecio.Text = string.Empty;
            comboBoxMarca.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            comboBoxUnidadMedida.SelectedIndex = -1;
            comboBoxSubcategoria.SelectedIndex = -1;
        }

        // Botón para actualizar un ítem
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var item = new ItemDTO
            {
                Id = this.Id,
                Codigo = textboxCodigo.Text,
                Descripcion = textBoxDescripcion.Text,
                MarcaId = (int)(comboBoxMarca.SelectedValue ?? 0),
                CategoriaId = (int)(comboBoxCategoria.SelectedValue ?? 0),
                SubcategoriaId = (int)(comboBoxSubcategoria.SelectedValue ?? 0),
                UnidadMedidaId = (int)(comboBoxUnidadMedida.SelectedValue ?? 0),
                StockGeneral = int.Parse(textboxStockGeneral.Text),
                Costo = decimal.Parse(textboxCosto.Text),
                Precio = decimal.Parse(textboxPrecio.Text),
                FechaCreacion = this.FechaCreacion,
                UsuarioCrea = this.UsuarioCrea,
                FechaModificacion = DateTime.Now,
                UsuarioModifica = "UsuarioDemo",
                Estado = checkBoxEstado.Checked
            };

            _itemBl.ActualizarItem(item);
            CargarItems();
            limpiarControles();
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Ítem actualizado correctamente.");            
        }

        private void SeleccionarPrimeraFila()
        {
            if (dataGridViewItems.Rows.Count > 0) // Verificar que haya filas en el DataGridView
            {
                dataGridViewItems.ClearSelection(); // Limpiar cualquier selección previa
                dataGridViewItems.Rows[0].Selected = true; // Seleccionar la primera fila

                // Llamar al método que maneja la carga de datos en los controles
                CargarDatosDeFilaSeleccionada();
            }
        }

        private void CargarDatosDeFilaSeleccionada()
        {
            if (dataGridViewItems.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewItems.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textboxCodigo.Text = row.Cells["Codigo"].Value?.ToString();
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                textboxStockGeneral.Text = row.Cells["StockGeneral"].Value?.ToString();
                textboxCosto.Text = row.Cells["Costo"].Value?.ToString();
                textboxPrecio.Text = row.Cells["Precio"].Value?.ToString();

                // Cargar los valores de los ComboBox (Marca, Categoría, Subcategoría, UnidadMedida)
                comboBoxMarca.SelectedValue = (int)row.Cells["MarcaId"].Value;
                comboBoxCategoria.SelectedValue = (int)row.Cells["CategoriaId"].Value;
                comboBoxSubcategoria.SelectedValue = (int)row.Cells["SubcategoriaId"].Value;
                comboBoxUnidadMedida.SelectedValue = (int)row.Cells["UnidadMedidaId"].Value;

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

        private void limpiarControles()
        {
            Id = -1;
            UsuarioCrea = string.Empty;
            textboxCodigo.Text = string.Empty;
            textBoxDescripcion.Text = string.Empty;
            textboxStockGeneral.Text = string.Empty;
            textboxCosto.Text = string.Empty;
            textboxPrecio.Text = string.Empty;
            comboBoxMarca.SelectedIndex = -1;
            comboBoxCategoria.SelectedIndex = -1;
            comboBoxUnidadMedida.SelectedIndex = -1;
            comboBoxSubcategoria.SelectedIndex = -1;
            checkBoxEstado.Checked = false;

            // Asegúrate de que el ComboBox se actualiza correctamente
            comboBoxMarca.DataSource = null;
            comboBoxCategoria.DataSource = null;
            comboBoxUnidadMedida.DataSource = null;
            comboBoxSubcategoria.DataSource = null;

            // Recargar los datos de los ComboBox
            CargaUnidadMedida();
            CargarMarcas();
            CargarCategorias();
        }

        // Botón para eliminar un ítem
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = this.Id;
            _itemBl.EliminarItem(id);
            CargarItems();
            // Limpiar los campos
            limpiarControles();
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            MessageBox.Show("Ítem eliminado correctamente.");            
        }

        private void comboBoxCategoria_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Asegurarse de que SelectedValue no sea nulo y sea del tipo esperado
            if (comboBoxCategoria.SelectedValue != null && comboBoxCategoria.SelectedValue is int)
            {
                int categoriaId = (int)comboBoxCategoria.SelectedValue;
                CargarSubcategorias(categoriaId);
            }
        }

        private void dataGridViewItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya seleccionado una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener el ítem seleccionado
                DataGridViewRow row = dataGridViewItems.Rows[e.RowIndex];

                // Cargar los valores en los controles del formulario                
                Id = Convert.ToInt32(row.Cells["Id"].Value);
                textboxCodigo.Text = row.Cells["Codigo"].Value?.ToString();
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();

                comboBoxMarca.SelectedValue = row.Cells["MarcaId"].Value;
                comboBoxCategoria.SelectedValue = row.Cells["CategoriaId"].Value;
                comboBoxSubcategoria.SelectedValue = row.Cells["SubcategoriaId"].Value;
                comboBoxUnidadMedida.SelectedValue = row.Cells["UnidadMedidaId"].Value;

                textboxStockGeneral.Text = row.Cells["StockGeneral"].Value.ToString();
                textboxCosto.Text = row.Cells["Costo"].Value.ToString();
                textboxPrecio.Text = row.Cells["Precio"].Value.ToString();

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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {         
            // Seleccionar la primera fila y cargar sus datos
            SeleccionarPrimeraFila();
            limpiarControles();            
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            textboxCodigo.Focus();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewItems.SelectedRows.Count > 0) // Verificar si hay filas seleccionadas
            {
                DataGridViewRow row = dataGridViewItems.SelectedRows[0]; // Obtener la primera fila seleccionada

                // Cargar los valores de la fila seleccionada en los controles
                Id = (int)row.Cells["Id"].Value;
                textboxCodigo.Text = row.Cells["Codigo"].Value?.ToString();
                textBoxDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
                textboxStockGeneral.Text = row.Cells["StockGeneral"].Value?.ToString();
                textboxCosto.Text = row.Cells["Costo"].Value?.ToString();
                textboxPrecio.Text = row.Cells["Precio"].Value?.ToString();

                // Cargar los valores de los ComboBox (Marca, Categoría, Subcategoría, UnidadMedida)
                comboBoxMarca.SelectedValue = (int)row.Cells["MarcaId"].Value;
                comboBoxCategoria.SelectedValue = (int)row.Cells["CategoriaId"].Value;
                comboBoxSubcategoria.SelectedValue = (int)row.Cells["SubcategoriaId"].Value;
                comboBoxUnidadMedida.SelectedValue = (int)row.Cells["UnidadMedidaId"].Value;

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

        private void FormItem_Load(object sender, EventArgs e)
        {            
            // Asignar el evento para cuando cambie la categoría seleccionada
            comboBoxCategoria.SelectedIndexChanged += comboBoxCategoria_SelectedIndexChanged;

            // Cargar los ítems en el DataGridView
            CargarItems();

            // Asegurarse de que el DataGridView permita el enfoque mediante el tabulador
            dataGridViewItems.TabStop = true;
            dataGridViewItems.TabIndex = 0;

            // Usar BeginInvoke para asegurar que el foco se establece correctamente
            this.BeginInvoke(new Action(() =>
            {
                // Establecer el foco en el DataGridView
                dataGridViewItems.Focus();

                // Seleccionar la primera celda automáticamente
                if (dataGridViewItems.Rows.Count > 0)
                {
                    dataGridViewItems.ClearSelection();
                    dataGridViewItems.Rows[0].Selected = true;
                    dataGridViewItems.CurrentCell = dataGridViewItems.Rows[0].Cells[0]; // Seleccionar la primera celda

                    // Para asegurarte de que el grid esté enfocado y listo para navegar
                    dataGridViewItems.Focus(); // Foco final en el grid
                }
            }));
        }
    }
}
