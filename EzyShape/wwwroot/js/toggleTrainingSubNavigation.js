document.addEventListener("DOMContentLoaded", function () {
    const buttons = document.querySelectorAll(".suv-nav-button");
    const programsDiv = document.querySelector(".programs-div");
    const historyDiv = document.querySelector(".history-div");

    buttons.forEach((button, index) => {
        button.addEventListener("click", function () {
            document.querySelector(".sub-active")?.classList.remove("sub-active");
            this.classList.add("sub-active");

            if (index === 0) {
                programsDiv.classList.add("div-active");
                historyDiv.classList.remove("div-active");
            } else {
                historyDiv.classList.add("div-active");
                programsDiv.classList.remove("div-active");
            }
        });
    });
});
