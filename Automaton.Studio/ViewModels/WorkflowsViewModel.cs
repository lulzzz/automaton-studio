﻿using AntDesign;
using AutoMapper;
using Automaton.Studio.Hubs;
using Automaton.Studio.Models;
using Automaton.Studio.Resources;
using Automaton.Studio.Services;
using Elsa.Models;
using Elsa.Persistence;
using Elsa.Persistence.Specifications;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Automaton.Studio.ViewModels
{
    public class WorkflowsViewModel : IWorkflowsViewModel, INotifyPropertyChanged
    {
        #region Members

        private readonly IWorkflowDefinitionStore workflowDefinitionStore;
        private readonly IRunnerService runnerService;
        private readonly MessageService messageService;
        private readonly IMapper mapper;

        #endregion

        #region Properties

        private IEnumerable<WorkflowInfo> workflows;
        public IEnumerable<WorkflowInfo> Workflows
        {
            get => workflows;

            set
            {
                workflows = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<WorkflowRunner> runners;
        public IEnumerable<WorkflowRunner> Runners
        {
            get => runners;

            set
            {
                runners = value;
                OnPropertyChanged();
            }
        }

        public WorkflowNew NewWorkflowDetails { get; set; } = new WorkflowNew();

        #endregion

        public WorkflowsViewModel
        (
            IRunnerService runnerService,
            IWorkflowDefinitionStore workflowDefinitionStore,
            MessageService messageService,
            IMapper mapper
        )
        {
            this.runnerService = runnerService;
            this.messageService = messageService;
            this.mapper = mapper;
            this.workflowDefinitionStore = workflowDefinitionStore;
        }

        public async Task Initialize()
        {
            var workflowDefinitions = await workflowDefinitionStore.FindManyAsync(Specification<WorkflowDefinition>.Identity);
            Workflows = mapper.Map<IEnumerable<WorkflowDefinition>, IEnumerable<WorkflowInfo>>(workflowDefinitions);     
            Runners = mapper.Map<IQueryable<Runner>, IEnumerable<WorkflowRunner>>(runnerService.List());
        }

        public async Task RunWorkflow(WorkflowInfo workflow)
        {
            await runnerService.RunWorkflow(workflow.DefinitionId, workflow.RunnerIds);
        }

        public async Task<WorkflowDefinition> NewWorkflow()
        {
            try
            {
                var workflowDefinition = mapper.Map<WorkflowNew, WorkflowDefinition>(NewWorkflowDetails);

                await workflowDefinitionStore.AddAsync(workflowDefinition);

                return workflowDefinition;
            }
            catch
            {
                await messageService.Error(Errors.NewWorkflowError);
                throw;
            }
            finally
            {
                ClearNewWorkflowDetails();
            }
        }

        private void ClearNewWorkflowDetails()
        {
            NewWorkflowDetails = new WorkflowNew();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
