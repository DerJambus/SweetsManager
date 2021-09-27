using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using SweetsManager.Service;
using SweetsManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetsManager.Components
{
    public partial class AddChoclate
    {
        [Inject]
        public IChocService _service { get; set; }
        [Parameter]
        public bool ShowDialog { get; set; }
        [Parameter]
        public List<Choclate> ChoclateList { get; set; }
        [Parameter]
        public EventCallback<bool> ShowDialogChanged { get; set; }
        [Parameter]
        public EventCallback<List<Choclate>> ChoclateListChanged { get; set; }

        public Choclate Choclate { get; set; } = new Choclate();

        public void Reset()
        {
            Choclate = new Choclate { };
        }

        public void Show()
        {
            Reset();
        }

        public void Close()
        {
            ShowDialog = !ShowDialog;
            ShowDialogChanged.InvokeAsync(ShowDialog);
        }

        public void HandleValidSubmit()
        {
            ChoclateList.Add(Choclate);
            ChoclateListChanged.InvokeAsync(ChoclateList);
            Reset();
            Close();
            Pages.Index.PushSystemStatus(" ");
        }
    }
}
