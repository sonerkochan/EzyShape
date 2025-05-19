document.getElementById('btn-finish').addEventListener('click', async () => {
    const exerciseContainers = document.querySelectorAll('.concrete-exercise-container');
    const exercises = [];

    exerciseContainers.forEach((container) => {
        const exerciseId = container.dataset.workoutid;
        const setsDivs = container.querySelectorAll('.concrete-set-div');

        const sets = Array.from(setsDivs).map((setDiv, i) => {
            const reps = setDiv.querySelector('.row-reps-input').value;
            const weight = setDiv.querySelector('.row-weigth-input').value;

            return {
                setNumber: i + 1,
                reps: reps ? parseInt(reps) : null,
                weight: weight ? parseFloat(weight) : null
            };
        });

        exercises.push({
            exerciseId: parseInt(exerciseId),
            sets: sets
        });
    });

    const workoutName = document.getElementById('workout-name-text').textContent.trim();
    const duration = `${hours}:${minutes}:${seconds}`;

    const data = {
        name: workoutName,
        duration: duration,
        exercises: exercises
    };

    console.log("Workout data:", data);
    console.log("Sending to server:", JSON.stringify(data));

    try {
        const response = await fetch('/Client/Workout/LogWorkout', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        });

        const result = await response.json();

        if (result.redirectUrl) {
            window.location.href = result.redirectUrl;
        } else {
            alert("Workout logged, but no redirect provided.");
        }
    } catch (error) {
        console.error("Error logging workout:", error);
        alert("There was an error logging the workout.");
    }
});
