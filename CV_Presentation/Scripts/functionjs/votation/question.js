function loadVotation() {
    $.get('/ApiVotation/VotationCreated', function (data, status) {
        $.each(data, function (key, votation) {
            $("#cboVotation").append('<option value=' + votation.id + '>' + votation.title + '</option>');
        });
    });
}
function loadQuestion() {

    var id = $("#cboVotation").val();
    $("#cboPreguntas").empty();

    $.get('/ApiVotation/QuestionVotation?id=' + id, function (data, status) {
        $.each(data, function (key, preguntas) {
            $("#cboPreguntas").append('<option value=' + preguntas.id + '>' + preguntas.question + '</option>');
        });
    });
}
function loadAnswer() {
    var id = $("#cboPreguntas").val();

    $.get('/ApiVotation/QuestionAnswer?id=' + id, function (data, status) {
        var i = 1;
        $.each(data, function (key, respuestas) {
            var pregunta = $('select[name="preguntas"] option:selected').text();
            $("#txtPregunta").val(pregunta);
            $("#txtRespuesta" + i).val(respuestas.answer);
            console.log(respuestas);
            i++;
        });
    });
}
function downloadTemplate(file) {
    window.location = "/ApiVotation/DownloadTemplate?file=" + file;
}

function ImportCSV() {
    var cbov = $("#cboVotation").val();

    if (cbov == "0") {
        alert("Selecciona una votación");
    }
    else {
        if (window.FormData !== undefined) {
            var fileUpload = $("#txtfile").get(0);
            var files = fileUpload.files;

            if (files.length == 0) {

                alert("Seleccione un archivo csv");
            } else {

                var fileData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }
                fileData.append('VotationId', $("#cboVotation").val());
                $.ajax({
                    url: "/ApiVotation/UploadFile",
                    type: "POST",
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: fileData,
                    success: function (result) {
                        console.log(result);
                        alert(result);
                        loadQuestion();
                    },
                    error: function (err) {
                        alert(err.statusText);
                    }
                });
            }
        }
        else {
            alert("FormData is not supported.");
        }
    }
}


window.onload = function () {
    loadVotation();
}
