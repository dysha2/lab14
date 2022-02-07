using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace lab14
{
    public class CarViewModel:INotifyPropertyChanged
    {
        private Car _selectedCar;
        public ObservableCollection<Car> Cars { get; set; }
        public CarViewModel()
        {
            using (FileStream fs = new FileStream("cars.json", FileMode.Open))
            {
                try
                {
                    Cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(fs);
                } catch { Cars=new ObservableCollection<Car> { }; }
            }
        }
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }
        public void AddCar()
        {
            Car car = new Car();
            Cars.Insert(0, car);
            SelectedCar = car;
            
        }
        public void DeleteCar()
        {
            if (_selectedCar != null)
            {
                Cars.Remove(SelectedCar);
            }
        }
        public void RefreshSource()
        {
            using (FileStream fs = new FileStream("cars.json", FileMode.Create))
            {
                JsonSerializer.Serialize<ObservableCollection<Car>>(fs, Cars);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
