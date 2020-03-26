using KoffieMachineDomain.Decorators;
using KoffieMachineDomain.Drinks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class FileHandler
    {
        private JObject _file;

        public FileHandler()
        {
            // TODO: TURN ON FOR BACKUP
            //using (StreamReader sr = new StreamReader("configuration-backup.json"))
            using (StreamReader sr = new StreamReader("configuration.json"))
            {
                _file = JObject.Parse(sr.ReadToEnd());
            }
        }

        public IDrink GetBaseDrink(string name)
        {
            IDrink sd;
            IList<JToken> results = _file["drinks"].ToList();
            foreach (JToken result in results)
            {
                if (result["Name"].ToString().Equals(name))
                {
                    string drinkName = result["Name"].ToString();
                    List<string> ing = new List<string>();
                    double price = Double.Parse(result["Price"].ToString());

                    foreach (JToken drink in result["Ingredients"])
                    {
                        ing.Add(drink.ToString());
                    }

                    sd = new SpecialDrink(drinkName, ing, price);

                    // TODO: TURN ON FOR BACKUP
                    //foreach (JToken topping in result["Toppings"])
                    //{
                    //    sd = new SpecialToppingDecorator(sd, topping.ToString());
                    //}

                    return sd;
                }
            }
            return null;
        }
    }
}
