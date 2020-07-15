using Altkom.WPFMVVM.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.WPFMVVM.ViewModels
{
    public class ActionsViewModel : BaseViewModel
    {
        public IEnumerable<Models.Action> Actions { get; set; }

        private readonly IActionService actionService;

        public ActionsViewModel(IActionService actionService)
        {
            this.actionService = actionService;

            Load();
        }

        private void Load()
        {
            Actions = actionService.Get();
        }
    }
}
