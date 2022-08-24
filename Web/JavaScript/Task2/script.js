//Task1

// let userName = prompt("Enter your name");

// if (userName == null) {
// 	alert("Invalid");
// } else {
// 	alert(`Hello, ${userName}`);
// }

//Task2

// const currYear = parseInt(new Date().getFullYear());

// let birthYear = parseInt(prompt("Enter your birth year", "2022"));

// if (!isNaN(birthYear)) {
// 	let age = currYear - birthYear;
// 	alert(`You are ${age} or ${age - 1} years old`);
// } else {
// 	alert("invalid input");
// }

//Task3

// let length = parseFloat(prompt("Enter length side of square", "4"));

// if (!isNaN(length)) {
// 	alert(`perimeter of the square: ${length * length}`);
// } else {
// 	alert("invalid input");
// }

//Task4

// let r = parseFloat(prompt("Enter radius of circle", "4"));

// if (!isNaN(r)) {
// 	alert(`perimeter of the square: ${Math.PI * Math.pow(r, 2)}`);
// } else {
// 	alert("invalid input");
// }

//Task5

// let distance = parseFloat(prompt("Enter distance(km)"));

// console.log(distance);

// if (!isNaN(distance)) {
// 	let time = parseFloat(prompt("Enter time(h)"));
// 	if (!isNaN(time)) {
// 		alert(`necessary speed: ${distance / time} km/h`);
// 	} else {
// 		alert("invalid input");
// 	}
// } else {
// 	alert("invalid input");
// }

// Task6

// const rateDollarToEuro = 0.984768;

// let dollars = parseFloat(prompt("Enter sum in dollars", "100"));

// console.log(rateDollarToEuro);
// console.log(dollars);

// if (!isNaN(dollars)) {
// 	let res = parseFloat(rateDollarToEuro * dollars).toFixed(3);
// 	alert(`${dollars}$ in euro = ${res}`);
// } else {
// 	alert("invalid input");
// }

// Task7

// let flashDriveMemory = parseFloat(prompt("Enter flash drive memory", "16"));

// if (!isNaN(flashDriveMemory)) {
// 	let res = parseInt((flashDriveMemory * 1000) / 820);
// 	alert(`${flashDriveMemory}gb = ${res} files by 820mb`);
// } else {
// 	alert("invalid input");
// }

//Task8

// let countMoney = parseFloat(prompt("Enter how much money you have", "100"));
// let chocolatePrice = parseFloat(prompt("Enter chocolate price", "10"));

// if (!isNaN(countMoney)) {
// 	if (!isNaN(chocolatePrice)) {
// 		alert(
// 			`You can buy ${parseInt(
// 				countMoney / chocolatePrice
// 			)} and remainder: ${countMoney % chocolatePrice} `
// 		);
// 	} else {
// 		alert("invalid input");
// 	}
// } else {
// 	alert("invalid input");
// }

//Task9

// let number = parseInt(prompt("Enter three-digit number", "123"));

// if (!isNaN(number)) {
// 	if (number > 99 && number < 1000) {
// 		let numbers = [];

// 		while (number % 10 != 0) {
// 			let digit = number % 10;
// 			numbers.push(digit);
// 			number = parseInt(number / 10);
// 		}

// 		let res = 0;
// 		for (let i = 0; i < numbers.length; i++) {
// 			if (i == 0) res += numbers[i] * Math.pow(10, numbers.length - 1);
// 			else res += numbers[i] * Math.pow(10, numbers.length - i - 1);
// 		}

// 		alert(`Reversed number: ${res}`);
// 	} else {
// 		alert("invalid input");
// 	}
// } else {
// 	alert("invalid input");
// }

//Task9 v2

// let numberStr = prompt("Enter three-digit number", "123");
// let number = parseInt(numberStr);

// if (!isNaN(number)) {
// 	alert(`Reversed number: ${numberStr.split("").reverse().join("")}`);
// } else {
// 	alert("invalid input");
// }

//Task10

// let number = parseInt(prompt("Enter whole number", "123"));

// if (!isNaN(number)) {
// 	alert(number % 2 == 0 ? "Number even" : "Number odd");
// } else {
// 	alert("invalid input");
// }
