let errorExists = false;

$("#submit").click(function () {
	try {
		let obj = JSON.parse(inputJson.value);
		outputJson.value = JSON.stringify(obj, undefined, 4);

		if (errorExists) {
			$(".errorMessage").html("");
			errorExists = false;
		}
	} catch {
		errorExists = true;
		outputJson.value = "";

		$(".errorMessage").html("[Format error]");
	}
});
