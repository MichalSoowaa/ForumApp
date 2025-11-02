import { errors } from "../shared/errors.js";

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

            if (!response.ok)
                throw new Error(`HTTP Error ${response.status}`);

            const result = await response.json();

            if (result.success) {
                location.reload();
            }
            else {
                errors.showErrors(formSelector, result.errors);
            }
        }
        catch (err) {
            console.error(err.messages);
            errors.showGlobalError(`Nie udało połączyć się z serwerem. ${err.messages}`);
        }
    });
}