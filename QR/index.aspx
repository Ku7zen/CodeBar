<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QR.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>  
                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                <asp:Button ID="btnGenerar" runat="server"  text="Generar codigo" OnClick="btnGenerar_Click" /> 
                <hr />
            </div>
            <div ID="panelresultado" class="panel">
                <img runat="server" id="imgCtrl" />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
