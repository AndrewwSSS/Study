let groups = [
	{
		name: "Group 1",
		students: ["Student1", "Student2", "Student3"],
		lessons: [
			{
				lesson: 1,
				Topic: "topic1",
				readOnly: false,
				Students: [
					{
						studentName: "Student1",
						status: false,
					},
					{
						studentName: "Student2",
						status: false,
					},
					{
						studentName: "Student3",
						status: false,
					},
				],
			},
			{
				lesson: 2,
				Topic: "topic2",
				readOnly: false,
				Students: [
					{
						studentName: "Student1",
						status: false,
					},
					{
						studentName: "Student2",
						status: false,
					},
					{
						studentName: "Student3",
						status: false,
					},
				],
			},
			{
				lesson: 3,
				Topic: "topic3",
				readOnly: false,
				Students: [
					{
						studentName: "Student1",
						status: false,
					},
					{
						studentName: "Student2",
						status: false,
					},
					{
						studentName: "Student3",
						status: false,
					},
				],
			},
		],
	},
	{
		name: "Group 2",
		students: ["Student4", "Student5", "Student6"],
		lessons: [
			{
				lesson: 1,
				Topic: "topic4",
				readOnly: false,
				Students: [
					{
						studentName: "Student4",
						status: false,
					},
					{
						studentName: "Student5",
						status: false,
					},
					{
						studentName: "Student6",
						status: false,
					},
				],
			},
			{
				lesson: 2,
				Topic: "topic5",
				readOnly: false,
				Students: [
					{
						studentName: "Student4",
						status: false,
					},
					{
						studentName: "Student5",
						status: false,
					},
					{
						studentName: "Student6",
						status: false,
					},
				],
			},
			{
				lesson: 3,
				Topic: "topic6",
				readOnly: false,
				Students: [
					{
						studentName: "Student4",
						status: false,
					},
					{
						studentName: "Student5",
						status: false,
					},
					{
						studentName: "Student6",
						status: false,
					},
				],
			},
		],
	},
];

const maxLessons = 3;
var selectedLesson = groups[0].lessons[0];

for (let i = 0; i < groups.length; i++) {
	let newOption = document.createElement("option");
	newOption.innerText = groups[i].name;
	newOption.value = groups[i].name;
	select_Groups.append(newOption);
}

for (let i = 0; i < maxLessons; i++) {
	let newOption = document.createElement("option");
	newOption.innerText = i + 1;
	newOption.value = i + 1;
	select_Lessons.append(newOption);
}

updateTable();

Button_Select_Group.addEventListener("click", selectNewGroup);
Button_Save.addEventListener("click", saveResults);

function selectNewGroup() {
	let currentGroup = groups.filter(
		(g) => g.name == select_Groups.options[select_Groups.selectedIndex].text
	)[0];

	let currentLesson = Number(
		select_Lessons.options[select_Lessons.selectedIndex].text
	);

	selectedLesson = currentGroup.lessons[currentLesson - 1];

	updateTable();
}

function updateTable() {
	mainTable.innerHTML = "";

	let Students = selectedLesson.Students;
	LessonTopic.innerText = selectedLesson.Topic;
	if (selectedLesson.readOnly == false) {
		for (let i = 0; i < Students.length; i++) {
			let tr = document.createElement("tr");

			let th1 = document.createElement("th");
			th1.innerText = Students[i].studentName;

			let th2 = document.createElement("th");
			let input = document.createElement("input");
			input.type = "checkBox";
			input.value = Students[i].studentName;
			th2.append(input);

			tr.append(th1);
			tr.append(th2);

			mainTable.append(tr);
		}
	} else {
		for (let i = 0; i < Students.length; i++) {
			let tr = document.createElement("tr");

			let th1 = document.createElement("th");
			th1.innerText = Students[i].studentName;
			tr.append(th1);

			if (Students[i].status) {
				let th2 = document.createElement("th");
				let span = document.createElement("span");
				span.innerText = "present";
				th2.append(span);
				tr.append(th2);
			}

			mainTable.append(tr);
		}
	}
}

function saveResults() {
	let checkBoxes = document.querySelectorAll("input[type='checkBox']");

	for (let i = 0; i < checkBoxes.length; i++) {
		if (checkBoxes[i].checked) {
			selectedLesson.Students.filter(
				(s) => s.studentName == checkBoxes[i].value
			)[0].status = true;
		}
	}

	selectedLesson.readOnly = true;
	updateTable();
}
