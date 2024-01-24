var entityMappings = {
    "user": ["FirstName", "LastName", "UserName", "Password", "AccountId"],
    "transfer": ["Code", "DateTime", "Amount", "OriginAccountId"],
    "account": ["Code", "MoneyAmount", "UserId"]
};

const button = document.getElementById("action-button");
var urlEnd = "/Insert";
var id = 0;
var entityName = $("#elementType").val();

if (!button.classList.contains("add")) {
    id = parseInt($("#" + entityName + "Id").val(), 10);
}

if (button.classList.contains("update")) {
    urlEnd = "/Update";
} else if (button.classList.contains("delete")) {
    urlEnd = "/Delete";
} else {
    urlEnd = "/Insert";
}

function buildJsonObject(entityName, id) {
    var json = { "Id": id };

    entityMappings[entityName].forEach(function (field) {
        json[field] = $("#" + entityName + field).val();
        if ($("#" + entityName + field).attr("type") == "number") {
            json[field] = parseInt(json[field]);
        }
    });

    return json;
}

function capitalizeFirstLetter(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

button.onclick = function () {
    var target = capitalizeFirstLetter(entityName);

    var json = buildJsonObject(entityName, id);

    $.ajax({
        type: "POST",
        url: "/" + target + urlEnd,
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.status === 200) {
                alert("Acción realizada con éxito");
            } else {
                alert("No se pudo realizar la acción");
            }
            window.location.href = "/" + target + "/Index";
        },
        error: function (response) {
            console.log("Error:", "error genérico", response);
        }
    });
};