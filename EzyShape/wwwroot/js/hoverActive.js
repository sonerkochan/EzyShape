document.addEventListener('DOMContentLoaded', function () {
    const menuItems = document.querySelectorAll('a.menu-item > p');
    const pageTitle = document.title;

    menuItems.forEach(item => {
        if (pageTitle.includes(item.textContent)) {
            item.classList.add('active');
        }

        item.addEventListener('click', function () {
            menuItems.forEach(i => i.classList.remove('active'));

            this.classList.add('active');
        });
    });
});