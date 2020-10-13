using AbpCMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpCMS.Permissions
{
    public class AbpCMSPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpCMSPermissions.GroupName);

            myGroup.AddPermission(AbpCMSPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(AbpCMSPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpCMSPermissions.MyPermission1, L("Permission:MyPermission1"));

            var cagegoryPermission = myGroup.AddPermission(AbpCMSPermissions.Cagegories.Default, L("Permission:Cagegories"));
            cagegoryPermission.AddChild(AbpCMSPermissions.Cagegories.Create, L("Permission:Create"));
            cagegoryPermission.AddChild(AbpCMSPermissions.Cagegories.Edit, L("Permission:Edit"));
            cagegoryPermission.AddChild(AbpCMSPermissions.Cagegories.Delete, L("Permission:Delete"));

            var companyPermission = myGroup.AddPermission(AbpCMSPermissions.Companies.Default, L("Permission:Companies"));
            companyPermission.AddChild(AbpCMSPermissions.Companies.Create, L("Permission:Create"));
            companyPermission.AddChild(AbpCMSPermissions.Companies.Edit, L("Permission:Edit"));
            companyPermission.AddChild(AbpCMSPermissions.Companies.Delete, L("Permission:Delete"));

            var companyDataPermission = myGroup.AddPermission(AbpCMSPermissions.CompanyDatas.Default, L("Permission:CompanyDatas"));
            companyDataPermission.AddChild(AbpCMSPermissions.CompanyDatas.Create, L("Permission:Create"));
            companyDataPermission.AddChild(AbpCMSPermissions.CompanyDatas.Edit, L("Permission:Edit"));
            companyDataPermission.AddChild(AbpCMSPermissions.CompanyDatas.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpCMSResource>(name);
        }
    }
}