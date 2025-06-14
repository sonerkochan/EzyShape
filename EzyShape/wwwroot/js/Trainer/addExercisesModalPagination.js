document.addEventListener('DOMContentLoaded', () => {
            const itemsPerPage = 8;
            const list = document.getElementById('exerciseList');
            const items = Array.from(list.children);
            const prevBtn = document.getElementById('prevPageBtn');
            const nextBtn = document.getElementById('nextPageBtn');
            const pageInfo = document.getElementById('pageInfo');

            let currentPage = 1;
            const totalPages = Math.ceil(items.length / itemsPerPage);

            function showPage(page) {
                currentPage = page;
                const start = (page - 1) * itemsPerPage;
                const end = start + itemsPerPage;

                items.forEach((item, index) => {
                    item.style.display = (index >= start && index < end) ? 'block' : 'none';
                });

                prevBtn.disabled = (currentPage === 1);
                nextBtn.disabled = (currentPage === totalPages);
                pageInfo.textContent = `Page ${currentPage} of ${totalPages}`;
            }

            prevBtn.addEventListener('click', () => {
                if (currentPage > 1) showPage(currentPage - 1);
            });

            nextBtn.addEventListener('click', () => {
                if (currentPage < totalPages) showPage(currentPage + 1);
            });

            showPage(1);
        });
