namespace WeeklyTest
{
    public class SaleTransaction
    {
        public static void Main(string[] args)
        {
            int choice;
            do{
                Console.WriteLine("================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your option: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    Console.Write("Enter Invoice No: ");
                    string? invoiceNo = Console.ReadLine();
                    Console.Write("Enter Customer Name: ");
                    string? customerName = Console.ReadLine();
                    Console.Write("Enter Item Name: ");
                    string? itemName = Console.ReadLine();
                    Console.Write("Enter Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Purchase Amount (total): ");
                    double purchaseAmount = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Selling Amount (total): ");
                    double sellingAmount = Convert.ToDouble(Console.ReadLine());

                    SaleDetails.SetSaleDetails(invoiceNo,customerName,itemName,quantity,purchaseAmount,sellingAmount);
                }
                else if(choice == 2)
                {
                    SaleDetails.ViewLastTransaction();
                }
                else if(choice == 3)
                {
                    SaleDetails.CalculateProfitOrLoss();
                }
                else if(choice == 4)
                {
                    Console.WriteLine("Thank you. Application closed normally.");
                }
                else
                {
                     Console.WriteLine("Please input a valid option.");
                }
            }while(choice != 4);
        }
    }
}
