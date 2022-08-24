let books = new Map();
let selectedBook;
const isNumeric = (n) => !!Number(n);
books.set("Computer programming", 16);
books.set("Python programming", 20);
books.set("Codes at work", 21);

let buttons = document.querySelectorAll("input[type=button]");

for (let i = 0; i < buttons.length; i++)
	buttons[i].addEventListener("click", selectBook);

Button_Buy.addEventListener("click", buyBooks);

function selectBook(event) {
	selectedBook = event.target.name;
	bookName.innerText = selectedBook;
	Input_Quantity.value = 1;
}

function buyBooks() {
	if (selectedBook != undefined) {
		if (!isNumeric(Input_Quantity.value)) {
			alert("invalid quantity");
			return;
		}
		if (Input_DeliveryAddress.value == "") {
			alert("invalid delivery address");
			return;
		}

		if (Date.parse(Input_DeliveryDate.value) < new Date()) {
			alert("invalid delivery date");
			return;
		}

		if (Input_Name.value == "") {
			alert("invalid Name");
			return;
		}

		if (Input_DeliveryDate.value > new Date()) {
			alert("invalid delivery date");
			return;
		}

		let sum = books.get(selectedBook) * Number(Input_Quantity.value);

		booksContainer.style.display = "none";

		resultContainer.style.display = "block";
		resultContainer.innerHTML = `<p>${Input_Name.value}, thanks for the order!</p>
        <p>Book "${selectedBook}" will be delivered on ${Input_DeliveryDate.value} to ${Input_DeliveryAddress.value}.</p>`;
	} else {
		alert("firstly, select any book");
	}
}
