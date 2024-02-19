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
                                <input id="txtEmail" class="form-control" type="email" placeholder="Enter Email" required />
                                <div id="emailMessage"></div>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword" class="form-label">Password:</label>
                                <input id="txtPassword" class="form-control" type="password" required />
                            </div>
                            <div class="d-flex justify-content-between mt-3">
                                <button id="bttnLogin" class="btn btn-primary" onclick="return login();">Login</button>
                                <a id="Register" href="RegisterForm.aspx" class="text-link">New User?? Register Here!!</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
        <script src="Scripts/Login.js"></script>
    </main>
</asp:Content>
