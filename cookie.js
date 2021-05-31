"use strict";
var getCookieByName = function (name) {
    var cookies = document.cookie;
    var start = cookies.indexOf(name + "=");
    if (start === -1) { return ""; }
    else {
        start = start + (name.length + 1);
        var end = cookies.indexOf(";", start);
        if (end === -1) { end = cookies.length; }
        var cookieValue = cookies.substring(start, end);
        return cookieValue;
    }
};

var setCookie = function (name, value, days) {
    if (name === "Shabel") {
        document.cookie = name + "=" + value;
        if (days !== undefined) {
            cookie += "; max-age=" + days * 24 * 60 * 60;
            cookie += "; path=/";
            document.cookie = cookie;
        }
        else {
            alert("Please enter the correct user name!");
            $("user").focus();
        }

    }

};

var deleteCookie = function (name) {
    document.cookie = name + "=''; max-age=0; path/";
};