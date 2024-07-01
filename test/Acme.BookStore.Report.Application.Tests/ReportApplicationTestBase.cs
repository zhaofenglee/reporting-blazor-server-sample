using Volo.Abp.Modularity;

namespace Acme.BookStore.Report;

public abstract class ReportApplicationTestBase<TStartupModule> : ReportTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
