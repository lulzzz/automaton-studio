﻿using Elsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Automaton.Studio.Activity
{
    /// <summary>
    /// A base class for all activity instances
    /// </summary>
    public abstract class StudioActivity
    {
        #region Elsa Activity properties

        public string ActivityId { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public ICollection<ActivityDefinitionProperty>? Properties { get; set; }

        #endregion

        public StudioActivity()
        {
            ActivityId = Guid.NewGuid().ToString();
            Properties = new List<ActivityDefinitionProperty>();
        }

        protected ActivityDefinitionProperty GetDefinitionProperty(string propertyName)
        {
            return Properties?.SingleOrDefault(x => x.Name == propertyName);
        }

        #region Abstracts

        /// <summary>
        /// Model associated with activity
        /// </summary>
        public abstract IStudioActivityModel Model { get; set; }

        /// <summary>
        /// Abstract method to get the view component type to use
        /// </summary>
        /// <returns></returns>
        public abstract Type GetViewComponent();

        /// <summary>
        /// Abstract method to get the properties component type to use
        /// </summary>
        /// <returns></returns>
        public abstract Type GetPropertiesComponent();

        /// <summary>
        /// Abstract method to get the model type associated with the activity
        /// </summary>
        /// <returns></returns>
        public abstract Type GetModelType();

        #endregion
    }
}
