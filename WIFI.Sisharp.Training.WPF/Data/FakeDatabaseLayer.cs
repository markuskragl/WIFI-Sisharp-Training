using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIFI.Sisharp.Training.WPF.Model;
using WIFI.Sisharp.Training.WPF.ServiceReference1;

namespace WIFI.Sisharp.Training.WPF.Data 
{
    class FakeDatabaseLayer : IService1
    {

        public static ObservableCollection<Person> GetPeopleFromDatabase()
        {
            //Simulate database extaction
            //For example from ADO DataSets or EF
            return new ObservableCollection<Person>
            {
                new Person { FirstName="Tom", LastName="Jones", Age=80 },
                new Person { FirstName="Dick", LastName="Tracey", Age=40 },
                new Person { FirstName="Harry", LastName="Hill", Age=60 },
            };
        }



        public string GetData(int value)
        {
            return value.ToString();
        }

        public Task<string> GetDataAsync(int value)
        {
            return System.Threading.Tasks.Task<string>.Run(() => this.ToString());
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite)
        {
            throw new NotImplementedException();
        }
    }
}
