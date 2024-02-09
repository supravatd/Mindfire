<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewCrud.aspx.cs" Inherits="AspNetPractice.GridViewCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
                OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                AllowPaging="True" PageSize="10" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Contact Name">
                        <ItemTemplate>
                            <asp:Label ID="City" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCountry" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewContactName" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>


        </div>
    </form>
</body>
</html>
