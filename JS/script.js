//Form Validation
function validateInput(inputField, initial = false) {
  const label = inputField.getAttribute("data-entry-label");
  const error = inputField.parentElement.querySelector(".errorDisplay");
  if (inputField.tagName === "SELECT") {
    validateSelectInput(inputField);
  } else {
    if (inputField.value.trim() === "") {
      const errorMessage = `${label} is required.`;
      error.textContent = errorMessage;
      error.classList.add("errorMessage");
    } else {
      if (inputField.type === "email") {
        if (!isValidEmail(inputField.value)) {
          const errorMessage = `${label} is not a valid email address.`;
          error.textContent = errorMessage;
          error.classList.add("errorMessage");
          return;
        }
      } else {
        error.textContent = "";
        error.classList.remove("errorMessage");
      }

      if (initial) {
        error.style.display = "";
      }
    }
  }
}

function isValidEmail(email) {
  const emailRegex = /^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$/;
  return emailRegex.test(email);
}

function validateSelectInput(selectInput) {
  const label = selectInput.getAttribute("data-entry-label");
  const error = selectInput.parentElement.querySelector(".errorDisplay");

  if (selectInput.value === "") {
    const errorMessage = `Please select a ${label}.`;
    error.textContent = errorMessage;
    error.classList.add("errorMessage");
  } else {
    error.textContent = "";
    error.classList.remove("errorMessage");
  }
}

// Select Field Display
window.onload = function () {
  const countryState = {
    India: ["Delhi", "Karnataka", "Mumbai", "Odisha", "Tamil Nadu", "Chennai"],
    USA: ["California", "Texas", "Florida", "Georgia", "Washington", "Hawaii"],
    Germany: ["Hamburg", "Berlin", "Bavaria", "Bremen"],
  };
  const idTypes = ["Aadhar", "Pan", "DL", "Voter"];
  const branch = ["CSE", "IT", "CSSE", "ETC", "CSCE"];
  const xboard = ["CISCE", "CBSE", "Other"];
  const xiiboard = ["CISCE", "CBSE", "Other"];

  const selectPresentCountry = document.querySelector("[name='presentAddressCountry']");
  const selectPresentState = document.querySelector("[name='presentAddressState']");
  const selectPermanentCountry = document.querySelector("[name='permanentAddressCountry']");
  const selectPermanentState = document.querySelector("[name='permanentAddressState']");
  const selectIdType = document.querySelector("[name='idType']");
  const selectBranch = document.querySelector("[name='branch']");
  const selectxiiBoard = document.querySelector("[name='xiiboard']");
  const selectxBoard = document.querySelector("[name='xboard']");

  function selectCountryState(countrySelection, stateSelection, options) {
    stateSelection.length = 1;
    for (let option of options) {
      stateSelection.options[stateSelection.options.length] = new Option(option, option);
    }
    countrySelection.disabled = false;
    stateSelection.disabled = false;
  }

  function selectList(selection, options) {
    options.forEach(function (type) {
      var optionElement = document.createElement("option");
      optionElement.value = type;
      optionElement.textContent = type;
      selection.appendChild(optionElement);
    });
  }

  for (let country in countryState) {
    selectPresentCountry.options[selectPresentCountry.options.length] = new Option(country, country);
  }
  selectPresentCountry.onchange = (e) => {
    selectCountryState(selectPresentCountry, selectPresentState, countryState[e.target.value]);
  };

  for (let country in countryState) {
    selectPermanentCountry.options[selectPermanentCountry.options.length] = new Option(country, country);
  }
  selectPermanentCountry.onchange = (e) => {
    selectCountryState(selectPermanentCountry, selectPermanentState, countryState[e.target.value]);
  };

  selectList(selectIdType, idTypes);
  selectList(selectBranch, branch);
  selectList(selectxiiBoard, xiiboard);
  selectList(selectxBoard, xboard);
};

// Copy Present to Permanent Address
var sameAsPresent = document.getElementById("sameAsPresent");
sameAsPresent.addEventListener("change", copyPresent(sameAsPresent));

function copyPresent(sameAsPresent) {
  return () => {
    if (sameAsPresent.checked) {
      const houseNo = document.getElementsByName("presentAddressHouse")[0].value;
      const street = document.getElementsByName("presentAddressStreet")[0].value;
      const presentAddCity = document.getElementsByName("presentAddressCity")[0].value;
      const pincode = document.getElementsByName("presentAddressPincode")[0].value;
      const presentAddCountry = document.getElementsByName("presentAddressCountry")[0].value;
      const presentAddState = document.getElementsByName("presentAddressState")[0].value;

      document.getElementsByName("permanentAddressHouseNo")[0].value = houseNo;
      document.getElementsByName("permanentAddressStreet")[0].value = street;
      document.getElementsByName("permanentAddressPincode")[0].value = pincode;

      const country = document.getElementsByName("permanentAddressCountry")[0];
      country.innerHTML = `<option value="${presentAddCountry}">${presentAddCountry}</option>`;
      country.value = presentAddCountry;

      const state = document.getElementsByName("permanentAddressState")[0];
      state.innerHTML = `<option value="${presentAddState}">${presentAddState}</option>`;
      state.value = presentAddState;

      document.getElementsByName("permanentAddressCity")[0].value = presentAddCity;

      var permanentAddressFields = document.querySelectorAll("[data-permanent-address]");

      permanentAddressFields.forEach((inputField) => { inputField.disabled = true; });
    }
  };
}

