using E_shop_Wpf_;
using System.Collections.ObjectModel;
using System.Windows;

namespace Wpf_E_shop
{
    public partial class ProductListingWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public List<Product> shoppingCart = new List<Product>();
        ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow();

        public ProductListingWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Title = "Produkt 1", Description = "Beschreibung 1", Price = 10.99 },
                new Product { Title = "Produkt 2", Description = "Beschreibung 2", Price = 15.49 },
                new Product { Title = "Produkt 3", Description = "Beschreibung 3", Price = 20.99 }
            };

            productsListView.ItemsSource = Products;
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (productsListView.SelectedItem != null)
            {
                Product selectedProduct = (Product)productsListView.SelectedItem;
                shoppingCart.Add(selectedProduct);

                MessageBox.Show($"Produkt '{selectedProduct.Title}' wurde zum Warenkorb hinzugefügt.");
                foreach (Product prod in shoppingCart)
                {
                    shoppingCartWindow.intoShoppingcart(prod);
                }
                shoppingCartWindow.Show();
                Hide();
                
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Produkt aus, das zum Warenkorb hinzugefügt werden soll.");
            }
        }

        private void ViewCartButton_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow();

            foreach (Product prod in shoppingCart)
            {
                shoppingCartWindow.intoShoppingcart(prod);
            }
            shoppingCartWindow.Show();
            Close();
        }
    }

    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}