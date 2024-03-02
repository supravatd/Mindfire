$(document).ready(function () {

    $.ajax({
        url: '/UserFormV2/GetCountryList',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (i, country) {
                $('#ddlPresentCountry').append($('<option></option>').val(country.CountryId).text(country.CountryName));
                $('#ddlPermanentCountry').append($('<option></option>').val(country.CountryId).text(country.CountryName));
            });
        },
    });

    $('#ddlPresentCountry').on('change', function () {
        var selectedCountryId = $(this).val();
        if (selectedCountryId) {
            populateStates(selectedCountryId, '#ddlPresentState');
        }
    });

    $('#ddlPermanentCountry').on('change', function () {
        var selectedCountryId = $(this).val();
        if (selectedCountryId) {
            populateStates(selectedCountryId, '#ddlPermanentState');
        }
    });

    $('#ddlPresentCountry, #ddlPermanentCountry').change(function () {
        var countryId = $(this).val();
        var targetDropdownId = $(this).attr('id') === 'ddlPresentCountry' ? 'ddlPresentState' : 'ddlPermanentState';
        populateStates(countryId, targetDropdownId);
    });

    var url = window.location.pathname;
    var parts = url.split('/');
    var userIdIndex = parts.indexOf('EditUserV2') + 1;
    var userId = parts[userIdIndex];

    var isEditMode = userId && !isNaN(userId);

    if (isEditMode) {
        loadUserDetails(parseInt(userId));
        $("#objectId").val(parseInt(userId));
    }
});

function populateStates(countryId, targetDropdownId) {
    $.ajax({
        url: '/UserFormV2/GetStatesByCountry',
        type: 'GET',
        data: { countryId: countryId },
        success: function (result) {
            $(targetDropdownId).html('');
            $.each(result, function (index, item) {
                $(targetDropdownId).append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
        }
    });
}

function SameAsPresent_Check() {
    var isSameAsPresent = $('#chkSameAsPresent').is(':checked');
    if (isSameAsPresent) {

        $('#txtPermanentHouseNo').val($('#txtPresentHouse').val());
        $('#txtPermanentStreet').val($('#txtPresentStreet').val());
        $('#txtPermanentCity').val($('#txtPresentCity').val());
        $('#txtPermanentPinCode').val($('#txtPresentPinCode').val());
        const presentAddCountry = $('#ddlPresentCountry').val();
        const presentAddState = $('#ddlPresentState').val();

        const presentAddCountryText = $('#ddlPresentCountry option:selected').text();

        const presentAddStateText = $('#ddlPresentState option:selected').text();

        const country = $("#ddlPermanentCountry");
        country.html(`<option value="${presentAddCountry}">${presentAddCountryText}</option>`);
        country.val(presentAddCountry);

        const state = $("#ddlPermanentState");
        state.html(`<option value="${presentAddState}">${presentAddStateText}</option>`);
        state.val(presentAddState);
    }
    else {
        $('#txtPermanentHouseNo').val('');
        $('#txtPermanentStreet').val('');
        $('#txtPermanentCity').val('');
        $('#txtPermanentPinCode').val('');
        $('#ddlPermanentCountry').val('');
        $('#ddlPermanentState').val('').trigger('change');
    }
}

function loadUserDetails(userId) {
    $.ajax({
        type: "POST",
        url: "/UserFormV2/EditUserV2",
        data: { id: userId },
        dataType: "json",
        success: function (data) {
            populateFormFields(data);
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
        $("#txtPresentPinCode").val(user.PresentAddress.PostalCode);
        populateCountryDropdown("#ddlPresentCountry", user.PresentAddress.CountryId);
        populateStates(user.PresentAddress.CountryId, '#ddlPresentState');

        $("#ddlPresentCountry").val(user.PresentAddress.CountryId);
        $("#ddlPresentState").val(user.PresentAddress.StateId);
    }

    if (user.PermanentAddress !== null) {
        $("#txtPermanentHouseNo").val(user.PermanentAddress.DoorNo);
        $("#txtPermanentStreet").val(user.PermanentAddress.Street);
        $("#txtPermanentCity").val(user.PermanentAddress.City);
        $("#txtPermanentPinCode").val(user.PermanentAddress.PostalCode);
        populateCountryDropdown("#ddlPermanentCountry", user.PermanentAddress.CountryId);
        populateStates(user.PermanentAddress.CountryId, '#ddlPermanentState');


        $("#ddlPermanentCountry").val(user.PermanentAddress.CountryId);
        $("#ddlPermanentState").val(user.PermanentAddress.StateId);

    }
}

function populateCountryDropdown(dropDownListId, selectedCountryId) {
    var dropdown = $(dropDownListId);

    dropdown.find('option').removeAttr('selected');
    dropdown.find('option[value="' + selectedCountryId + '"]').attr('selected', 'selected');
}

function populateStatesSelected(dropDownListId, countryId, selectedStateId) {
    $.ajax({
        type: "POST",
        url: "/UserFormV2/PopulateStates",
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

function checkEmailAvailability() {
    $("#txtEmail").on("focusout", function () {
        var email = $("#txtEmail").val();

        $.ajax({
            type: "POST",
            url: "/UserFormV2/EmailExists",
            data: JSON.stringify({ email: email }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.exists) {
                    $("#lblEmailError").text("Email already exists.").css("color", "red");
                } else {
                    $("#lblEmailError").text("Valid Email.").css("color", "green");
                }
            },
            error: function (xhr, status, error) {
                console.error("Error checking email:", error);
            }
        });

        checkUserEmail(email, userId);
    });
}


function checkUserEmail(email, userId) {
    $.ajax({
        type: "POST",
        url: "/UserFormV2/CheckUserEmail",
        data: JSON.stringify({ userId: userId, email: email }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.valid) {
                $("#lblEmailError").text("Valid Email.").css("color", "green");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error checking email:", error);
        }
    });
}
