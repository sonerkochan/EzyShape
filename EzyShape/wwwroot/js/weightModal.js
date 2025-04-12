// Open Weight Modal
document.getElementById("add-weight-button").onclick = function () {
    document.getElementById("addWeightLogModal").style.display = "flex";
};

// Close Modal on 'X' click
document.getElementById("closeWeightModalBtn").onclick = closeWeightModal;

function closeWeightModal() {
    document.getElementById("addWeightLogModal").style.display = "none";
}

// Close when clicking outside the modal content
window.onclick = function (event) {
    const modal = document.getElementById("addWeightLogModal");
    if (event.target === modal) {
        closeWeightModal();
    }
};