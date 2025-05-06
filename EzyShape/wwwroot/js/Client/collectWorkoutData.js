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

    const duration = `${hours}:${minutes}:${seconds}`;

    const data = {
        duration: duration,
    exercises: exercises
    };
    console.log("Workout data:", data);
    console.log("Sending to server:", JSON.stringify(data));

    await fetch('/Client/Workout/LogWorkout', {
        method: 'POST',
    headers: {
        'Content-Type': 'application/json',
        },
    body: JSON.stringify(data)
    });

    alert("Workout logged!");
});
