﻿using Automaton.Studio.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Automaton.Studio.ViewModels
{
    public interface ITreeActivityViewModel
    {
        #region Events

        event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        IList<ActivityTreeModel> TreeItems { get; set; }
        ActivityTreeModel SelectedActivity { get; set; }

        #endregion

        #region Methods

        Task Initialize();
        void DragActivity(ActivityTreeModel activityModel);

        #endregion
    }
}
