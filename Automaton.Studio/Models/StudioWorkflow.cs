﻿using Automaton.Studio.Activity;
using Elsa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Automaton.Studio.Models
{
    public class StudioWorkflow : INotifyPropertyChanged
    {
        #region Elsa properties

        // Observation:
        // Replaced Elsa Activities with own Studio Activities
        // which are easily mapped to each other

        public string? Tag { get; set; }
        public bool IsLatest { get; set; }
        public bool IsPublished { get; set; }
        public bool DeleteCompletedInstances { get; set; }
        public WorkflowPersistenceBehavior PersistenceBehavior { get; set; }
        public bool IsSingleton { get; set; }
        public WorkflowContextOptions? ContextOptions { get; set; }
        public Variables CustomAttributes { get; set; }
        public int Version { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Name { get; set; }
        public string? TenantId { get; set; }
        public string VersionId { get; }
        public string DefinitionId { get; set; }
        public Variables Variables { get; set; }
        public ICollection<ConnectionDefinition> Connections { get; set; }

        #endregion

        #region Public Properties

        private IList<StudioActivity>? activities = new List<StudioActivity>();
        public IList<StudioActivity> Activities
        {
            get => activities;

            set
            {
                activities = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public StudioWorkflow()
        {
            Name = "Untitled";
            DisplayName = "Untitled";
            Version = 1;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
