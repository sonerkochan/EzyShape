document.addEventListener("DOMContentLoaded", function () {
    const taskNameInput = document.getElementById('taskName');
    const taskDescriptionInput = document.getElementById('taskDescription');
    const dueDateInput = document.getElementById('dueDate');
    const submitButton = document.getElementById('submitButton');

    function updateButtonColor() {
        if (taskNameInput.value.trim() !== "" ||
            taskDescriptionInput.value.trim() !== "" ||
            dueDateInput.value.trim() !== "") {
            submitButton.style.backgroundColor = "#2051f1"; // Change to your desired color
        } else {
            submitButton.style.backgroundColor = "#9fb3f5"; // Default color
        }
    }

    // Add event listeners to inputs
    taskNameInput.addEventListener('input', updateButtonColor);
    taskDescriptionInput.addEventListener('input', updateButtonColor);
    dueDateInput.addEventListener('input', updateButtonColor);
});