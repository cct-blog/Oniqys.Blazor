function scrollElementById(id) {
    const element = document.getElementById(id);
    if (element instanceof HTMLElement) {
        element.scrollIntoView({
            behavior: "smooth",
            block: "start",
            inline: "nearest"
        });
    }
}

function focusElementById(id) {
    const element = document.getElementById(id);
    element.focus();
}
