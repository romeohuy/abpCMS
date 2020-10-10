using System.IO;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AbpCMS.EntityFrameworkCore;
using AbpCMS.Localization;
using AbpCMS.MultiTenancy;
using AbpCMS.Permissions;
using AbpCMS.Web.Menus;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Account.Admin.Web;
using Volo.Abp.Account.Public.Web;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Commercial;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Lepton;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AuditLogging.Web;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Web;
using Volo.Abp.IdentityServer.Web;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.TextTemplateManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Saas.Host;

namespace AbpCMS.Web
{
    [DependsOn(
        typeof(AbpCMSHttpApiModule),
        typeof(AbpCMSApplicationModule),
        typeof(AbpCMSEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountPublicWebIdentityServerModule),
        typeof(AbpAuditLoggingWebModule),
        typeof(LeptonThemeManagementWebModule),
        typeof(SaasHostWebModule),
        typeof(AbpAccountAdminWebModule),
        typeof(AbpIdentityServerWebModule),
        typeof(LanguageManagementWebModule),
        typeof(AbpAspNetCoreMvcUiLeptonThemeModule),
        typeof(TextTemplateManagementWebModule)
        )]
    public class AbpCMSWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(AbpCMSResource),
                    typeof(AbpCMSDomainModule).Assembly,
                    typeof(AbpCMSDomainSharedModule).Assembly,
                    typeof(AbpCMSApplicationModule).Assembly,
                    typeof(AbpCMSApplicationContractsModule).Assembly,
                    typeof(AbpCMSWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureUrls(configuration);
            ConfigurePages(configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigurePages(IConfiguration configuration)
        {
            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/HostDashboard", AbpCMSPermissions.Dashboard.Host);
                options.Conventions.AuthorizePage("/TenantDashboard", AbpCMSPermissions.Dashboard.Tenant);
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.Audience  = "AbpCMS";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpCMSWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpCMSWebModule>();

                if (hostingEnvironment.IsDevelopment())
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpCMSDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}AbpCMS.Domain.Shared", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpCMSDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}AbpCMS.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpCMSApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}AbpCMS.Application.Contracts", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpCMSApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}AbpCMS.Application", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpCMSHttpApiModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}AbpCMS.HttpApi", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpCMSWebModule>(hostingEnvironment.ContentRootPath);
                }
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpCMSMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AbpCMSApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AbpCMS API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpCMS API");
            });
            app.UseAuditing();
            app.UseConfiguredEndpoints();
        }
    }
}
