﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoryWriter.PageModels.Base;

namespace StoryWriter.PageModels
{
    public class DashboardPageModel : PageModelBase
    {

        private SummaryPageModel _summaryPM;
        public SummaryPageModel SummaryPageModel
        {
            get => _summaryPM;
            set => SetProperty(ref _summaryPM, value);
        }

        private ProfilePageModel _profilePM;
        public ProfilePageModel ProfilePageModel
        {
            get => _profilePM;
            set => SetProperty(ref _profilePM, value);
        }

        private SettingsPageModel _settigsPM;
        public SettingsPageModel SettingsPageModel
        {
            get => _settigsPM;
            set => SetProperty(ref _settigsPM, value);
        }

        private TimeClockPageModel _timeclockPM;
        public TimeClockPageModel TimeClockPageModel
        {
            get => _timeclockPM;
            set => SetProperty(ref _timeclockPM, value);
        }

        public DashboardPageModel(
            ProfilePageModel profilePM,
            SettingsPageModel settingsPM,
            SummaryPageModel summaryPM,
            TimeClockPageModel timeClockPM
            )
        {
            ProfilePageModel = profilePM;
            SettingsPageModel = settingsPM;
            SummaryPageModel = summaryPM;
            TimeClockPageModel = timeClockPM;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(
                base.InitializeAsync(navigationData),
                ProfilePageModel.InitializeAsync(null),
                SettingsPageModel.InitializeAsync(null),
                SummaryPageModel.InitializeAsync(null),
                TimeClockPageModel.InitializeAsync(null));

            return base.InitializeAsync(navigationData);
        }
    }
}