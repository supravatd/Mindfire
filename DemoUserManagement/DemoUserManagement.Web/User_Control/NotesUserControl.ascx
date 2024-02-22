<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesUserControl.ascx.cs" Inherits="DemoUserManagement.Web.User_Control.NotesUserControl" %>

<style>
    .notesDisplay {
        height: 200px;
        width: 10vw;
    }
</style>

<h5>Add Notes:</h5>
<div class="container-fluid">
    <div class="row">
        <div class="col-md-6">
            <div class="notesDisplay">
                <div class="form-group">
                    <input type="text" id="txtNotes" placeholder="Add Notes Here" class="form-control notes" />
                </div>
                <br />
                <div class="form-group">
                    <button type="button" id="bttnAddNotes" class="btn btn-primary" onclick="addNotes()">Add</button>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <asp:HiddenField ID="hfObjectId" runat="server" />
            <asp:HiddenField ID="hfNoteObjType" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:GridView ID="NotesGrid" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" AllowCustomPaging="true" AllowSorting="true" AllowPaging="true"
                        PageSize="3" OnSorting="NotesGrid_Sorting" OnPageIndexChanging="NotesGrid_PageIndexChanging" EnableViewState="true">
                        <Columns>
                            <asp:BoundField HeaderText="Note ID" DataField="NoteID" ItemStyle-Width="150px" SortExpression="NoteID" />
                            <asp:BoundField HeaderText="Note" DataField="NoteData" ItemStyle-Width="150px" SortExpression="NoteData" />
                            <asp:BoundField HeaderText="Object ID" DataField="ObjectID" ItemStyle-Width="150px" SortExpression="ObjectID" />
                            <asp:BoundField HeaderText="Object Type" DataField="ObjectType" ItemStyle-Width="150px" SortExpression="ObjectType" />
                            <asp:BoundField HeaderText="Added On" DataField="DateTimeAdded" ItemStyle-Width="300px" SortExpression="DateTimeAdded" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
</div>


