
function sendRequest() {
    $.ajax({
        type: "POST",
        url: "/" + target + urlEnd,
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.status === 200) {
                alert("Acci�n realizada con �xito");
            } else {
                alert("No se pudo realizar la acci�n");
            }
            window.location.href = "/" + target + "/ListAndShow";
        },
        error: function (response) {
            console.log("Error:", "error gen�rico", response);
        }
    });
}