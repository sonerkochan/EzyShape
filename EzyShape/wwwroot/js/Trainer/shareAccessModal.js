document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById("accessModal");
    const button = document.querySelector(".button-access");
    const closeBtn = document.querySelector(".close-button");

    button.addEventListener("click", function () {
        modal.style.display = "flex";
    });

    closeBtn.addEventListener("click", function () {
        modal.style.display = "none";
    });

    window.addEventListener("click", function (e) {
        if (e.target === modal) {
            modal.style.display = "none";
        }
    });
});
