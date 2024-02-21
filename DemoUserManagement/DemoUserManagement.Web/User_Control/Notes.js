function addNotes() {
    var noteData = document.getElementById('txtNotes').value;
    var objectId = document.getElementById('hfObjectId').value;
    $.ajax({
        type: "POST",
        url: "RegisterForm.aspx/AddNotes",
        data: JSON.stringify({ noteData: noteData, objectId: objectId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Notes Added");
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}
