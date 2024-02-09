<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="AspNetPractice.UserForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 278px;
        }

        .auto-style3 {
            width: 278px;
            height: 23px;
        }

        .auto-style4 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DataGrid ID="DataGrid1" runat="server">
        </asp:DataGrid>
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="username" runat="server" required="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="EmailIdLabel" runat="server" Text="Email ID"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailID" runat="server" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label></td>
                    <td>
                        <asp:RadioButton ID="Male" runat="server" GroupName="gender" Text="Male" />
                        <asp:RadioButton ID="Female" runat="server" GroupName="gender" Text="Female" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="CourseLabel" runat="server" Text="Select Course"></asp:Label>s</td>
                    <td>
                        <asp:CheckBox ID="CSharp" runat="server" Text="C#" />
                        <asp:CheckBox ID="Sql" runat="server" Text="SQL" />
                        <asp:CheckBox ID="AspNet" runat="server" Text="ASP.Net" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="message" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
    </form>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="ShowUserNameLabel" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="ShowUserName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="ShowEmailIDLabel" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="ShowEmail" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="ShowGenderLabel" runat="server"></asp:Label></td>
            <td class="auto-style4">
                <asp:Label ID="ShowGender" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="ShowCourseLabel" runat="server"></asp:Label></td>
            <td>
                <asp:Label ID="ShowCourses" runat="server"></asp:Label></td>
        </tr>
    </table>
</body>
</html>
