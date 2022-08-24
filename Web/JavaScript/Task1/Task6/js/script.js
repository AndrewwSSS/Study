const placesInTrain = 28;

var directions = ["Odessa - Lviv", "Lviv - Odessa"];
var dates = [
	new Date(2022, 7, 25),
	new Date(2022, 7, 24),
	new Date(2022, 7, 26),
];

var timetable = [
	{
		direction: "Odessa - Lviv",
		date: new Date(2022, 7, 24),
		places: [],
	},
	{
		direction: "Odessa - Lviv",
		date: new Date(2022, 7, 25),
		places: [],
	},
	{
		direction: "Odessa - Lviv",
		date: new Date(2022, 7, 26),
		places: [],
	},
	{
		direction: "Lviv - Odessa",
		date: new Date(2022, 7, 24),
		places: [],
	},
	{
		direction: "Lviv - Odessa",
		date: new Date(2022, 7, 25),
		places: [],
	},
	{
		direction: "Lviv - Odessa",
		date: new Date(2022, 7, 26),
		places: [],
	},
];

var currentTrain = timetable[1];
var purchasedTickets = [];
var ticketsInBascket = [];

for (let i = 0; i < directions.length; i++) {
	let option = document.createElement("option");
	option.innerText = directions[i];
	select_Direction.append(option);
}

for (let i = 0; i < dates.length; i++) {
	let option = document.createElement("option");
	option.innerText = dates[i].toString();
	select_Dates.append(option);
}

updatePlaces();

Button_Search.addEventListener("click", search);
Button_Buy_Tickets.addEventListener("click", buyTickets);

function updatePlaces() {
	places.innerHTML = "";
	ticketsInBascket = [];
	for (let l = 0; l < placesInTrain; l++) {
		let placeContainer = document.createElement("div");
		placeContainer.className = "placeContainer";

		let input = document.createElement("input");
		input.type = "checkBox";
		input.value = l + 1;

		if (currentTrain.places.some((p) => p == l + 1)) {
			input.setAttribute("disabled", "");
			input.checked = true;
		}

		input.addEventListener("change", checkBoxOnChange);

		let span = document.createElement("span");
		span.innerText = l + 1;

		placeContainer.append(input);
		placeContainer.append(span);

		places.append(placeContainer);
	}

	currentPrice.innerHTML = "";
	let b = document.createElement("b");
	b.innerText = "0$";
	currentPrice.append(b);
}

function checkBoxOnChange(e) {
	let checkBox = e.target;
	let selectedPlace = Number(checkBox.value);

	if (checkBox.checked) {
		ticketsInBascket.push(selectedPlace);
	} else {
		ticketsInBascket = ticketsInBascket.filter((t) => t != selectedPlace);
	}

	currentPrice.innerHTML = "";
	let b = document.createElement("b");
	b.innerText = `${ticketsInBascket.length * 62}$`;
	currentPrice.append(b);
}

function search() {
	let dir = select_Direction.options[select_Direction.selectedIndex].text;
	let date = select_Dates.options[select_Dates.selectedIndex].text;

	let train = timetable.filter((t) => t.direction == dir && t.date == date);
	if (train.length != 0) {
		currentTrain = train[0];
		updatePlaces();
	} else {
		alert("train not found");
	}
}

function buyTickets() {
	for (let i = 0; i < ticketsInBascket.length; i++) {
		purchasedTickets.push({
			direction: currentTrain.direction,
			date: currentTrain.date,
			place: ticketsInBascket[i],
		});
		currentTrain.places.push(ticketsInBascket[i]);
	}

	ticketsInBascket = [];

	ticketsContainer.style.display = "block";
	ticketsTable.innerHTML = "";
	for (let i = 0; i < purchasedTickets.length; i++) {
		let tr = document.createElement("tr");
		let th1 = document.createElement("th");
		let th2 = document.createElement("th");
		let th3 = document.createElement("th");

		th1.innerText = purchasedTickets[i].direction;
		th2.innerText = purchasedTickets[i].date
			.toLocaleString("en-us", {
				year: "numeric",
				month: "2-digit",
				day: "2-digit",
			})
			.replace(/(\d+)\/(\d+)\/(\d+)/, "$3-$1-$2");
		th3.innerText = purchasedTickets[i].place;

		tr.append(th1);
		tr.append(th2);
		tr.append(th3);

		ticketsTable.append(tr);
	}

	updatePlaces();
}
