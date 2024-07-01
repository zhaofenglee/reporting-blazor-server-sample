using Acme.BookStore.Report.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Acme.BookStore.Report.Blazor;

public abstract class ReportComponentBase : AbpComponentBase
{
    protected ReportComponentBase()
    {
        LocalizationResource = typeof(ReportResource);
    }
}
