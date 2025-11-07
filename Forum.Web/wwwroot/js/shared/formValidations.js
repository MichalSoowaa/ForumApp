import { showErrors } from "./errors.js";
import { showGlobalError } from "./errors.js";

export function validateForm(formSelector) {
    const form = document.getElementById(formSelector);

    if (!form) {
        console.warn(`Form not found: ${formSelector}`);
        return;
    }

    //const errorBox = document.getElementById("newAnswerValidationSummary");

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

            if (!response.ok) {
                console.error("Server error:", response.status);
                window.location.href = "/Home/Error";
                return;
            }

            const result = await response.json();

            if (result.success) {
                window.location.href = result.redirectUrl;
            }
            else {
                showErrors(formSelector, result.errors);
            }
        }
        catch (err) {
            console.error(err.message);
            showGlobalError(`Nie udało połączyć się z serwerem. ${err.message}`);
        }
    });
}