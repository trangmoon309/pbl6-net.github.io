using Volo.Abp.Reflection;

namespace PBL6.Hreo.Permissions
{
    public class HreoPermissions
    {
        public const string GroupName = "Hreo";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(HreoPermissions));
        }
    }
}