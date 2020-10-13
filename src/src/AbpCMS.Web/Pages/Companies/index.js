$(function () {   
    var l = abp.localization.getResource("AbpCMS");
	
	var companyService = window.abpCMS.companies.company;
	
        var lastNpIdId = '';
        var lastNpDisplayNameId = '';

        var _lookupModal = new abp.ModalManager({
            viewUrl: abp.appPath + "Shared/LookupModal",
            scriptUrl: "/Pages/Shared/lookupModal.js",
            modalClass: "navigationPropertyLookup"
        });

        $('.lookupCleanButton').on('click', '', function () {
            $(this).parent().parent().find('input').val('');
        });

        _lookupModal.onClose(function () {
            var modal = $(_lookupModal.getModal());
            $('#' + lastNpIdId).val(modal.find('#CurrentLookupId').val());
            $('#' + lastNpDisplayNameId).val(modal.find('#CurrentLookupDisplayName').val());
        });
		
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Companies/CreateModal",
        scriptUrl: "/Pages/Companies/createModal.js",
        modalClass: "companyCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Companies/EditModal",
        scriptUrl: "/Pages/Companies/editModal.js",
        modalClass: "companyEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),	
            code: $("#CodeFilter").val(),
			name: $("#NameFilter").val(),
            isActive: (function () {
                var value = $("#IsActiveFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			cagegoryId: $("#CagegoryIdFilter").val()
        };
    };
	
    var dataTable = $("#CompaniesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(companyService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('AbpCMS.Companies.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.company.id });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('AbpCMS.Companies.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    companyService.delete(data.record.company.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "company.code" }
,			{ data: "company.name" }
,            {
                data: "company.isActive",
                render: function (isActive) {
                    return isActive ? l("Yes") : l("No");
                }
            }

            ,
            {
                data: "cagegory.name",
                defaultContent : ""
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewCompanyButton").click(function (e) {
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