<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReqValidator.aspx.cs" Inherits="AspNetValidator.ReqValidator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 165px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">User Name</td>
                <td>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="username" ErrorMessage="Please enter a user name" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td>
                    <asp:TextBox ID="password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="pass" runat="server" ControlToValidate="password" ErrorMessage="Please enter a password"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="login" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
