document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("splitSearchInput");
    const table = document.getElementById("splitTable");
    const rows = table?.getElementsByTagName("tr");

    searchInput.addEventListener("keyup", function () {
        const filter = this.value.toLowerCase();

        for (let i = 1; i < rows.length; i++) { // skip header row (i=0)
            const cells = rows[i].getElementsByTagName("td");
            let match = false;

            for (let j = 0; j < cells.length; j++) {
                const text = cells[j].textContent || cells[j].innerText;
                if (text.toLowerCase().includes(filter)) {
                    match = true;
                    break;
                }
            }

            rows[i].style.display = match ? "" : "none";
        }
    });
});