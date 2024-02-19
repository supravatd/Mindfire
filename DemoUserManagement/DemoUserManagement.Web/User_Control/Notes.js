function addNotes(objectId, noteData) {
    $.ajax({
        type: "POST",
        url: "NotesUC.ascx/AddNotes",
        data: JSON.stringify({ objectId: objectId, noteData: noteData }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Notes added successfully.");
        },
        error: function (xhr, status, error) {
            console.error("Error adding notes: " + error);
        }
    });
}

function getAllNotes(pageIndex, pageSize, objectId) {
    $.ajax({
        type: "POST",
        url: "NotesUC.ascx/GetAllNotes",
        data: JSON.stringify({ pageIndex: pageIndex, pageSize: pageSize, objectId: objectId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var notes = response.d;
            console.log("Received notes:", notes);
        },
        error: function (xhr, status, error) {
            console.error("Error getting notes: " + error);
        }
    });
}

function getTotalNotes(objectId) {
    $.ajax({
        type: "POST",
        url: "NotesUC.ascx/GetTotalNotes",
        data: JSON.stringify({ objectId: objectId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var totalNotes = response.d;
            console.log("Total notes:", totalNotes);
        },
        error: function (xhr, status, error) 
            console.error("Error getting total notes: " + error);
        }
    });
}

function getSortDirection(sortDirection) {
    $.ajax({
        type: "POST",
        url: "NotesUC.ascx/GetSortDirection",
        data: JSON.stringify({ sortDirection: sortDirection }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var newSortDirection = response.d;
            console.log("New sort direction:", newSortDirection);
        },
        error: function (xhr, status, error) {
            console.error("Error getting sort direction: " + error);
        }
    });
}

function bindNotesGrid(pageIndex, pageSize, sortExpression, sortDirection, objectId) {
    $.ajax({
        type: "POST",
        url: "NotesUControl.ascx/BindNotesGrid",
        data: JSON.stringify({ pageIndex: pageIndex, pageSize: pageSize, sortExpression: sortExpression, sortDirection: sortDirection, objectId: objectId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Notes grid binded successfully.");

        },
        error: function (xhr, status, error) {
            console.error("Error binding notes grid: " + error);
        }
    });
}
