function changueVisibility(val) {
    $.get("/ApiVote/ChangueVisibility?visible=" + val, function (data, status) {
        console.log(data);
    });
}

function selectQuestionforVotation() {
    $.get("/ApiVote/SelectQuestionforVotation", function (data, status) {
        console.log(data);
    });
}
function deleteQuestion() {
    $.get("/ApiVote/DeleteQuestion", function (data, status) {
        alert(data);
        console.log(data);
    });
}
function deleteAllQuestion() {
    $.get("/ApiVote/DeleteAllQuestion", function (data, status) {
        alert(data);
        console.log(data);
    });
}

function stopVotation() {
    $.get("/ApiVote/StopVotación", function (data, status) {
        alert(data);
        console.log(data);
    });
}

function getDetaill() {
    $.get("/ApiVote/GetDetaillVote", function (data, status) {
        // alert(data);
        $("#RequestModal").empty();
        console.log(data);
        var tableHtml = '<table class="table table-bordered"><thead><tr><th scope="col">Nombre</th><th scope="col">Apellidos</th><th scope="col">Resultado</th><th scope="col">Fecha y hora</th></tr></thead><tbody>';
        for (var i = 0; i < data.length; i++) {
            tableHtml += '<tr>'
                + '<td>' + data[i].nameuser + '</td >'
                + '<td>' + data[i].lastname + '</td >'
                + '<td>' + data[i].result + '</td >'
                + '<td>' + data[i].fhvotacion + '</td >'
                + '</tr > ';
        }
        tableHtml += '</tbody></table>';
        $("#RequestModal").append(tableHtml);
    });
}