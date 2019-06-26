<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datos_producto.aspx.cs" Inherits="Reportes.datos_producto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Generar una nueva clave de producto"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Ingresa el nombre de producto:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="210px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btn_GuardaProducto" runat="server" OnClick="btn_GuardaProducto_Click" Text="Guardar y generar" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Regresar" runat="server" OnClick="Regresar_Click" Text="Volver" />
        </p>
    </form>
</body>
</html>
