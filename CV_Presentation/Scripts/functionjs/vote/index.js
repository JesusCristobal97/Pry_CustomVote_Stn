setInterval('getQuestions()', 2000);

function getQuestions() {
    var abc = ["0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j"];


    $.get('/ApiVote/getQuestions', function (data, status) {
        if (data[0] != null) {
            $("#control").css("display", "block");
            console.log(data);
            console.log(data.question);
            $("#Respuesta").empty();
            $("#Pregunta").html(data[0]);
            for (var i = 1; i < data.length; i++) {
                console.log(data[i]);
                $("#Respuesta").append("<h3 class='op'>" + abc[i] + ". " + data[i] + "<h3>");

            }
        } else {
            $("#lblOK").html("");
            $("#lblData").html("");
            $("#Respuesta").empty();
            $("#Pregunta").html("Votación Cerrada");
            $("#control").css("display", "none");
        }


    });
}

function setVote(value) {
    var d = new Date();
    var mes = d.getMonth() + 1;
    var fechavotacion = d.getDate() + "/" + mes + "/" + d.getFullYear() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();

    var v = {
        result: value,
        datevote: fechavotacion
    }

    var json = JSON.stringify(v);

    $.ajax({
        url: '/ApiVote/CreateVote',
        type: 'post',
        dataType: 'JSON',
        contentType: "application/json; charset=utf-8",
        data: json,
        success: function (data, textStatus, jQxhr) {

            $("#lblOK").html("OK");
            $("#lblData").html(value);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}