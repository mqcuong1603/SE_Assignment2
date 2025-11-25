namespace Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }

        public string ItemName { get; set; }
        public string Size { get; set; }
    }
}
