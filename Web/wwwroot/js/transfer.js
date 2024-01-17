const button = document.getElementById("action-button");

var urlEnd;
var id = 0;
var target = "Transfer";

if (button.classList.contains("update")) {
    urlEnd = "/Update";
    id = parseInt($("#transferId").val(), 10);
} else if (button.classList.contains("delete")) {
    urlEnd = "/Delete";
    id = parseInt($("#transferId").val(), 10);
} else {
    urlEnd = "/Insert";
}

var json = {
    "Id": id,
    "Code": $("transferCode").val(),
    "DateTime": $("#transferDateTime").val(),
    "Amount": parseInt($("#transferAmount").val(), 10),
    "OriginAccountId": parseInt($("#transferOriginAccountId").val(), 10)
};