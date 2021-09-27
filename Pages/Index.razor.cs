using SweetsManager.Shared;
using SweetsManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SweetsManager.Pages
{
    public partial class Index
    {

        [Inject]
        public IChocService _service { get; set; }

        [Inject]
        private IJSRuntime _runTime { get; set; }

        public static string SysStatWas;
        public static string SysStat = "Just for Testing";
        public static bool _statChanged;
        public Choclate Choc;
        public bool _showDialog;
        public bool _showEditDialog;
        public List<Choclate> _choclates;
        public bool _nameASC;
        public bool _vendorASC;
        public bool _radeOfCacaoASC;
        public bool _isTooSweetASC;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _choclates = _service.GetChoclate();
        }

        public void AddChoclate()
        {
            _showDialog = !_showDialog;
        }

        public void EditChoclate(Choclate choc)
        {
            HoldSystemStatus(choc);
            Choc = choc;
            _showEditDialog = !_showEditDialog;
        }

        protected async Task DeleteAsync(Choclate choc)
        {
            if (!await _runTime.InvokeAsync<bool>("confirm", $"Sind Sie sicher, dass Sie {choc._name}-Schokolade löschen wollen?"))
            {
                return;
            }
            _choclates.Remove(choc);
            PushSystemStatus(Choclate.ToString(choc) + " " + "Wurde entfernt.");
        }

        public static void PushSystemStatus(string status)
        {
            SysStat = status;
        }

        public static void HoldSystemStatus(Choclate status)
        {
            SysStatWas = Choclate.ToString(status);
        }

        public static string GetOldStatus()
        {
            return SysStatWas;
        }

        public void Sort(int pivot)
        {
            switch (pivot)
            {
                case 1: _choclates = _choclates.OrderByDescending(choc => choc._name).ToList(); _nameASC = false; break;
                case 2: _choclates = _choclates.OrderByDescending(choc => choc._vendor).ToList(); _vendorASC = false; break;
                case 3: _choclates = _choclates.OrderByDescending(choc => choc._radeOfCacao).ToList(); _radeOfCacaoASC = false; break;
                case 4: _choclates = _choclates.OrderByDescending(choc => choc._isToSweet).ToList(); _isTooSweetASC = false; break;
                case 5: _choclates = _choclates.OrderBy(choc => choc._name).ToList(); _nameASC = true; break;
                case 6: _choclates = _choclates.OrderBy(choc => choc._vendor).ToList(); _vendorASC = true; break;
                case 7: _choclates = _choclates.OrderBy(choc => choc._radeOfCacao).ToList(); _radeOfCacaoASC = true; break;
                case 8: _choclates = _choclates.OrderBy(choc => choc._isToSweet).ToList(); _isTooSweetASC = true; break;
                default: return;
            }
        }


    }
}
