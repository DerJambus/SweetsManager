using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SweetsManager.Service;
using SweetsManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetsManager.Pages;

namespace SweetsManager.Components
{
    public partial class EditChoclate
    {

        [Parameter]
        public bool ShowDialog { get; set; }

        [Parameter]
        public Choclate Choc { get; set; }

        [Parameter]
        public EventCallback<bool> ShowDialogChanged { get; set; }
        [Parameter]
        public EventCallback<Choclate> ChocChanged { get; set; }



        protected override void OnInitialized()
        {
            base.OnInitialized();
        }




        public void Close()
        {
            ShowDialog = !ShowDialog;
            ShowDialogChanged.InvokeAsync(ShowDialog);
        }

        public void HandleValidSubmit()
        {
            string bevor = Pages.Index.GetOldStatus();
            ChocChanged.InvokeAsync(Choc);
            string after = Choclate.ToString(Choc);
            string newStatus = bevor + " Wurde geändert zu: " + after;
            Close();
            if (bevor.Equals(after))
            {
                Pages.Index.PushSystemStatus(" ");
            }
            else
            {
                Pages.Index.PushSystemStatus(newStatus);
            }
        }
    }
}
