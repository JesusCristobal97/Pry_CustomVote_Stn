function clearElements() {
    $("#txtUsers").val('');
    $("#txtTitle").val('');
    $("#cboDiapo").val(0);
    $("#cboType").val(0);
}

function createVotation() {
    var votation = {
        users: $("#txtUsers").val(),
        title: $("#txtTitle").val(),
        status: 1,
        type: $("#cboType").val(),
        diapositive: false,
        ndiapositive: $("cboDiapo").val()
    }
    var json = JSON.stringify(votation);
    $.ajax({
        url: '/ApiVotation/OpenVotation',
        type: 'post',
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (data, textStatus, jQxhr) {
            alert("Votaciòn creada correctamente");
            clearElements();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert("Error al crear la votaciòn");
        }
    });
}
