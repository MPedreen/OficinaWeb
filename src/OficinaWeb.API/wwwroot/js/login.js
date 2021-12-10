function login(event) {

    event.preventDefault();

    var formData = {
        email: $("#Email").val(),
        password: $("#Senha").val()
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(formData),
        url: "",
        success: function (result) {

        },
        error: function (error) {

        }
    })
}