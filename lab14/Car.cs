using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Car:INotifyPropertyChanged
    {
        private string _model;
        private int _maxSpeed;
        private double _discount;
        private decimal _price;
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
        public double Discount { get { return _discount; }
        set { _discount = value; 
                OnPropertyChanged("Discount");
                OnPropertyChanged("PriceWithDiscount");
            }
        }
        public int MaxSpeed { 
            get { return _maxSpeed; }
        set { 
                _maxSpeed = value; 
                OnPropertyChanged("MaxSpeed"); 
            }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("PriceWithDiscount");
            }
        }
        public decimal PriceWithDiscount
        {
            get { return Price * (decimal)(1 - Discount);  }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
