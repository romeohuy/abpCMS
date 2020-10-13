using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using AbpCMS.Localization;
using AbpCMS.Permissions;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.IdentityServer.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Saas.Host.Navigation;

namespace AbpCMS.Web.Menus
{
    public class AbpCMSMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<AbpCMSResource>();

            //Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    AbpCMSMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fa fa-home",
                    order: 1
                )
            );

            if (await context.IsGrantedAsync(AbpCMSPermissions.Dashboard.Host))
            {
                //HostDashboard
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        AbpCMSMenus.HostDashboard,
                        l["Menu:Dashboard"],
                        "~/HostDashboard",
                        icon: "fa fa-line-chart",
                        order: 2
                    )
                );
            }

            if (await context.IsGrantedAsync(AbpCMSPermissions.Dashboard.Tenant))
            {
                //TenantDashboard
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        AbpCMSMenus.TenantDashboard,
                        l["Menu:Dashboard"],
                        "~/Dashboard",
                        icon: "fa fa-line-chart",
                        order: 2
                    )
                );
            }

            //Administration
            var administration = context.Menu.GetAdministration();
            administration.Order = 3;

            //Administration->Saas
            administration.SetSubItemOrder(SaasHostMenuNames.GroupName, 1);

            //Administration->Identity
            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);

            //Administration->Identity Server
            administration.SetSubItemOrder(AbpIdentityServerMenuNames.GroupName, 3);

            //Administration->Language Management
            administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 4);

            //Administration->Text Template Management
            administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 5);

            //Administration->Audit Logs
            administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 6);

            //Administration->Settings
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 7);

            if (await context.IsGrantedAsync(AbpCMSPermissions.Cagegories.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        "AbpCMS.Cagegories",
                        l["Menu:Cagegories"],
                        url: "/Cagegories",
                        icon: "fa fa-file-alt")
                );
            }

            if (await context.IsGrantedAsync(AbpCMSPermissions.Companies.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        "AbpCMS.Companies",
                        l["Menu:Companies"],
                        url: "/Companies",
                        icon: "fa fa-file-alt")
                );
            }

            if (await context.IsGrantedAsync(AbpCMSPermissions.CompanyDatas.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem(
                        "AbpCMS.CompanyDatas",
                        l["Menu:CompanyDatas"],
                        url: "/CompanyDatas",
                        icon: "fa fa-file-alt")
                );
            }
        }
    }
}