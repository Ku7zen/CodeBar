<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="codigobarra.aspx.cs" Inherits="QR.codigobarra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 52%;
        }
        .auto-style2 {
            height: 85px;
            width: 339px;
        }
        .auto-style3 {
            height: 85px;
            width: 212px;
        }
        .auto-style4 {
            width: 212px;
        }
        .auto-style5 {
            width: 339px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;</div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Ingresa la clave de producto:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">
                    <br />
                    <asp:Button ID="Button1" runat="server" Height="33px" OnClick="Button1_Click" Text="Generar Codigo de barras" Width="203px" />
                    <br />
                </td>
            </tr>
        </table>
        <asp:Label ID="Labelbar" runat="server" Text="Codigo de Barras"></asp:Label>
        <p>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </p>
    </form>
</body>
</html>
