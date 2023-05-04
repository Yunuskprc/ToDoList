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

        /// <summary>
        /// Çekilen veriden derece değerini geri döndürür
        /// </summary>
        /// <param name="sehir">Sorgusu yapılacak sehir adı</param>
        /// <param name="connection">API adresi</param>
        /// <returns>Derece Değerini string olarak geri döndürür</returns>
        public string Derece(string sehir, string connection)
        {
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return temp;

        }

        /// <summary>
        /// Çekilen veriden hava tipi değerini geri döndürür
        /// </summary>
        /// <param name="sehir">Sorgusu yapılacak sehir adı</param>
        /// <param name="connection">API adresi</param>
        /// <returns>Hava tipini string olarak geri döndürür</returns>
        public string HavaTipi(string sehir, string connection)
        {
            XDocument weather = XDocument.Load(connection);
            var temp2 = weather.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            havaTip = temp2;
            return temp2.ToUpper();
        }

        /// <summary>
        /// Hava tipine göre geriye resim döndürür.
        /// </summary>
        /// <param name="sehir">Sorgusu yapılacak sehir adı</param>
        /// <param name="connection">API adresi</param>
        /// <returns></returns>
        public Image HavaTipiResmiDondur(string sehir, string connection)
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
