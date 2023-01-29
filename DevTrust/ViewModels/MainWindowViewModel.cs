using Bogus.DataSets;
using DevTrust.Data;
using DevTrust.Models;
using DevTrust.ViewModels.Base;
using DevTrust.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace DevTrust.ViewModels
{
    public class MainWindowViewModel : ViewModelsBase
    {
        public ObservableCollection<User> Users { get; set; }


        public MainWindowViewModel(IFakeUser fakeUser)
        {
            Users = new ObservableCollection<User>(fakeUser.GenerateUsers());
  
        }

        private bool selectedItem;
        public bool SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public Visibility HaveSelectedItems 
        {
            get{ if (GetSelectedUsers().Count == 0) return Visibility.Collapsed;
                else return Visibility.Visible;
               }

        }
        private RelayCommand _exportToTxtCommand;
        public RelayCommand ExportToTxtCommand
        {
            get
            {
                string path = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,"Result/result.txt"));
                return _exportToTxtCommand ??
                   (_exportToTxtCommand = new RelayCommand(obj =>
                   {
                       File.WriteAllText(path, String.Empty);
                       using (StreamWriter tw = File.AppendText(path))
                       {
                           foreach (var user in GetSelectedUsers())
                           {
                               tw.Write($"Id :{user.Id} , " +
                                   $"FirstName : {user.FirstName} , " +
                                   $"LastName : {user.LastName} , " +
                                   $"UserName : {user.UserName} , " +
                                   $"Email : {user.Email} , " +
                                   $"Gender : {user.Gender}");
                               tw.WriteLine();
                           }
                       }
                   }));
            }
        }

        private RelayCommand _exportToCsvCommand;
        public RelayCommand ExportToCsvCommand
        {
            get
            {
                string path = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Result/result.csv"));
                return _exportToCsvCommand ??
                  (_exportToCsvCommand = new RelayCommand(obj =>
                  {
                      File.WriteAllText(path, String.Empty);
                      using (StreamWriter tw = File.AppendText(path))
                      {
                          foreach (var user in GetSelectedUsers())
                          {
                              tw.Write($"{user.Id},{user.FirstName},{user.LastName},{user.UserName},{user.Email},{user.Gender}");
                              tw.WriteLine("");
                          }
                      }
                  }));
            }
        }

        private List<User> GetSelectedUsers()
        {
            var selectedUsers = Users.Where(u => u.IsSelected).ToList();

            return selectedUsers;
        }
    }
}
