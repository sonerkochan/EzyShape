document.addEventListener("DOMContentLoaded", function () {
    const nameInput = document.querySelector(".name-input");
    const saveNameBtn = document.querySelector(".save-name-button");
    const originalName = nameInput.value.trim();

    const langSelect = document.getElementById("languageSelect");
    const changeLangBtn = document.getElementById("changeLanguageBtn");
    const currentLang = langSelect.value;

    // Disable save buttons initially
    saveNameBtn.disabled = true;
    changeLangBtn.disabled = true;

    // Enable "Save Name" button only if input changes
    nameInput.addEventListener("input", function () {
        const changed = nameInput.value.trim() !== originalName;
        saveNameBtn.disabled = !changed;
    });

    // Enable "Change Language" button only if a different language is selected
    langSelect.addEventListener("change", function () {
        const newLang = langSelect.value;
        const isDifferent = newLang !== currentLang;
        changeLangBtn.disabled = !isDifferent;
    });
});