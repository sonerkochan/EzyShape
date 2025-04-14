document.getElementById("add-program").onclick = function () {
    document.getElementById("addProgramModal").style.display = "flex";
};

document.getElementById("closeModalBtn").onclick = closeAddProgramModal;

function closeAddProgramModal() {
    document.getElementById("addProgramModal").style.display = "none";
}

window.onclick = function (event) {
    const modal = document.getElementById("addProgramModal");
    if (event.target === modal) {
        closeAddProgramModal();
    }
};

document.getElementById("submitButton").onclick = function () {
    const clientId = document.getElementById('clientId').value;
    const selectedSplits = [];

    // Collect selected splits
    document.querySelectorAll('.program-checkbox:checked').forEach(function (checkbox) {
        selectedSplits.push(parseInt(checkbox.getAttribute('data-split-id')));
    });

    if (selectedSplits.length === 0) {
        toastr.error("Please select at least one program.");
        return;
    }

    // Prepare data to send
    const requestData = {
        clientId: clientId,
        splitIds: selectedSplits
    };

    // Send AJAX request
    fetch('/Trainer/Client/AssignSplit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json' // Ensure the request is sent as JSON
        },
        body: JSON.stringify(requestData),
        credentials: 'include' // Include cookies in the request if needed
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                closeAddProgramModal(); // Close the modal after success
                toastr.success("Programs assigned successfully");
            } else {
                toastr.error(data.errors ? data.errors.join(' ') : "An error occurred while assigning the programs.");
            }
        })
        .catch(error => {
            console.error('Error:', error);
            toastr.error("An error occurred while assigning the programs.");
        });
}
