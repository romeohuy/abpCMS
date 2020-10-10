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
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpCMSResource>(name);
        }
    }
}