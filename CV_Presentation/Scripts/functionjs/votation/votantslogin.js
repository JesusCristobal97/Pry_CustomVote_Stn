function sendlogin() {
    var userv = {
        login: $("#usuario").val(),
        password: $("#password").val()
    }
    var json = JSON.stringify(userv);
    $.ajax({
        url: '/ApiUserVote/Login',
        type: 'post',
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        data: json,
        success: function (data, textStatus, jQxhr) {
            alert(data);
            window.location.href = '/Vote/Index';
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log("error es " + errorThrown);
            alert("Usuario no registrado");
        }
    });
}