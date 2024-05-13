// MainWindow.xaml.cs
using System.Collections.Generic;
using System.Windows;

namespace WpfItemListApp
{
    public partial class MainWindow : Window
    {
        public List<Item> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Items = new List<Item>
            {
                new Item("Laptop", "A high-performance laptop with Intel i7 processor and 16GB RAM", 1200, "Electronics"),
                new Item("Smartphone", "The latest smartphone with a dual-camera setup and 128GB storage", 800, "Electronics"),
                new Item("Headphones", "Wireless noise-cancelling headphones with up to 30 hours of battery life", 250, "Electronics"),
                new Item("Running Shoes", "High-quality running shoes with breathable mesh and cushioned sole", 100, "Sports"),
                new Item("Gaming Mouse", "Ergonomic gaming mouse with customizable RGB lighting", 50, "Gaming"),
            };
            itemListBox.ItemsSource = Items;
        }

        private void itemListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedItem = itemListBox.SelectedItem as Item;
            if (selectedItem != null)
            {
                // Update UI with selected item details
            }
        }
    }
}
