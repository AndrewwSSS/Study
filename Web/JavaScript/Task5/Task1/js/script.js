let links = $("ul > li > a");
let regeX = new RegExp("^(http(s)?://)");

console.log(links);

for (let i = 0; i < links.length; i++) {
	// innerText потому что я использую сервер и он автоматом прибавляет туда свою локальную ссылку
	// http://127.0.0.1:5500/Task5/Task1/index.html - по типу такого
	if (regeX.test(links[i].innerText)) $(links[i]).addClass("dotted");
}
