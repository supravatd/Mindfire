$(document).ready(function () {
    $("#bttnSubmit").click(function (e) {
        e.preventDefault();
        if (validateForm()) {
            $("form").submit();
        }
    });
});

function validateForm() {
    $(".error").text("").removeClass("errorMessage");

    $(".body-content input[type='text'][data-bs-toggle='tooltip'], .body-content input[type='email'][data-bs-toggle='tooltip']").each(function () {
        validateInput(this);
    });

    $(".body-content select[data-bs-toggle='tooltip']").each(function () {
        validateSelectInput(this);
    });

    $(".body-content .radio-group[data-bs-toggle='tooltip']").each(function () {
        validateRadioGroup(this);
    });

    $(".body-content .checkbox-group[data-bs-toggle='tooltip']").each(function () {
        validateCheckboxGroup(this);
    });

    $("[data-bs-toggle='tooltip']").on("input", function () {
        const inputField = $(this);
        inputField.tooltip('hide');
        inputField.removeClass("is-invalid");
    });

    function validateInput(inputField) {
        const label = $(inputField).attr("data-entry-label");
        const error = $(inputField).parent().find(".error");

        if ($(inputField).val().trim() === "") {
            const errorMessage = `${label} is required.`;
            error.text(errorMessage).addClass("errorMessage");

            $(inputField).tooltip('dispose');
            $(inputField).tooltip('show');
            $(inputField).addClass("is-invalid");
        } else if ($(inputField).prop("type") === "email" && !isValidEmail($(inputField).val())) {
            const errorMessage = `${label} is not a valid email address.`;
            error.text(errorMessage).addClass("errorMessage");

            $(inputField).tooltip('dispose');
            $(inputField).tooltip('show');
            $(inputField).addClass("is-invalid");
        } else {
            error.text("").removeClass("errorMessage");
            $(inputField).tooltip('hide');
            $(inputField).removeClass("is-invalid");
            $(inputField).addClass("is-valid");
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
        } else {
            error.text("").removeClass("errorMessage");
            $(selectInput).tooltip('hide');
            $(selectInput).removeClass("is-invalid");
            $(selectInput).addClass("is-valid");
        }
    }

    function validateRadioGroup(radioGroup) {
        const label = $(radioGroup).attr("data-entry-label");
        const error = $(radioGroup).parent().find(".error");

        if (!$(radioGroup).find("input[type='radio']:checked").val()) {
            const errorMessage = `${label} is required.`;
            error.text(errorMessage).addClass("errorMessage");
        } else {
            error.text("").removeClass("errorMessage");
        }
    }

    function validateCheckboxGroup(checkboxGroup) {
        const label = $(checkboxGroup).attr("data-entry-label");
        const error = $(checkboxGroup).parent().find(".error");

        if (!$(checkboxGroup).find("input[type='checkbox']:checked").length) {
            const errorMessage = `${label} is required.`;
            error.text(errorMessage).addClass("errorMessage");
        } else {
            error.text("").removeClass("errorMessage");
        }
    }

    function isValidEmail(email) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }

    return !hasErrors();
}

function hasErrors() {
    return $(".body-content .error.errorMessage").length > 0;
}
