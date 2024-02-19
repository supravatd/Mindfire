<%@ Page Title="User Form" Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="DemoUserManagement.Web.RegisterForm" MasterPageFile="~/Site.Master" %>


<%@ Register Src="~/User_Control/NotesUserControl.ascx" TagPrefix="uc1" TagName="Notes" %>
<%@ Register Src="~/User_Control/DocumentUserControl.ascx" TagPrefix="uc1" TagName="DocumentUserControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">
    <div class="container">
        <header>Mindfire Solutions Form</header>


        <div>
            <!-- Personal Details Field -->
            <fieldset id="personalDetails">
                <span class="title">Personal Details</span>
                <div class="fields" id="userDetails">

                    <div class="row">
                        <div class="name col-sm-4">
                            <label for="txtFirstName">First Name<sup>*</sup></label>
                            <input id="txtFirstName" class="form-control" name="txtFirstName" type="text" display-all-data="data"
                                data-entry-label="FirstName" placeholder="First Name" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label for="txtMiddleName">Middle Name</label>
                            <input id="txtMiddleName" class="form-control" name="txtMiddleName" display-all-data="data" type="text"
                                data-entry-label="MiddleName" placeholder="Middle Name" />
                        </div>
                        <div class="name col-sm-4">
                            <label for="txtLastName">Last Name</label>
                            <input id="txtLastName" class="form-control" display-all-data="data" type="text" data-entry-label="LastName"
                                name="txtLastName" placeholder="Last name" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="name col-sm-4">
                            <label for="txtFatherFirstName">Father's First Name<sup>*</sup></label>
                            <input id="txtFatherFirstName" class="form-control" name="txtFatherFirstName" type="text" display-all-data="data"
                                data-entry-label="FatherFirstName" placeholder="First Name" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label for="txtFatherMiddleName">Father's Middle Name</label>
                            <input id="txtFatherMiddleName" class="form-control" name="txtFatherMiddleName" display-all-data="data" type="text"
                                data-entry-label="FatherMiddleName" placeholder="Middle Name" />
                        </div>
                        <div class="name col-sm-4">
                            <label for="txtFatherLastName">Father's Last Name</label>
                            <input id="txtFatherLastName" class="form-control" display-all-data="data" type="text" data-entry-label="FatherLastName"
                                name="txtFatherLastName" placeholder="Last name" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="name col-sm-4">
                            <label for="txtMotherFirstName">Mother's First Name<sup>*</sup></label>
                            <input id="txtMotherFirstName" class="form-control" name="txtMotherFirstName" type="text" display-all-data="data"
                                data-entry-label="MotherFirstName" placeholder="First Name" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label for="txtMotherMiddleName">Mother's Middle Name</label>
                            <input id="txtMotherMiddleName" class="form-control" name="txtMotherMiddleName" display-all-data="data" type="text"
                                data-entry-label="MotherMiddleName" placeholder="Middle Name" />
                        </div>
                        <div class="name col-sm-4">
                            <label for="txtMotherLastName">Mother's Last Name</label>
                            <input id="txtMotherLastName" class="form-control" display-all-data="data" type="text" data-entry-label="MotherLastName"
                                name="txtMotherLastName" placeholder="Last name" />
                        </div>
                    </div>

                    <div class="row ">
                        <div class="email col-sm-4">
                            <label for="email">Email<sup>*</sup></label>
                            <input id="txtEmail" class="form-control" display-all-data="data" type="email" data-entry-label="Email" name="email"
                                placeholder="Enter your email" data-bs-toggle="tooltip" oninput="checkEmailAvailability()" />
                            <div class="error"></div>
                        </div>

                        <div class="dateofBirth col-sm-4">
                            <label for="dateofBirth">Date of Birth<sup>*</sup></label>
                            <input id="txtDateOfBirth" class="form-control" display-all-data="data" type="date" name="dateofBirth"
                                data-entry-label="Dob" placeholder="Enter birth date" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>

                        <div class="name col-sm-4">
                            <label>Blood Group<sup>*</sup></label>
                            <select id="ddlBloodGroup" name="bloodGroup" class="form-control" display-all-data="data" data-entry-label="BloodGroup"
                                data-bs-toggle="tooltip">
                                <option>Select</option>
                                <option>A+</option>
                                <option>B+</option>
                                <option>AB+</option>
                                <option>O+</option>
                            </select>
                            <div class="error"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label for="txtPassword">Password<sup>*</sup></label>
                            <input type="password" id="txtPassword" class="password form-control" placeholder="Enter your password" title="Password" data-entry-label="Password" />
                            <div class="error"></div>
                        </div>
                        <div class="mobile col-sm-4 row">
                            <label for="txtMobile">Mobile No.<sup>*</sup></label>
                            <div class="col-sm-12">
                                <input type="text" id="txtMobile" class="no form-control" placeholder="Enter your number" title="Mobile No" data-entry-label="MobileNo" />
                                <div class="error"></div>
                            </div>
                        </div>
                        <div class="id col-sm-4 row">
                            <label for="ddlIdType">ID<sup>*</sup></label>
                            <div class="col-sm-3">
                                <select id="ddlIdType" class="selectIdType form-control" title="IDType" data-entry-label="IDType">
                                    <option value="">ID type</option>
                                    <option value="Aadhar">Aadhar</option>
                                    <option value="Pan">Pan</option>
                                    <option value="DL">DL</option>
                                    <option value="Voter">Voter</option>
                                </select>
                            </div>
                            <div class="col-sm-5">
                                <input type="text" id="txtIdNumber" class="idNumber form-control" placeholder="Select ID Type First" title="ID No" data-entry-label="IDNo" />
                                <div class="error"></div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="gender col-sm-4">
                            <label for="gender">Gender</label>
                            <div id="radioGender">
                                <input type="radio" id="rbMale" display-all-data="data" name="gender" class="radio"
                                    data-entry-label="Gender" value="Male" />
                                <label for="male">Male</label>

                                <input type="radio" id="rbFemale" display-all-data="data" name="gender" class="radio" value="Female"
                                    data-entry-label="Gender" />
                                <label for="female">Female</label>

                                <input type="radio" id="rbOthers" display-all-data="data" name="gender" class="radio" value="Others"
                                    data-entry-label="Gender" />
                                <label for="others">Others</label>
                            </div>
                        </div>
                        <div class="hobbies col-sm-8">
                            <label for="hobbies">Hobbies</label>
                            <div id="checkHobbies">
                                <input type="checkbox" id="chkReading" value="Reading" name="hobbies" display-all-data="data"
                                    data-entry-label="Hobbies" />
                                <label for="reading">Reading</label>

                                <input type="checkbox" id="chkSinging" value="Singing" name="hobbies" display-all-data="data"
                                    data-entry-label="Hobbies" />
                                <label for="singing">Singing</label>

                                <input type="checkbox" id="chkDancing" value="Dancing" name="hobbies" display-all-data="data"
                                    data-entry-label="Hobbies" />
                                <label for="dancing">Dancing</label>

                                <input type="checkbox" id="chkTravelling" value="Traveling" name="hobbies" display-all-data="data"
                                    data-entry-label="Hobbies" />
                                <label for="traveling">Traveling</label>

                                <input type="checkbox" id="chkGaming" value="Gaming" name="hobbies" display-all-data="data"
                                    data-entry-label="Hobbies" />
                                <label for="gaming">Gaming</label>

                                <input type="checkbox" id="chkCoding" value="Coding" name="hobbies" display-all-data="data"
                                    data-entry-label="Hobbies" />
                                <label for="coding">Coding</label>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

            <!-- Address Details Field -->
            <fieldset id="addressDetails">
                <span class="title">Address Details</span>
                <h3>Current Address</h3>
                <div>
                    <div id="presentAddress" class="fields">
                        <div class="row">
                            <div class="name col-sm-4">
                                <label>House/Flat No.<sup>*</sup></label>
                                <input id="txtPresentHouse" class="form-control" type="text" placeholder="Door No" data-entry-label="DoorNo"
                                    presentaddress="presentAddrHouseNo" display-all-data="data" name="presentAddressHouse"
                                    data-entry-catg="presentAddress" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                            <div class="name col-sm-4">
                                <label>Street</label>
                                <input id="txtPresentStreet" class="form-control" type="text" data-entry-label="Street" placeholder="Enter Street Name"
                                    name="presentAddressStreet" data-entry-catg="presentAddress" />
                            </div>

                            <div class="name col-sm-4">
                                <label>City<sup>*</sup></label>
                                <input id="txtPresentCity" class="form-control" type="text" placeholder="Enter city" data-entry-label="City"
                                    display-all-data="data" data-entry-catg="presentAddress" name="presentAddressCity"
                                    data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="name col-sm-4">
                                <label>Pincode<sup>*</sup></label>
                                <input id="txtPresentPincode" class="form-control" display-all-data="data" type="number" data-entry-label="PostalCode"
                                    placeholder="Enter area code" name="presentAddressPincode" data-entry-catg="presentAddress"
                                    data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>

                            <div class="name col-sm-4">
                                <label>Country<sup>*</sup></label>
                                <select id="ddlPresentCountry" data-bs-toggle="tooltip" class="Country form-control"
                                    data-entry-catg="presentAddress" display-all-data="data" name="presentAddressCountry"
                                    data-entry-label="CountryId">
                                    <option>Select</option>
                                </select>
                                <div class="error"></div>
                            </div>

                            <div class="name col-sm-4">
                                <label>State<sup>*</sup></label>
                                <select id="ddlPresentState" class="State form-control" data-bs-toggle="tooltip"
                                    data-entry-catg="presentAddress" display-all-data="data" name="presentAddressState"
                                    data-entry-label="StateId">
                                    <option>Select</option>
                                </select>
                                <div class="error"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3>Permanent Address</h3>
                <input type="checkbox" name="sameAsPresent" id="sameAsPresent" />
                <label for="sameAsPresent" class="sameAsPresentAdd">Same as current address</label>
                <div>
                    <div id="permanentAddress" class="fields">
                        <div class="row">
                            <div class="name col-sm-4">
                                <label>House/Flat No.<sup>*</sup></label>
                                <input id="txtPermanentHouseNo" class="form-control" name="permanentAddressHouseNo" type="text" data-entry-label="DoorNo"
                                    display-all-data="data" placeholder="Door No" data-entry-catg="permanentAddress"
                                    data-permanent-address="false" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                            <div class="name col-sm-4">
                                <label>Street</label>
                                <input id="txtPermanentStreet" class="form-control" name="permanentAddressStreet" type="text" data-entry-label="Street"
                                    placeholder="Street Name" display-all-data="data" data-permanent-address="false"
                                    data-entry-catg="permanentAddress" />
                            </div>

                            <div class="name col-sm-4">
                                <label>City<sup>*</sup></label>
                                <input id="txtPermanentCity" class="form-control" name="permanentAddressCity" display-all-data="data"
                                    data-entry-label="City" type="text" placeholder="Enter your city" data-entry-catg="permanentAddress"
                                    data-permanent-address="false" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="name col-sm-4">
                                <label>Pincode<sup>*</sup></label>
                                <input id="txtPermanentPincode" class="form-control" name="permanentAddressPincode" display-all-data="data" type="number"
                                    data-entry-label="Postalcode" placeholder="Enter area code" data-permanent-address="false"
                                    data-entry-catg="permanentAddress" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>

                            <div class="name col-sm-4">
                                <label>Country<sup>*</sup></label>
                                <select id="ddlPermanentCountry" class="Country form-control" data-entry-catg="permanentAddress"
                                    display-all-data="data" data-bs-toggle="tooltip" name="permanentAddressCountry"
                                    data-entry-label="CountryId" data-permanent-address="false">
                                    <option>Select</option>
                                </select>
                                <div class="error"></div>
                            </div>

                            <div class="name col-sm-4">
                                <label data-entry-label="data">State<sup>*</sup></label>
                                <select id="ddlPermanentState" class="State form-control" data-entry-catg=" permanentAddress"
                                    display-all-data="data" data-bs-toggle="tooltip" name="permanentAddressState"
                                    data-entry-label="StateId" data-permanent-address="false">
                                    <option>Select</option>
                                </select>
                                <div class="error"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

            <br />
            <div class="form-group">
                <div class="d-flex align-items-center">
                    <h5 class="mr-6 mb-1">Upload Resume:</h5>
                    <div class="input-group">
                        <label id="lblFileName"></label>
                        <input type="hidden" id="FileGuid" />
                        <div class="custom-file">
                            <input type="file" id="FileUploadControl" class="custom-file-input" />
                        </div>
                    </div>
                </div>
            </div>
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <br />
            <uc1:Notes runat="server" ID="NotesUserControl" />
            <br />
            <uc1:DocumentUserControl runat="server" ID="DocumentUserControl" />
            <br />
            <div class="text-center">
                <button id="bttnSubmit" type="button" class="btn btn-primary w-25" data-toggle="modal">Submit</button>
                <button id="bttnUpdate" type="button" class="bttn bttn-primary w-25" data-toggle="modal">Update</button>
                <input id="bttnReset" class="reset btn btn-primary w-25" type="reset" value="Reset" />
            </div>
        </div>

    </div>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js"
        integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js"
        integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>

    <script src="index.js"></script>

</asp:Content>
