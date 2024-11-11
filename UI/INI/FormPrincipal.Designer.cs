namespace Demo.UI.INI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            procesosToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            marcasToolStripMenuItem = new ToolStripMenuItem();
            categoríaToolStripMenuItem = new ToolStripMenuItem();
            subcategoríaToolStripMenuItem = new ToolStripMenuItem();
            unidadDeMedidaToolStripMenuItem = new ToolStripMenuItem();
            ítemsToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButtonMarcas = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            bodegaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, procesosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 34);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            inicioToolStripMenuItem.Image = (Image)resources.GetObject("inicioToolStripMenuItem.Image");
            inicioToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(83, 28);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Image = (Image)resources.GetObject("salirToolStripMenuItem.Image");
            salirToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(133, 38);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // procesosToolStripMenuItem
            // 
            procesosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inventarioToolStripMenuItem });
            procesosToolStripMenuItem.Image = (Image)resources.GetObject("procesosToolStripMenuItem.Image");
            procesosToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            procesosToolStripMenuItem.Size = new Size(105, 28);
            procesosToolStripMenuItem.Text = "Procesos";
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { marcasToolStripMenuItem, categoríaToolStripMenuItem, subcategoríaToolStripMenuItem, unidadDeMedidaToolStripMenuItem, ítemsToolStripMenuItem, bodegaToolStripMenuItem });
            inventarioToolStripMenuItem.Image = (Image)resources.GetObject("inventarioToolStripMenuItem.Image");
            inventarioToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.Size = new Size(236, 38);
            inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // marcasToolStripMenuItem
            // 
            marcasToolStripMenuItem.Image = (Image)resources.GetObject("marcasToolStripMenuItem.Image");
            marcasToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            marcasToolStripMenuItem.Size = new Size(242, 38);
            marcasToolStripMenuItem.Text = "Marcas";
            marcasToolStripMenuItem.Click += marcasToolStripMenuItem_Click;
            // 
            // categoríaToolStripMenuItem
            // 
            categoríaToolStripMenuItem.Name = "categoríaToolStripMenuItem";
            categoríaToolStripMenuItem.Size = new Size(242, 38);
            categoríaToolStripMenuItem.Text = "Categorías";
            categoríaToolStripMenuItem.Click += categoríaToolStripMenuItem_Click;
            // 
            // subcategoríaToolStripMenuItem
            // 
            subcategoríaToolStripMenuItem.Name = "subcategoríaToolStripMenuItem";
            subcategoríaToolStripMenuItem.Size = new Size(242, 38);
            subcategoríaToolStripMenuItem.Text = "Subcategorías";
            subcategoríaToolStripMenuItem.Click += subcategoríaToolStripMenuItem_Click;
            // 
            // unidadDeMedidaToolStripMenuItem
            // 
            unidadDeMedidaToolStripMenuItem.Name = "unidadDeMedidaToolStripMenuItem";
            unidadDeMedidaToolStripMenuItem.Size = new Size(242, 38);
            unidadDeMedidaToolStripMenuItem.Text = "Unidades de medida";
            unidadDeMedidaToolStripMenuItem.Click += unidadDeMedidaToolStripMenuItem_Click;
            // 
            // bodegaToolStripMenuItem
            // 
            bodegaToolStripMenuItem.Name = "bodegaToolStripMenuItem";
            bodegaToolStripMenuItem.Size = new Size(242, 38);
            bodegaToolStripMenuItem.Text = "Bodega";
            bodegaToolStripMenuItem.Click += bodegasToolStripMenuItem_Click;
            // ítemsToolStripMenuItem
            // 
            ítemsToolStripMenuItem.Name = "ítemsToolStripMenuItem";
            ítemsToolStripMenuItem.Size = new Size(242, 38);
            ítemsToolStripMenuItem.Text = "Ítems";
            ítemsToolStripMenuItem.Click += ítemsToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonMarcas, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 34);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(914, 71);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonMarcas
            // 
            toolStripButtonMarcas.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonMarcas.Image = (Image)resources.GetObject("toolStripButtonMarcas.Image");
            toolStripButtonMarcas.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonMarcas.ImageTransparentColor = Color.Magenta;
            toolStripButtonMarcas.Name = "toolStripButtonMarcas";
            toolStripButtonMarcas.Size = new Size(68, 68);
            toolStripButtonMarcas.Text = "Marcas";
            toolStripButtonMarcas.TextAlign = ContentAlignment.BottomCenter;
            toolStripButtonMarcas.TextImageRelation = TextImageRelation.Overlay;
            toolStripButtonMarcas.Click += toolStripButtonMarcas_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 71);
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 26);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(100, 20);
            toolStripStatusLabel1.Text = "UsuarioDemo";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            //
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondo4;
            ClientSize = new Size(914, 600);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Principal";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem procesosToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem marcasToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonMarcas;
        private ToolStripSeparator toolStripSeparator1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem categoríaToolStripMenuItem;
        private ToolStripMenuItem subcategoríaToolStripMenuItem;
        private ToolStripMenuItem unidadDeMedidaToolStripMenuItem;
        private ToolStripMenuItem ítemsToolStripMenuItem;
        private ToolStripMenuItem bodegaToolStripMenuItem;
    }
}