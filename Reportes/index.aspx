<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Reportes.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
     
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 97%;
            height: 228px;
            margin-bottom: 48px;
        }
        .auto-style3 {
            width: 121px;
            height: 43px;
        }
        .auto-style8 {
            height: 73px;
        }
        .auto-style9 {
            width: 277px;
            height: 43px;
        }
        .auto-style10 {
            height: 88px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Consulta Codigo de barra"></asp:Label>
        <p>
            Puedes ingresar la clave o generar una nueva</p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Ingresa la clave:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox1"  runat="server" Width="210px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" ForeColor="#990000" Text="Ingresa solo numeros" Visible="False"></asp:Label>
                </td>
                <td rowspan="2">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <br />
                    <asp:Button ID="Button3" runat="server" Height="24px" Text="Agregar a pdf" Width="262px" OnClick="Button3_Click" Visible="False" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style10" colspan="2">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generar codigo de barras" Width="294px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">
                    <br />
                    producto sin clave:<br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="registrar un nuevo producto" />
                </td>
                <td class="auto-style8">
                    <asp:LinkButton ID="Button4" target runat="server" Text="Ver PDF" Width="163px" OnClick="Button4_Click" />
                </td>
            </tr>
            </table>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
