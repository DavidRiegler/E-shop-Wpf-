using E_shop_Wpf_;
using System.Diagnostics.Eventing.Reader;
using System.Windows;

namespace Wpf_E_shop
{
    public partial class MainWindow : Window
    {
        int anmeldeVeruche = 0;
        private List<User> users = new List<User>();

        private User user1 = new User("Batman", "Jack", "1234");
        private User user2 = new User("Ironman", "Tony", "4321");

        public MainWindow()
        {
            InitializeComponent();
            AddPersonenToArray();
        }

        public void AddPersonenToArray() {
            users.Add(user1);
            users.Add(user2);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredFirstName = firstNameTextBox.Text;
            string enteredLastName = lastNameTextBox.Text;
            string enteredPassword = passwordBox.Password;

            bool gefunden = AuthenticateUser(enteredFirstName, enteredLastName, enteredPassword);

            

            if (gefunden == true)
            {
                MessageBox.Show($"Willkommen, {enteredFirstName} {enteredLastName}!", "Anmeldung erfolgreich", MessageBoxButton.OK, MessageBoxImage.Information);
                ProductListingWindow productListingWindow = new ProductListingWindow();
                productListingWindow.Show();
                Close();
            }
            else if (anmeldeVeruche == 3)
            {
                MessageBox.Show("Keine Anmeldeversuche mehr :(", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            else
            {
                anmeldeVeruche++;
                MessageBox.Show("Falsche Anmeldeinformationen. Versuchen Sie es erneut.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool AuthenticateUser(string vorname, string nachname, string password)
        {
            foreach (User user in users)
            {
                if (user.Vorname == vorname && user.Nachname == nachname && user.password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
