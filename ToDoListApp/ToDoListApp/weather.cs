using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoListApp
{
    internal class weather
    {
        static string havaTip;
        public string derece(string sehir, string connection)
        {
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return temp;

        }

        public string havatipi(string sehir, string connection)
        {
            XDocument weather = XDocument.Load(connection);
            var temp2 = weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            havaTip = temp2;
            return temp2.ToUpper();
        }

        // resim ekleme kaldı resimleri kırpıp ayarlamak
        public Image resimDondur(string sehir, string connection)
        {
            Image img = null;
            switch (havaTip)
            {
                case "açık":
                    img = ToDoListApp.Properties.Resources.havaGunesli;
                    break;

                case "kapalı":
                    img = ToDoListApp.Properties.Resources.havaBulutlu;
                    break;

                case "bulutlar":
                    img = ToDoListApp.Properties.Resources.havaBulutlu;
                    break;

                case "dağınık bulutlar":
                    img = ToDoListApp.Properties.Resources.havaParcaliBulutlu;
                    break;

                case "kırık bulutlar":
                    img = ToDoListApp.Properties.Resources.havaParcaliBulutlu;
                    break;

                case "az bulutlu":
                    img = ToDoListApp.Properties.Resources.havaBulutlu;
                    break;

                case "parçalı az bulutlu":
                    img = ToDoListApp.Properties.Resources.havaParcaliBulutlu;
                    break;

                case "parçalı bulutlu":
                    img = ToDoListApp.Properties.Resources.havaParcaliBulutlu;
                    break;

                case "parçalı çok bulutlu":
                    img = ToDoListApp.Properties.Resources.havaParcaliBulutlu;
                    break;

                case "yağmurlu":
                    img = ToDoListApp.Properties.Resources.havaYagmurlu;
                    break;

                case "fırtınalı":
                    img = ToDoListApp.Properties.Resources.havaFirtina;
                    break;

                case "karlı":
                    img = ToDoListApp.Properties.Resources.havaKarli;
                    break;

                case "sisli":
                    img = ToDoListApp.Properties.Resources.havaSisli;
                    break;

            }

            return img;
        }
    }
}
