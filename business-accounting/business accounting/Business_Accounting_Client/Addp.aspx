<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addp.aspx.cs" Inherits="Inventory_Management_Client.Addp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            NAME:&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            QUANTITY:</p>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        BRAND:<p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        PRICE:<br />
        <br />
        <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
        <br />
        <br />
        CHECKED BY:<br />
        <p>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            DATE OF ARRIVAL:</p>
        <asp:TextBox ID="TextBox6" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD" />
        </p>
    </form>
</body>
</html>