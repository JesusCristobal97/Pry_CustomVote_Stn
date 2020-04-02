function loadVotation() {
    $.get('/ApiVotation/VotationCreated', function (data, status) {
        $.each(data, function (key, votation) {
            $("#cboVotation").append('<option value=' + votation.id + '>' + votation.title + '</option>');
        });
    });
}
function loadTypeGraphic() {
    $.get('/ApiVotation/TypeGraphic', function (data, status) {
        $.each(data, function (key, graphic) {
            $("#cboGrafico").append('<option value=' + graphic.id + '>' + graphic.descripcion + '</option>');
        });
    });
}

function createGraphic() {
    var cbov = $("#cboVotation").val();
    var cbog = $("#cboGrafico").val();
    if (cbov == "0") {
        alert("Seleccione una votación");
    } else if (cbog == "0") {
        alert("Seleccione un gráfico");
    }
    else {
        if (window.FormData !== undefined) {
            var fileUpload = $("#txtImage").get(0);
            var files = fileUpload.files;

            if (files.length == 0) {
                alert("Seleccione una imagen");
            } else {

                var fileData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }
                fileData.append('VotationId', $("#cboVotation").val());
                fileData.append('GraphicId', $("#cboGrafico").val());
                fileData.append('Width', $("#txtwidth").val());
                fileData.append('Height', $("#txtheight").val());

                $.ajax({
                    url: '/ApiVotation/UploadImage',
                    type: "POST",
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: fileData,
                    success: function (result) {
                        alert("Gràfico registrado correctamente");
                        window.location.href = '/Home/IndexVotation';
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
    loadTypeGraphic();
}