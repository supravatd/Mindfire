<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentUserControl.ascx.cs" Inherits="DemoUserManagement.Web.User_Control.DocumentUserControl" %>


<div class="form-group">
    <label for="ddlDocumentType">Select Document Type:</label>
    <asp:DropDownList ID="ddlDocumentType" runat="server" CssClass="form-control" DataTextField="DocumentTypeName" DataValueField="DocumentTypeID"></asp:DropDownList>
</div>
<div class="form-group">
    <label for="fileUpload">Upload Document:</label>
    <div class="input-group">
        <div class="custom-file">
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" />
        </div>
        <div class="input-group-append">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="btnUpload_Click" />
        </div>
    </div>
</div>
<br />
<div class="col-md-6">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="DocumentGrid" runat="server" AutoGenerateColumns="False" ClientIDMode="Static" AllowCustomPaging="true"
                AllowSorting="true" AllowPaging="true" PageSize="2" OnSorting="DocumentGrid_Sorting" OnPageIndexChanging="DocumentGrid_PageIndexChanging" EnableViewState="true">
                <Columns>
                    <asp:BoundField DataField="DocumentID" HeaderText="Document ID" SortExpression="DocumentID" />
                    <asp:BoundField DataField="ObjectID" HeaderText="Object ID" SortExpression="ObjectID" />
                    <asp:BoundField DataField="ObjectType" HeaderText="Object Type" SortExpression="ObjectType" />
                    <asp:BoundField DataField="DocumentType" HeaderText="Document Type" SortExpression="DocumentType" />
                    <asp:BoundField DataField="DocumentOriginalName" HeaderText="Document Original Name" SortExpression="DocumentOriginalName" />
                    <asp:TemplateField HeaderText="Download File">
                        <ItemTemplate>
                            <asp:HyperLink ID="hypDownload" runat="server" Text="Download" NavigateUrl='<%# $"FileDownloadHandler.ashx?fileName="+Eval("DocumnetNameonDisk") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AddedOn" HeaderText="Added On" SortExpression="AddedOn" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
