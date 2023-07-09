
function Login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    $.ajax('http://localhost:5058/api/login/User',
        {
            type: 'POST',
            data: {
                "username": `${username}`,
                "password": `${password}`
            },
            success: function () {
                GetFoods();
            },
        });
}

function GetFoods() {
    $.ajax('http://localhost:5058/api/Food', {
        type: 'get',
        dataType: 'json',
        success: function (result) {
            MakeCard(result);
        }
    });
}


function MakeCard(data) {
    var title = document.getElementById('title');
    title.innerHTML = "Food Section";
    document.getElementById("login").remove();
    var goCart = $("<button class='btn btn-success m-4' onclick=''>Cart</button>")
    $("#container").append(goCart)
    for (var food of data) {
        var div = $("<div class='card border border-1'></div>")
        var imgPath = "./Photo/" + `${food.photoPath}`;
        var img = $(`<img class="card-img-top p-2 img-style" src="${imgPath}" />`);
        var body = $(`<div class="card-body text-center"></div>`);
        var header = $(`<h5 class="card-header text-center mb-2">${food.name}</h5>`);
        var text = $(`<div class="card-text text-style">${food.description}</div>`);
        var footer = $(`<div class="card-footer text-center">${food.price} T</div>`);
        var button = $('<button type="button" class="mt-2 btn btn-primary" onclick="">Add</button>')
        body.append(header);
        body.append(text);
        body.append(footer);
        body.append(button);
        div.append(img)
        div.append(body)
        $("#card").append(div)

    }
}

        