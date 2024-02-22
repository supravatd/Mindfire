$(document).ready(function () {
    showButton(true);
    const queryString = window.location.search;
    const url = new URLSearchParams(queryString);
    userId = url.get("UserId");

    if (userId) {
        showButton(false);
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
        var lblEmailError = document.getElementById("lblEmailError");
        if (lblEmailError.textContent === "Email Already exists.") {
            alert("Email already exists. Please choose a different email.");
            return;
        }
        sendFormData();
    });

    $("#bttnUpdate").on("click", function () {
        var lblEmailError = document.getElementById("lblEmailError");
        if (lblEmailError.textContent === "Email Already exists.") {
            alert("Email already exists. Please choose a different email.");
            return;
        }
        updateUser();
    });

    $(window).on("click", function (event) {
        if ($(event.target).is("#displayError")) {
            $("#displayError").css("display", "none");
        }
    });
});

function checkEmailAvailability() {
    document.getElementById("txtEmail").addEventListener("focusout", function () {
        var email = document.getElementById("txtEmail").value;

        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    if (response && response.d) {
                        document.getElementById("lblEmailError").textContent = "Email Already exists.";
                        document.getElementById("lblEmailError").style.color = "red";
                    } else {
                        document.getElementById("lblEmailError").textContent = "Valid Email.";
                        document.getElementById("lblEmailError").style.color = "green";
                    }
                } else {
                    console.error(xhr.responseText);
                    document.getElementById("lblEmailError").textContent = "Error checking email.";
                }
            }

        };
        xhr.open("POST", "RegisterForm.aspx/EmailExists", true);
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.send(JSON.stringify({ email: email }));
        checkUserEmail(email);
    });
}

function checkUserEmail(email) {
    const queryString = window.location.search;
    const url = new URLSearchParams(queryString);
    let userId = url.get("UserId");
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/CheckUserEmail",
        data: JSON.stringify({ userId: userId, email: email }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d) {
                document.getElementById("lblEmailError").textContent = "Valid Email.";
                document.getElementById("lblEmailError").style.color = "green";
            }

        },
        error: function (xhr, status, error) {
            console.error("Error checking email:", error);
        }
    });
}

function showButton(button) {
    var bttnSubmit = document.getElementById("bttnSubmit");
    var bttnUpdate = document.getElementById("bttnUpdate");
    if (button) {
        bttnSubmit.style.display = "block";
        bttnUpdate.style.display = "none";
    } else {
        bttnSubmit.style.display = "none";
        bttnUpdate.style.display = "block";
    }
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
            if ($(this).is(':checked')) {
                if (!data[fieldName]) {
                    data[fieldName] = '';
                }
                data[fieldName] += $(this).val() + ',';
            }
        } else if ($(this).is('input[type="radio"]')) {
            if ($(this).is(':checked')) {
                data[fieldName] = $(this).val();
            }
        } else if ($(this).is('select')) {
            data[fieldName] = $(this).val();
        } else {
            data[fieldName] = $(this).val();
        }
    });

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
            var countryData = response.d;
            populateCountry('#ddlPresentCountry', JSON.parse(countryData));
            populateCountry('#ddlPermanentCountry', JSON.parse(countryData));
        },
        error: function (xhr, status, error) {
            console.error('Failed to populate countries:', error);
        }
    });
}

function populateCountry(dropDownListId, countries) {
    var dropdown = $(dropDownListId);
    dropdown.empty().append($('<option>').text('Select').val(''));

    if (Array.isArray(countries)) {
        $.each(countries, function (index, country) {
            var option = $('<option></option>').val(country.CountryId).text(country.CountryName);
            dropdown.append(option);
        });
    } else {
        console.error('Data is not an array:', countries);
    }
}

