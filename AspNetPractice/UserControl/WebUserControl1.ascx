<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="AspNetPractice.WebUserControl1" %>

<asp:Label ID="lblPageName" runat="server"></asp:Label>
<br/>
<asp:TextBox ID="Note" runat="server" placeholder="Add Notes For this Page" Width="1000px" Height="100px"></asp:TextBox>
<br/>
<asp:TextBox ID="UserId" runat="server" placeholder="User ID"></asp:TextBox>
<asp:Button ID="Add" runat="server" Text="Add Note" OnClick="Add_Click" />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3"
    BackColor="White" BorderColor="#CCCCCC" BorderWidth="2px">

    <Columns>
        <asp:BoundField HeaderText="Note ID" DataField="NoteID" ItemStyle-Width="150px" />
        <asp:BoundField HeaderText="Note" DataField="NoteData" ItemStyle-Width="150px"/>
        <asp:BoundField HeaderText="User ID" DataField="UserID" ItemStyle-Width="150px"/>
        <asp:BoundField HeaderText="Page Name" DataField="PageName" ItemStyle-Width="150px"/>
        <asp:BoundField HeaderText="Added On" DataField="DateTimeAdded" ItemStyle-Width="300px"/>
    </Columns>
</asp:GridView>

