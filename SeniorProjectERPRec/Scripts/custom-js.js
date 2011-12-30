$(document).ready(function () {
	//Form Widgets
	$("#CloseDate").datepicker({
		showButtonPanel: true
	});
	//Table
	$('.datatable').dataTable({
		"bJQueryUI": true,
		"bRetrieve": true
	});
	$('#approval-datatable').dataTable({
		"bJQueryUI": true,
		"bRetrieve": true,
		"bLengthChange": false,
		"bFilter": true,
		"bSort": false
	});
	//Buttons
	$(".add-button").button({ icons: { primary: "ui-icon-circle-plus"} });
	$(".back-button").button({ icons: { primary: "ui-icon-circle-arrow-w"} });
	$(".save-button").button();
	$(".edit-button").button({ icons: { primary: "ui-icon ui-icon-document"} });
	$(".delete-button").button({ icons: { primary: "ui-icon-trash"} });
	$(".approval-button").button({ icons: { primary: "ui-icon-check"} });
	$(".promote-button").button({ icons: { primary: "ui-icon-arrowthick-1-n"} });
	//Charts
	$('#applicantposition')
	.visualize({
		type: 'pie',
		width: 300,
		height: 300
	})
	.appendTo("#appending");
	$('#applicantposition').hide();
});
