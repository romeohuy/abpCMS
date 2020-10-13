$(function () {   
    var l = abp.localization.getResource("AbpCMS");
	
	var cagegoryService = window.abpCMS.cagegories.cagegory;
	
		
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Cagegories/CreateModal",
        scriptUrl: "/Pages/Cagegories/createModal.js",
        modalClass: "cagegoryCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Cagegories/EditModal",
        scriptUrl: "/Pages/Cagegories/editModal.js",
        modalClass: "cagegoryEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),	
            name: $("#NameFilter").val(),
            isActive: (function () {
                var value = $("#IsActiveFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })()
        };
    };
	
    var dataTable = $("#CagegoriesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(cagegoryService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('AbpCMS.Cagegories.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('AbpCMS.Cagegories.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    cagegoryService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "name" }
,            {
                data: "isActive",
                render: function (isActive) {
                    return isActive ? l("Yes") : l("No");
                }
            }

            
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewCagegoryButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });
	
    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
});