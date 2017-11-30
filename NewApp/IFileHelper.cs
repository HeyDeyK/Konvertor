using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp
{
    interface IFileHelper
    {
        string FormatCollectionToString(List<Produkt> input);
        List<Produkt> FormatStringToCollection(string input);
    }
}
