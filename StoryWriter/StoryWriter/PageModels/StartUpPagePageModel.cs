using StoryWriter.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryWriter.PageModels
{
    public class StartUpPagePageModel : PageModelBase
    {
        public StartUpPagePageModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; }

        public async override Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);

            await NavigationService.NavigateToAsync<DashboardPageModel>();
        }
    }
}