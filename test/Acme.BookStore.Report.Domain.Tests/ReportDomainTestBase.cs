using Volo.Abp.Modularity;

namespace Acme.BookStore.Report;

/* Inherit from this class for your domain layer tests. */
public abstract class ReportDomainTestBase<TStartupModule> : ReportTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
