let books = ["Book1", "Book2", "Book3", "Book4", "Book5"];
let currentBook;

for (let i = 0; i < books.length; i++) {
	let li = document.createElement("li");
	li.innerText = books[i];
	li.addEventListener("click", click);
	List.append(li);
}

function click(e) {
	if (currentBook != undefined) {
		currentBook.style.backgroundColor = "transparent";
	}

	currentBook = e.target;
	e.target.style.backgroundColor = "#ffa984";
}
