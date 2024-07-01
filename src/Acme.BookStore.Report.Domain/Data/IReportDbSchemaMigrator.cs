using System.Threading.Tasks;

namespace Acme.BookStore.Report.Data;

public interface IReportDbSchemaMigrator
{
    Task MigrateAsync();
}
