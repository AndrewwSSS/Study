let questions = [
	{
		question: 'How many letters art there in word "Hello"',
		variants: ["5", "2"],
		right: "5",
	},
	{
		question: 'How many letters art there in word "World"',
		variants: ["4", "5"],
		right: "5",
	},
];
let currentQuestion = 1;
let countRightQuestions = 0;

questionText.append(
	`${currentQuestion}) ${questions[currentQuestion - 1].question}`
);

for (let i = 0; i < questions[0].variants.length; i++) {
	let inpContainer = document.createElement("div");
	inpContainer.className = "inputContainer";

	let variantInput = document.createElement("input");
	variantInput.type = "radio";
	variantInput.value = questions[0].variants[i];
	variantInput.name = "variant";

	inpContainer.append(variantInput);

	inpContainer.append(`${questions[0].variants[i]}`);
	variantsContainer.append(inpContainer);
}

nextButton.addEventListener("click", onSubmit);

function onSubmit() {
	let radios = document.getElementsByName("variant");

	let checkedExist = false;
	for (var i = 0; i < radios.length; i++) {
		if (radios[i].checked) {
			checkedExist = true;

			if (radios[i].value == questions[currentQuestion - 1].right) {
				countRightQuestions++;
			}
		}
	}

	if (!checkedExist) {
		alert("Ответ не выбран");
		return;
	} else {
		currentQuestion++;
	}

	if (currentQuestion <= questions.length) {
		questionText.innerText = "";
		questionText.append(
			`${currentQuestion}) ${questions[currentQuestion - 1].question}`
		);

		variantsContainer.innerText = "";

		let variants = questions[currentQuestion - 1].variants;
		for (let i = 0; i < variants.length; i++) {
			let inpContainer = document.createElement("div");
			let variantInput = document.createElement("input");
			variantInput.type = "radio";
			variantInput.value = variants[i];
			variantInput.name = "variant";

			inpContainer.append(variantInput);
			inpContainer.append(`${variants[i]}`);

			variantsContainer.append(inpContainer);
		}
	} else {
		mainForm.style.display = "none";

		resultContainer.innerHTML = `Result: <b>${countRightQuestions}</b> correct answers to ${questions.length} questions`;
	}
	return false;
}