function populateCountryDropdown(dropDownListId, selectedCountryId) {
    var dropdown = $(dropDownListId);

    dropdown.find('option').removeAttr('selected');
    dropdown.find('option[value="' + selectedCountryId + '"]').attr('selected', 'selected');
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
            id = user.userId;
            populateFormFields(user);
            if (user.PresentAddress !== null) {
                populateCountryDropdown("#ddlPresentCountry", user.PresentAddress.CountryId);
                getStates(user.PresentAddress.CountryId, '#ddlPresentState');
            }
            if (user.PermanentAddress !== null) {
                populateCountryDropdown("#ddlPermanentCountry", user.PermanentAddress.CountryId);
                getStates(user.PermanentAddress.CountryId, '#ddlPermanentState');
            }
        },
        error: function (xhr, status, error) {
            console.error("Error loading user details:", error);
        }
    });
}


function populateFormFields(user) {
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
    $("#txtPassword").val(user.Password);

    var dobMilliseconds = parseInt(user.Dob.match(/\d+/)[0]);
    var dobDate = new Date(dobMilliseconds);
    var formattedDate = dobDate.toISOString().split('T')[0];

    $("#txtDateOfBirth").val(formattedDate);

    $("#ddlBloodGroup").val(user.BloodGroup);
    $("#txtMobile").val(user.MobileNo);
    $("#ddlIdType").val(user.IDType);
    $("#txtIdNumber").val(user.IDNo);

    if (user.Gender === "Male") {
        $("#rbMale").prop("checked", true);
    } else if (user.Gender === "Female") {
        $("#rbFemale").prop("checked", true);
    } else if (user.Gender === "Others") {
        $("#rbOthers").prop("checked", true);
    }

    var hobbies = user.Hobbies.split(',');
    hobbies.forEach(function (hobby) {
        switch (hobby.trim()) {
            case "Reading":
                $("#chkReading").prop("checked", true);
                break;
            case "Singing":
                $("#chkSinging").prop("checked", true);
                break;
            case "Dancing":
                $("#chkDancing").prop("checked", true);
                break;
            case "Traveling":
                $("#chkTraveling").prop("checked", true);
                break;
            case "Gaming":
                $("#chkGaming").prop("checked", true);
                break;
            case "Coding":
                $("#chkCoding").prop("checked", true);
                break;
            default:
                break;
        }
    });


    $("#lblFileName").text(user.FileOriginal);

    if (user.PresentAddress !== null) {
        $("#txtPresentHouse").val(user.PresentAddress.DoorNo);
        $("#txtPresentStreet").val(user.PresentAddress.Street);
        $("#txtPresentCity").val(user.PresentAddress.City);
        $("#txtPresentPincode").val(user.PresentAddress.PostalCode);

    }

    if (user.PermanentAddress !== null) {
        $("#txtPermanentHouseNo").val(user.PermanentAddress.DoorNo);
        $("#txtPermanentStreet").val(user.PermanentAddress.Street);
        $("#txtPermanentCity").val(user.PermanentAddress.City);
        $("#txtPermanentPincode").val(user.PermanentAddress.PostalCode);

    }
}

function populateStatesSelected(dropDownListId, countryId, selectedStateId) {
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/PopulateStates",
        data: JSON.stringify({ countryId: countryId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var states = response.d;
            var ddlStates = $(dropDownListId);

            ddlStates.empty().append($('<option>').text('Select').val(''));

            if (Array.isArray(states)) {
                states.forEach(function (state) {
                    var option = $("<option>").val(state.StateId).text(state.StateName);
                    if (state.StateId === selectedStateId) {
                        option.prop('selected', true);
                    }
                    ddlStates.append(option);
                });
            } else {
                console.error('Data is not an array:', states);
            }
        },
        error: function (xhr, status, error) {
            console.error("Error populating states:", error);
        }
    });
}

function updateUser() {
    $.ajax({
        url: 'RegisterForm.aspx/UpdateFormData',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            user: getUserData(),
            presentAddress: getAddressData('#presentAddress'),
            permanentAddress: getAddressData('#permanentAddress')
        }),
        success: function (response) {
        },
        error: function (xhr, status, error) {
            console.error('Failed to send user details:', error);
        }
    });
}
