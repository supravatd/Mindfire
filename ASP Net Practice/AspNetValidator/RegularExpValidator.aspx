<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegularExpValidator.aspx.cs" Inherits="AspNetValidator.RegularExpValidator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Email ID</td>
                    <td>
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="username"
                            ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Save" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
