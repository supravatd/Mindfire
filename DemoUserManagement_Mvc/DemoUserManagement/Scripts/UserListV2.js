$(document).ready(function () {
    $('#userTable').DataTable({
        "processing": true,
        "serverSide": true,
        "ordering": true,
        "ajax": {
            "url": "/UserListV2/GetUserListData",
            "type": "POST"
        },
        "columns": [
            { "data": "UserId" },
            { "data": "FirstName" },
            { "data": "Email" },
            {
                "data": "Dob",
                "render": function (data) {
                    var date = new Date(parseInt(data.substr(6)));
                    return date.toLocaleDateString(undefined, { year: 'numeric', month: 'long', day: 'numeric' });
                }
            },
            { "data": "MobileNo" },
            { "data": "Gender" },
            { "data": "Hobbies" },
            {
                "data": "FileOriginal",
                "render": function (data, type, row) {
                    if (data && row.FileGuid) {
                        var downloadUrl = '/UploadDocuments/' + row.FileGuid + '&name=' + encodeURIComponent(data);
                        return '<a href="' + downloadUrl + '" class="btn btn-link" download="' + data + '">' + data + '</a>';
                    }
                    return '';
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/UserFormV2/EditUserV2/' + row.UserId + '" class="btn btn-primary btn-sm">Edit</a>';
                }
            }
        ]
    });
});