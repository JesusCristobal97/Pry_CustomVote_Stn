function loadVotation() {
    $.get("/ApiVotation/VotationCreated", function (data, status) {
        $.each(data, function (key, votation) {
            $("#cboVotation").append('<option value=' + votation.id + '>' + votation.title + '</option>');
        });
    });
}
function downloadTemplate(file) {
    window.location = '/ApiVotation/DownloadTemplate?file=' + file;
}

function ImportCSV() {
    var cbov = $("#cboVotation").val();

    if (cbov == "0") {
        alert("Selecciona una votación");
    } else {

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
                    url: '/ApiVotation/UploadFileVotants',
                    type: "POST",
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: fileData,
                    success: function (result) {
                        alert("CSV insertado correctamente");
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

function registerVotantes() {
    var cbov = $("#cboVotation").val();

    if (cbov == "0") {
        alert("Selecciona una votación");
    } else {
        if ($("#txtnombre").val() == "") {
            alert("Campo nombre obligatorio");
        } else if ($("#txtapellido").val() == "") {
            alert("Campo apellido obligatorio");

        } else if ($("#txtdni").val() == "") {
            alert("Campo DNI obligatorio");

        } else if ($("#txtusuario").val() == "") {
            alert("Campo usuario obligatorio");

        } else if ($("#txtpassword").val() == "") {
            alert("Campo contraseña obligatorio");

        } else {
            var userVote = {
                login: $("#txtusuario").val(),
                password: $("#txtpassword").val(),
                typeUserid: 3,
                votationid: $("#cboVotation").val(),
                nameUser: $("#txtnombre").val(),
                lastnameUser: $("#txtapellido").val(),
                dni: $("#txtdni").val()
            }
            var json = JSON.stringify(userVote);
            console.log(userVote);

            $.ajax({
                url: '/ApiVotation/CreateUserVotation',
                type: 'post',
                dataType: 'JSON',
                contentType: 'application/json; charset=utf-8',
                data: json,
                success: function (data, textStatus, jQxhr) {
                    alert("Votante creado correctamente");
                    clearElments();
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log("error es " + errorThrown);
                    alert("Error al crear la Opciones");
                }
            });
        }
    }

}

function validateField() {
    if ($("#txtnombre").val() == "") {
        alert("Campo nombre obligatorio");
        return false;
    } else if ($("#txtapellido").val() == "") {
        alert("Campo apellido obligatorio");
        return false;

    } else if ($("#txtdni").val() == "") {
        alert("Campo DNI obligatorio");
        return false;

    } else if ($("#txtusuario").val() == "") {
        alert("Campo usuario obligatorio");
        return false;

    } else if ($("#txtpassword").val() == "") {
        alert("Campo contraseña obligatorio");
        return false;

    }
}

function clearElments() {
    $("#txtnombre").val("");
    $("#txtapellido").val("");
    $("#txtdni").val("");
    $("#txtusuario").val("");
    $("#txtpassword").val("");
}

window.onload = function () {
    loadVotation();
}