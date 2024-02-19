<%@ Page Title="User List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="DemoUserManagement.Web.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" cssclass="panel panel-default" />
    <div>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel">
            <ContentTemplate>
                <asp:GridView ID="DisplayUser" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    OnRowEditing="DisplayUser_Edit" AllowCustomPaging="true" ClientIDMode="Static"
                    AllowSorting="true" OnSorting="DisplayUser_Sorting" OnPageIndexChanging="DisplayUser_PageIndexChanging"
                    DataKeyNames="UserId" PageSize="5" AutoPostBack="true">
                    <Columns>
                        <asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Dob" HeaderText="Date Of Birth" SortExpression="Dob" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile" SortExpression="MobileNo" />
                        <asp:BoundField DataField="IDType" HeaderText="ID Type" SortExpression="IDType" />
                        <asp:BoundField DataField="IDNo" HeaderText="ID No." SortExpression="IDNo" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                        <asp:BoundField DataField="Hobbies" HeaderText="Hobbies" />
                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                                <%# GenerateDownloadLink(Eval("FileGuid"), Eval("FileOriginal")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("UserId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Visible="True" />
                </asp:GridView>
                <asp:Button runat="server" ID="NewUser" OnClick="NewUser_Click" Text="Add User" UseSubmitBehavior="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
