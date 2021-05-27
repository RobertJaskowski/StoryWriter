using StoryWriter.Models;
using StoryWriter.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoryWriter.PageModels.StoriesPage
{
    public class MyStoriesPageModel : PageModelBase
    {
        private ObservableCollection<Story> _myStoriesList;

        public ObservableCollection<Story> MyStoriesList
        {
            get
            {
                if (_myStoriesList == null)
                {
                    _myStoriesList = new ObservableCollection<Story>();
                    //_storiesList.Add(new Story("test1"));
                }

                return _myStoriesList;
            }
            set
            {
                SetProperty(ref _myStoriesList, value);
            }
        }

        public ICommand ItemTapCommand { get; }

        public StoriesPageModel Root { get; }

        public MyStoriesPageModel(StoriesPageModel root)
        {
            Root = root;

            ItemTapCommand = new Command(OnItemTap);
        }

        private void OnItemTap(object obj)
        {
            if (obj is Story)
            {
            }
        }
    }
}