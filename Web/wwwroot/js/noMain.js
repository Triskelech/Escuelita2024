
function sendRequest() {
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
            window.location.href = "/" + target + "/ListAndShow";
        },
        error: function (response) {
            console.log("Error:", "error genérico", response);
        }
    });
}