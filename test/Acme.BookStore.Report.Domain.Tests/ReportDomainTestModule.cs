using Volo.Abp.Modularity;

namespace Acme.BookStore.Report;

[DependsOn(
    typeof(ReportDomainModule),
    typeof(ReportTestBaseModule)
)]
public class ReportDomainTestModule : AbpModule
{

}
