let currentDeleteBtn = null;

document.querySelectorAll('.button-remove-program').forEach(button => {
    button.addEventListener('click', function () {
        currentDeleteBtn = this;
        document.getElementById('deleteSplitModal').classList.remove('hidden');
    });
});

document.getElementById('cancelDeleteSplitBtn').addEventListener('click', function () {
    document.getElementById('deleteSplitModal').classList.add('hidden');
    currentDeleteBtn = null;
});

document.getElementById('confirmDeleteSplitBtn').addEventListener('click', async function () {
    const splitId = currentDeleteBtn?.getAttribute('data-split-id');
    const clientId = document.getElementById('clientId')?.value;

    // Debugging: Log the values
    console.log('splitId:', splitId);
    console.log('clientId:', clientId);

    if (!splitId || !clientId) {
        alert("Missing splitId or clientId!");
        return;
    }

    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    const formData = new URLSearchParams();
    formData.append("splitId", splitId);
    formData.append("clientId", clientId);
    formData.append("__RequestVerificationToken", token);

    const response = await fetch('/Trainer/Client/DeleteClientSplit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: formData
    });

    const result = await response.json();
    console.log('Delete response:', result); // Log the response for debugging

    if (result.success) {
        currentDeleteBtn.closest('.program-div').remove();
    } else {
        alert(result.message || "An error occurred.");
    }

    document.getElementById('deleteSplitModal').classList.add('hidden');
    currentDeleteBtn = null;
});
