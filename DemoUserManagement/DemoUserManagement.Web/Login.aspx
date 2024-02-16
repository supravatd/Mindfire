<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoUserManagement.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container">
            <div class="row h-100 justify-content-center align-items-center">
                <div class="col-md-6 col-sm-12">
                    <div class="card shadow-lg">
                        <div class="card-header">
                            <h3 class="card-title text-center">Login here...</h3>
                        </div>
                        <div class="card-body">
                                <div class="form-group">
                                    <label for="txtEmail" class="form-label">Username:</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtPassword" class="form-label">Password:</label>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="password" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="d-flex justify-content-between mt-3">
                                    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" OnClick="Login" Text="Login" />
                                    <asp:HyperLink ID="Register" runat="server" NavigateUrl="~/UserForm.aspx" CssClass="text-link">New User?? Register Here!!</asp:HyperLink>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
