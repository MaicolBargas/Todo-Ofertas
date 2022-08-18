using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistencia;
using Todo_Ofertas;

namespace Presentacion
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerificarLogin();
                Listar();
            }
        }

        protected void VerificarLogin()
        {
            int ci = int.Parse(Session["ci"].ToString());

            if (PersUsuario.SesionIniciada(ci) == false)
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void linkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Listar()
        {
            GridOfertas.DataSource = PersOferta.ListaOferta();
            GridOfertas.DataBind();
        }

        protected void link_OnClick(object sender, EventArgs e)
        {
            int idOferta = Convert.ToInt32((sender as LinkButton).CommandArgument);
            int ciComprador = int.Parse(Session["ci"].ToString());
            Venta unaVenta = new Venta(ciComprador, idOferta);

            PersVenta.AltaVenta(unaVenta);
            lblAlertas.Text = "Compra realizada con exito";
            Listar();
        }
    }
}