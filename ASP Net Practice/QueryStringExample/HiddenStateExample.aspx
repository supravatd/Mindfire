<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiddenStateExample.aspx.cs" Inherits="QueryStringExample.HiddenStateExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:Label ID="lblCurrentDateTime" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
