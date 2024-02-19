$(document).ready(function () {
    const queryString = window.location.search;
    const url = new URLSearchParams(queryString);
    userId = url.get("UserId");
    if (userId) {
        loadUserDetails(userId);
    }

    const idTypes = ["Aadhar", "Pan", "DL", "Voter"];
    const selectIdType = $("[name='idType']");
    getCountry();

    $('#ddlPresentCountry').on('change', function () {
        var selectedCountryId = $(this).val();
        if (selectedCountryId) {
            getStates(selectedCountryId, '#ddlPresentState');
        }
    });

    $('#ddlPermanentCountry').on('change', function () {
        var selectedCountryId = $(this).val();
        if (selectedCountryId) {
            getStates(selectedCountryId, '#ddlPermanentState');
        }
    });

    selectList(selectIdType, idTypes);

    $('#sameAsPresent').click(function () {
        if ($(this).prop("checked") == true)
            copyPresent($('#sameAsPresent'));
    });

    $("#bttnSubmit").on("click", function () {
        sendFormData();
    });

    $(window).on("click", function (event) {
        if ($(event.target).is("#displayError")) {
            $("#displayError").css("display", "none");
        }
    });
});

function checkEmailAvailability() {
    var email = document.getElementById("txtEmail").value;
    var errorMessageElement = document.querySelector(".email .error");

    // Create a new XMLHttpRequest object
    var xhr = new XMLHttpRequest();

    // Configure the request
    xhr.open("GET", "CheckUserExists.aspx?email=" + email, true);

    // Define a function to handle the response
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                var response = xhr.responseText;
                if (response === "valid") {
                    errorMessageElement.innerText = "Email is available.";
                    errorMessageElement.style.color = "green";
                } else {
                    errorMessageElement.innerText = "Email is not available.";
                    errorMessageElement.style.color = "red";
                }
            } else {
                errorMessageElement.innerText = "Error occurred while checking email availability.";
                errorMessageElement.style.color = "red";
            }
        }
    };

    // Send the request
    xhr.send();
}

function copyPresent(sameAsPresent) {
    if (sameAsPresent.prop("checked")) {
        const presentAddCountry = $("[name='presentAddressCountry']").val();
        const presentAddState = $("[name='presentAddressState']").val();

        $("[name='permanentAddressHouseNo']").val($("[name='presentAddressHouse']").val());
        $("[name='permanentAddressStreet']").val($("[name='presentAddressStreet']").val());
        $("[name='permanentAddressCity']").val($("[name='presentAddressCity']").val());
        $("[name='permanentAddressPincode']").val($("[name='presentAddressPincode']").val());

        const country = $("[name='permanentAddressCountry']");
        const presentAddCountryText = $("[name='presentAddressCountry'] option:selected").text();
        country.html(`<option value="${presentAddCountry}">${presentAddCountryText}</option>`);
        country.val(presentAddCountry);

        const state = $("[name='permanentAddressState']");
        const presentAddStateText = $("[name='presentAddressState'] option:selected").text();
        state.html(`<option value="${presentAddState}">${presentAddStateText}</option>`);
        state.val(presentAddState);
    };
}

function sendFormData() {
    $.ajax({
        url: 'RegisterForm.aspx/SubmitFormData',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            user: getUserData(),
            presentAddress: getAddressData('#presentAddress'),
            permanentAddress: getAddressData('#permanentAddress')
        }),
        success: function (response) {
            // Handle success response
        },
        error: function (xhr, status, error) {
            console.error('Failed to send user details:', error);
        }
    });
}

function getUserData() {
    return getObjectData('#userDetails');
}

function getAddressData(selector) {
    return getObjectData(selector);
}

function getObjectData(selector) {
    const data = {};
    $(`${selector} [data-entry-label]`).each(function () {
        const fieldName = $(this).attr('data-entry-label');
        if ($(this).is('input[type="checkbox"]')) {
            // Handle checkboxes
            if ($(this).is(':checked')) {
                if (!data[fieldName]) {
                    data[fieldName] = '';
                }
                data[fieldName] += $(this).val() + ',';
            }
        } else if ($(this).is('input[type="radio"]')) {
            // Handle radio buttons
            if ($(this).is(':checked')) {
                data[fieldName] = $(this).val();
            }
        } else if ($(this).is('select')) {
            // Handle dropdowns
            data[fieldName] = $(this).val();
        } else {
            // Handle other input elements
            data[fieldName] = $(this).val();
        }
    });

    // Remove the last comma for checkbox values
    for (const fieldName in data) {
        if (Array.isArray(data[fieldName])) {
            data[fieldName] = data[fieldName].join(',');
        }
    }

    return data;
}



