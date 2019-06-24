using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using WIFI.Sisharp.Training.TreeView;
using System.Linq;
using System.Text;

namespace WIFI.Sisharp.Training.TreeView
{
    public class Data
    {
        public List<Family> probe()
        {
            List<Family> families = new List<Family>();

            Family family1 = new Family() { Name = "The Doe's" };
            family1.Members.Add(new FamilyMember() { Name = "John Doe", Age = 42 });
            family1.Members.Add(new FamilyMember() { Name = "Jane Doe", Age = 39 });
            family1.Members.Add(new FamilyMember() { Name = "Sammy Doe", Age = 13 });
            families.Add(family1);

            Family family2 = new Family() { Name = "The Moe's" };
            family2.Members.Add(new FamilyMember() { Name = "Mark Moe", Age = 31 });
            family2.Members.Add(new FamilyMember() { Name = "Norma Moe", Age = 28 });
            families.Add(family2);

            return families;
                                   
        }
    }
}
