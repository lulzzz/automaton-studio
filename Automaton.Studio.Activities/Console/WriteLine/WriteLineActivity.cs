﻿using Automaton.Studio.Activity;
using Automaton.Studio.Activity.Metadata;
using Elsa.Models;
using System;
using System.Collections.Generic;

namespace Automaton.Studio.Activities.Console.WriteLine
{
    [StudioActivity(
        Name = "WriteLineActivity",
        DisplayName = "Write Line",
        ElsaName = "WriteLine",
        Category = "Console",
        Description = "Write text to console",
        Icon = "field-string"
    )]
    public class WriteLineActivity : StudioActivity
    {
        private ActivityDefinitionProperty TextProperty => GetProperty(nameof(Text));
        public string Text
        {
            get
            {
                return TextProperty.Expressions[TextProperty.Syntax];
            }
            set
            {
                TextProperty.Expressions[TextProperty.Syntax] = value;
                OnPropertyChanged();
            }
        }

        public WriteLineActivity(IActivityTypeDescriber activityDescriber) 
            : base(activityDescriber)
        {
            Name = "WriteLineActivity";
            Type = "WriteLine";

            Properties = new List<ActivityDefinitionProperty>
            {
                ActivityDefinitionProperty.Liquid(nameof(Text), string.Empty)
            };
        }

        public override Type GetDesignerComponent()
        {
            return typeof(WriteLineDesigner);
        }

        public override Type GetPropertiesComponent()
        {
            return typeof(WriteLineProperties);
        }
    }
}
