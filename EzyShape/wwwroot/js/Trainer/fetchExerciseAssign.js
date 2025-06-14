document.getElementById("openSelectExerciseModal").addEventListener("click", function () {
    document.getElementById("selectExerciseModal").style.display = "block";
});

document.getElementById("closeSelectModal").addEventListener("click", function () {
    document.getElementById("selectExerciseModal").style.display = "none";
});

document.querySelectorAll(".selectExerciseBtn").forEach(btn => {
    btn.addEventListener("click", function () {
        const exerciseId = this.getAttribute("data-id");
        document.getElementById("exerciseId").value = exerciseId;
        document.getElementById("selectExerciseModal").style.display = "none";
        document.getElementById("exerciseDetailsModal").style.display = "block";
    });
});

document.getElementById("closeDetailsModal").addEventListener("click", function () {
    document.getElementById("exerciseDetailsModal").style.display = "none";
});

document.getElementById("addExerciseForm").addEventListener("submit", function (e) {
    e.preventDefault();
    const formData = new FormData(this);

    fetch('/Trainer/Workout/AssignExercise?id=' + formData.get('WorkoutId'), {
        method: 'POST',
        body: formData
    })
        .then(res => {
            if (res.ok) {
                location.reload();
            }
        });
});