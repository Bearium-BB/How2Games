// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const signup = document.getElementById('signUp');
const signup_overlay = document.getElementById('overlay');

const login = document.getElementById('logIn');
const login_overlay = document.getElementById('overlay1');

function validatePassword() {

    var password = document.getElementById("password").value;

    var pattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$/;

    if (!pattern.test(password)) {
        alert("Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be between 8 and 20 characters long.");

        return false;
    }

    return true;
}

function darkMode() {
    var element = document.body;
    element.classList.toggle("darkmode-toggle");
}

signup.onclick = function () {
    if (login_overlay.style.display == 'flex') {
        login_overlay.style.display = 'none'
        document.body.style.backgroundColor = "rgba(220,220,220,0.3)";
        signup_overlay.style.display = 'flex';
    }
    else {
        signup_overlay.style.display = 'flex';
    }

}
login.onclick = function () {
    if (signup_overlay.style.display == 'flex') {
        login_overlay.style.display = 'flex';
        signup_overlay.style.display = 'none';
    }
    else {
        login_overlay.style.display = 'flex';
    }

}
document.addEventListener('keydown', function (event) {
    if (event.keyCode == 27) {
        login_overlay.style.display = 'none';
        signup_overlay.style.display = 'none';
    }
});
