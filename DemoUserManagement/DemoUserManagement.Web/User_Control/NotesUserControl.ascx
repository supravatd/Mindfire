<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesUserControl.ascx.cs" Inherits="DemoUserManagement.Web.User_Control.NotesUserControl" %>

<style>
    .notes{
        height:100px;
        width:1000px;
    }
    .notesDisplay{
        height:200px;
        width:100vw;
    }
</style>

<h3>Notes:</h3>
<div class="notesDisplay">
    <asp:TextBox ID="txtNotes" runat="server" placeholder="Add Notes Here" CssClass="notes" ClientIDMode="Static" BorderStyle="Groove"></asp:TextBox>
    <asp:Button ID="bttnAddNotes" runat="server" Text="Add" UseSubmitBehavior="false" />
</div>

<asp:GridView ID="NotesGrid" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" CellPadding="2" BackColor="White" 
    BorderColor="Black" BorderStyle="None" BorderWidth="2px" Height="200px" Width="1000px">
    <Columns>
        <asp:BoundField HeaderText="Note ID" DataField="NoteID" ItemStyle-Width="150px" SortExpression="NoteID"/>
        <asp:BoundField HeaderText="Note" DataField="NoteData" ItemStyle-Width="150px" SortExpression="NoteData"/>
        <asp:BoundField HeaderText="User ID" DataField="UserID" ItemStyle-Width="150px" SortExpression="UserID"/>
        <asp:BoundField HeaderText="Page Name" DataField="PageName" ItemStyle-Width="150px" SortExpression="PageName"/>
        <asp:BoundField HeaderText="Added On" DataField="DateTimeAdded" ItemStyle-Width="300px" SortExpression="DateTimeAdded"/>
    </Columns>
</asp:GridView>
