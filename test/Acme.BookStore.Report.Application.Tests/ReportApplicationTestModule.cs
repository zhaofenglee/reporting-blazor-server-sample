using Volo.Abp.Modularity;

namespace Acme.BookStore.Report;

[DependsOn(
    typeof(ReportApplicationModule),
    typeof(ReportDomainTestModule)
)]
public class ReportApplicationTestModule : AbpModule
{

}
