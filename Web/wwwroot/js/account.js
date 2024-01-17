const button = document.getElementById("action-button");

var urlEnd;
var id = 0;
var target = "Account";

if (button.classList.contains("update")) {
    urlEnd = "/Update";
    id = parseInt($("#accountId").val(), 10);
} else if (button.classList.contains("delete")) {
    urlEnd = "/Delete";
    id = parseInt($("#accountId").val(), 10);
} else {
    urlEnd = "/Insert";
}

var json = {
    "Id": id,
    "Code": $("#accountCode").val(),
    "MoneyAmount": $("#accountMoneyAmount").val(),
    "UserId": parseInt($("#accountUserId").val(), 10)
};