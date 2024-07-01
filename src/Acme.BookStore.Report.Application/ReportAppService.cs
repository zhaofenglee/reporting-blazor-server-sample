using System;
using System.Collections.Generic;
using System.Text;
using Acme.BookStore.Report.Localization;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Report;

/* Inherit your application services from this class.
 */
public abstract class ReportAppService : ApplicationService
{
    protected ReportAppService()
    {
        LocalizationResource = typeof(ReportResource);
    }
}
