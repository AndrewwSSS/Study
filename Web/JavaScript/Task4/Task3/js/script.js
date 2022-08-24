document.body.addEventListener("click", onClick, true);
document.body.style.width = `${window.outerWidth}px`;
document.body.style.height = `${window.outerHeight}px`;

// console.log(`${window.outerWidth}px`);
// console.log(`${window.outerHeight}px`);

function onClick(e) {
	console.log(`${e.clientX} ${e.clientY}`);

	if (window.outerWidth - e.clientX - 50 < 50 || e.clientX - 50 < 50) {
		return;
	}

	if (window.outerHeight - e.clientY - 50 < 50 || e.clientY - 50 < 50) {
		return;
	}

	ball.style.left = `${e.clientX - 50}px`;
	ball.style.top = `${e.clientY - 50}px`;
}
