using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitanicPop.Domain.Entities
{
    public class Passenger
    {
        public string PassengerId { get; set; }
        public bool Survived { get; set; }
        public int Pclass { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string SibSp { get; set; }
        public string Parch { get; set; }
        public string Ticket { get; set; }
        public string Fare { get; set; }
        public string Cabin { get; set; }
        public string Embarked { get; set; }
    }
}
