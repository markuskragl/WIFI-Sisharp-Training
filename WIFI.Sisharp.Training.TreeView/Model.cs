using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WIFI.Sisharp.Training.TreeView
{





    public class Family
    {
        public Family()
        {
            this.Members = new ObservableCollection<FamilyMember>();
        }

        public string Name { get; set; }

        public ObservableCollection<FamilyMember> Members { get; set; }
    }

    public class FamilyMember
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

}
