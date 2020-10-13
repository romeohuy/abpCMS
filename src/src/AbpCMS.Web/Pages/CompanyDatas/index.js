$(function () {   
    var l = abp.localization.getResource("AbpCMS");
	
	var companyDataService = window.abpCMS.companyDatas.companyData;
	
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
	    $('#CompanyFilterLookupOpenButton').on('click', '', function () {
        lastNpDisplayNameId = 'Company_Filter_Name';
        lastNpIdId = 'CompanyIdFilter';
        _lookupModal.open({
            currentId: $('#CompanyIdFilter').val(),
            currentDisplayName: $('#Company_Filter_Name').val(),
            serviceMethod: function () {
                            
                            return window.abpCMS.companyDatas.companyData.getCompanyLookup;
            }
        });
    });	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "CompanyDatas/CreateModal",
        scriptUrl: "/Pages/CompanyDatas/createModal.js",
        modalClass: "companyDataCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "CompanyDatas/EditModal",
        scriptUrl: "/Pages/CompanyDatas/editModal.js",
        modalClass: "companyDataEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),	
            percent: $("#PercentFilter").val(),
			cN: $("#CNFilter").val(),
			tN: $("#TNFilter").val(),
			gia: $("#GiaFilter").val(),
			giaTheoPhanTram: $("#GiaTheoPhanTramFilter").val(),
			bienDongGia: $("#BienDongGiaFilter").val(),
			bienDongCaoThap: $("#BienDongCaoThapFilter").val(),
			luuY: $("#LuuYFilter").val(),
			kL: $("#KLFilter").val(),
			kLPhanTram: $("#KLPhanTramFilter").val(),
			nN: $("#NNFilter").val(),
			giaTriNN: $("#GiaTriNNFilter").val(),
			nNMuaCongBan: $("#NNMuaCongBanFilter").val(),
			nNMuaTruBan: $("#NNMuaTruBanFilter").val(),
			sucManh: $("#SucManhFilter").val(),
			diemGia: $("#DiemGiaFilter").val(),
			linkThamKhao: $("#LinkThamKhaoFilter").val(),
			createdDateMin: $("#CreatedDateFilterMin").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			createdDateMax: $("#CreatedDateFilterMax").data().datepicker.getFormattedDate('yyyy-mm-dd'),
			companyId: $("#CompanyIdFilter").val()
        };
    };
	
    var dataTable = $("#CompanyDatasTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(companyDataService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('AbpCMS.CompanyDatas.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.companyData.id });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('AbpCMS.CompanyDatas.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    companyDataService.delete(data.record.companyData.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "companyData.percent" }
,			{ data: "companyData.cN" }
,			{ data: "companyData.tN" }
,			{ data: "companyData.gia" }
,			{ data: "companyData.giaTheoPhanTram" }
,			{ data: "companyData.bienDongGia" }
,			{ data: "companyData.bienDongCaoThap" }
,			{ data: "companyData.luuY" }
,			{ data: "companyData.kL" }
,			{ data: "companyData.kLPhanTram" }
,			{ data: "companyData.nN" }
,			{ data: "companyData.giaTriNN" }
,			{ data: "companyData.nNMuaCongBan" }
,			{ data: "companyData.nNMuaTruBan" }
,			{ data: "companyData.sucManh" }
,			{ data: "companyData.diemGia" }
,			{ data: "companyData.linkThamKhao" }
,            {
                data: "companyData.createdDate",
                render: function (createdDate) {
                    if (!createdDate) {
                        return "";
                    }
                    
					var date = Date.parse(createdDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            }

            ,
            {
                data: "company.name",
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

    $("#NewCompanyDataButton").click(function (e) {
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