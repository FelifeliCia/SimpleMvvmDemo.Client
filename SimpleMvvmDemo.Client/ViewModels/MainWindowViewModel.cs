using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmDemo.Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
                
        }


        private string num1;

        public string Num1
        {
            get { return num1; }
            set { num1 = value; RaisePropertyChanged("Num1"); }
        }


        private string num2;

        public string Num2
        {
            get { return num2; }
            set { num2 = value; RaisePropertyChanged("Num2"); }
        }

        private string num3;

        public string Num3
        {
            get { return num3; }
            set { num3 = value; RaisePropertyChanged("Num3"); }
        }

        public DelegateCommand<object> DelegateCommand => new DelegateCommand<object>(Func);

        private void Func(object obj)
        {
            string func = (string)obj;
            if (func=="Add")
            {
                Num3 = (int.Parse(num1) + int.Parse(num2)).ToString();
            }
            else
            {

            }
        }
    }
}
