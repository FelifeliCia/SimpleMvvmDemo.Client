using Prism.Commands;
using Prism.Mvvm;
using SimpleMvvmDemo.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SimpleMvvmDemo.Client.ViewModels
{
    public class MenuPageViewModel : BindableBase
    {
        public MenuPageViewModel()
        {
           ReadXml();
        }


        private List<Food> foods;

        public List<Food> Foods
        {
            get { return foods; }
            set { foods = value; RaisePropertyChanged("Foods"); }
        }


        private List<string> foodClassification;

        public List<string> FoodClassification
        {
            get { return foodClassification; }
            set { foodClassification = value; RaisePropertyChanged("FoodClassification"); }
        }


        //public DelegateCommand delegateCommand => new DelegateCommand(ReadXml);

        public async void ReadXml()
        {
            await Task.Run(() =>
                {
                    try
            {
                Console.WriteLine("test");

                XElement xmlElement = XElement.Load(@"..\..\DishesClassification.xml");
                IEnumerable<XElement> foodsXElement = from ele in xmlElement.Elements("food") select ele;

                List<Food> foodsList = new List<Food>();
                List<string> classification = new List<string>();
                foreach (var item in foodsXElement)
                {
                    Food food1 = new Food();
                    food1.Name = item.Element("name").Value;
                    food1.Number = int.Parse(item.Element("number").Value);
                    food1.Classification = item.Element("classname").Value;
                    string class1 = classification.Find((string m) => m == food1.Classification);
                    if (string.IsNullOrEmpty(class1))
                    {
                        classification.Add(food1.Classification);
                    }
                    foodsList.Add(food1);
                }
                FoodClassification = new List<string>(classification);
                Foods = new List<Food>(foodsList);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
                });
        }
    }
}
