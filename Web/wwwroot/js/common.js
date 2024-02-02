var entityMapping = [];

$('#fields > div').each(function () {
    var name = $(this).find('input').attr('name');
    entityMapping.push(name);
});

function entitySave(entityName, id, entityMapping, urlEnd) {
    var json = buildJsonObject(entityName, id, entityMapping);

    $.ajax({
        type: "POST",
        url: "/" + entityName + urlEnd,
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.status === 200) {
                alert("Acción realizada con éxito");
            } else {
                alert("No se pudo realizar la acción");
            }
            window.location.href = "/" + entityName + "/Index";
        },
        error: function (response) {
            console.log("Error:", "error genérico", response);
        }
    });
}

function buildJsonObject(entityName, id, entityMapping) {
    var json = { "Id": id };

    entityMapping.forEach(function (field) {
        json[field] = $("#" + entityName + field).val();
        if ($("#" + entityName + field).attr("type") == "number") {
            json[field] = parseInt(json[field]);
        }
    });

    return json;
}