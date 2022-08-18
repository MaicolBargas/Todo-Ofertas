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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCodeAdmin.Visible = false;
            }
        }
        private bool FaltanDatos()
        {
            if (this.txtMail.Text == "" || this.txtPassword.Text == "")
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

        protected void linkAdmin_Click(object sender, EventArgs e)
        {
            txtCodeAdmin.Visible = true;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            List<Admin> lista = new List<Admin>();
            lista = PersAdmin.ListaAdmin();

            if (!FaltanDatos())
            {
                string mail = this.txtMail.Text;
                string pass = this.txtPassword.Text;
                string password = Encrypt(pass);

                if (this.txtCodeAdmin.Text != "")
                {
                    int code = int.Parse(this.txtCodeAdmin.Text);

                    foreach (Admin admin in lista)
                    {
                        if (admin.Code == code && admin.Mail == mail && admin.Password == password)
                        {
                            Session["Email"] = mail;
                            Session["Password"] = password;
                            Session["ci"] = admin.Ci;

                            Response.Redirect("Admins.aspx");
                        }
                        else
                        {
                            lblAlertas.Text = "Email, Constraseña o Codigo de admin incorrectos, Verifique";
                        }
                    }
                }
                else
                {
                    List<Usuario> listaU = new List<Usuario>();
                    listaU = PersUsuario.ListaUsuario();

                    foreach (Usuario user in listaU)
                    {
                        if (user.Mail == mail && user.Password == password)
                        {
                            Session["Email"] = mail;
                            Session["Password"] = password;
                            Session["ci"] = user.Ci;                           
                            Response.Redirect("Main.aspx");
                        }
                        else
                        {
                            lblAlertas.Text = "Email o Constraseña incorrectos, Verifique";
                        }
                    }
                }
            }
            else { lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}