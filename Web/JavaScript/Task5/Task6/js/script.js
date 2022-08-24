let resizingStatus = 1;
let currElem;

$(".triangle-bottom-right").mousedown(function (e) {
	currElem = $(this).closest(".container");
	console.log(currElem);
	resizingStatus = 2;
});

$(".triangle-bottom-right").mouseup(function (e) {
	resizingStatus = 1;
});

$("body").mousemove(function (e) {
	if (resizingStatus == 2) {
		let newWidth = e.clientX - currElem.offset().left;
		let newHeight = e.clientY - currElem.offset().top;

		currElem.width(`${newWidth}px`);
		currElem.height(`${newHeight}px`);
	}
});
