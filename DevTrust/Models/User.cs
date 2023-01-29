using DevTrust.ViewModels.Base;
using System;
using static Bogus.DataSets.Name;


namespace DevTrust.Models
{
    public class User: ViewModelsBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public User() { }
    }

}
