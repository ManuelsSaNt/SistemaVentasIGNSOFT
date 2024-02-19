using System;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using System.Linq;
using System.Collections.Generic;

namespace SistemaDeVentas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void  btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> Test = new CN_Usuario().listar();
            
            Usuario ousuario = new CN_Usuario().listar().Where(u => u.Documento == txtDocumento.Text && u.Clave == txtClave.Text).FirstOrDefault();
            
            if (ousuario !=null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();
                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se Encontro el Usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }
    }
}