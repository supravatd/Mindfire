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

    $('#documentGrid').on('click', 'th a', function (e) {
        e.preventDefault();

        var sortBy = $(this).data('sortby');
        $(this).toggleClass('asc desc');
        $('.sort-link').removeClass('active');
        $(this).addClass('active');

        var sortOrder = $(this).hasClass('asc') ? 'asc' : 'desc';
        var objectId = parseInt($("#objectId").val());

        $.ajax({
            url: '/Document/_DocumentPartial',
            type: 'GET',
            data: { objectId: objectId, page: 1, sortBy: sortBy, sortOrder: sortOrder },
            success: function (result) {
                $('#documentGrid tbody').html($(result).find('tbody').html());
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
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
            url: '/Document/UploadFile',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                console.log('File uploaded successfully. GUID: ' + data.FileName);

                $.ajax({
                    url: '/Document/DocumentPartial',
                    type: 'GET',
                    data: { objectId: objectId, objectType: objectType },
                    success: function (result) {
                        $('#documentGrid').html(result);
                    },
                    error: function () {
                        console.error('Error refreshing document grid.');
                    }
                });
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
        url: '/Document/DownloadFile',
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