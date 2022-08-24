$("li").mouseover(function () {
	$(this).css("font-weight", "bold");
});

$("li").mouseout(function () {
	$(this).css("font-weight", "normal");
});

$(".folder").click(function () {
	$(this).next().toggle();
});
