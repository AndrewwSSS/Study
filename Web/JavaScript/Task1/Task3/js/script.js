ButtonShowText.addEventListener("click", onClick);

function onClick() {
	if (inputText.value != "") {
		res = document.getElementById("resultContainer");

		resultContainer.style.display = "block";
		resultHeader.style.display = "block";

		resultContainer.innerText = inputText.value;

		if (CheckBox_Bold.checked) res.style.fontWeight = "bold";
		else res.style.fontWeight = "normal";

		console.log(res.style.fontStyle);
		if (CheckBox_Italics.checked) res.style.fontStyle = "italic";
		else res.style.fontStyle = "normal";

		if (CheckBox_Underline.checked) res.style.textDecoration = "underline";
		else res.style.textDecoration = "none";

		if (Radio_Left.checked) res.style.textAlign = "left";

		if (Radio_Right.checked) res.style.textAlign = "right";

		if (Radio_Justify.checked) res.style.textAlign = "justify";
	}
}
