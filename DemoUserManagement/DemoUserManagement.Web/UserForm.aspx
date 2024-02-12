﻿<%@ Page Title="User Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="DemoUserManagement.Web.UserForm" %>

<%@ Register Src="~/User_Control/NotesUserControl.ascx" TagPrefix="uc1" TagName="Notes" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlPersonalDetails" runat="server" GroupingText="Personal Details">
        <span class="title">Personal Details</span>
        <div class="fields">

            <div class="row">
                <div class="name col-sm-4">
                    <asp:Label ID="lblFirstName" runat="server">First Name<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" ToolTip="First Name" data-entry-label="First Name" />
                    <div class="error"></div>
                </div>
                <div class="name col-sm-4">
                    <asp:Label ID="lblMiddleName" runat="server">Middle Name<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" placeholder="Middle Name" ToolTip="Middle Name" data-entry-label="Middle Name" />
                </div>
                <div class="name col-sm-4">
                    <asp:Label ID="lblLastName" runat="server">Last Name<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name" ToolTip="Last Name" data-entry-label="Last Name" />
                </div>
            </div>

            <div class="row">
                <div class="name col-sm-4">
                    <asp:Label ID="lblFatherFirstName" runat="server" AssociatedControlID="txtFatherFirstName">Father's First Name<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtFatherFirstName" runat="server" CssClass="form-control" placeholder="First Name" ToolTip="Father's First Name" data-entry-label="Father First Name" />
                    <div class="error"></div>
                </div>
                <div class="name col-sm-4">
                    <asp:Label ID="lblFatherMiddleName" runat="server" AssociatedControlID="txtFatherMiddleName">Father's Middle Name</asp:Label>
                    <asp:TextBox ID="txtFatherMiddleName" runat="server" CssClass="form-control" placeholder="Middle Name" data-entry-label="Middle Name" />
                </div>
                <div class="name col-sm-4">
                    <asp:Label ID="lblFatherLastName" runat="server" AssociatedControlID="txtFatherLastName">Father's Last Name</asp:Label>
                    <asp:TextBox ID="txtFatherLastName" runat="server" CssClass="form-control" placeholder="Last Name" data-entry-label="Last Name" />
                </div>
            </div>

            <div class="row">
                <div class="name col-sm-4">
                    <asp:Label ID="lblMotherFirstName" runat="server" AssociatedControlID="txtMotherFirstName">Mother's First Name<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtMotherFirstName" runat="server" CssClass="form-control" placeholder="First Name" ToolTip="Mother's First Name" data-entry-label="Mother First Name" />
                    <div class="error"></div>
                </div>
                <div class="name col-sm-4">
                    <asp:Label ID="lblMotherMiddleName" runat="server" AssociatedControlID="txtMotherMiddleName">Mother's Middle Name</asp:Label>
                    <asp:TextBox ID="txtMotherMiddleName" runat="server" CssClass="form-control" placeholder="Middle Name" data-entry-label="Middle Name" />
                </div>
                <div class="name col-sm-4">
                    <asp:Label ID="lblMotherLastName" runat="server" AssociatedControlID="txtMotherLastName">Mother's Last Name</asp:Label>
                    <asp:TextBox ID="txtMotherLastName" runat="server" CssClass="form-control" placeholder="Last Name" data-entry-label="Last Name" />
                </div>
            </div>

            <div class="row ">
                <div class="email col-sm-4">
                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email" ToolTip="Email" data-entry-label="Email" />
                    <div class="error"></div>
                </div>

                <div class="dateofBirth col-sm-4">
                    <asp:Label ID="lblDateOfBirth" runat="server" AssociatedControlID="txtDateOfBirth">Date of Birth<sup>*</sup></asp:Label>
                    <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date" placeholder="Enter birth date" ToolTip="Date of Birth" data-entry-label="Date of Birth" />
                    <div class="error"></div>
                </div>


                <div class="name col-sm-4">
                    <asp:Label ID="lblBloodGroup" runat="server" AssociatedControlID="ddlBloodGroup">Blood Group<sup>*</sup></asp:Label>
                    <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control" data-entry-label="Blood Group" ToolTip="Blood Group" data-bs-toggle="tooltip">
                        <asp:ListItem Text="Select" Value="" />
                        <asp:ListItem Text="A+" Value="A+" />
                        <asp:ListItem Text="B+" Value="B+" />
                        <asp:ListItem Text="AB+" Value="AB+" />
                        <asp:ListItem Text="O+" Value="O+" />
                    </asp:DropDownList>
                    <div class="error"></div>
                </div>
            </div>

            <div class="row">
                <div class="mobile col-sm-6 row">
                    <asp:Label ID="lblMobile" runat="server" AssociatedControlID="ddlMobileCode">Mobile No.<sup>*</sup></asp:Label>
                    <div class="mobileCode col-sm-3">
                        <asp:DropDownList ID="ddlMobileCode" runat="server" CssClass="country form-control" data-entry-label="Country Code" ToolTip="Country Code">
                            <asp:ListItem Text="+91" Value="+91" />
                            <asp:ListItem Text="+1" Value="+1" />
                            <asp:ListItem Text="+44" Value="+44" />
                            <asp:ListItem Text="+975" Value="+975" />
                            <asp:ListItem Text="+39" Value="+39" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="no form-control" data-entry-label="Mobile No" placeholder="Enter your number" ToolTip="Mobile No" data-bs-toggle="tooltip" />
                        <div class="error"></div>
                    </div>
                </div>
                <div class="id col-sm-6 row">
                    <asp:Label ID="lblId" runat="server" AssociatedControlID="ddlIdType">ID<sup>*</sup></asp:Label>
                    <div class="idNo col-sm-4">
                        <asp:DropDownList ID="ddlIdType" runat="server" CssClass="selectIdType form-control" data-entry-label="ID Type" ToolTip="ID Type">
                            <asp:ListItem Text="ID type" Value="" />
                            <asp:ListItem Text="Aadhar" Value="Aadhar" />
                            <asp:ListItem Text="Pan" Value="Pan" />
                            <asp:ListItem Text="DL" Value="DL" />
                            <asp:ListItem Text="Voter" Value="Voter" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtIdNumber" runat="server" CssClass="idNumber form-control" data-entry-label="ID No" placeholder="Select ID Type First" ToolTip="ID No" data-bs-toggle="tooltip" />
                        <div class="error"></div>
                    </div>
                </div>
            </div>

            <div class="gender col-sm-4">
                <asp:Label ID="lblGender" runat="server" AssociatedControlID="rbMale">Gender</asp:Label>
                <div id="radioGender">
                    <asp:RadioButton ID="rbMale" runat="server" CssClass="radio" GroupName="gender" data-entry-label="Gender" Text="Male" value="Male" />
                    <%--<label for="male">Male</label>--%>

                    <asp:RadioButton ID="rbFemale" runat="server" CssClass="radio" GroupName="gender" data-entry-label="Gender" Text="Female" value="Female" />
                    <%--<label for="female">Female</label>--%>

                    <asp:RadioButton ID="rbOthers" runat="server" CssClass="radio" GroupName="gender" data-entry-label="Gender" Text="Others" value="Others" />
                    <%--<label for="others">Others</label>--%>
                </div>
            </div>

            <div class="hobbies col-sm-8">
                <asp:Label ID="lblHobbies" runat="server">Hobbies</asp:Label>
                <div id="checkHobbies">
                    <asp:CheckBox ID="chkReading" runat="server" Text="Reading" CssClass="checkbox" value="Reading" data-entry-label="Hobbies" />
                    <asp:CheckBox ID="chkSinging" runat="server" Text="Singing" CssClass="checkbox" value="Singing" data-entry-label="Hobbies" />
                    <asp:CheckBox ID="chkDancing" runat="server" Text="Dancing" CssClass="checkbox" value="Dancing" data-entry-label="Hobbies" />
                    <asp:CheckBox ID="chkTraveling" runat="server" Text="Traveling" CssClass="checkbox" value="Traveling" data-entry-label="Hobbies" />
                    <asp:CheckBox ID="chkGaming" runat="server" Text="Gaming" CssClass="checkbox" value="Gaming" data-entry-label="Hobbies" />
                    <asp:CheckBox ID="chkCoding" runat="server" Text="Coding" CssClass="checkbox" value="Coding" data-entry-label="Hobbies" />
                </div>
            </div>
        </div>
    </asp:Panel>


    <asp:Panel ID="pnlAddressDetails" runat="server" GroupingText="Address Details">
        <span class="title">Address Details</span>

        <h3>Current Address</h3>
        <div>
            <div class="fields">
                <div class="row">
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPresentAddressHouse" runat="server">House/Flat No.<sup>*</sup></asp:Label>
                        <asp:TextBox ID="txtPresentAddressHouse" runat="server" CssClass="form-control" placeholder="Door No" data-entry-label="Door No" presentAddress="presentAddrHouseNo" data-entry-catg="presentAddress" data-bs-toggle="tooltip" />
                        <div class="error"></div>
                    </div>
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPresentAddressStreet" runat="server">Street</asp:Label>
                        <asp:TextBox ID="txtPresentAddressStreet" runat="server" CssClass="form-control" placeholder="Enter Street Name" data-entry-label="Street" name="presentAddressStreet" data-entry-catg="presentAddress" />
                    </div>
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPresentAddressCity" runat="server">City<sup>*</sup></asp:Label>
                        <asp:TextBox ID="txtPresentAddressCity" runat="server" CssClass="form-control" placeholder="Enter city" data-entry-label="City" display-all-data="data" data-entry-catg="presentAddress" name="presentAddressCity" data-bs-toggle="tooltip" />
                        <div class="error"></div>
                    </div>
                </div>

                <div class="row">
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPresentAddressPincode" runat="server">Pincode<sup>*</sup></asp:Label>
                        <asp:TextBox ID="txtPresentAddressPincode" runat="server" CssClass="form-control" data-entry-label="Pincode" placeholder="Enter area code" name="presentAddressPincode" data-entry-catg="presentAddress" data-bs-toggle="tooltip" />
                        <div class="error"></div>
                    </div>

                    <div class="name col-sm-4">
                        <asp:Label ID="lblPresentAddressCountry" runat="server">Country<sup>*</sup></asp:Label>
                        <asp:DropDownList ID="ddlPresentAddressCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PresentCountryState" CssClass="Country form-control" data-bs-toggle="tooltip" data-entry-catg="presentAddress" display-all-data="data" name="presentAddressCountry" data-entry-label="Country">
                        </asp:DropDownList>
                        <div class="error"></div>
                    </div>

                    <div class="name col-sm-4">
                        <asp:Label ID="lblPresentAddressState" runat="server">State<sup>*</sup></asp:Label>
                        <asp:DropDownList ID="ddlPresentAddressState" runat="server" CssClass="State form-control" data-bs-toggle="tooltip" data-entry-catg="presentAddress" display-all-data="data" name="presentAddressState" data-entry-label="State">
                        </asp:DropDownList>
                        <div class="error"></div>
                    </div>
                </div>
            </div>
        </div>

        <h3>Permanent Address</h3>
        <asp:CheckBox ID="chkSameAsPresent" runat="server" AutoPostBack="true" OnCheckedChanged="SameAsPresent_Check" Text="Same as current address" CssClass="sameAsPresentAdd" />
        <div>
            <div class="fields">
                <div class="row">
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPermanentAddressHouseNo" runat="server">House/Flat No.<sup>*</sup></asp:Label>
                        <asp:TextBox ID="txtPermanentAddressHouseNo" runat="server" CssClass="form-control" data-entry-label="House No" placeholder="Door No" display-all-data="data" data-entry-catg="permanentAddress" data-permanent-address="false" data-bs-toggle="tooltip"></asp:TextBox>
                        <div class="error"></div>
                    </div>
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPermanentAddressStreet" runat="server">Street</asp:Label>
                        <asp:TextBox ID="txtPermanentAddressStreet" runat="server" CssClass="form-control" data-entry-label="Street" placeholder="Street Name" display-all-data="data" data-permanent-address="false" data-entry-catg="permanentAddress"></asp:TextBox>
                    </div>
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPermanentAddressCity" runat="server">City<sup>*</sup></asp:Label>
                        <asp:TextBox ID="txtPermanentAddressCity" runat="server" CssClass="form-control" data-entry-label="City" placeholder="Enter your city" display-all-data="data" data-entry-catg="permanentAddress" data-permanent-address="false" data-bs-toggle="tooltip"></asp:TextBox>
                        <div class="error"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPermanentAddressPincode" runat="server">Pincode<sup>*</sup></asp:Label>
                        <asp:TextBox ID="txtPermanentAddressPincode" runat="server" CssClass="form-control" data-entry-label="Pincode" placeholder="Enter area code" display-all-data="data" data-permanent-address="false" data-entry-catg="permanentAddress" data-bs-toggle="tooltip" TextMode="Number"></asp:TextBox>
                        <div class="error"></div>
                    </div>
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPermanentAddressCountry" runat="server">Country<sup>*</sup></asp:Label>
                        <asp:DropDownList ID="ddlPermanentAddressCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PermanentCountryState" CssClass="Country form-control" data-entry-catg="permanentAddress" display-all-data="data" data-bs-toggle="tooltip" name="permanentAddressCountry" data-entry-label="Country" data-permanent-address="false">
                            <asp:ListItem Text="Select" Value="" />
                        </asp:DropDownList>
                        <div class="error"></div>
                    </div>
                    <div class="name col-sm-4">
                        <asp:Label ID="lblPermanentAddressState" runat="server">State<sup>*</sup></asp:Label>
                        <asp:DropDownList ID="ddlPermanentAddressState" runat="server" CssClass="State form-control" data-entry-catg="permanentAddress" display-all-data="data" data-bs-toggle="tooltip" name="permanentAddressState" data-entry-label="State" data-permanent-address="false">
                            <asp:ListItem Text="Select" Value="" />
                        </asp:DropDownList>
                        <div class="error"></div>
                    </div>
                </div>
            </div>
        </div>





    </asp:Panel>
    <uc1:Notes runat="server" ID="NotesUserControl" PageName ="UserForm"/>
    <div>
        <div class="input-field-group buttons">
            <div class="input-field">
                    <asp:Button runat="server" ID="bttnSubmit" class="btn btn-primary w-25" ClientIDMode="Static" Text="Submit" OnClick="Submit_Click" UseSubmitBehavior="false" />
                    <asp:Button runat="server" ID="bttnEdit" class="btn btn-primary w-25" ClientIDMode="Static" Text="Update" OnClick="Update_Click" />
            </div>
        </div>
    </div>
</asp:Content>