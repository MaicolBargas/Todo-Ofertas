<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Presentacion.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Register</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <div class="container">
           <div class="form">
                <div class="login">
            <p class="tittle">Registrate</p>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="textboxs" placeHolder="Nombre"></asp:TextBox>

            <asp:TextBox ID="txtCi" runat="server" CssClass="textboxs" placeHolder="C.I"></asp:TextBox>

            <asp:TextBox ID="txtMail" runat="server" CssClass="textboxs" placeHolder="E-Mail"></asp:TextBox>

            <asp:TextBox ID="txtPassword" runat="server" CssClass="textboxs" TextMode="Password" placeHolder="Contraseña" AutoCompleteType="Disabled" CausesValidation="True"></asp:TextBox>

            <asp:Button ID="btnRegister" runat="server" CssClass="button"  Text="Registrate" OnClick="btnRegister_Click" />
                <br />  
            <asp:Label ID="lblAlertas" runat="server"></asp:Label>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
