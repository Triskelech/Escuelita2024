const button = document.getElementById("action-button");

var urlEnd;
var id = 0;
var target = "User";

if (button.classList.contains("update")) {
    urlEnd = "/Update";
    id = parseInt($("#userId").val(), 10);
} else if (button.classList.contains("delete")) {
    urlEnd = "/Delete";
    id = parseInt($("#userId").val(), 10);
} else {
    urlEnd = "/Insert";
}

var json = {
    "Id": id,
    "FirstName": $("#userFirstName").val(),
    "LastName": $("#userLastName").val(),
    "UserName": $("#userUserName").val(),
    "Password": $("#userPassword").val(),
    "AccountId": parseInt($("#userAccountId").val(), 10)
};