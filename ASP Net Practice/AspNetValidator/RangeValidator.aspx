<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RangeValidator.aspx.cs" Inherits="AspNetValidator.RangeValidator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 82px;
        }

        .auto-style2 {
            width: 100%;
        }

        .auto-style3 {
            width: 89px;
        }

        .auto-style4 {
            margin-left: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <p class="auto-style4">
                Enter value between 100 and 200<br />
            </p>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="Enter a value"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="uesrInput" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="uesrInput"
                            ErrorMessage="Enter value in specified range" ForeColor="Red" MaximumValue="199" MinimumValue="101"
                            SetFocusOnError="True" Type=" Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Save" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
