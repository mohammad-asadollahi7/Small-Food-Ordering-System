
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
    for (var i = 0; i < data.length; i++) {
        var div = $("<div class='card border border-1'></div>")
        var hiddenId = $(`<div id="foodId${i}" class="d-none">${data[i].id}</div>`);
        var imgPath = "./Photo/" + `${data[i].photoPath}`;
        var img = $(`<img id='foodImg${i}' class="card-img-top p-2 img-style" src="${imgPath}" />`);
        var body = $(`<div class="card-body text-center"></div>`);
        var header = $(`<h5 id="foodName${i}" class="card-header text-center mb-2">${data[i].name}</h5>`);
        var text = $(`<div id="foodDescription${i}" class="card-text text-style">${data[i].description}</div>`);
        var footer = $(`<div id="foodPrice${i}" class="card-footer text-center">${data[i].price}</div>`);
        var button = $(`<button type="button" class="mt-2 btn btn-primary" onclick="AddFood(${i})">Add</button>`);
        body.append(hiddenId);
        body.append(header);
        body.append(text);
        body.append(footer);
        body.append(button);
        div.append(img)
        div.append(body)
        $("#card").append(div)
    }
}


function AddFood(i) {

    var id = document.getElementById(`foodId${i}`).innerHTML;
    var name = document.getElementById(`foodName${i}`).innerHTML;
    var photo = document.getElementById(`foodImg${i}`).getAttribute("src");
    var description = document.getElementById(`foodDescription${i}`).innerHTML;
    var price = document.getElementById(`foodPrice${i}`).innerHTML;
   
    $.ajax({
        type: "POST",
        url: "http://localhost:5058/api/Order",
        data: JSON.stringify(
            
                {
                    "Id":`${id}`,
                    "Name":`${name}`,
                    "Price":`${price}`,
                    "Description":`${description}`,
                    "PhotoPath":`${photo}`
                }),

        contentType: "application/json",
        success: function (msg) {
            alert('The Food was added to your cart');
        }
    });
}

