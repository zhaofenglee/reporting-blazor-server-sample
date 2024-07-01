using Acme.BookStore.Report.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Report.Permissions;

public class ReportPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ReportPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ReportPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ReportResource>(name);
    }
}
