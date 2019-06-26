<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Codebar.aspx.cs" Inherits="QR.Codebar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" text="Ingresa la clave aqui  "/> 
            <asp:TextBox ID="txtCodigo" runat="server"/>
            <br />
            <br />
            <asp:Button ID="btnGenerar" runat="server"  text="Generar codigo" OnClick="btnGenerar_Click" /> 
            <asp:Button ID="btnGuardar" runat="server"  text="Guardar codigo" OnClick="btnGuardar_Click" /> 
        </div>
        <div id="paneldiv" runat="server">
            <panel id="panelrespuesta" runat="server" />
            <asp:Image  runat="server" ID="imgCtrl"/>
        </div>
    </form>
</body>
</html>
