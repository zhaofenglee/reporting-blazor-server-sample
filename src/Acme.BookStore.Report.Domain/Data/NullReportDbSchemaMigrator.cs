using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore.Report.Data;

/* This is used if database provider does't define
 * IReportDbSchemaMigrator implementation.
 */
public class NullReportDbSchemaMigrator : IReportDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
