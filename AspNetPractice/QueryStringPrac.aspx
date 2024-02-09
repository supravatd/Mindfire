<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryStringPrac.aspx.cs" Inherits="AspNetPractice.QueryStringPrac" %>

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
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Age:</td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Roll No:</td>
                    <td>
                        <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
</html>