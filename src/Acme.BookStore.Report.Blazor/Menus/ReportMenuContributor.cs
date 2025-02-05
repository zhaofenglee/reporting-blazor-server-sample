﻿using System.Threading.Tasks;
using Acme.BookStore.Report.Localization;
using Acme.BookStore.Report.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace Acme.BookStore.Report.Blazor.Menus;

public class ReportMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ReportResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ReportMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                "Viewer",
                l["Viewer"],
                "/Viewer"
            )
        );

        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                "ViewerAddParamKey",
                l["ViewerAddParamKey"],
                "/Viewer/1FE985CE-149F-4D46-A57F-5E3FE95AEF2F"
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
