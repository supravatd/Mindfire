$(document).ready(function () {
    $.each(countryState, function (country, states) {
        $('#presentCountry').append(new Option(country, country));
        $('#permanentCountry').append(new Option(country, country));
    });

    $('#presentCountry').on('change', function (e) {
        var selectedValue = $(this).val();
        selectCountryState($('#presentCountry'), $('#presentState'), countryState[selectedValue]);
    });

    $('#permanentCountry').on('change', function (e) {
        var selectedValue = $(this).val();
        selectCountryState($('#permanentCountry'), $('#permanentState'), countryState[selectedValue]);
    });

    selectList(selectIdType, idTypes);
    selectList(selectBranch, branch);
    selectList(selectxiiBoard, xiiboard);
    selectList(selectxBoard, xboard);

    $('#sameAsPresent').click(function () {
        if ($(this).prop("checked") == true)
            copyPresent($('#sameAsPresent'));
    });


    $("#submit").on("click", function () {
        validateForm();
        return false;
    });


    $(window).on("click", function (event) {
        if ($(event.target).is("#displayError")) {
            $("#displayError").css("display", "none");
        }
    });

});

function validateForm() {
    $(".error").text("").removeClass("errorMessage");

    $("fieldset [data-bs-toggle='tooltip']").each(function () {
        validateInput(this);
    });

    $("fieldset select[data-bs-toggle='tooltip']").each(function () {
        validateSelectInput(this);
    });

    $("[data-bs-toggle='tooltip']").on("input", function () {
        const inputField = $(this);
        inputField.tooltip('hide');
        inputField.removeClass("is-invalid");
    });

    if (hasErrors()) {
        $("#formDataDisplay .modal-body").html("<p style='color: red;'>Complete all fields</p>");
        $('#formDataDisplay').modal({
            keyboard: false
        });
    } else {
        $('[data-bs-toggle="tooltip"]').tooltip('hide');
        $('[data-bs-toggle="tooltip"]').removeClass("is-invalid");

        processFormData();
        $('#formDataDisplay').modal({
            keyboard: false
        });
    }
}

function validateInput(inputField, initial = false) {
    const label = $(inputField).attr("data-entry-label");
    const error = $(inputField).parent().find(".error");

    if ($(inputField).prop("tagName") === "SELECT") {
        validateSelectInput(inputField);
    } else {
        if ($(inputField).val().trim() === "") {
            const errorMessage = `${label} is required.`;
            error.text(errorMessage).addClass("errorMessage");

            $(inputField).tooltip('dispose');
            $(inputField).tooltip('show');
            $(inputField).addClass("is-invalid");
        }
        else {
            if ($(inputField).prop("type") === "email") {
                if (!isValidEmail($(inputField).val())) {
                    const errorMessage = `${label} is not a valid email address.`;
                    error.text(errorMessage).addClass("errorMessage");

                    $(inputField).tooltip('dispose');
                    $(inputField).tooltip('show');
                    $(inputField).addClass("is-invalid");
                    return;
                }
            } else {
                error.text("").removeClass("errorMessage");
            }

            if (initial) {
                error.css("display", "");
            }

            $(inputField).tooltip('hide');
            $(inputField).removeClass("is-invalid");
            $(inputField).addClass("is-valid");
        }
    }
}

function validateSelectInput(selectInput) {
    const label = $(selectInput).data("entry-label");
    const error = $(selectInput).parent().find(".error");

    const selectedValue = $(selectInput).val();
    const defaultValue = "Select";

    if (selectedValue === defaultValue) {
        const errorMessage = `Please select a ${label}.`;
        error.text(errorMessage).addClass("errorMessage");

        $(selectInput).tooltip('dispose');
        $(selectInput).tooltip('show');
        $(selectInput).addClass("is-invalid");
    }
    else {
        error.text("").removeClass("errorMessage");
        $(selectInput).tooltip('hide');
        $(selectInput).removeClass("is-invalid");
        $(selectInput).addClass("is-valid");
    }
}

