document.addEventListener('DOMContentLoaded', function () {
    const hamburger = document.getElementById('hamburger');
    const navbarModal = document.getElementById('navbar-modal');

    // Toggle modal visibility
    function toggleModal() {
        navbarModal.classList.toggle('active');
        // Disable scroll when modal is active, enable when not
        if (navbarModal.classList.contains('active')) {
            document.body.style.overflow = 'hidden';
        } else {
            document.body.style.overflow = 'auto';
        }
    }

    // Close the modal
    function closeModal() {
        if (navbarModal.classList.contains('active')) {
            navbarModal.classList.remove('active');
            document.body.style.overflow = 'auto';
        }
    }

    // Toggle modal on hamburger click
    hamburger.addEventListener('click', function (event) {
        event.stopPropagation(); // Prevent click from propagating to document
        toggleModal();
    });

    // Close the modal when clicking outside of it
    document.addEventListener('click', function (event) {
        // If modal is active and click is outside modal and not on hamburger
        if (navbarModal.classList.contains('active') &&
            !event.target.closest('#navbar-modal') &&
            !event.target.closest('#hamburger')) {
            closeModal();
        }
    });
});
