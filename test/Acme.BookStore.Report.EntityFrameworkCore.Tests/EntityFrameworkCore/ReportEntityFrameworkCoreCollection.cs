using Xunit;

namespace Acme.BookStore.Report.EntityFrameworkCore;

[CollectionDefinition(ReportTestConsts.CollectionDefinitionName)]
public class ReportEntityFrameworkCoreCollection : ICollectionFixture<ReportEntityFrameworkCoreFixture>
{

}
