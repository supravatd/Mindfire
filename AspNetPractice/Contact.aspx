<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AspNetPractice.Contact" %>

<%@ Register Src="~/UserControl/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <uc1:WebUserControl1 runat="server" id="WebUserControl1" PageName="Contact"/>
    </main>
</asp:Content>
