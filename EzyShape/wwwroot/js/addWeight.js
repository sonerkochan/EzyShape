// Handle submit button click (no form)
document.getElementById("submitWeightButton").onclick = function () {
    const weight = document.getElementById("weightInput").value;
    const date = document.getElementById("weightDate").value;

    if (!weight || !date) {
        toastr.warning("Please enter a weight and date.");
        return;
    }

    const weightData = new URLSearchParams();
    weightData.append("Weight", weight);
    weightData.append("LogDate", date);

    fetch("/Client/Weigth/AddWeight", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        body: weightData.toString(),
        credentials: "include"
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                toastr.success("Weight logged successfully!");
            } else {
                toastr.error(data.errors?.join(", ") || "Failed to add weight.");
            }
        })
        .catch(err => {
            console.error("Error:", err);
            toastr.error("An error occurred while adding the weight.");
        });
    closeWeightModal();

};