using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using Newtonsoft.Json;

namespace NewApp
{
    class JsonHelper : IFileHelper
    {
        public string FormatCollectionToString(List<Produkt> input)
        {
            return JsonConvert.SerializeObject(input);
        }

        public List<Produkt> FormatStringToCollection(string input)
        {
            return JsonConvert.DeserializeObject<List<Produkt>>(input);
        }
    }
}
