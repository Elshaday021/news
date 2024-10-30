using HCMS.Domain.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SMS.Persistence.SeedData;

public static class RolesAndPermisssionsSeedData
{
    public static async Task SeedAsync(RoleManager<HRRole> roleManager)
    {
        await CreateHROfficerRole(roleManager);
        await CreateShareAdminSectionHeadRole(roleManager);
        await SystemAdminRole(roleManager);
    }

    private static async Task CreateHROfficerRole(RoleManager<HRRole> roleManager)
    {
        var HROfficerRole = await roleManager.FindByNameAsync(Roles.HROfficer);
        if (HROfficerRole == null)
        {
            HROfficerRole = new HRRole(Roles.HROfficer, "Officer", "Officer")
            {
                Id = Guid.NewGuid().ToString()
            };
            await roleManager.CreateAsync(HROfficerRole);
        }

        //var claims = await roleManager.GetClaimsAsync(HROfficerRole!);

        ////shareholder
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.PersonalInfo.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.BlockedStatus.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.InActiveState.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.PowerOfAttorney.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.Relatives.Edit);

        ////subscription
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Subscription.Add);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Subscription.Cancel);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Subscription.Reverse);

        ////payment
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.Add);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.Discard);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Refund.View.Appproved);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.View.Returned);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Refund.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Refund.Add);

        ////Transfer
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.Add);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.update.Edit);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.Return);
        //await AddClaimToRole(roleManager, HROfficerRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.Reverse);



    }

    private static async Task CreateShareAdminSectionHeadRole(RoleManager<HRRole> roleManager)
    {
        var shareAdminSectionHeadRole = await roleManager.FindByNameAsync(Roles.HRSectionHead);
        if (shareAdminSectionHeadRole == null)
        {
            shareAdminSectionHeadRole = new HRRole(Roles.HRSectionHead, " HR Section Head", "HR  Section Head");
            shareAdminSectionHeadRole.Id = Guid.NewGuid().ToString();
            await roleManager.CreateAsync(shareAdminSectionHeadRole);
        }

        //var claims = await roleManager.GetClaimsAsync(shareAdminSectionHeadRole!);

        ////shareholder
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.PersonalInfo.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.PowerOfAttorney.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.BlockedStatus.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.Relatives.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Shareholder.InActiveState.Approve);


        ////subscription
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Subscription.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Subscription.Returned);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Subscription.ReverseApprove);

        ////payment
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.Return);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Collect.View.Pending);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Refund.View.ReversePending);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Payment.Refund.Approve);

        ////allocation
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Allocation.Add);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Allocation.View.AllView);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Allocation.View.Returned);

        ////Transfer
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.Approve);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.update.Edit);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.View.Pending);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.Return);
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.Transfer.ReverseApprove);

        ////EndOfDay
        //await AddClaimToRole(roleManager, shareAdminSectionHeadRole, claims, CustomClaimTypes.Permission, UserPermissions.EndOfDay.Process);

    }

    private async static Task SystemAdminRole(RoleManager<HRRole> roleManager)
    {
        var systemAdminRole = await roleManager.FindByNameAsync(Roles.ITAdmin);
        if (systemAdminRole == null)
        {
            systemAdminRole = new HRRole(Roles.ITAdmin, "IT Admin", "IT Admin");
            await roleManager.CreateAsync(systemAdminRole);
        }

        //var claims = await roleManager.GetClaimsAsync(systemAdminRole!);

        //await AddClaimToRole(roleManager, systemAdminRole, claims, CustomClaimTypes.Permission, UserPermissions.User.Disable);
        //await AddClaimToRole(roleManager, systemAdminRole, claims, CustomClaimTypes.Permission, UserPermissions.User.Edit);
        //await AddClaimToRole(roleManager, systemAdminRole, claims, CustomClaimTypes.Permission, UserPermissions.User.Enable);
        //await AddClaimToRole(roleManager, systemAdminRole, claims, CustomClaimTypes.Permission, UserPermissions.User.View);
        //await AddClaimToRole(roleManager, systemAdminRole, claims, CustomClaimTypes.Permission, UserPermissions.EndOfDay.Process);

    }


    private static async Task AddClaimToRole(RoleManager<HRRole> roleManager, HRRole HROfficerRole, IList<Claim> currentClaims, string claimType, string value)
    {
        if (!currentClaims.Any(claim => claim.Type == claimType && claim.Value == value))
            await roleManager.AddClaimAsync(HROfficerRole, new Claim(claimType, value));
    }
}
