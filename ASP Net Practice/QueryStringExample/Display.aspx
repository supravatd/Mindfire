<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="QueryStringExample.Display" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Age:</td>
                    <td>
                        <asp:TextBox ID="Age" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Roll No:</td>
                    <td>
                        <asp:TextBox ID="RollNo" runat="server"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
