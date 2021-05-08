﻿using Automaton.Studio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automaton.Studio.ViewModels
{
    public interface IWorkflowsViewModel
    {
        IEnumerable<WorkflowModel> Workflows { get; set; }
        IEnumerable<RunnerModel> Runners { get; set; }
        NewWorkflowModel NewWorkflowDetails { get; set; }

        Task Initialize();
        Task NewWorkflow();
        Task RunWorkflow(WorkflowModel workflow);
    }
}
