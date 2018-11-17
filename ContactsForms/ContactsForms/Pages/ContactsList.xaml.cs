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

        Action<Exception> modelExceptionHandler;

        public ContactsList() {
            InitializeComponent();

            modelExceptionHandler = async (e) => {
                if (e != null) {
                    await DisplayAlert("Ошибка", "Произошла ошибка при загрузке базы данных", "Повторить");
                    Model = new UserManager(modelExceptionHandler);
                }
            };

            Model = new UserManager(modelExceptionHandler);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {
            var myItem = (sender as ListView).SelectedItem;
            Navigation.PushAsync(new ContactDetails(myItem as User));
        }
    }
}
