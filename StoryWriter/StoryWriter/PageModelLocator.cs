using StoryWriter.Models;
using StoryWriter.PageModels;
using StoryWriter.PageModels.Base;
using StoryWriter.PageModels.StoriesPage;
using StoryWriter.Pages;
using StoryWriter.Pages.StoriesPages;
using StoryWriter.Services;
using StoryWriter.Services.Stories;
using System;
using System.Collections.Generic;
using TinyIoC;
using Xamarin.Forms;

namespace StoryWriter
{
    public class PageModelLocator
    {
        private static TinyIoCContainer _container;
        private static Dictionary<Type, Type> _lookupTable;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _lookupTable = new Dictionary<Type, Type>();

            // Register Page and Page Models

            Register<StartUpPagePageModel, StartUpPage>();

            Register<StoriesPageModel, StoriesPage>();
            Register<CreateStoryPageModel, CreateStoryPage>();
            Register<StoryWritingRoomPageModel, StoryWritingRoomPage>();
            Register<EditStoryPageModel, EditStoryPage>();

            Register<DashboardPageModel, DashboardPage>();
            Register<LoginPageModel, LoginPage>();
            Register<LoginEmailPageModel, LoginEmailPage>();
            Register<LoginPhonePageModel, LoginPhonePage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            // Register Services (registered as Singletons by default)

            _container.Register<INavigationService, NavigationService>();

            _container.Register<IAccountService>(DependencyService.Get<IAccountService>());
            _container.Register<IStoriesService>(DependencyService.Get<IStoriesService>());
            _container.Register<IMessageService>(DependencyService.Get<IMessageService>());

            _container.Register(DependencyService.Get<IStoryRoomFC<Story>>());
            _container.Register(DependencyService.Get<IFavoritedRoomFC<FavoritedRoom>>());

            _container.Register(DependencyService.Get<IFirebaseCollection<Story>>());
            ////_container.Register(DependencyService.Get<IFirebaseCollection<WorkItem>>());
            _container.Register(DependencyService.Get<IFirebaseCollection<TestData>>());
            _container.Register(DependencyService.Get<IFirebaseCollection<MyTestData>>());
        }

        /// <summary>
        /// Private utility method to Register page and page model for page retrieval by it's
        /// specified page model type.
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <typeparam name="TPage"></typeparam>
        private static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _lookupTable.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }

        public static T Resolve<T>() where T : class
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (TinyIoCResolutionException e)
            {
                var message = e.Message;
                System.Diagnostics.Debug.WriteLine(e.Message);

                while (e.InnerException is TinyIoCResolutionException ex)
                {
                    message = ex.Message;
                    System.Diagnostics.Debug.WriteLine("\t" + ex.Message);
                    e = ex;
                }
#if DEBUG
                App.Current.MainPage.DisplayAlert("Resolution Error", message, "Ok");
#endif
            }
            return default(T);
        }

        public static Page CreatePageFor<TPageModelType>() where TPageModelType : PageModelBase
        {
            Type pageModelType = typeof(TPageModelType);
            var pageType = _lookupTable[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = Resolve<TPageModelType>();
            page.BindingContext = pageModel;
            return page;
        }

        public static Page CreatePageFor<TPageModelType>(out PageModelBase pageModel) where TPageModelType : PageModelBase
        {
            Type pageModelType = typeof(TPageModelType);
            var pageType = _lookupTable[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            pageModel = Resolve<TPageModelType>();
            page.BindingContext = pageModel;
            return page;
        }
    }
}