
function Login() {
    debugger;
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    $.ajax('http://localhost:5058/api/login/User',
        {
            type: 'POST',
            data: {
                "username": `${username}`,
                "password": `${password}`
            },
            dataType: 'json',
            success: function (data) {
                var food = document.getElementById("foods");
                food.innerHTML = data;
            },

        });
}