function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function hasErrors() {
    var errorFields = $("fieldset .error");
    for (var i = 0; i < errorFields.length; i++) {
        if ($(errorFields[i]).text() !== null && $(errorFields[i]).text() !== '') {
            return true;
        }
    }
    return false;
}

function selectCountryState(countrySelection, stateSelection, options) {
    stateSelection.empty().append('<option value="">Select State</option>');
    for (let option of options) {
        stateSelection.append(new Option(option, option));
    }
}

function selectList(selection, options) {
    $.each(options, function (key, value) {
        var optionElement = $("<option>").val(value).text(value);
        selection.append(optionElement);
    });
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
        country.html(`<option value="${presentAddCountry}">${presentAddCountry}</option>`);
        country.val(presentAddCountry);

        const state = $("[name='permanentAddressState']");
        state.html(`<option value="${presentAddState}">${presentAddState}</option>`);
        state.val(presentAddState);


        $("[data-permanent-address]").prop("disabled", true);
    };
}

function processFormData() {
    $("#regForm").find("fieldset").each(function () {
        const fieldset = $(this);
        const fieldsetId = fieldset.attr("id");
        const formData = {};

        inputFieldsData(fieldset, formData);
        radioButtonsData(fieldset, formData);
        processCheckboxes(fieldset, formData);

        localStorage.setItem(fieldsetId, JSON.stringify(formData));
    });
    displayFormData();
}

function inputFieldsData(fieldset, formData) {
    const fieldsetId = fieldset.attr("id");
    const inputFields = fieldset.find("[data-entry-label]");
    inputFields.each(function () {
        const inputField = $(this);
        const fieldName = inputField.attr("name");
        const label = inputField.attr("data-entry-label");
        const value = inputField.val();

        if (!formData[fieldsetId]) {
            formData[fieldsetId] = {};
        }
        if (fieldName) {
            formData[fieldsetId][fieldName] = { value, label };
        }
    });
}

function radioButtonsData(fieldset, formData) {
    const fieldsetId = fieldset.attr("id");
    var radioButtons = fieldset.find("input[name='gender']");

    radioButtons.each(function () {
        const radioButton = $(this);
        const fieldName = radioButton.attr("name");
        const label = radioButton.attr("data-entry-label");
        const value = $("input[name='gender']:checked").val();

        if (!formData[fieldsetId]) {
            formData[fieldsetId] = {};
        }
        formData[fieldsetId][fieldName] = { value, label };

    });
}

function processCheckboxes(fieldset, formData) {
    const fieldsetId = fieldset.attr("id");

    const checkboxes = fieldset.find("input[name='hobbies']:checked");

    if (fieldsetId === "personalDetails") {
        formData[fieldsetId]["hobbies"] = {
            value: checkboxes.map((index, checkbox) => $(checkbox).val()).get(),
            label: "Hobbies",
        };
    }
}

function displayFormData() {
    $(".modal-body").empty();
    $("#regForm").find("fieldset").each(function () {
        const fieldset = $(this);
        const fieldsetId = fieldset.attr("id");
        var storedData = JSON.parse(localStorage.getItem(fieldsetId));
        var container = $("<div>");
        for (var key in storedData) {
            if (storedData.hasOwnProperty(key)) {
                var fieldsetData = storedData[key];
                var fieldsetContainer = $("<div>");
                for (var fieldKey in fieldsetData) {
                    if (storedData.hasOwnProperty(key)) {
                        var fieldData = fieldsetData[fieldKey];
                        var value = fieldData.value;
                        var label = fieldData.label;
                        var paragraph = $("<p>").html(`<span class="label">${label}:</span><span class="value">${value}</span>`);
                        fieldsetContainer.append(paragraph).addClass("fieldsetContainer");
                    }
                }
                container.append(fieldsetContainer);
            }
        }
        $(".modal-body").append(container);
    })
}

function clearLocalStorage() {
    localStorage.clear();
}