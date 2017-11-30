using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace NewApp
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string userInput = "";
        List<Produkt> seznam = new List<Produkt>();
        public MainWindow()
        {
            InitializeComponent();
            List<int> data = new List<int>();
            
            seznam.Add(new Produkt("tramvaj", 2000));
            seznam.Add(new Produkt("helikoptéra", 5819));

            

            string ctu = File.ReadAllText("text.json");

            //Produkt produkt = JsonConvert.DeserializeObject<Produkt>(ctu);

            foreach (var Auta in seznam)
            {
                string cusxml = Auta.ToString();
                var xmlwriter = new System.IO.StringWriter();
                var xmlserializer = new XmlSerializer(cusxml.GetType());
                xmlserializer.Serialize(xmlwriter, cusxml);
                System.IO.File.AppendAllText( "text.xml", xmlwriter.ToString());
            }
            
            
            //fileHelper.FormatCollectionToString(data);
            //fileHelper.FormatStringToCollection("string ve spravnem formatu");
        }
        public void Vyber()
        {
            JsonHelper jsonHelper = new JsonHelper();
            CsvHelper csvHelper = new CsvHelper();
            XmlHelper xmlHelper = new XmlHelper();

            IFileHelper fileHelper = new JsonHelper();
            if (userInput.Equals(".json"))
            {
                fileHelper = new JsonHelper();

            }
            else if (userInput.Equals(".csv"))
            {
                fileHelper = new CsvHelper();
            }
            else if (userInput.Equals(".xml"))
            {
                fileHelper = new XmlHelper();
            }

            File.WriteAllText("data.txt", fileHelper.FormatCollectionToString(seznam));
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            userInput = ".json";
            Vyber();
        }
    }
}
