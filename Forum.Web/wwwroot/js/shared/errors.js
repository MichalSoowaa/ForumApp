export function showErrors(formId, errors) {
    document.querySelectorAll("error").forEach(e => e.remove());

    console.log(errors);

    for (const key in errors) {
        const messages = errors[key];
        const input = document.querySelector(`${formId} [name="${key}"]`);

        if (input) {
            const span = document.createElement("span");
            span.classList.add("text-danger", "error");
            span.textContent = messages.join(", ");
            input.parentNode.appendChild(span);
        }
    }
}

export function showGlobalError(message) {
    let box = document.getElementById("globalErrorBox");
    if (!box) {
        box = document.createElement("div");
        box.id = "globalErrorBox";
        box.style.position = "fixed";
        box.style.bottom = "20px";
        box.style.right = "20px";
        box.style.background = "#dc3545";
        box.style.color = "#fff";
        box.style.padding = "10px 15px";
        box.style.borderRadius = "8px";
        box.style.zIndex = "9999";
        document.body.appendChild(box);
    }

    box.textContent = message;
    box.style.display = "block";

    setTimeout(() => {
        box.style.display = "none";
    }, 4000);
}