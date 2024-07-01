using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.BookStore.Report.Blazor;

[Dependency(ReplaceServices = true)]
public class ReportBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Report";
}
