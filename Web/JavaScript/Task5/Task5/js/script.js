let peoples = [
	{
		FirstName: "Aboba",
		LastName: "1",
		Age: 34,
		Company: "Facebook1",
	},
	{
		FirstName: "Boba",
		LastName: "2",
		Age: 55,
		Company: "Facebook2",
	},
	{
		FirstName: "Cobra",
		LastName: "3",
		Age: 22,
		Company: "Facebook3",
	},
	{
		FirstName: "Derby",
		LastName: "4",
		Age: 44,
		Company: "Facebook4",
	},
	{
		FirstName: "Elephant",
		LastName: "5",
		Age: 23,
		Company: "Facebook77",
	},
];

let lastElem;
let lastColumnName;
let currDir = -1;

$("thead > tr > td").click(function (e) {
	let columnName = $(this).attr("name");

	if (columnName == "Age") {
		if (columnName == lastColumnName && (currDir == -1 || currDir == 2)) {
			updateTable(
				peoples.sort((a, b) => {
					return a.Age === b.Age ? 0 : a.Age < b.Age ? 1 : -1;
				})
			);
			currDir = 1;
		} else {
			updateTable(
				peoples.sort((a, b) => {
					return a.Age === b.Age ? 0 : a.Age < b.Age ? -1 : 1;
				})
			);
			currDir = 2;
		}
	} else {
		if (lastColumnName == columnName && (currDir == -1 || currDir == 2)) {
			updateTable(
				peoples.sort((a, b) => {
					return a[columnName] === b[columnName]
						? 0
						: a[columnName] < b[columnName]
						? 1
						: -1;
				})
			);
			currDir = 1;
		} else {
			updateTable(
				peoples.sort((a, b) => {
					return a[columnName] === b[columnName]
						? 0
						: a[columnName] < b[columnName]
						? -1
						: 1;
				})
			);
			currDir = 2;
		}
	}

	if (lastElem != undefined) {
		$(lastElem).css("background-color", "transparent");
	}

	$(this).css("background-color", currDir == 1 ? "red" : "green");

	lastElem = $(this);
	lastColumnName = columnName;
});

function updateTable(peoples) {
	$("#tbody").html("");
	for (let i = 0; i < peoples.length; i++) {
		let tr = document.createElement("tr");

		let td1 = document.createElement("td");
		let td2 = document.createElement("td");
		let td3 = document.createElement("td");
		let td4 = document.createElement("td");

		td1.innerText = peoples[i].FirstName;
		td2.innerText = peoples[i].LastName;
		td3.innerText = peoples[i].Age;
		td4.innerText = peoples[i].Company;

		tr.append(td1);
		tr.append(td2);
		tr.append(td3);
		tr.append(td4);

		$("#tbody").append(tr);
	}
}

updateTable(peoples);
