document.getElementById("add-program").onclick = function () {
    document.getElementById("addProgramModal").style.display = "flex";
};

document.getElementById("closeModalBtn").onclick = closeModal;

function closeModal() {
    document.getElementById("addProgramModal").style.display = "none";
}

window.onclick = function (event) {
    const modal = document.getElementById("addProgramModal");
    if (event.target === modal) {
        closeModal();
    }
};