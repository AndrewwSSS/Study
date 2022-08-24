//Task1

// let age = parseInt(prompt("Enter your age"));

// if (!isNaN(age) && age >= 0) {
// 	if (age >= 0 && age < 12) {
// 		alert("You are kid");
// 	} else if (age >= 12 && age < 18) {
// 		alert("You are teen");
// 	} else if (age >= 18 && age < 60) {
// 		alert("You are adult");
// 	} else {
// 		alert("You are pensioner");
// 	}
// } else alert("invalid input");

//Task2

// let num = parseInt(prompt("Enter 0-9"));

// if (!isNaN(num) && num >= 0 && num <= 9) {
// 	switch (num) {
// 		case 0: {
// 			alert(")");
// 			break;
// 		}
// 		case 1: {
// 			alert("!");
// 			break;
// 		}
// 		case 2: {
// 			alert("@");
// 			break;
// 		}
// 		case 3: {
// 			alert("#");
// 			break;
// 		}
// 		case 4: {
// 			alert("$");
// 			break;
// 		}
// 		case 5: {
// 			alert("%");
// 			break;
// 		}
// 		case 6: {
// 			alert("^");
// 			break;
// 		}
// 		case 7: {
// 			alert("&");
// 			break;
// 		}
// 		case 8: {
// 			alert("*");
// 			break;
// 		}
// 		case 9: {
// 			alert("(");
// 			break;
// 		}
// 	}
// } else alert("invalid input");

//Task3

// let num = parseInt(prompt("Enter 3-digit number"));

// if (!isNaN(num) && num > 99 && num < 1000) {
// 	let arr = [
// 		num % 10,
// 		parseInt((num /= 10)) % 10,
// 		parseInt((num /= 10)) % 10,
// 	];

// 	var isDuplicate = arr.some(function (a, b) {
// 		return arr1.indexOf(a) != b;
// 	});

// 	alert(isDuplicate);
// } else alert("invalid input");

//Task4

// let year = parseInt(prompt("Enter year", "2022"));

// if (!isNaN(year) && year > 0) {
// 	if (year % 4 != 0) alert("Simple");
// 	else {
// 		if (year % 100 == 0 && year % 400 != 0) alert("Simple");
// 		else alert177("leap year");
// 	}
// }else alert("invalid input");

//Task5

// let numStr = prompt("Enter 5-digit", "12321");
// let num = parseInt(numStr);

// if (!isNaN(num) && num >= 10000 && num < 100000) {
// 	if (numStr == numStr.split("").reverse().join("")) {
// 		alert("palindrome");
// 	} else {
// 		alert("no palindrome");
// 	}
// } else alert("invalid input");

//Task6

// const UsdToEuro = 0.99;
// const UsdToUan = 29.52;
// const UsdToAzn = 1.7;

// let usd = parseFloat(prompt("Usd:", "1"));

// if (!isNaN(usd)) {
// 	let currency = prompt("currency").toLowerCase();
// 	switch (currency) {
// 		case "euro": {
// 			alert(`${UsdToEuro * usd} Euro`);
// 			break;
// 		}
// 		case "uan": {
// 			alert(`${UsdToUan * usd} UAN`);
// 			break;
// 		}
// 		case "azn": {
// 			alert(`${UsdToAzn * usd} Azn`);
// 			break;
// 		}
// 		default: {
// 			alert("Invalid input");
// 			break;
// 		}
// 	}
// }

//Task7

// let sum = parseInt(prompt("Enter sum"));

// if (!isNaN(sum) && sum > 0) {
// 	if (sum >= 200 && sum < 300) {
// 		alert(`to pay: ${sum - (sum / 100) * 3}`);
// 	} else if (sum >= 300 && sum < 500) {
// 		alert(`to pay: ${sum - (sum / 100) * 5}`);
// 	} else if (sum >= 500) {
// 		alert(`to pay: ${sum - (sum / 100) * 7}`);
// 	} else {
// 		alert(`to pay: ${sum}`);
// 	}
// } else alert("invalid input");

// Task8

// let pSquare = parseFloat(prompt("P square:"));

// if (!isNaN(pSquare) && pSquare > 0) {
// 	let a = pSquare / 4;

// 	let circleLength = parseFloat(prompt("circle length:"));

// 	if (!isNaN(circleLength) && circleLength > 0) {
// 		let r = circleLength / (2 * Math.PI);
// 		if (r < a / 2) {
// 			alert("placed");
// 		} else {
// 			alert("no placed");
// 		}
// 	} else alert("invalid input");
// } else alert("invalid input");

//Task9

// let score = 0;

// let answer1 = prompt("9 > 10 ? {yes, no, i dont know}");

// if (answer1 == "no") score += 2;

// let answer2 = prompt("10 = 10 ? {yes, no, i dont know}");

// if (answer2 == "yes") score += 2;

// let answer3 = prompt("5 != 6 ? {yes, no, i dont know}");

// if (answer3 == "yes") score += 2;

// alert(`your scorer ${score}`);

//Task10

let day = parseInt(prompt("day"));

if (!isNaN(day)) {
	let month = parseInt(prompt("month"));
	if (!isNaN(month)) {
		let year = parseInt(prompt("year"));
		if (!isNaN(year)) {
			let date = new Date(year, month - 1, day);
			date.setDate(date.getDate() + 1);
			console.log(date);
		}
	}
}
