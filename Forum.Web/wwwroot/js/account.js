import { validateForm } from "./shared/formValidations.js";

document.addEventListener("DOMContentLoaded", function () {
    const loginModal = document.getElementById("loginModal");

    if (loginModal) {
        loginModal.addEventListener("shown.bs.modal", () => {
            validateForm("loginForm");
        });
    }

    const registerModal = document.getElementById("registerModal");

    if (registerModal) {
        registerModal.addEventListener("shown.bs.modal", () => {
            validateForm("registerForm");
        });
    }
});
