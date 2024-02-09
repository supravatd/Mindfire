<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practice.aspx.cs" Inherits="AspNetPractice.Practice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.Net User Form</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            margin-left: 0px;
        }

        .auto-style3 {
            width: 121px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>Provide the Following Details:</h4>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Email</td>
                    <td>
                        <asp:TextBox ID="email" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Password</td>
                    <td>
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td>
                        <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="UserName" runat="server" Text="User Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" AccessKey="C" TabIndex="1" BackColor="LightGray" BorderColor="Black"
                            BorderWidth="2px" Font-Names="Arial" Font-Size="12pt" ForeColor="Blue" Placeholder="Example Text" ToolTip="This is a tooltip"
                            Visible="true" Height="20px" Width="200px" MaxLength="50" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Text="Upload a File"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" /></td>
                </tr>

            </table>
            <div>
                <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName="Gender" />
                <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="Gender" />
            </div>
            <div>
                <asp:Label ID="Hobbies" runat="server" Text="Hobbies:"></asp:Label>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Cricket" />
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Football" />
                <asp:CheckBox ID="CheckBox3" runat="server" Text="VolleyBall" />
            </div>

            <div>
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                <asp:DataList runat="server" DataSourceID="SqlDataSource1" ID="ctl08">

                    <ItemTemplate>
                        name:  
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("firstname") %>' />
                        <br />
                    </ItemTemplate>

                </asp:DataList>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ConnectionStrings:StudentConnectionString2 %>" SelectCommand="SELECT * FROM [student]"></asp:SqlDataSource>

            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </div>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Click here To know more " NavigateUrl="www.javatpoint.com"></asp:HyperLink>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">ASP.Net</asp:LinkButton>
            </div>
        </div>
        <div>&nbsp;</div>
    </form>
    <asp:Label runat="server" ID="genderId"></asp:Label>
    <asp:Label runat="server" ID="ShowDate"></asp:Label>
    <p>
        Courses Selected:
        <asp:Label runat="server" ID="ShowCourses"></asp:Label>
    </p>
    <asp:Label runat="server" ID="LinkButton"></asp:Label>
    <asp:Label runat="server" ID="FileUploadStatus"></asp:Label>
    <asp:Label ID="ConfirmPassword" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Gender" runat="server"></asp:Label>
</body>
</html>
