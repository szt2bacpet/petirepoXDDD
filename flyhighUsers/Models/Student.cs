using System;

namespace StudentProject.Models
{
    public enum EatFormat { Normal, Vegan}

    public class Utas
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public int Sorszam { get; set; }
        public EatFormat PlanClass { get; set; }
        public string PlaceClassType { get; set; }

        public Utas(string firstName, string lastName, DateTime birthsDay, int sorszam, EatFormat schoolClass, string classType)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Sorszam = sorszam;
            PlanClass = schoolClass;
            PlaceClassType = classType;
        }

        public Utas()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Sorszam = 9;
            PlanClass = EatFormat.Normal;
            PlaceClassType = string.Empty;
        }

        public string HungarianFullName => $"{LastName} {FirstName}";
        public string HungarianBirthsDay => BirthsDay.ToString("yyyy.MM.dd.");
        public string HungarianLongBirthsDay => BirthsDay.ToString("yyyy.MM.dd. dddd");

        public string SchoolYearAndClass
        {
            get
            {
                string Sorszam = string.Empty;
                switch (PlanClass)
                {
                    case EatFormat.Normal: Sorszam = "sorszám"; break;
                    case EatFormat.Vegan: Sorszam = "sorszám"; break;
                }
                if (Sorszam != string.Empty)
                    return $"{this.Sorszam}.{Sorszam}";
                else
                    return $"{this.Sorszam} sorszám";
            }
        }

        public string AllProperty => $"{LastName} {FirstName} ({SchoolYearAndClass}) \n{HungarianBirthsDay}\n{PlaceClassType}";

        public override string ToString()
        {
            return AllProperty;
        }
    }
}
