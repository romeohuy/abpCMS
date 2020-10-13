var abp = abp || {};

abp.modals.companyDataCreate = function () {
    var initModal = function (publicApi, args) {
        
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
        
        $('#CompanyLookupOpenButton').on('click', '', function () {
            lastNpDisplayNameId = 'Company_Name';
            lastNpIdId = 'Company_Id';
            _lookupModal.open({
                currentId: $('#Company_Id').val(),
                currentDisplayName: $('#Company_Name').val(),
                serviceMethod: function() {
                    
                    return window.abpCMS.companyDatas.companyData.getCompanyLookup;
                }
            });
        });
    };

    return {
        initModal: initModal
    };
};