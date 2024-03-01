using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_E_shop
{
    public partial class ShoppingCartWindow : Window
    {
        public ObservableCollection<Product> ShoppingCart { get; set; }
        private List<Product> shoppingCart = new List<Product>();
        Kasse kasse = new Kasse();
       
        public ShoppingCartWindow()
        {
            InitializeComponent();
            UpdateCartView();
        }

        public void AddToCart(Product product)
        {
            shoppingCart.Add(product);
            UpdateCartView();
        }

        public void RemoveFromCart(Product product)
        {
            shoppingCart.Remove(product);
            UpdateCartView();
        }

        private void UpdateCartView()
        {
            if (shoppingCart.Count > 0)
            {
                cartListView.ItemsSource = shoppingCart;
                emptyCartTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                cartListView.ItemsSource = null;
                emptyCartTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void RemoveFromCartButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Product product = btn.DataContext as Product;
                if (product != null)
                {
                    RemoveFromCart(product);
                }
            }
        }

        private void BackToProductListingButton_Click(object sender, RoutedEventArgs e)
        {
            ProductListingWindow productListingWindow = new ProductListingWindow();
            productListingWindow.Show();
            Hide();
        }

        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            shoppingCart.Clear();
            UpdateCartView();
        }

        private void ProceedToCheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            kasse.Show();
            Close();
        }

        public void intoShoppingcart(Product prod) {
            shoppingCart.Add(prod);
            UpdateCartView();
        }
    }
}
