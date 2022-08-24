var state = 1;

NextButton.addEventListener("click", next);

function next() {
	let circles = document.getElementsByClassName("circle");

	switch (state) {
		case 1: {
			circles[0].className = "circle";
			circles[1].className = "circle yellowC";
			state++;
			break;
		}
		case 2: {
			circles[1].className = "circle";
			circles[2].className = "circle redC";
			state++;
			break;
		}
		case 3: {
			circles[2].className = "circle";
			circles[0].className = "circle greenC";
			state = 1;
			break;
		}
	}
}
