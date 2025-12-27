namespace WeeklyTest
{
    /// <summary>
    /// Entity class to store all the details
    /// </summary>
    public class PatientBill
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Console based input</param>
        public static void Main(string[] args)
        {
            int choice;
            do{
                Console.WriteLine("================MediSureClinicBilling================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                ///Based on users choice call the classes/methods
                if(choice == 1)
                {
                    Console.Write("Enter Bill Id: ");
                    string? billId = Console.ReadLine();
                    Console.Write("Enter Patient Name: ");
                    string? patientName = Console.ReadLine();
                    Console.Write("Is the patient insured? (Y/N): ");
                    char isInsurance = Console.ReadLine()!.Trim()[0];
                    bool hasInsurance;
                    if(isInsurance == 'Y'){
                        hasInsurance = true;
                    }
                    else {
                        hasInsurance = false;
                    }
                    Console.Write("Enter Consultation Fee: ");
                    double consultationFee = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Lab Charges: ");
                    double labCharges = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Medicine Charges: ");
                    double medicineCharges = Convert.ToDouble(Console.ReadLine());

                    CalculateBill calculateBill = new CalculateBill(hasInsurance, consultationFee, labCharges, medicineCharges);
                    double grossAmount = calculateBill.GetGrossAmount();
                    double discountAmount = calculateBill.GetDiscountAmount();
                    double payableAmount = calculateBill.GetPayableAmount();

                    Console.WriteLine("Bill created successfully.");
                    Console.WriteLine("Gross Amount: " + grossAmount);
                    Console.WriteLine("Discount Amount: "+ discountAmount);
                    Console.WriteLine("Final Payable: "+ payableAmount);

                    BillDetails.CreateBill(billId,patientName,hasInsurance,consultationFee,labCharges,medicineCharges);
                }

                else if(choice == 2)
                {
                    BillDetails.ViewBill();
                }

                else if(choice == 3)
                {
                    BillDetails.ClearBill();
                }

                else if(choice == 4)
                {
                    Console.WriteLine("Thank you. Application closed normally.");
                }

                else
                {
                    Console.WriteLine("Please input a valid option.");
                }

                Console.WriteLine("------------------------------------------------------------");
            }while(choice != 4);
        }
    }
}