function selectList(selection, options) {
    $.each(options, function (key, value) {
        var optionElement = $("<option>").val(value).text(value);
        selection.append(optionElement);
    });
}

function getStates(selectedCountryId, stateDropdown) {
    $.ajax({
        url: 'RegisterForm.aspx/PopulateStates',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ countryId: parseInt(selectedCountryId) }),
        success: function (response) {
            var stateData = JSON.parse(response.d);
            populateStateDropdown(stateDropdown, stateData);
        },
        error: function (xhr, status, error) {
            console.error('Failed to get states:', error);
        }
    });
}

function getCountry() {
    $.ajax({
        url: 'RegisterForm.aspx/PopulateCountries',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        success: function (response) {
            var countryData = JSON.parse(response.d);
            populateCountryDropdown('#ddlPresentCountry', countryData);
            populateCountryDropdown('#ddlPermanentCountry', countryData);
        },
        error: function (xhr, status, error) {
            console.error('Failed to populate countries:', error);
        }
    });
}

function populateCountryDropdown(selector, data) {
    var dropdown = $(selector);
    dropdown.empty().append($('<option>').text('Select').val(''));

    if (Array.isArray(data)) {
        $.each(data, function (index, item) {
            dropdown.append($('<option>').text(item.CountryName).val(item.CountryId));
        });
    } else {
        console.error('Data is not an array:', data);
    }
}

function populateStateDropdown(selector, data) {
    var dropdown = $(selector);
    dropdown.empty().append($('<option>').text('Select').val(''));

    if (Array.isArray(data)) {
        $.each(data, function (index, item) {
            dropdown.append($('<option>').text(item.StateName).val(item.StateId));
        });
    } else {
        console.error('Data is not an array:', data);
    }
}

function loadUserDetails(userId) {
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/GetUserDetails",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var user = response.d;
            populateFormFields(user);

            // Usage for present address
            var presentCountryId = user.PresentAddress.CountryId;
            getAllCountries(presentCountryId, "#ddlPresentCountry", function () {
                populateStates('#ddlPresentState', presentCountryId, user.PresentAddress.StateId);
            });

            // Usage for permanent address
            var permanentCountryId = user.PermanentAddress.CountryId;
            getAllCountries(permanentCountryId, "#ddlPermanentCountry", function () {
                populateStates('#ddlPermanentState', permanentCountryId, user.PermanentAddress.StateId);
            });
        },
        error: function (xhr, status, error) {
            console.error("Error loading user details:", error);
        }
    });
}

function getAllCountries(selectedCountryId, countryDropdownId, callback) {
    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/GetAllCountries",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var countries = response.d;
            populateCountryDropdown(countryDropdownId, countries, selectedCountryId);
            if (callback && typeof callback === 'function') {
                callback();
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving countries:", error);
        }
    });
}

function populateStates(stateDropdownId, countryId, selectedStateId) {
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/PopulateStates",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var states = response.d;
            var ddlStates = $(stateDropdownId);
            ddlStates.empty();
            $.each(states, function (index, state) {
                ddlStates.append($("<option></option>").val(state.StateId).text(state.StateName));
            });
            if (selectedStateId) {
                ddlStates.val(selectedStateId);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error populating states:", error);
        }
    });
}


