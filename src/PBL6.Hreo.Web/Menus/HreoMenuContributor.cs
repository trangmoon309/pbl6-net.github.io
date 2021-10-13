using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace PBL6.Hreo.Web.Menus
{
    public class HreoMenuContributor : IMenuContributor
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
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(HreoMenus.Prefix, displayName: "Hreo", "~/Hreo", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
}