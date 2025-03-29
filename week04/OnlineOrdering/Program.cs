using System;

class Program
{
    static void Main(string[] args)
    {
         // Create some products
            Product product1 = new Product("Laptop", "P1001", 999.99, 1);
            Product product2 = new Product("Mouse", "P1002", 25.50, 2);
            Product product3 = new Product("Keyboard", "P1003", 49.99, 1);
            Product product4 = new Product("Monitor", "P1004", 199.99, 2);
            Product product5 = new Product("Headphones", "P1005", 79.99, 3);

            // Create some addresses
            Address usaAddress = new Address("123 Main St", "Springfield", "IL", "USA");
            Address internationalAddress = new Address("456 High St", "London", "Greater London", "UK");

            // Create some customers
            Customer customer1 = new Customer("John Smith", usaAddress);
            Customer customer2 = new Customer("Emma Johnson", internationalAddress);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            Order order2 = new Order(customer2);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            // Display order information
            Console.WriteLine("Order 1:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}");
            Console.WriteLine();

            Console.WriteLine("Order 2:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
        }
    }

    public class Product
    {
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public string GetName() { return _name; }
        public string GetProductId() { return _productId; }
        public double CalculateTotalCost() { return _price * _quantity; }
    }

    public class Address
    {
        private string _street;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string street, string city, string stateProvince, string country)
        {
            _street = street;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        public bool IsInUSA() { return _country.ToLower() == "usa"; }

        public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName() { return _name; }
        public Address GetAddress() { return _address; }
        public bool IsInUSA() { return _address.IsInUSA(); }
    }

    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalCost()
        {
            double total = 0;
            foreach (Product product in _products)
            {
                total += product.CalculateTotalCost();
            }

            // Add shipping cost
            total += _customer.IsInUSA() ? 5 : 35;

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "";
            foreach (Product product in _products)
            {
                label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
        }
    }

