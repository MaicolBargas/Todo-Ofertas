<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
           <div class="container">
            <div class="form">
                <div class="login">
                    <p class="tittle">LOGIN</p>
                    
                    <asp:TextBox ID="txtMail" runat="server" CssClass="textboxs" placeHolder="E-Mail" CausesValidation="True"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textboxs" TextMode="Password" placeHolder="Password"></asp:TextBox>
                    <asp:LinkButton ID="linkAdmin" runat="server" CssClass="link" Font-Names="Bell MT" ForeColor="Black" OnClick="linkAdmin_Click">Eres Admin? Click Aquí</asp:LinkButton>
                    <br />
                    <br />
                    <asp:TextBox ID="txtCodeAdmin" runat="server" CssClass="textboxs" TextMode="Number" placeHolder="Ingresa tu codigo de Admin" CausesValidation="True" EnableTheming="True"></asp:TextBox>
                    <div class="">
                        <asp:Button ID="btnLogin" runat="server" CssClass="button" Text="Inicio Sesion" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnRegister" runat="server" CssClass="button" Text="¿No tienes cuenta? Registrate" OnClick="btnRegister_Click"/>
                    </div>
                    <br />
                    <asp:Label ID="lblAlertas" CssClass="alertas" runat="server"></asp:Label>

                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
