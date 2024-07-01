using Volo.Abp.Settings;

namespace Acme.BookStore.Report.Settings;

public class ReportSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ReportSettings.MySetting1));
    }
}
