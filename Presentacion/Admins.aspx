<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admins.aspx.cs" Inherits="Presentacion.Admins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin page</title>
    <link rel="stylesheet" href="styles.css" />

</head>
<body>
    <form id="form1" runat="server">
      <div class="main">
            <div class="navbar">
                <asp:LinkButton ID="LinkLogOut" runat="server" CssClass="linkMenu" OnClick="LinkLogOut_Click" > Cerrar Sesion</asp:LinkButton>
                <asp:Label ID="Label1" runat="server" Text="Gestionar Ofertas"></asp:Label>
            </div>
            <hr />
            <div class="formulario">
                <div class="datos">                    
                    <asp:TextBox ID="txtId" cssClass="inputs" runat="server" placeHolder="Id" Enabled="False"></asp:TextBox>

                    <asp:TextBox ID="txtTitulo" cssClass="inputs" placeHolder="Titulo" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtDescripcion" CssClass="inputs" placeHolder="Descripcion" runat="server"></asp:TextBox>
            
                    <asp:TextBox ID="txtPrecio" cssClass="inputs" placeHolder="Precio" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtDescuento" cssClass="inputs" placeHolder="Descuento" runat="server"></asp:TextBox>
          
                    <asp:TextBox ID="txtPrecioFinal" cssClass="inputs" placeHolder="Precio Final" runat="server" Enabled="False"></asp:TextBox>
                </div>
                
                <div class="buttons">                    
                    <asp:Button ID="btnAlta" runat="server" CssClass="btn" Text="Alta" OnClick="btnAlta_Click"  />
                    <asp:Button ID="btnBaja" runat="server" Text="Eliminar" CssClass="btn" OnClick="btnBaja_Click"  />
                    <asp:Button ID="btnLimpiar" runat="server" CssClass="btn" Text="Limpiar" OnClick="btnLimpiar_Click"  />
                </div>
             </div>
           

            <div class="grid">
                <asp:GridView ID="GridOfertas" runat="server" AutoGenerateColumns ="False" Width="888px" CellPadding="3" GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" >
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Precio" HeaderText="$ Antes " />
                        <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                        <asp:BoundField DataField="PrecioFinal" HeaderText="$ Ahora" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="link_OnClick" >Seleccionar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
                <div class="ContainerAlerts">
                    <asp:Label ID="lblAlertas" CssClass="alerts" runat="server"></asp:Label>
                </div>    
            </div>
        </div>
    </form>
</body>
</html>
