function loadVotation() {
    $.get('/ApiVotation/VotationCreated', function (data, status) {
        $.each(data, function (key, votation) {
            $("#cboVotation").append('<option value=' + votation.id + '>' + votation.title + '</option>');
        });
    });
}

function viewOptions() {
    var options = $("#cbopOpciones").val();
    console.log("options are" + options);
    var max = 6;
    for (var i = 1; i <= max; i++) {
        if (i <= options) {
            $("#Divopcion" + i).css("display", "block");
        }
        else {
            $("#Divopcion" + i).css("display", "none");
            $("#Divopcion" + i).val("");
        }
    }

}

function registerOption(letter, value, color) {



    var opt = {
        votationId: $("#cboVotation").val(),
        letter: letter,
        valueoption: value,
        color: "#" + color
    }
    var json = JSON.stringify(opt);
    console.log(opt);

    $.ajax({
        url: '/ApiVotation/CreateOptionvotation',
        type: 'post',
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (data, textStatus, jQxhr) {
            console.log(data);
            window.location.href = '/Home/IndexVotation';
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log("error es " + errorThrown);
            alert("Error al crear la Opciones");
        }
    });

}

function registerAllOption() {
    var cbov = $("#cboVotation").val();
    if (cbov == 0) {
        alert("Elija una votación");
    } else if ($("#txt1").val() == "") {
        alert("Complete los campos");
    }
    else {
        for (var i = 1; i < 7; i++) {
            if ($("#txt" + i).val() != "") {
                registerOption(i, $("#txt" + i).val(), $("#color" + i).val());

            }
        }
        alert("Opciones creadas correctamente");
    }
}

window.onload = function () {
    loadVotation();
}