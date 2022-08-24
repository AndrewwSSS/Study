let form = document.getElementById("addMessageContainer");

form.addEventListener("submit", onSubmit);

function onSubmit(event) {
	if (LocalName.value != "" && LocalMessage.value != "") {
		let newMessage = document.createElement("div");
		newMessage.className = "messageBox";

		let messageInfo = document.createElement("div");
		messageInfo.className = "messageInfo";

		let senderName = document.createElement("span");
		senderName.innerText = LocalName.value;

		let sendTime = document.createElement("span");
		sendTime.innerText = new Date().toLocaleString();

		messageInfo.append(senderName);
		messageInfo.append(sendTime);

		let messageContent = document.createElement("div");
		messageContent.className = "messageContent";

		let messageText = document.createElement("span");
		messageText.innerText = LocalMessage.value;

		messageContent.append(messageText);

		newMessage.append(messageInfo);
		newMessage.append(messageContent);

		messagesContainer.append(newMessage);

		LocalName.value = "";
		LocalMessage.value = "";
	} else {
		alert("Invalid input");
	}
}
