using System;


namespace SweetsManager.Shared
{
    public class Choclate
    {
       public string _name { get; set; }
       public string _vendor { get; set; }
       public bool _isToSweet { get; set; }
       public int _radeOfCacao { get; set; }

        // das das eine static Methode ist ein schweres Verbrechen aber ohne Konstruktor geht es nicht anders.
       public static string ToString(Choclate choc)
        {

            string result = "";
            result += choc._name + " " + choc._vendor + " " + choc._isToSweet + " " + choc._radeOfCacao;
            return result;
        }
    }
}
