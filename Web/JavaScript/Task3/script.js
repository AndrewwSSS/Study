// Task1

// let array = [
// 	{
// 		name: "Apple",
// 		isBought: true,
// 		count: 1,
// 	},
// 	{
// 		name: "Carrot",
// 		isBought: false,
// 		count: 0,
// 	},
// ];

// function printProducts(products) {
// 	products.sort((x, y) => {
// 		return x.isBought === y.isBought ? 0 : !x.isBought ? -1 : 1;
// 	});
// 	console.log(products);
// }

// function addProduct(products, prodName) {
// 	let product = products.filter(
// 		(p) => p.name === prodName && p.isBought == false
// 	)[0];

// 	if (product != undefined) {
// 		product.count += 1;
// 	} else {
// 		products.push({
// 			name: prodName,
// 			isBought: false,
// 			count: 1,
// 		});
// 	}
// }

// function buyProduct(products, prodName) {
// 	let product = products.filter(
// 		(p) => p.name === prodName && p.isBought == false && p.count > 0
// 	)[0];

// 	if (product != null) {
// 		product.count--;

// 		let boughtProduct = products.filter(
// 			(p) => p.isBought == true && p.name == prodName
// 		)[0];

// 		if (boughtProduct != undefined) {
// 			boughtProduct.count += 1;
// 		} else {
// 			products.push({
// 				name: prodName,
// 				isBought: true,
// 				count: 1,
// 			});
// 		}

// 		return true;
// 	} else {
// 		return false;
// 	}
// }

// addProduct(array, "Carrot");

// addProduct(array, "Apple");

// printProducts(array);

// buyProduct(array, "Carrot");

// printProducts(array);





// Task2

// let array = [
// 	{
// 		name: "Prod1",
// 		count: 2,
// 		price: 100,
// 	},
// 	{
// 		name: "Prod2",
// 		count: 500,
// 		price: 10,
// 	},
// 	{
// 		name: "Prod3",
// 		count: 10,
// 		price: 10,
// 	},
// ];

// function print(products) {
// 	let res = "";
// 	for (let i = 0; i < products.length; i++) {
// 		res += `${products[i].name}. Count: ${
// 			products[i].count
// 		}. Total price: ${products[i].price * products[i].count}\n`;
// 	}
// 	res += `Total sum: ${countTotalSum(products)}`;
// 	console.log(res);
// }

// function countTotalSum(products) {
// 	console.log(products);
// 	return products
// 		.map((p) => p.price * p.count)
// 		.reduce((a, b) => {
// 			return a + b;
// 		}, 0);
// }

// function getMostExpensive(products) {
// 	return products.reduce(function (a, b) {
// 		return a.price * a.count > b.price * b.count ? a : b;
// 	});
// }

// function getAverageSum(products) {
// 	let sum = products
// 		.map((a) => a.price * a.count)
// 		.reduce((a, b) => {
// 			return a + b;
// 		}, 0);
// 	return sum / products.length;
// }

// print(array);

// console.log(countTotalSum(array));

// console.log(getMostExpensive(array));

// console.log(getAverageSum(array));




//Task3

// let styleArray = [
// 	{
// 		name: "font-size",
// 		value: "59px",
// 	},
// 	{
// 		name: "background-color",
// 		value: "red",
// 	},
// 	{
// 		name: "color",
// 		value: "white",
// 	},
// ];

// let res = '<p style="';

// for (let i = 0; i < styleArray.length; i++) {
// 	res += `${styleArray[i].name}:${styleArray[i].value};`;
// }

// res += '">test</p>';

// document.write(res);





//Task4

// let audiences = [
// 	{
// 		name: "A1",
// 		places: 10,
// 		faculty: "F1",
// 	},
// 	{
// 		name: "A2",
// 		places: 20,
// 		faculty: "F2",
// 	},
// 	{
// 		name: "A3",
// 		places: 15,
// 		faculty: "F3",
// 	},
// 	{
// 		name: "A4",
// 		places: 12,
// 		faculty: "F3",
// 	},
// ];

// function print(audiences) {
// 	let res = "";
// 	for (let i = 0; i < audiences.length; i++) {
// 		res += `${audiences[i].name}. Places: ${audiences[i].places}. Faculty: ${audiences[i].faculty}\n`;
// 	}
// 	console.log(res);
// }

// function printByFaculty(audiences, faculty) {
// 	let res = "";
// 	for (let i = 0; i < audiences.length; i++) {
// 		if (audiences[i].faculty === faculty) {
// 			res += `${audiences[i].name}. Places: ${audiences[i].places}. Faculty: ${audiences[i].faculty}\n`;
// 		}
// 	}
// 	console.log(res);
// }

// function printByGroup(audiences, group) {
// 	let res = "";

// 	for (let i = 0; i < audiences.length; i++) {
// 		if (
// 			audiences[i].faculty === group.faculty &&
// 			audiences[i].places >= group.countStudents
// 		) {
// 			res += `${audiences[i].name}. Places: ${audiences[i].places}. Faculty: ${audiences[i].faculty}\n`;
// 		}
// 	}
// 	console.log(res);
// }

// function sortAudiencesByPlaces(audiences) {
// 	audiences.sort((a, b) =>
// 		a.places === b.places ? 0 : a.places > b.places ? -1 : 1
// 	);
// }

// function sortAudiencesByNames(audiences) {
// 	audiences.sort((a, b) =>
// 		a.name === b.name ? 0 : a.name > b.name ? -1 : 1
// 	);
// }

// print(audiences);

// printByFaculty(audiences, "F3");

// printByGroup(audiences, { name: "G1", countStudents: 15, faculty: "F3" });

// sortAudiencesByPlaces(audiences);
// console.log(audiences);

// sortAudiencesByNames(audiences);
// console.log(audiences);
