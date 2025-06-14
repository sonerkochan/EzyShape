document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("clientSearchInput");
    const table = document.getElementById("clientTable");
    const rows = table?.getElementsByTagName("tr");

    searchInput.addEventListener("keyup", function () {
        const filter = this.value.toLowerCase();

        for (let i = 1; i < rows.length; i++) { // skip header
            const nameCell = rows[i].querySelector(".client-name-p");
            if (nameCell) {
                const text = nameCell.textContent || nameCell.innerText;
                rows[i].style.display = text.toLowerCase().includes(filter) ? "" : "none";
            }
        }
    });
});