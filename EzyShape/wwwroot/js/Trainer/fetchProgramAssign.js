(() => {
    const addWorkoutBtn = document.getElementById("add-workout-btn");
    const modal = document.getElementById("addWorkoutModal");
    const closeModalBtn = document.getElementById("closeModalBtn");
    const assignForm = document.getElementById("assignWorkoutsForm");

    addWorkoutBtn.addEventListener("click", () => {
        modal.style.display = "flex";
        modal.setAttribute('aria-hidden', 'false');
        const firstCheckbox = modal.querySelector('.workout-checkbox');
        (firstCheckbox || closeModalBtn).focus();
    });

    function closeModal() {
        modal.style.display = "none";
        modal.setAttribute('aria-hidden', 'true');
        addWorkoutBtn.focus();
    }

    closeModalBtn.addEventListener("click", closeModal);
    window.addEventListener("click", (e) => {
        if (e.target === modal) closeModal();
    });

    // Submit form
    assignForm.addEventListener("submit", e => {
        e.preventDefault();
        const splitId = document.getElementById("splitId").value;
        const selectedWorkoutIds = Array.from(assignForm.querySelectorAll('input[name="workoutIds"]:checked'))
            .map(cb => parseInt(cb.value));

        if (selectedWorkoutIds.length === 0) {
            toastr.warning("Please select at least one workout.");
            return;
        }

        fetch('/Trainer/Split/AssignWorkouts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ splitId, workoutIds: selectedWorkoutIds }),
            credentials: 'include'
        })
            .then(res => res.json())
            .then(result => {
                if (result.success) {
                    toastr.success("Workouts assigned successfully.");
                    closeModal();
                    setTimeout(() => location.reload(), 1000);
                } else {
                    const errorMsg = result.errors?.join(", ") || "Unknown error";
                    toastr.error(`Error: ${errorMsg}`);
                }
            })
            .catch(err => {
                console.error(err);
                toastr.error("An error occurred while assigning workouts.");
            });
    });
})();
