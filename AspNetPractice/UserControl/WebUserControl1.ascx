<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="AspNetPractice.WebUserControl1" %>

<asp:Label ID="lblPageName" runat="server"></asp:Label>
<br/>
<asp:TextBox ID="Note" runat="server" placeholder="Add Notes For this Page" Width="1000px" Height="100px"></asp:TextBox>
<br/>
<asp:Label ID="UserId" runat="server"></asp:Label>
<asp:Button ID="Add" runat="server" Text="Add Note" OnClick="Add_Click" />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="true" OnPageIndexChanging="OnPaging"
    BackColor="White" BorderColor="#CCCCCC" BorderWidth="2px" AllowSorting="true" AllowCustomPaging="true" OnSorting="GridView_Sorting">
    <PagerSettings Mode="Numeric" />
    <Columns>
        <asp:BoundField HeaderText="Note ID" DataField="NoteID" ItemStyle-Width="150px" SortExpression="NoteID"/>
        <asp:BoundField HeaderText="Note" DataField="NoteData" ItemStyle-Width="150px" SortExpression="NoteData"/>
        <asp:BoundField HeaderText="User ID" DataField="UserID" ItemStyle-Width="150px" SortExpression="UserID"/>
        <asp:BoundField HeaderText="Page Name" DataField="PageName" ItemStyle-Width="150px" SortExpression="PageName"/>
        <asp:BoundField HeaderText="Added On" DataField="DateTimeAdded" ItemStyle-Width="300px" SortExpression="DateTimeAdded"/>
    </Columns>
</asp:GridView>
<asp:DropDownList ID="ddlPageNumber" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageNumber_Changed" />
        

