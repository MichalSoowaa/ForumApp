// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addConnectionBetweenLoginAndRegisterModals() {
    const registerLink = document.getElementById("showRegisterLink");

    if (registerLink) {
        registerLink.addEventListener("click", function (e) {
            e.preventDefault();

            const loginModal = bootstrap.Modal.getInstance(document.getElementById("loginModal"));
            loginModal.hide();

            const registerModal = new bootstrap.Modal(document.getElementById("registerModal"));
            registerModal.show();
        })
    }
}

function addDropdownLogic() {
    const dropdown = document.getElementById("user-dropdown");
    const icon = document.querySelector(".user-icon");

    if (!dropdown || !icon) return;

    // Toggle dropdown on icon click
    icon.addEventListener("click", function (e) {
        e.stopPropagation();  // Prevent event bubbling to document
        dropdown.classList.toggle("hidden");
    });

    // Hide dropdown when clicking outside
    document.addEventListener("click", function (e) {
        if (!icon.contains(e.target) && !dropdown.contains(e.target)) {
            dropdown.classList.add("hidden");
        }
    });
}
function toggleAnswerForm() {
    const container = document.getElementById("answerContainer");

    if (!container) {
        return;
    }

    container.style.display = container.style.display === "none" ? "block" : "none";
}

document.addEventListener('DOMContentLoaded', function () {
    //validateLogin();
    addConnectionBetweenLoginAndRegisterModals();
    //validateRegistration();
    addDropdownLogic();
    //validateNewPost();
    //toggleAnswerForm();
    //validateNewAnswer();
});