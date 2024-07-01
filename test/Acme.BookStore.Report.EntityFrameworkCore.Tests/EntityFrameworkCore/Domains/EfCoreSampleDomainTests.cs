using Acme.BookStore.Report.Samples;
using Xunit;

namespace Acme.BookStore.Report.EntityFrameworkCore.Domains;

[Collection(ReportTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ReportEntityFrameworkCoreTestModule>
{

}
