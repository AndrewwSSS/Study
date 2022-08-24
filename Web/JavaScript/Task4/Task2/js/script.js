showModalWindow.addEventListener("click", showModal);
closeModalWindow.addEventListener("click", closeModal);

function showModal() {
	modal.style.opacity = 1;
	modal.style.pointerEvents = "all";
}

function closeModal() {
	modal.style.opacity = 0;
	modal.style.pointerEvents = "none";
}
