$(".Page").hide();
$("#Page1").show();

$('.btn').on('click', (event) => {
    const TargetPage = event.target.dataset.target;
    $(".Page").hide();
    $(`#${TargetPage}`).toggle();
});