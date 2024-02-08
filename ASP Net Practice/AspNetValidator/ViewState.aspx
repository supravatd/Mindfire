<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewState.aspx.cs" Inherits="AspNetValidator.ViewState" %>

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
                    <td>Username:</td>
                    <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="RestoreButton" runat="server" Text="Restore" OnClick="btnRestore_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
