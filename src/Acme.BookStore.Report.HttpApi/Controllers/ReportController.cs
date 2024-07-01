using Acme.BookStore.Report.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.Report.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ReportController : AbpControllerBase
{
    protected ReportController()
    {
        LocalizationResource = typeof(ReportResource);
    }
}
