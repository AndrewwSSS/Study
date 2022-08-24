InputText.addEventListener("input", onChange);

function onChange(e) {
	let input = e.target;
	console.log(input.value);
	let res = input.value.replace(/[0-9]/, "");

	input.value = res;
}
