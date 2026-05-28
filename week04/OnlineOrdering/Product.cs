class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public string Name => _name;
    public string ProductId => _productId;
    public decimal Price => _price;
    public int Quantity => _quantity;
    public decimal TotalCost => _price * _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }
}
