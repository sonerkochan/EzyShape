document.getElementById("add-task").onclick = function () {
    document.getElementById("addTaskModal").style.display = "flex";
}

function closeModal() {
    document.getElementById("addTaskModal").style.display = "none";
}

window.onclick = function (event) {
    const modal = document.getElementById("addTaskModal");
    if (event.target === modal) {
        modal.style.display = "none";
    }
}

document.getElementById("addTaskForm").onsubmit = function (event) {
    event.preventDefault(); // Prevent the default form submission

    const taskName = document.getElementById("taskName").value;
    const taskDescription = document.getElementById("taskDescription").value;
    const dueDate = document.getElementById("dueDate").value;

    // Prepare data to send
    const taskData = new URLSearchParams();
    taskData.append('Name', taskName);
    taskData.append('Description', taskDescription);
    taskData.append('DueDate', dueDate);

    // Send AJAX request
    fetch('/Trainer/Task/AddTask', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded', // Change content type to match the data format
        },
        body: taskData.toString(), // Send the data as URL-encoded string
        credentials: 'include' // Include cookies in the request
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json(); // Parse the JSON from the response
        })
        .then(data => {
            if (data.success) {
                // Handle success (e.g., show a success message, update UI)
                alert(data.message);
                // Optionally, refresh or update the task list here
            } else {
                // Handle validation errors
                alert("Error: " + data.errors.join(", "));
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("An error occurred while adding the task.");
        });

    closeModal(); // Close the modal after submission
}
