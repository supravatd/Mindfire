document.getElementById('btnUpload').addEventListener('click', function () {
    var fileInput = document.getElementById('fileUpload');
    var file = fileInput.files[0];

    if (!file) {
        alert("Please select a file.");
        return;
    }

    var documentTypeId = document.getElementById('ddlDocumentType').value;

    var formData = new FormData();
    formData.append('file', file);
    formData.append('documentTypeId', documentTypeId);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'FileUploadHandler.ashx', true);

    xhr.onload = function () {
        if (xhr.status === 200) {
            var fileInfo = JSON.parse(xhr.responseText);

            console.log('File uploaded successfully. GUID: ' + fileInfo.FileName);
        } else {
            console.error('Error uploading file.');
        }
    };

    xhr.send(formData);
});

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/GetDocumentTypes",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var ddlDocumentType = $('#ddlDocumentType');
            ddlDocumentType.empty();
            $.each(response.d, function (key, value) {
                ddlDocumentType.append($("<option></option>").val(value.DocumentTypeID).text(value.DocumentTypeName));
            });
        },
        failure: function (response) {
            alert(response.d);
        }
    });
});
