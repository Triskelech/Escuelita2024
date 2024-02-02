const button = document.getElementById("action-button");
var id = 0;
var entityName = $("#elementType").val();

if (!button.classList.contains("add")) {
    id = parseInt($("#" + entityName + "Id").val(), 10);
}

function saveUser() {
    entitySave(entityName, id, entityMapping, "/Save");
}
