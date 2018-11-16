using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using ContactsForms.BusinessLogicLayer;

namespace ContactsForms {
    public partial class ContactsList : ContentPage {
        UserManager Model {
            get {
                return BindingContext as UserManager;
            }
            set {
                BindingContext = value;
                OnPropertyChanged();
            }
        }

        public ContactsList() {
            InitializeComponent();
            Model = new UserManager();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            var myItem = (sender as ListView).SelectedItem;
            Navigation.PushAsync(new ContactDetails(myItem as User));
        }
    }
}
