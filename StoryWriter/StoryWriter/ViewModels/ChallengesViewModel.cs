using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryWriter.ViewModels
{

    public  class ChallengesViewModel :BaseViewModel
    {

        int selectedCategoryIndex;

        public ChallengesViewModel()
        {
            SelectedCategoryCommand = new Command<string>(OnSelectCategory);
        }

        public int SelectedCategoryIndex
        {
            get => selectedCategoryIndex;
            set => SetProperty(ref selectedCategoryIndex, value);
        }

        public Command<string> SelectedCategoryCommand { get; }

        void OnSelectCategory(string index)
        {
            if(int.TryParse(index, out int i))
            {
                SelectedCategoryIndex = i;
            }
        }
    }
}
