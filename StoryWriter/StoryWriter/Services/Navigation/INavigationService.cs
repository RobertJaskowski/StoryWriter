using StoryWriter.PageModels.Base;
using System;
using System.Threading.Tasks;

namespace StoryWriter
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to asynchonously navigate between Page Models,
        /// and optionally pass navigation Data.
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <param name="navigationData"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase;

        /// <summary>
        /// Pop navigation backstack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();

        Action<PageModelBase> OnPageSwitched { get; set; }
    }
}
