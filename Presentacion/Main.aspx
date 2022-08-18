<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Presentacion.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
    <link rel="stylesheet" href="styles.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
           <div class="navbar">
               <asp:LinkButton ID="linkLogin" runat="server" CssClass="btnLogin" OnClick="linkLogin_Click">Cerrar Sesion</asp:LinkButton>
                <asp:Label ID="Label1" runat="server" Text="TODO OFERTAS"></asp:Label>

           </div>
            <hr />
            <div class="ContainerOfertas">
            <asp:GridView ID="GridOfertas" runat="server" AutoGenerateColumns ="False" Width="700px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Precio" HeaderText="$ Antes " />
                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                    <asp:BoundField DataField="PrecioFinal" HeaderText="$ Ahora" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="link_OnClick"  >Comprar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>

        </div>
                <asp:Label ID="lblAlertas" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
