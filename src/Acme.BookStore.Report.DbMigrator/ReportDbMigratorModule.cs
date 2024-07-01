using Acme.BookStore.Report.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Report.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ReportEntityFrameworkCoreModule),
    typeof(ReportApplicationContractsModule)
    )]
public class ReportDbMigratorModule : AbpModule
{
}
