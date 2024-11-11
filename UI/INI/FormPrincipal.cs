using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.UI.INI
{
    public partial class FormPrincipal : Form
    {
        private Form? childForm;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormMarca();
                childForm.MdiParent = this;
                childForm.Text = "Consulta de órdenes";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonMarcas_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormMarca();
                childForm.MdiParent = this;
                childForm.Text = "Marcas";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void categoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormCategoria();
                childForm.MdiParent = this;
                childForm.Text = "Categorías";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void subcategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormSubcategoria();
                childForm.MdiParent = this;
                childForm.Text = "Subcategorías";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void unidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormUnidadMedida();
                childForm.MdiParent = this;
                childForm.Text = "Unidades de medida";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void ítemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormItem();
                childForm.MdiParent = this;
                childForm.Text = "Ítems";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }

        private void bodegasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new INV.FormBodega();
                childForm.MdiParent = this;
                childForm.Text = "Consulta de registros";
                childForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                childForm.BringToFront();
                childForm.WindowState = FormWindowState.Normal;
            }
        }
    }
}
