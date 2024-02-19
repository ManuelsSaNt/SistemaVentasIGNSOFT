﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using FontAwesome.Sharp;
using CapaNegocio;

namespace SistemaDeVentas
{
	public partial class Inicio : Form
	{
		private static Usuario usuarioActual;
		private static IconMenuItem MenuActivo = null;
		private static Form FormularioActivo = null;
		public Inicio(Usuario objusuario = null)
		{
			if (objusuario == null) usuarioActual = new Usuario() { NombreCompleto ="ADMIN PREDEFINIDO",IdUsuario = 1};
			else 
				usuarioActual = objusuario;
			usuarioActual = objusuario;

			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			throw new System.NotImplementedException();
		}


		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			throw new System.NotImplementedException();
		}

		private void iconMenuItem1_Click(object sender, EventArgs e)
		{
			throw new System.NotImplementedException();
		}

        private void Inicio_Load(object sender, EventArgs e)
        {
			List<Permiso> ListaPermisos = new CN_Permiso().listar(usuarioActual.IdUsuario);

			foreach (IconMenuItem iconmenu in menu.Items) {

				bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

				if (encontrado == false)
				{
					iconmenu.Visible = false;
				}
			}


			lblusuario.Text = usuarioActual.NombreCompleto;
        }

		private void AbrirFormulario(IconMenuItem menu, Form formulario)
		{
			if(MenuActivo != null)
			{
				MenuActivo.BackColor = Color.White;
			}
			menu.BackColor = Color.Silver;
			MenuActivo = menu;

			if (FormularioActivo != null)
			{
				FormularioActivo.Close();
			}

			FormularioActivo = formulario;
			formulario.TopLevel = false;
			formulario.FormBorderStyle = FormBorderStyle.None;
			formulario.Dock = DockStyle.Fill;
			formulario.BackColor = Color.MidnightBlue;
			contenedor.Controls.Add(formulario);
			formulario.Show();
		}
        private void menuUsuario_Click(object sender, EventArgs e)
        {
			AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new frmCategoria());

        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuMantenedor, new frmProducto());

        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new frmVentas());

        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new frmDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new frmCompras());

        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new frmDetalleCompra());

        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());

        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());

        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());

        }
    }
}