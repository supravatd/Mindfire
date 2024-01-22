$(document).ready(function () {
  const countryState = {
    India: ["Delhi", "Karnataka", "Mumbai", "Odisha", "Tamil Nadu", "Chennai"],
    USA: ["California", "Texas", "Florida", "Georgia", "Washington", "Hawaii"],
    Germany: ["Hamburg", "Berlin", "Bavaria", "Bremen"],
  };
  const idTypes = ["Aadhar", "Pan", "DL", "Voter"];
  const branch = ["CSE", "IT", "CSSE", "ETC", "CSCE"];
  const xboard = ["CISCE", "CBSE", "Other"];
  const xiiboard = ["CISCE", "CBSE", "Other"];

  const selectIdType = $("[name='idType']");
  const selectBranch = $("[name='branch']");
  const selectxiiBoard = $("[name='xiiboard']");
  const selectxBoard = $("[name='xboard']");

  $.each(countryState, function (country, states) {
    $('#selectPresentCountry').append(new Option(country, country));
    $('#selectPermanentCountry').append(new Option(country, country));
  });

  $('#selectPresentCountry').on('change', function (e) {
    var selectedValue = $(this).val();
    selectCountryState($('#selectPresentCountry'), $('#selectPresentState'), countryState[selectedValue]);
  });

  $('#selectPermanentCountry').on('change', function (e) {
    var selectedValue = $(this).val();
    selectCountryState($('#selectPermanentCountry'), $('#selectPermanentState'), countryState[selectedValue]);
  });

  selectList(selectIdType, idTypes);
  selectList(selectBranch, branch);
  selectList(selectxiiBoard, xiiboard);
  selectList(selectxBoard, xboard);

  $('#sameAsPresent').click(function () {
    if ($(this).prop("checked") == true)
      copyPresent($('#sameAsPresent'));
  });

  function hasErrors() {
    var errorFields = $("fieldset .errorDisplay");
    for (var i = 0; i < errorFields.length; i++) {
      if ($(errorFields[i]).text() !== null && $(errorFields[i]).text() !== '') {
        return true;
      }
    }
    return false;
  }

  function processFormData() {
    $("#regFormBody").find("fieldset").each(function () {
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
    $("#displayModalBox").css("display", "block");
    $("#displayData .div-display").remove();
    $("#regFormBody").find("fieldset").each(function () {
      const fieldset = $(this);
      const fieldsetId = fieldset.attr("id");
      var storedData = JSON.parse(localStorage.getItem(fieldsetId));
      var container = $("<div>");

      for (var key in storedData) {
        if (storedData.hasOwnProperty(key)) {
          var fieldsetData = storedData[key];
          var fieldsetContainer = $("<div>").addClass("fieldsetContainer");

          for (var fieldKey in fieldsetData) {
            if (storedData.hasOwnProperty(key)) {
              var fieldData = fieldsetData[fieldKey];
              var value = fieldData.value;
              var label = fieldData.label;

              var paragraph = $("<p>").html(`<span class="label">${label}:</span><span class="value">${value}</span>`);
              fieldsetContainer.append(paragraph);
            }
          }
          container.append(fieldsetContainer).addClass("div-display");
        }
      }
      $("#displayData").append(container);
    })
  }

  $("#bttnSubmit").on("click", function (event) {
    event.preventDefault();
    if (!hasErrors()) {
      processFormData();
    } else {
      $("#displayModalError").css("display", "block");
      $("#errorMessageContainer").html("Complete all fields");
    }
    return false;
  });

  $(window).on("click", function (event) {
    if ($(event.target).is("#displayModalError")) {
      $("#displayModalError").css("display", "none");
    }
  });

});

function validateInput(inputField, initial = false) {
  const label = $(inputField).attr("data-entry-label");
  const error = $(inputField).parent().find(".errorDisplay");

  if ($(inputField).prop("tagName") === "SELECT") {
    validateSelectInput(inputField);
  } else {
    if ($(inputField).val().trim() === "") {
      const errorMessage = `${label} is required.`;
      error.text(errorMessage).addClass("errorMessage");
    } else {
      if ($(inputField).prop("type") === "email") {
        if (!isValidEmail($(inputField).val())) {
          const errorMessage = `${label} is not a valid email address.`;
          error.text(errorMessage).addClass("errorMessage");
          return;
        }
      } else {
        error.text("").removeClass("errorMessage");
      }

      if (initial) {
        error.css("display", "");
      }
    }
  }
}

function validateSelectInput(selectInput) {
  const label = $(selectInput).attr("data-entry-label");
  const error = $(selectInput).parent().find(".errorDisplay");

  if ($(selectInput).val() === "") {
    const errorMessage = `Please select a ${label}.`;
    $(error).text(errorMessage).addClass("errorMessage");
  } else {
    $(error).text("").removeClass("errorMessage");
  }
}

function isValidEmail(email) {
  const emailRegex = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$/;
  return emailRegex.test(email);
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

function clearLocalStorage() {
  localStorage.clear();
  closeDisplayModal();
  return false;
}

function closeDisplayModal() {
  $("#displayModalBox").css("display", "none");
  return false;
}