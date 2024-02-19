<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="DemoUserManagement.UserForm" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" href="style.css" />
    <title>Form</title>
</head>

<body data-bs-spy="scroll" data-bs-target=".navbar" data-bs-offset="50">
    <nav class="navbar navbar-expand-sm bg-light navbar-light fixed-top opacity-50">
        <div class="container-fluid">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="#personalDetails">Personal</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#addressDetails">Address</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#educationDetails">Educational</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#employmentDetails">Employment</a>
                </li>
            </ul>
            <form class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                <button class="btn btn-outline-success" type="submit">Search</button>
            </form>
        </div>
    </nav>

    <div class="container">
        <header>Mindfire Solutions Form</header>

        <form class="allDetails" id="regForm">
            <div>
                <!-- Personal Details Field -->
                <fieldset id="personalDetails">
                    <span class="title">Personal Details</span>
                    <div class="fields">

                        <div class="row">
                            <div class="name col-sm-4">
                                <label for="txtFirstName">First Name<sup>*</sup></label>
                                <input class="form-control" name="txtFirstName" type="text" display-all-data="data"
                                    data-entry-label="First Name" placeholder="First Name" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                            <div class="name col-sm-4">
                                <label for="txtMiddleName">Middle Name</label>
                                <input class="form-control" name="txtMiddleName" display-all-data="data" type="text"
                                    data-entry-label="Middle Name" placeholder="Middle Name" />
                            </div>
                            <div class="name col-sm-4">
                                <label for="txtLastName">Last Name</label>
                                <input class="form-control" display-all-data="data" type="text" data-entry-label="Last Name"
                                    name="txtLastName" placeholder="Last name" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="name col-sm-4">
                                <label for="txtFatherFirstName">Father's First Name<sup>*</sup></label>
                                <input class="form-control" name="txtFatherFirstName" type="text" display-all-data="data"
                                    data-entry-label=" Father First Name" placeholder="First Name" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                            <div class="name col-sm-4">
                                <label for="txtFatherMiddleName">Father's Middle Name</label>
                                <input class="form-control" name="txtFatherMiddleName" display-all-data="data" type="text"
                                    data-entry-label="Middle Name" placeholder="Middle Name" />
                            </div>
                            <div class="name col-sm-4">
                                <label for="txtFatherLastName">Father's Last Name</label>
                                <input class="form-control" display-all-data="data" type="text" data-entry-label="Last Name"
                                    name="txtFatherLastName" placeholder="Last name" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="name col-sm-4">
                                <label for="txtMotherFirstName">Mother's First Name<sup>*</sup></label>
                                <input class="form-control" name="txtMotherFirstName" type="text" display-all-data="data"
                                    data-entry-label="Mother First Name" placeholder="First Name" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>
                            <div class="name col-sm-4">
                                <label for="txtMotherMiddleName">Mother's Middle Name</label>
                                <input class="form-control" name="txtMotherMiddleName" display-all-data="data" type="text"
                                    data-entry-label="Middle Name" placeholder="Middle Name" />
                            </div>
                            <div class="name col-sm-4">
                                <label for="txtMotherLastName">Mother's Last Name</label>
                                <input class="form-control" display-all-data="data" type="text" data-entry-label="Last Name"
                                    name="txtMotherLastName" placeholder="Last name" />
                            </div>
                        </div>

                        <div class="row ">
                            <div class="email col-sm-4">
                                <label for="email">Email<sup>*</sup></label>
                                <input class="form-control" display-all-data="data" type="email" data-entry-label="Email" name="email"
                                    placeholder="Enter your email" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>

                            <div class="dateofBirth col-sm-4">
                                <label for="dateofBirth">Date of Birth<sup>*</sup></label>
                                <input id="dateOfBirth" class="form-control" display-all-data="data" type="date" name="dateofBirth"
                                    data-entry-label="Date of Birth" placeholder="Enter birth date" data-bs-toggle="tooltip" />
                                <div class="error"></div>
                            </div>

                            <div class="name col-sm-4">
                                <label>Blood Group<sup>*</sup></label>
                                <select name="bloodGroup" class="form-control" display-all-data="data" data-entry-label="Blood Group"
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
                            <div class="mobile col-sm-6 row">
                                <label for="mobile">Mobile No.<sup>*</sup></label>
                                <div class="mobileCode col-sm-3">
                                    <select class="country form-control" name="mobileCode" display-all-data="data"
                                        data-entry-label="Country Code">
                                        <option>+91</option>
                                        <option>+1</option>
                                        <option>+44</option>
                                        <option>+975</option>
                                        <option>+39</option>
                                    </select>
                                </div>
                                <div class="col-sm-9">
                                    <input class="no form-control" display-all-data="data" type="number" name="mobile"
                                        data-entry-label="Mobile No" placeholder="Enter your number" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                            </div>
                            <div class="id col-sm-6 row">
                                <label for="id">ID<sup>*</sup></label>
                                <div class="idNo col-sm-4">
                                    <select class="selectIdType form-control" name="idType" display-all-data="data"
                                        data-entry-label="ID Type">
                                        <option>ID type</option>
                                    </select>
                                </div>
                                <div class="col-sm-8">
                                    <input id="idNumber" class="idNumber form-control" display-all-data="data" name="id"
                                        data-entry-label="ID No" type="number" placeholder="Select ID Type First"
                                        data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="about col-sm-12">
                                <label for="textAbout">About Me</label>
                                <textarea class="form-control" name="textAbout" display-all-data="data" cols="70"
                                    data-entry-label="About" rows="5" placeholder="Write sommething about yourself"></textarea>
                            </div>
                        </div>

                        <div class="row">
                            <div class="gender col-sm-4">
                                <label for="gender">Gender</label>
                                <div id="radioGender">
                                    <input type="radio" id="male" display-all-data="data" name="gender" class="radio"
                                        data-entry-label="Gender" value="Male" />
                                    <label for="male">Male</label>

                                    <input type="radio" id="female" display-all-data="data" name="gender" class="radio" value="Female"
                                        data-entry-label="Gender" />
                                    <label for="female">Female</label>

                                    <input type="radio" id="others" display-all-data="data" name="gender" class="radio" value="Others"
                                        data-entry-label="Gender" />
                                    <label for="others">Others</label>
                                </div>
                            </div>
                            <div class="hobbies col-sm-8">
                                <label for="hobbies">Hobbies</label>
                                <div id="checkHobbies">
                                    <input type="checkbox" id="reading" value="Reading" name="hobbies" display-all-data="data"
                                        data-entry-label="Hobbies" />
                                    <label for="reading">Reading</label>

                                    <input type="checkbox" id="singing" value="Singing" name="hobbies" display-all-data="data"
                                        data-entry-label="Hobbies" />
                                    <label for="singing">Singing</label>

                                    <input type="checkbox" id="dancing" value="Dancing" name="hobbies" display-all-data="data"
                                        data-entry-label="Hobbies" />
                                    <label for="dancing">Dancing</label>

                                    <input type="checkbox" id="travelling" value="Traveling" name="hobbies" display-all-data="data"
                                        data-entry-label="Hobbies" />
                                    <label for="traveling">Traveling</label>

                                    <input type="checkbox" id="gaming" value="Gaming" name="hobbies" display-all-data="data"
                                        data-entry-label="Hobbies" />
                                    <label for="gaming">Gaming</label>

                                    <input type="checkbox" id="coding" value="Coding" name="hobbies" display-all-data="data"
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
                        <div class="fields">
                            <div class="row">
                                <div class="name col-sm-4">
                                    <label>House/Flat No.<sup>*</sup></label>
                                    <input class="form-control" type="text" placeholder="Door No" data-entry-label="Door No"
                                        presentaddress="presentAddrHouseNo" display-all-data="data" name="presentAddressHouse"
                                        data-entry-catg="presentAddress" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                                <div class="name col-sm-4">
                                    <label>Street</label>
                                    <input class="form-control" type="text" data-entry-label="Street" placeholder="Enter Street Name"
                                        name="presentAddressStreet" data-entry-catg="presentAddress" />
                                </div>

                                <div class="name col-sm-4">
                                    <label>City<sup>*</sup></label>
                                    <input class="form-control" type="text" placeholder="Enter city" data-entry-label="City"
                                        display-all-data="data" data-entry-catg="presentAddress" name="presentAddressCity"
                                        data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="name col-sm-4">
                                    <label>Pincode<sup>*</sup></label>
                                    <input class="form-control" display-all-data="data" type="number" data-entry-label="Pincode"
                                        placeholder="Enter area code" name="presentAddressPincode" data-entry-catg="presentAddress"
                                        data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>

                                <div class="name col-sm-4">
                                    <label>Country<sup>*</sup></label>
                                    <select id="presentCountry" data-bs-toggle="tooltip" class="Country form-control"
                                        data-entry-catg="presentAddress" display-all-data="data" name="presentAddressCountry"
                                        data-entry-label="Country">
                                        <option>Select</option>
                                    </select>
                                    <div class="error"></div>
                                </div>

                                <div class="name col-sm-4">
                                    <label>State<sup>*</sup></label>
                                    <select id="presentState" class="State form-control" data-bs-toggle="tooltip"
                                        data-entry-catg="presentAddress" display-all-data="data" name="presentAddressState"
                                        data-entry-label="State">
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
                        <div class="fields">
                            <div class="row">
                                <div class="name col-sm-4">
                                    <label>House/Flat No.<sup>*</sup></label>
                                    <input class="form-control" name="permanentAddressHouseNo" type="text" data-entry-label="House No"
                                        display-all-data="data" placeholder="Door No" data-entry-catg="permanentAddress"
                                        data-permanent-address="false" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                                <div class="name col-sm-4">
                                    <label>Street</label>
                                    <input class="form-control" name="permanentAddressStreet" type="text" data-entry-label="Street"
                                        placeholder="Street Name" display-all-data="data" data-permanent-address="false"
                                        data-entry-catg="permanentAddress" />
                                </div>

                                <div class="name col-sm-4">
                                    <label>City<sup>*</sup></label>
                                    <input class="form-control" name="permanentAddressCity" display-all-data="data"
                                        data-entry-label="City" type="text" placeholder="Enter your city" data-entry-catg="permanentAddress"
                                        data-permanent-address="false" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="name col-sm-4">
                                    <label>Pincode<sup>*</sup></label>
                                    <input class="form-control" name="permanentAddressPincode" display-all-data="data" type="number"
                                        data-entry-label="Pincode" placeholder="Enter area code" data-permanent-address="false"
                                        data-entry-catg="permanentAddress" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>

                                <div class="name col-sm-4">
                                    <label>Country<sup>*</sup></label>
                                    <select id="permanentCountry" class="Country form-control" data-entry-catg="permanentAddress"
                                        display-all-data="data" data-bs-toggle="tooltip" name="permanentAddressCountry"
                                        data-entry-label="Country" data-permanent-address="false">
                                        <option>Select</option>
                                    </select>
                                    <div class="error"></div>
                                </div>

                                <div class="name col-sm-4">
                                    <label data-entry-label="data">State<sup>*</sup></label>
                                    <select id="permanentState" class="State form-control" data-entry-catg=" permanentAddress"
                                        display-all-data="data" data-bs-toggle="tooltip" name="permanentAddressState"
                                        data-entry-label="State" data-permanent-address="false">
                                        <option>Select</option>
                                    </select>
                                    <div class="error"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>

                <!-- Education Details Feild -->
                <fieldset id="educationDetails">
                    <span class="title">Educational Details</span>
                    <h3>Class 10</h3>
                    <div class="fields row">
                        <div class="name col-sm-4">
                            <label>Board<sup>*</sup></label>
                            <select name="xboard" class="form-control" display-all-data="data" data-bs-toggle="tooltip"
                                data-entry-label="X Board">
                                <option>Select</option>
                            </select>
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label>Year<sup>*</sup></label>
                            <input class="form-control" display-all-data="data" type="number" data-entry-label="X Year"
                                placeholder="Enter Year" name="xYear" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label>Percentage/CGPA<sup>*</sup></label>
                            <input class="form-control" display-all-data="data" type="text" data-entry-label="X Percentage"
                                placeholder="Percentage" name="xPercentage" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                    </div>

                    <h3>Class 12</h3>
                    <div class="fields row">
                        <div class="name col-sm-4">
                            <label>Board<sup>*</sup></label>
                            <select class="form-control" name="xiiboard" data-bs-toggle="tooltip" display-all-data="data"
                                data-entry-label="XII Board">
                                <option>Select</option>
                            </select>
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label>Year<sup>*</sup></label>
                            <input class="form-control" type="text" display-all-data="data" data-entry-label="XII Year"
                                placeholder="Year of Passing" name="xiiYear" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label>Percentage/CGPA<sup>*</sup></label>
                            <input class="form-control" type="text" display-all-data="data" data-entry-label="XII Percentage"
                                placeholder="Percentage/CGPA" name="xiiPercentage" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                    </div>

                    <h3>Graduation</h3>
                    <div class="fields row">
                        <div class="name col-sm-4">
                            <label>Branch<sup>*</sup></label>
                            <select class="form-control" name="branch" display-all-data="data" data-entry-label="Branch"
                                data-bs-toggle="tooltip">
                                <option>Select</option>
                            </select>
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label data-entry-label="data">Year<sup>*</sup></label>
                            <input class="form-control" display-all-data="data" type="text" name="gradYear"
                                placeholder="Year of Graduation" data-entry-label="Graduation Year" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                        <div class="name col-sm-4">
                            <label data-entry-label="data">Percentage/CGPA<sup>*</sup></label>
                            <input class="form-control" type="text" name="gradPercentage" display-all-data="data"
                                placeholder="% or CGPA" data-entry-label="CGPA" data-bs-toggle="tooltip" />
                            <div class="error"></div>
                        </div>
                    </div>
                </fieldset>

                <!-- Employment Details Field -->
                <fieldset id="employmentDetails">
                    <span class="title">Employment Details</span>

                    <div class="fields">
                        <div>
                            <div class="row">
                                <div class="name col-sm-4">
                                    <label data-entry-label="data">Company Name<sup>*</sup></label>
                                    <input class="form-control" display-all-data="data" name="companyName" data-entry-label="Company Name"
                                        type="text" placeholder="Name" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                                <div class="name col-sm-4">
                                    <label data-entry-label="data">Role<sup>*</sup></label>
                                    <input class="form-control" display-all-data="data" data-entry-label="Role" type="text"
                                        placeholder="Role" id="txtrole" name="role" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                                <div class="name col-sm-4">
                                    <label>Designation<sup>*</sup></label>
                                    <input class="form-control" data-entry-label="Designation" display-all-data="data" type="text"
                                        placeholder="Designation" name="designation" id="designation" data-bs-toggle="tooltip" />
                                    <div class="error"></div>
                                </div>
                            </div>
                        </div>
                        <div class="about">
                            <label>Skills</label>
                            <textarea name="skills" class="form-control" id="skills" cols="70" rows="2" display-all-data="data"
                                placeholder="Add your Skills" data-entry-label="Skills"></textarea>
                        </div>

                        <div class="name">
                            <label>Documents</label>
                            <input type="file" class="form-control" display-all-data=" data" name="resume" id="resume"
                                data-entry-label="Documents" />
                        </div>
                    </div>
                </fieldset>
                <div class="text-center">
                    <button id="submit" type="button" class="btn btn-primary w-25" data-toggle="modal"
                        data-target="#formDataDisplay">
                        Submit</button>

                    <div class="modal fade" id="formDataDisplay" tabindex="-1" role="dialog"
                        aria-labelledby="formDataDisplayTitle" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-scrollable" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="formDataDisplayTitle">Modal title</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    <button type="button" class="btn btn-primary" data-dismiss="modal"
                                        onclick="return clearLocalStorage()">
                                        Delete Data</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <input class="reset btn btn-primary w-25" type="reset" value="Reset" />
                </div>
            </div>
    </div>
    </form>

  </div>
  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"
      integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"
      crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js"
        integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js"
        integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>


    <script src="script.js"></script>

</body>

</html>
