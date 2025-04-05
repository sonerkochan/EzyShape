let currentFinishTaskBtn = null;

document.querySelectorAll('#finishTaskButton').forEach(button => {
    button.addEventListener('click', function () {
        currentFinishTaskBtn = this;
        document.getElementById('finishTaskModal').classList.remove('hidden');
    });
});

document.getElementById('cancelFinishTaskBtn').addEventListener('click', function () {
    document.getElementById('finishTaskModal').classList.add('hidden');
    currentFinishTaskBtn = null;
});

document.getElementById('confirmFinishTaskBtn').addEventListener('click', async function () {
    const taskId = currentFinishTaskBtn?.getAttribute('data-task-id');

    // Debugging: Log the taskId
    console.log('taskId:', taskId);

    if (!taskId) {
        alert("Missing taskId!");
        return;
    }

    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    const formData = new URLSearchParams();
    formData.append("taskId", taskId);
    formData.append("__RequestVerificationToken", token);

    const response = await fetch('/Trainer/Task/FinishTask', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: formData
    });

    const result = await response.json();
    console.log('Finish Task response:', result); // Log the response for debugging

    if (result.success) {
        currentFinishTaskBtn.closest('.task-item').remove();
    } else {
        alert(result.message || "An error occurred.");
    }

    document.getElementById('finishTaskModal').classList.add('hidden');
    currentFinishTaskBtn = null;
});
