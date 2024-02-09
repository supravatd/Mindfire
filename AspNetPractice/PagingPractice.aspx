<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagingPractice.aspx.cs" Inherits="AspNetPractice.PagingPractice" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            OnPageIndexChanging="OnPaging" PageSize="10" AllowCustomPaging="true" AllowSorting="true" OnSorting="GridView_Sorting">
            <PagerSettings Mode="Numeric" />
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerId"/>
                <asp:BoundField ItemStyle-Width="150px" DataField="ContactName" HeaderText="Contact Name" SortExpression="ContactName"/>
                <asp:BoundField ItemStyle-Width="150px" DataField="City" HeaderText="City"  SortExpression="City"/>
                <asp:BoundField ItemStyle-Width="150px" DataField="Country" HeaderText="Country"  SortExpression="Country"/>
            </Columns>
        </asp:GridView>
        <asp:DropDownList ID="ddlPageNumber" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageNumber_Changed" />
        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="GoButton_Clicked" />
    </form>
</body>
</html>