function hasErrors() {
  var errorFields = document.querySelectorAll("fieldset .errorDisplay");
  for (var i = 0; i < errorFields.length; i++) {
    if (errorFields[i].textContent !== null && errorFields[i].textContent !== '') {
      return true;
    }
  }
  return false;
}

function processFormData() {
  var formData = {};
  var fieldsets = document.querySelectorAll("fieldset");

  fieldsets.forEach(function (fieldset) {
    inputFieldsData(fieldset, formData);
    radioButtonsData(fieldset, formData);
    processCheckboxes(fieldset, formData);
  });
  localStorage.setItem("formData", JSON.stringify(formData));
  displayFormData();
}

function inputFieldsData(fieldset, formData) {
  var fieldsetId = fieldset.id;
  var inputFields = fieldset.querySelectorAll("[display-all-data]");

  inputFields.forEach(function (inputField) {
    var fieldName = inputField.getAttribute("name");
    if (fieldName) {
      var label = inputField.getAttribute("data-entry-label");
      var value = inputField.value;

      if (!formData[fieldsetId]) {
        formData[fieldsetId] = {};
      }
      formData[fieldsetId][fieldName] = { value: value, label: label };
    }
  });
}

function radioButtonsData(fieldset, formData) {
  var fieldsetId = fieldset.id;
  var radioButtons = fieldset.querySelectorAll("input[name='gender']");

  radioButtons.forEach(function (radioButton) {
    var fieldName = radioButton.getAttribute("name");
    if (fieldName) {
      var label = radioButton.getAttribute("data-entry-label");
      var value = radioButton.value;

      if (!formData[fieldsetId]) {
        formData[fieldsetId] = {};
      }
      if (!formData[fieldsetId][fieldName]) {
        formData[fieldsetId][fieldName] = { value: "", label: label };
      }
      if (radioButton.checked) {
        formData[fieldsetId][fieldName].value = value;
      }
    }
  });
}

function processCheckboxes(fieldset, formData) {
  var fieldsetId = fieldset.id;
  var checkboxes = fieldset.querySelectorAll("input[name='hobbies']:checked");

  if (fieldsetId === "personalDetails") {
    formData[fieldsetId]["hobbies"] = {
      value: Array.from(checkboxes).map((checkbox) => checkbox.value),
      label: "Hobbies",
    };
  }
}

function displayFormData() {
  var displayData = document.getElementById("displayModalBox");
  var displayContent = document.getElementById("displayData");
  displayData.style.display = "block";
  divDisplay = displayContent.getElementsByClassName("div-display");

  while (divDisplay.length > 0) {
    divDisplay[0].remove();
  }

  var storedData = JSON.parse(localStorage.getItem("formData"));

  var container = document.createElement("div");

  for (var key in storedData) {
    if (storedData.hasOwnProperty(key)) {
      var fieldsetData = storedData[key];
      var fieldsetContainer = document.createElement("div");
      fieldsetContainer.classList.add("fieldsetContainer");

      for (var fieldKey in fieldsetData) {
        if (fieldsetData.hasOwnProperty(fieldKey)) {
          var fieldData = fieldsetData[fieldKey];
          var value = fieldData.value;
          var label = fieldData.label;

          var paragraph = document.createElement("p");
          paragraph.innerHTML = `<span class="label">${label}:</span><span class="value">${value}</span>`;
          fieldsetContainer.appendChild(paragraph);
        }
      }
      container.appendChild(fieldsetContainer).classList.add("div-display");
    }
  }

  displayContent.appendChild(container);
}

var submitButton = document.getElementById("bttnSubmit");
submitButton.onclick = function (event) {
  event.preventDefault();
  if (!hasErrors()) {
    processFormData();
  } else {
    var displayError = document.getElementById("displayModalError");
    var errorMessageContainer = document.getElementById("errorMessageContainer");
    displayError.style.display = "block";
    errorMessageContainer.innerHTML = "Complete all fields"
  }
  return false;
};

window.onclick = function (event) {
  if (event.target == document.getElementById("displayModalError")) {
    document.getElementById("displayModalError").style.display = "none";
  }
};

function clearLocalStorage() {
  localStorage.clear();
  closeDisplayModal();
  return false;
}

function closeDisplayModal() {
  var displayData = document.getElementById("displayModalBox");
  displayData.style.display = "none";
  return false;
}
