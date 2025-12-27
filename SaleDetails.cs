namespace WeeklyTest
{
    public class SaleDetails
    {
        public static SaleDetails? LastTransaction ;
        public static bool HasLastTransaction  = false;
        public string? InvoiceNo{get; set;}
        public string? CustomerName{get; set;}
        public string? ItemName{get; set;}
        public int Quantity{get; set;}
        public double PurchaseAmount{get; set;}
        public double SellingAmount{get; set;}
        public string? ProfitOrLossStatus{get; set;}
        public double ProfitOrLossAmount{get; set;}
        public double ProfitMarginPercent{get; set;}

        public void SetSaleDetails(string invoiceNo, string customerName, string itemName, int quantity, double purchaseAmount, double sellingAmount)
        {
            if (string.IsNullOrWhiteSpace(invoiceNo))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                return;
            }
            if(purchaseAmount > 0 || sellingAmount >= 0)
            {
                Console.WriteLine("Invalid amount entered.");
                return;
            }

            string profitOrLossStatus = "";
            double profitOrLossAmount = 0.0;
            double profitOrLossMargin = 0.0;
            if(sellingAmount > purchaseAmount)
            {
                profitOrLossStatus = "PROFIT";
                profitOrLossAmount = sellingAmount - purchaseAmount;
            }
            else if(sellingAmount < purchaseAmount)
            {
                profitOrLossStatus = "LOSS";
                profitOrLossAmount = purchaseAmount - sellingAmount;
            }
            else
            {
                profitOrLossStatus = "BREAK-EVEN";
                profitOrLossAmount = 0;
            }
            profitOrLossMargin = (profitOrLossAmount/purchaseAmount) * 100;
            LastTransaction = new SaleDetails
            {
                InvoiceNo = invoiceNo,
                CustomerName = customerName,
                ItemName = itemName,
                Quantity = quantity,
                PurchaseAmount = purchaseAmount,
                SellingAmount = sellingAmount,
                ProfitOrLossStatus = profitOrLossStatus,
                ProfitOrLossAmount = profitOrLossAmount,
                ProfitMarginPercent = profitOrLossMargin,
            };

            HasLastTransaction = true;

            Console.WriteLine("Transaction saved successfully.");
        }

        public static void CalculateProfitOrLoss()
        {
            SaleDetails saleDetails = new SaleDetails();
            
            double profitOrLossAmount = 0.0;
            if(saleDetails.SellingAmount > saleDetails.PurchaseAmount)
            {
                profitOrLossAmount = saleDetails.SellingAmount - saleDetails.PurchaseAmount;
            }
            else if(saleDetails.SellingAmount < saleDetails.PurchaseAmount)
            {
                profitOrLossAmount = saleDetails.PurchaseAmount - saleDetails.SellingAmount;
            }
            else
            {
                profitOrLossAmount = 0;
            }
            Console.WriteLine("Profit/ Loss:" + profitOrLossAmount);
        }

        public static void ViewLastTransaction()
        {
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Console.WriteLine("----------- Last Transaction -----------");
            Console.WriteLine($"InvoiceNo: {LastTransaction!.InvoiceNo}");
            Console.WriteLine($"Customer Name: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item Name: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount}");
            Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount}");
            Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent}");
            Console.WriteLine("--------------------------------");
        }
    }
}