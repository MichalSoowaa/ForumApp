import { validation } from "../shared/formValidations.js";

document.addEventListener("DOMContentLoaded", function () {
    validation.validateForm("registerForm");
    validation.validateForm("loginForm");
});
