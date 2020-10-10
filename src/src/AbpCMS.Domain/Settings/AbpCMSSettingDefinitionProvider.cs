using Volo.Abp.Settings;

namespace AbpCMS.Settings
{
    public class AbpCMSSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpCMSSettings.MySetting1));
        }
    }
}