function populateFormFields(user) {
    // Populate the form fields with user details
    $("#txtFirstName").val(user.FirstName);
    $("#txtLastName").val(user.LastName);
    $("#txtMiddleName").val(user.MiddleName);
    $("#txtFatherFirstName").val(user.FatherFirstName);
    $("#txtFatherMiddleName").val(user.FatherMiddleName);
    $("#txtFatherLastName").val(user.FatherLastName);
    $("#txtMotherFirstName").val(user.MotherFirstName);
    $("#txtMotherMiddleName").val(user.MotherMiddleName);
    $("#txtMotherLastName").val(user.MotherLastName);
    $("#txtEmail").val(user.Email);
    $("#txtDateOfBirth").val(user.DateOfBirth); // Assuming DateOfBirth is the property name
    $("#ddlBloodGroup").val(user.BloodGroup);
    $("#txtMobile").val(user.MobileNo);
    $("#ddlIdType").val(user.IDType);
    $("#txtIdNumber").val(user.IDNo);

    // Handle gender
    if (user.Gender === "Male") {
        $("#rbMale").prop("checked", true);
    } else if (user.Gender === "Female") {
        $("#rbFemale").prop("checked", true);
    } else if (user.Gender === "Others") {
        $("#rbOthers").prop("checked", true);
    }

    // Handle hobbies
    var hobbies = user.Hobbies.split(',');
    hobbies.forEach(function (hobby) {
        $("#" + hobby.trim()).prop("checked", true); // Use trim() to remove whitespace
    });

    // Handle file details (if applicable)
    $("#lblFileName").text(user.FileOriginal); // Assuming lblFileName is a label to display the file name

    // Handle present address
    $("#txtPresentHouse").val(user.PresentAddress.DoorNo);
    $("#txtPresentStreet").val(user.PresentAddress.Street);
    $("#txtPresentCity").val(user.PresentAddress.City);
    $("#txtPresentPincode").val(user.PresentAddress.PostalCode);
    var presentCountryId = user.PresentAddress.CountryId;
    populateCountries("#ddlPresentCountry", presentCountryId); // Populate present country dropdown
    $("#ddlPresentCountry").val(user.PresentAddress.CountryId)
    populateStates("#ddlPresentState", presentCountryId, user.PresentAddress.StateId); // Populate present state dropdown

    // Usage for permanent address


    // Handle permanent address (similar to present address)
    $("#txtPermanentHouseNo").val(user.PermanentAddress.DoorNo);
    $("#txtPermanentStreet").val(user.PermanentAddress.Street);
    $("#txtPermanentCity").val(user.PermanentAddress.City);
    $("#txtPermanentPincode").val(user.PermanentAddress.PostalCode);


    // Usage for permanent address
    var permanentCountryId = user.PermanentAddress.CountryId;
    populateCountries("#ddlPermanentCountry", permanentCountryId); // Populate permanent country dropdown
    populateStates("#ddlPermanentState", permanentCountryId, user.PermanentAddress.StateId); // Populate permanent state dropdown
    
    setSelectedState(user.PermanentAddress.StateId, user.PermanentAddress.CountryId, selectedCountryName, $("#ddlPermanentState"));
}

function setSelectedState(stateId, countryId, selectedCountryName, stateDropdown) {
    // Call the web method to get the state name
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/GetStateNameById",
        data: JSON.stringify({ stateId: stateId, countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var selectedStateName = response.d;
            if (selectedStateName) {
                stateDropdown.val(stateId.toString());
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving state name:", error);
        }
    });
}

function populateCountries(dropDownListId, selectedCountryId) {
    $.ajax({
        url: 'RegisterForm.aspx/PopulateCountries',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        success: function (response) {
            var countries = response.d; // Assuming response contains countries in the correct format
            populateCountryDropdown('#ddlPresentCountry', countries);
            populateCountryDropdown('#ddlPermanentCountry', countries);
        },
        error: function (xhr, status, error) {
            console.error('Failed to populate countries:', error);
        }
    });
}

function populateStates(dropDownListId, countryId, selectedStateId) {
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/PopulateStates",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var states = response.d; // Assuming response contains states for the selected country
            var ddlStates = $(dropDownListId);
            ddlStates.empty(); // Clear existing options
            $.each(states, function (index, state) {
                ddlStates.append($("<option></option>").val(state.StateId).text(state.StateName));
            });
            // Select the previously selected state if available
            if (selectedStateId) {
                ddlStates.val(selectedStateId);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error populating states:", error);
        }
    });
}

function getAllStates(countryId, stateDropdownId, stateid = -1) {
    var arr = { countryid: countryId };
    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/GetStates",
        data: JSON.stringify(arr),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: "false",
        success: function (response) {
            var $stateDropdown = $(stateDropdownId);
            $stateDropdown.empty();
            response.d.forEach((item) => {
                var $newOption = `<option value="${item.StateId}">${item.StateName}</option>`;
                $stateDropdown.append($newOption);
            });
            if (stateid != -1) {
                $stateDropdown.val(stateid);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving states:", error);
        }
    });
}


function getAllCountries(selectedCountryId, countryDropdownId) {
    $.ajax({
        type: "POST",
        url: "Dashboard.aspx/GetAllCountries",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var countries = response.d;
            populateCountryDropdown(countryDropdownId, countries, selectedCountryId);
        },
        error: function (xhr, status, error) {
            console.error("Error retrieving countries:", error);
        }
    });
}

function populateCountryDropdown(countryDropdownId, countries, selectedCountryId) {
    var $countryDropdown = $(countryDropdownId);
    $countryDropdown.empty();
    countries.forEach(function (country) {
        var $newOption = $("<option></option>").val(country.CountryId).text(country.CountryName);
        if (country.CountryId === selectedCountryId) {
            $newOption.attr("selected", true);
        }
        $countryDropdown.append($newOption);
    });
}

// Usage for present address
