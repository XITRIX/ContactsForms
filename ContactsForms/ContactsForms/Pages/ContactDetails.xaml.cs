using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsForms {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage {
        public User Model {
            get {
                return BindingContext as User;
            }
            set {
                BindingContext = value;
                OnPropertyChanged();
            }
        }

        public ContactDetails(User user) {
            InitializeComponent();
            Model = user;
        }
    }
}