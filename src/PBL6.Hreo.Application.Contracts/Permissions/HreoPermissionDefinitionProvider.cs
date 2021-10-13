using PBL6.Hreo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace PBL6.Hreo.Permissions
{
    public class HreoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HreoPermissions.GroupName, L("Permission:Hreo"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HreoResource>(name);
        }
    }
}