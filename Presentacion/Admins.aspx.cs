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
    public partial class Admins : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VerificarLogin();
                Listar();
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
            }
        }
        protected void Listar()
        {
            GridOfertas.DataSource = PersOferta.ListaOferta();
            GridOfertas.DataBind();
        }
        protected void VerificarLogin()
        {
            int ci = int.Parse(Session["ci"].ToString());

            if (PersAdmin.SesionIniciada(ci) == false)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Limpiar()
        {
            this.txtId.Text = "";
            this.txtTitulo.Text = "";
            this.txtDescripcion.Text = "";
            this.txtPrecio.Text = "";
            this.txtDescuento.Text = "";
            this.txtPrecioFinal.Text = "";

            btnAlta.Enabled = true;
            btnBaja.Enabled = false;
        }
        private bool FaltanDatos()
        {
            if (this.txtTitulo.Text == "" || this.txtDescripcion.Text == "" || this.txtPrecio.Text == "" || this.txtDescuento.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void link_OnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            Oferta oferta = PersOferta.BuscarOfertaID(id);

            this.txtId.Text = oferta.Id.ToString();
            this.txtTitulo.Text = oferta.Titulo.ToString();
            this.txtDescripcion.Text = oferta.Descripcion.ToString();
            this.txtPrecio.Text = oferta.Precio.ToString();
            this.txtDescuento.Text = oferta.Descuento.ToString();
            this.txtPrecioFinal.Text = oferta.PrecioFinal.ToString();

            btnAlta.Enabled = false;
            btnBaja.Enabled = true;
        }

        protected void LinkLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                string titulo = this.txtTitulo.Text;
                string descripcion = this.txtDescripcion.Text;
                int precio = int.Parse(this.txtPrecio.Text);
                int descuento = int.Parse(this.txtDescuento.Text);

                Oferta unaOferta = new Oferta(titulo, descripcion, precio, descuento);

                if (PersOferta.AltaOferta(unaOferta))
                {
                    this.lblAlertas.Text = "Oferta ingresada con éxito";
                    Limpiar();
                    Listar();
                }
            }
            else { this.lblAlertas.Text = "Debe ingresar todos los datos"; }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);

            if (PersOferta.BajaOferta(id))
            {
                this.lblAlertas.Text = "Oferta dada de baja";
                Limpiar();
                Listar();
            }
            else
            {
                this.lblAlertas.Text = "ERROR!!";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}