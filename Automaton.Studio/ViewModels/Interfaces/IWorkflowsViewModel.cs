﻿using Automaton.Studio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automaton.Studio.ViewModels
{
    public interface IWorkflowsViewModel
    {
        IEnumerable<StudioWorkflow> Workflows { get; set; }
        IEnumerable<WorkflowRunner> Runners { get; set; }
        WorkflowNew NewWorkflowDetails { get; set; }

        Task Initialize();
        Task NewWorkflow();
        Task RunWorkflow(StudioWorkflow workflow);
    }
}
