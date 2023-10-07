// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleSidebar() {
    const sidebarContainer = document.getElementById('mySidebar');
    sidebarContainer.classList.toggle('open');

    const openButton = document.querySelector('.openbtn');
    openButton.classList.toggle('open');

    if (openButton.classList.contains('open')) {
        openButton.textContent = '✕ Close Sidebar';
    } else {
        openButton.textContent = '☰ Open Sidebar';
    }
}