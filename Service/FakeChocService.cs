using SweetsManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetsManager.Service
{
    public class FakeChocService : IChocService
    {
        public List<Choclate> GetChoclate()
        {

            List<Choclate> result = new List<Choclate>
            {
                new Choclate{_name="Milka Superkrass Extrazucker", _vendor="Milka Inc.", _radeOfCacao = 80, _isToSweet = true },
                new Choclate{_name="Vegan Weltretter", _vendor="666 KG", _radeOfCacao = 4, _isToSweet = false },
                new Choclate{_name="Apfelkirschtraum Diabetis", _vendor="Super Evil & Co KG", _radeOfCacao=0, _isToSweet= true},
                new Choclate {_name="Zimtversuchung", _vendor="Tante Emma Läden Kollektiv", _radeOfCacao=80, _isToSweet= false}
            };
            return result;
        }
    }
}
