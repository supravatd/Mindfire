$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/Document/GetDocumentTypes",
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
    $('#documentGrid').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/DocumentV2/_DocumentPartialV2",
            "type": "POST",
            "data": function (d) {
                d.objectId = $('#objectId').val();
                d.sortBy = "DocumentID"
            }
        },
        "columns": [
            { "data": "DocumentID" },
            { "data": "ObjectID" },
            { "data": "ObjectType" },
            { "data": "DocumentType" },
            { "data": "DocumentOriginalName" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="#" class="download-link" data-filename="' + row.DocumnetNameOnDisk + '" data-original-filename="' + row.DocumentOriginalName + '">Download</a>';
                }
            },
            { "data": "AddedOn" }
        ]
    });
    $('#btnUpload').on('click', function () {
        var fileInput = $('#fileUpload')[0].files[0];
        var objectId = $('#objectId').val();
        var objectType = $('#objectType').val();

        if (!fileInput) {
            alert("Please select a file.");
            return;
        }

        var documentTypeId = $('#ddlDocumentType').val();

        var formData = new FormData();
        formData.append('file', fileInput);
        formData.append('documentTypeId', documentTypeId);
        formData.append('objectId', objectId);
        formData.append('objectType', objectType);

        $.ajax({
            url: '/DocumentV2/UploadFile',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                console.log('File uploaded successfully. GUID: ' + data.FileName);
            },
            error: function () {
                console.error('Error uploading file.');
            }
        });
    });
    $('.download-link').click(function (e) {
        e.preventDefault();
        var fileName = $(this).data('filename');
        var originalFileName = $(this).data('original-filename');
        downloadFile(fileName, originalFileName);
    });
});

function downloadFile(fileName, originalFileName) {
    $.ajax({
        url: '/DocumentV2/DownloadFile',
        type: 'GET',
        data: { fileName: fileName, originalFileName: originalFileName },
        xhrFields: {
            responseType: 'blob'
        },
        success: function (data, textStatus, jqXHR) {
            var a = document.createElement('a');
            var url = window.URL.createObjectURL(data);
            a.href = url;
            a.download = originalFileName;
            document.body.append(a);
            a.click();
            a.remove();
            window.URL.revokeObjectURL(url);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Error downloading file:', errorThrown);
        }
    });
}