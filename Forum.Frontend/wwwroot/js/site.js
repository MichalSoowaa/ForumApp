// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



// trzeba zrefaktoryzować ten JS :(


function validateLogin() {
    const form = document.getElementById("loginForm");

    if (!form) {
        console.warn("loginForm not found");
        return;
    }

    const errorBox = document.getElementById("loginValidationSummary");

    form.addEventListener("submit", async function (e) {
        e.preventDefault();

        const formData = new FormData(form);
        const data = new URLSearchParams(formData);

        try {
            const response = await fetch(form.action, {
                method: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: data
            });

            const result = await response.json();

            if (result.success) {
                location.reload();
            }
            else {
                errorBox.innerHTML = result.message;
            }
        }
        catch (err) {
            console.error("Błąd logowania", err);
            errorBox.innerHTML = "Wystąpił błąd serwera.";
        }
    });
}

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

function validateRegistration() {
    const registerForm = document.getElementById("registerForm");
    const errorBox = document.getElementById("registerValidationSummary");

    if (registerForm) {
        registerForm.addEventListener("submit", async function (e) {
            e.preventDefault();

            const formData = new FormData(registerForm);
            const data = new URLSearchParams(formData);

            try {
                const response = await fetch(registerForm.action, {
                    method: "POST",
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    },
                    body: data
                });

                const result = await response.json();

                if (result.success) {
                    window.location.href = result.redirectUrl;
                }
                else {
                    showRegisterErrors(result.errors);
                }
            }
            catch (err) {
                console.log("Błąd rejestracji", err);
                errorBox.innerHTML = "Wystąpił błąd serwera";
            }
        });
    }

    function showRegisterErrors(errors) {
        document.querySelectorAll(".register-error").forEach(e => e.remove());

        console.log(errors);

        for (const key in errors) {
            const messages = errors[key];
            const input = document.querySelector(`#registerForm [name="${key}"]`);

            if (input) {
                const span = document.createElement("span");
                span.classList.add("text-danger", "register-error");
                span.textContent = messages.join(", ");
                input.parentNode.appendChild(span);
            }
        }
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

function validateNewPost() {
    const form = document.getElementById("newPostForm");

    if (!form) {
        console.warn("newPostForm not found");
        return;
    }

    const errorBox = document.getElementById("newPostValidationSummary");

    form.addEventListener("submit", async function (e) {
        e.preventDefault();

        const formData = new FormData(form);
        const data = new URLSearchParams(formData);

        try {
            const response = await fetch(form.action, {
                method: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: data
            });

            const result = await response.json();

            console.log(result);

            if (result.success) {
                location.reload();
            }
            else {
                showErrors(result.errors);
            }
        }
        catch (err) {
            console.error("Błąd logowania", err);
            errorBox.innerHTML = "Wystąpił błąd serwera.";
        }

        function showErrors(errors) {
            document.querySelectorAll(".register-error").forEach(e => e.remove());

            console.log(errors);

            for (const key in errors) {
                const messages = errors[key];
                const input = document.querySelector(`#newPostForm [name="${key}"]`);

                if (input) {
                    const span = document.createElement("span");
                    span.classList.add("text-danger", "register-error");
                    span.textContent = messages.join(", ");
                    input.parentNode.appendChild(span);
                }
            }
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

function validateNewAnswer() {
    const form = document.getElementById("answerForm");

    if (!form) {
        console.warn("Answer form not found");
        return;
    }

    const errorBox = document.getElementById("newAnswerValidationSummary");

    form.addEventListener("submit", async function (e) {
        e.preventDefault();

        const formData = new FormData(form);
        const data = new URLSearchParams(formData);

        try {
            const response = await fetch(form.action, {
                method: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                body: data
            });

            const result = await response.json();

            console.log(result);

            if (result.success) {
                location.reload();
            }
            else {
                showErrors(result.errors);
            }
        }
        catch (err) {
            console.error("Błąd logowania", err);
            errorBox.innerHTML = "Wystąpił błąd serwera.";
        }

        function showErrors(errors) {
            document.querySelectorAll(".register-error").forEach(e => e.remove());

            console.log(errors);

            for (const key in errors) {
                const messages = errors[key];
                const input = document.querySelector(`#answerForm [name="${key}"]`);

                if (input) {
                    const span = document.createElement("span");
                    span.classList.add("text-danger", "register-error");
                    span.textContent = messages.join(", ");
                    input.parentNode.appendChild(span);
                }
            }
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    validateLogin();
    addConnectionBetweenLoginAndRegisterModals();
    validateRegistration();
    addDropdownLogic();
    validateNewPost();
    //toggleAnswerForm();
    validateNewAnswer();
});