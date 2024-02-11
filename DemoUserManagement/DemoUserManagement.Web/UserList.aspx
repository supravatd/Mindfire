<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="DemoUserManagement.Web.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="DisplayUser" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" OnSelectedIndexChanged="DisplayUser_Edit">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FatherFirstName" HeaderText="Father Name" />
                    <asp:BoundField DataField="MotherFirstName" HeaderText="Mother Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Dob" HeaderText="Date Of Birth" SortExpression="Dob" />
                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile" SortExpression="MobileNo" />
                    <asp:BoundField DataField="IDType" HeaderText="ID Type" SortExpression="IDType" />
                    <asp:BoundField DataField="IDNo" HeaderText="ID No." SortExpression="IDNo" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Hobbies" HeaderText="Hobbies" />
                    <asp:ButtonField Text="Edit" CommandName="Select" runat="server" />
                </Columns>
            </asp:GridView>
            <asp:Button runat="server" ID="NewUser" OnClick="NewUser_Click" Text="Add User" UseSubmitBehavior="false" />
        </div>
    </form>
</body>
</html>
