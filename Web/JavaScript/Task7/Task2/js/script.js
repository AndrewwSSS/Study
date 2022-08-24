let users;
let $selectedUser;

$(document).ready(function () {
	$(".userInfo").toggle();
	$(".userPosts").toggle();

	$.ajax({
		method: "GET",
		url: "https://jsonplaceholder.typicode.com/users",
		dataType: "json",
		success: function (res) {
			users = res;
			users.forEach((user) => {
				let div = document.createElement("div");
				div.className = "user-container";
				div.innerText = user.name;
				$(div).click(userOnClick);
				$(".users-container").append(div);
			});
		},
	});
});

$("#showPostsButton").click(function () {
	if ($selectedUser != undefined) {
		$(".posts-container").html("");
		let userId = users.find((user) => user.name == $selectedUser.text()).id;
		$.ajax({
			method: "GET",
			url: `https://jsonplaceholder.typicode.com/posts?userId=${userId}`,
			dataType: "json",
			success: function (res) {
				res.forEach((post) => {
					let $div = $("<div></div>");
					$div.addClass("post");
					$div.append(`<b class="post-title">${post.title}</b>`);
					$div.append(`<div>${post.body}</div>`);

					$div.appendTo(".posts-container");
				});
				$(".userPosts").show();
			},
		});
	}
});

function userOnClick() {
	$(".userInfo").show();
	if ($selectedUser == undefined) {
		$selectedUser = $(this);
		$selectedUser.addClass("selected-user");
		updateUserInfoTable();
		$(".userPosts").hide();
	} else {
		if ($(this).text() != $selectedUser.text()) {
			$selectedUser.removeClass("selected-user");
			$selectedUser = $(this);
			$selectedUser.addClass("selected-user");

			updateUserInfoTable();
			$(".userPosts").hide();
		}
	}
}

function updateUserInfoTable() {
	$(".userInfo-table").html("");

	let info = users.find((user) => user.name == $selectedUser.text());

	$(`<tr><td>Name:</td><td>${info.name}</td></tr>`).appendTo(
		".userInfo-table"
	);
	$(`<tr><td>Username:</td><td>${info.username}</td></tr>`).appendTo(
		".userInfo-table"
	);
	$(`<tr><td>Addres:</td><td>${info.address.street}</td></tr>`).appendTo(
		".userInfo-table"
	);
	$(`<tr><td>Email:</td><td>${info.email}</td></tr>`).appendTo(
		".userInfo-table"
	);
	$(`<tr><td>Phone:</td><td>${info.phone}</td></tr>`).appendTo(
		".userInfo-table"
	);
	$(`<tr><td>Website:</td><td>${info.website}</td></tr>`).appendTo(
		".userInfo-table"
	);
}
