using Acme.BookStore.Report.Samples;
using Xunit;

namespace Acme.BookStore.Report.EntityFrameworkCore.Applications;

[Collection(ReportTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ReportEntityFrameworkCoreTestModule>
{

}
