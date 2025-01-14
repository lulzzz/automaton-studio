﻿using System;

namespace Automaton.Studio.Core
{
    public class ActivityEventArgs : EventArgs
    {
        public ActivityEventArgs(StudioActivity activity)
        {
            Activity = activity;
        }

        public StudioActivity Activity { get; set; }
    }
}