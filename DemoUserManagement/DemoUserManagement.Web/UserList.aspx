<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="DemoUserManagement.Web.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Management</title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="DisplayUser" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" OnSelectedIndexChanged="DisplayUser_Edit" AllowPaging="true" PageSize="5"
                AllowSorting="true" OnSorting="DisplayUser_Sorting" OnPageIndexChanging="DisplayUser_Paging">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FatherFirstName" HeaderText="Father Name" />
                    <asp:BoundField DataField="MotherFirstName" HeaderText="Mother Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Dob" HeaderText="Date Of Birth" SortExpression="Dob" DataFormatString="{0:d}"/>
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
