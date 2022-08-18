using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Persistencia;
using Todo_Ofertas;

namespace Presentacion
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool FaltanDatos()
        {
            if (this.txtMail.Text == "" || this.txtPassword.Text == "" || this.txtNombre.Text == "" || this.txtCi.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
         }
        public static string Encrypt(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            if (!FaltanDatos())
            {
                string nombre = this.txtNombre.Text;
                int ci = int.Parse(this.txtCi.Text);
                string mail = this.txtMail.Text;
                string pass = this.txtPassword.Text;
                string password = Encrypt(pass);


                if (PersUsuario.BuscarUsuarioCI(ci) == null)
                {
                    Usuario unUsuario = new Usuario( ci,nombre, mail, password);

                    if (PersUsuario.AltaUsuario(unUsuario))
                    {
                        Session["Nombre"] = nombre;
                        Session["ci"] = ci;

                        Response.Redirect("Main.aspx");
                    }
                }
                else
                {
                    this.lblAlertas.Text = "Este usuario ya ha sido registrado";
                }

            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }

        }
    }
}