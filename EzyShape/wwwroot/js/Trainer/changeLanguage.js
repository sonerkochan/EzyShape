function updateButtonState() {
    const selectedLang = document.getElementById("languageSelect").value;
    const currentLang = document.getElementById("languageSelect").options[0].value;

    const button = document.getElementById("changeLanguageBtn");

    if (selectedLang === currentLang) {
        button.disabled = true;
        button.classList.add("disabled");
    } else {
        button.disabled = false;
        button.classList.remove("disabled");
    }
}

updateButtonState();

document.getElementById("languageSelect").addEventListener("change", updateButtonState);

document.getElementById("changeLanguageBtn").onclick = function () {
    const selectedLang = document.getElementById("languageSelect").value;

    fetch('/Trainer/Trainer/ChangeLanguage', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ languageCode: selectedLang }),
        credentials: 'include'
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                toastr.success("Language changed successfully.");
                window.location.href = window.location.href; // This reloads the page
            } else {
                toastr.error("Failed to change language.");
            }
        })
        .catch(error => {
            console.error('Error:', error);
            toastr.error("An error occurred while changing the language.");
        });
};
