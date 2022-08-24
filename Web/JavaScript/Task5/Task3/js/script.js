let BooksArray = [
	"Book1",
	"Book2",
	"Book3",
	"Book4",
	"Book5",
	"Book6",
	"Book7",
];

let currIndex = -1;
let liBooks;

for (let i = 0; i < BooksArray.length; i++) {
	let li = document.createElement("li");
	li.innerText = BooksArray[i];
	Books.append(li);
}

liBooks = $("#Books > li").toArray();

$("#Books > li").click(function (e) {
	if (e.ctrlKey) {
		$(this).toggleClass("checked");

		currIndex = liBooks.indexOf($(this)[0]);
	}

	if (e.shiftKey) {
		let index = liBooks.indexOf($(this)[0]);

		let left = currIndex < index ? currIndex : index;
		let right = currIndex > index ? currIndex : index;

		for (let i = left; i <= right; i++) {
			$(liBooks[i]).addClass("checked");
		}
	}
});
