document.getElementById("add-photo-button").addEventListener("click", function () {
    document.getElementById("photo-upload-input").click();
});

document.getElementById("photo-upload-input").addEventListener("change", function () {
    const file = this.files[0];
    if (!file) {
        toastr.warning("No photo selected.");
        return;
    }

    const formData = new FormData();
    formData.append("photo", file);

    fetch("/Client/Gallery/UploadPhoto", {
        method: "POST",
        body: formData,
        credentials: "include"
    })
        .then(res => res.json())
        .then(data => {
            if (data.success) {
                toastr.success("Photo uploaded successfully!");

                const galleryDiv = document.querySelector(".gallery-content-div");

                // Remove "no photo" message if exists
                const noPhotoP = galleryDiv.querySelector(".no-photos-p");
                if (noPhotoP) {
                    noPhotoP.remove();
                }

                // Add new photo to gallery
                const img = document.createElement("img");
                img.src = `/images/${data.fileName}`;
                img.alt = "Uploaded Photo";
                img.classList.add("gallery-photo");
                galleryDiv.appendChild(img);
            } else {
                toastr.error(data.errors?.join(", ") || "Failed to upload photo.");
            }
        })
        .catch(err => {
            console.error("Upload error:", err);
            toastr.error("An error occurred while uploading the photo.");
        });

    this.value = ""; // Reset input
});