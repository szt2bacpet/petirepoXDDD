using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentProject.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentProject.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> _classType = new ObservableCollection<string>(new ClassType().classType);

        [ObservableProperty]
        private ObservableCollection<Utas> _utasok = new ObservableCollection<Utas>();

        [ObservableProperty]
        private Utas _selectedUtas;

        private string _selectedclassType = string.Empty;
        public string SelectedclassType
        {
            get => _selectedclassType;
            set
            {
                SetProperty(ref _selectedclassType, value);
                SelectedUtas.PlaceClassType = _selectedclassType;
            }
        }    

        public StudentViewModel()
        {
            Utasok.Add(new Utas("Test", "User", System.DateTime.Now, 9, EatFormat.Normal, "Turista osztály"));
            Utasok.Add(new Utas("Makán", "Péter", System.DateTime.Now, 10, EatFormat.Vegan, "Business osztály"));
            Utasok.Add(new Utas("Bácskai", "Péter", System.DateTime.Now, 11, EatFormat.Normal, "Turista osztály"));
            SelectedUtas = new Utas();
            SelectedclassType = _classType.ElementAt(0);
        }

        [RelayCommand]
        public void DoSave(Utas newStudent)
        {
            Utasok.Add(newStudent);
            OnPropertyChanged(nameof(Utasok));
        }

        [RelayCommand]
        void DoNewStudent()
        {
            SelectedUtas = new Utas();
        }

        [RelayCommand]
        public void DoRemove(Utas studentToDelete)
        {
            Utasok.Remove(studentToDelete);
            OnPropertyChanged(nameof(Utasok));
        }
    }
}
