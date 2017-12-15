function editFeedback(id) {
    var description = $("#feed-" + id + " #feed-description").val();
    var note = $("#feed-" + id + " #feed-note").val();
    var serviceURL = "/feedbacks/Edit/" + id;
    $.ajax({
        type: "POST",
        url: "http://localhost:60350/feedbacks/Edit/" + id + "/" + description + "/" + note,
        data: "",
        //data: { description: description, id: id, note: note },
        //data: { Description: description, ID: id, Note: note },
        //data: "Description="+description+"&ID="+id+"&Note="+note ,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}