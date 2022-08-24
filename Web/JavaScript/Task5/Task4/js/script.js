var currState = 1;

$("body").keydown(function (e) {
	//E
	if (e.ctrlKey && e.keyCode == 69) {
		if (currState == 1) {
			let text = $(".textField")[0].innerText;
			$(".textField").remove();

			let textArea = document.createElement("textarea");
			textArea.value = text;
			$(textArea).addClass("textField");
			$(textArea).attr("rows", "15");
			$(".separator").after(textArea);

			currState = 2;
		}
		return false;
	}

	//S
	if (e.ctrlKey && e.keyCode == 83) {
		if (currState == 2) {
			let text = $(".textField")[0].value;
			$(".textField").remove();

			let div = document.createElement("div");
			div.innerText = text;
			$(div).addClass("textField");
			$(".separator").after(div);
			currState = 1;
		}
		return false;
	}
});
