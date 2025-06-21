document.addEventListener('DOMContentLoaded', () => {
    let currentNoteElement = null;

    document.querySelectorAll('.note-title').forEach(note => {
        note.addEventListener('click', function () {
            currentNoteElement = this;
            document.getElementById('noteModal').style.display = 'flex';
            document.getElementById('modalTitle').innerText = this.dataset.title;
            document.getElementById('modalContent').innerText = this.dataset.content;
            document.getElementById('archiveBtn').setAttribute('data-note-id', this.dataset.id);
        });
    });

    document.querySelector('.close-modal').addEventListener('click', () => {
        document.getElementById('noteModal').style.display = 'none';
        currentNoteElement = null;
    });

    window.addEventListener('click', (event) => {
        const modal = document.getElementById('noteModal');
        if (event.target === modal) {
            modal.style.display = 'none';
            currentNoteElement = null;
        }
    });

    document.getElementById('archiveBtn').addEventListener('click', function () {
        const noteId = this.getAttribute('data-note-id');

        fetch(`/Client/Note/ArchiveNote`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ noteId: parseInt(noteId) })
        })
            .then(response => {
                const contentType = response.headers.get("content-type");
                if (contentType && contentType.includes("application/json")) {
                    return response.json();
                }
                return response.text().then(text => {
                    throw new Error(text);
                });
            })
            .then(data => {
                if (data.success) {
                    // Close modal
                    document.getElementById('noteModal').style.display = 'none';

                    // Remove the note element from the list if it exists
                    if (currentNoteElement) {
                        currentNoteElement.remove();
                        currentNoteElement = null;

                        // Optionally update the note count in the header
                        const notesCountElement = document.querySelector('.notes-header p');
                        if (notesCountElement) {
                            // Extract current count from text like "RecentNotes (X)"
                            const text = notesCountElement.textContent;
                            const match = text.match(/\((\d+)\)/);
                            if (match) {
                                let count = parseInt(match[1]);
                                count = Math.max(0, count - 1);
                                notesCountElement.textContent = text.replace(/\(\d+\)/, `(${count})`);
                            }
                        }
                    }

                    // Optionally, show a success toast/message here
                } else {
                    // Show errors from server
                }
            })
            .catch(error => {
                console.error('Error:', error);
                toastr.error('Error: ' + error.message);
            });
    });
});
