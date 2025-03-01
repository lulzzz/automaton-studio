﻿using AntDesign;
using Automaton.Studio.Components;
using Automaton.Studio.Models;
using Automaton.Studio.Resources;
using Automaton.Studio.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Automaton.Studio.Pages
{
    partial class Workflows : ComponentBase
    {
        [Inject] 
        private NavigationManager NavigationManager { get; set; } = default!;
        [Inject] 
        private IWorkflowsViewModel WorkflowsViewModel { get; set; } = default!;
        [Inject] 
        ModalService ModalService { get; set; } = default!;

        private Table<WorkflowInfo> workflowsTable;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await WorkflowsViewModel.Initialize();
        }

        private async Task RunWorkflow(WorkflowInfo workflow)
        {
            await WorkflowsViewModel.RunWorkflow(workflow);
        }

        private void EditWorkflow(WorkflowInfo workflow)
        {
            NavigationManager.NavigateTo($"designer/{workflow.DefinitionId}");
        }

        private async Task DeleteWorkflow(WorkflowInfo workflow)
        {
            await WorkflowsViewModel.DeleteWorkflow(workflow);
            //StateHasChanged();
        }

        private async Task ShowNewWorkflowDialog()
        {
            var modalConfig = new ModalOptions
            {
                Title = Labels.NewWorkflowTitle,
                // Needed as a workaround to prevent dialog
                // close imediatelly when clicking OK button
                MaskClosable = false
            };

            var modalRef = await ModalService.CreateModalAsync<WorkflowNew, NewWorkflow>(modalConfig, WorkflowsViewModel.NewWorkflowDetails);

            modalRef.OnOk = async () =>
            {
                // Needed to update OK button loading icon
                modalRef.Config.ConfirmLoading = true;
                await modalRef.UpdateConfigAsync();

                var workflow = await WorkflowsViewModel.NewWorkflow();

                NavigationManager.NavigateTo($"designer/{workflow.DefinitionId}");
            };
        }
    }
}
