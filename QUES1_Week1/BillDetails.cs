namespace WeeklyTest
{
    /// <summary>
    /// Class to store information provided by the user
    /// </summary>
    public class BillDetails
    {
        public static BillDetails? LastBill;
        public static bool HasLastBill = false;

        public string? BillId { get; set; }
        public string? PatientName { get; set; }
        public bool HasInsurance { get; set; }
        public double ConsultationFee { get; set; }
        public double LabCharges { get; set; }
        public double MedicineCharges { get; set; }
        public double GrossAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double FinalPayable { get; set; }

        /// <summary>
        /// This will save the bill after creating
        /// </summary>
        /// <param name="billId">Input bill id</param>
        /// <param name="patientName">Input Patient Name</param>
        /// <param name="hasInsurance">Input if has insurance or not</param>
        /// <param name="consultationFee">Input consultation fee</param>
        /// <param name="labCharges">Input Lab charges</param>
        /// <param name="medicineCharges">Input medicine charges</param>
        public static void CreateBill(string billId, string patientName, bool hasInsurance, double consultationFee, double labCharges, double medicineCharges)
        {
            if (string.IsNullOrWhiteSpace(billId))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                return;
            }

            if (consultationFee <= 0 || labCharges < 0 || medicineCharges < 0)
            {
                Console.WriteLine("Invalid fee values entered.");
                return;
            }
            double gross = consultationFee + labCharges + medicineCharges;
            double discount = hasInsurance ? gross * 0.10 : 0;
            double payable = gross - discount;

            LastBill = new BillDetails
            {
                BillId = billId,
                PatientName = patientName,
                HasInsurance = hasInsurance,
                ConsultationFee = consultationFee,
                LabCharges = labCharges,
                MedicineCharges = medicineCharges,
                GrossAmount = gross,
                DiscountAmount = discount,
                FinalPayable = payable
            };

            HasLastBill = true;

            Console.WriteLine("Bill created successfully.");
        }

        /// <summary>
        /// This will clear the bill data
        /// </summary>
        public static void ClearBill()
        {
            if (!HasLastBill)
            {
                Console.WriteLine("No bill to clear.");
                return;
            }

            LastBill = null;
            HasLastBill = false;

            Console.WriteLine("Last bill cleared.");
        }

        /// <summary>
        /// this will display the bill
        /// </summary>
        public static void ViewBill()
        {
            if (!HasLastBill)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
                return;
            }

            Console.WriteLine("----------- Last Bill -----------");
            Console.WriteLine($"Bill Id          : {LastBill!.BillId}");
            Console.WriteLine($"Patient Name     : {LastBill.PatientName}");
            Console.WriteLine($"Insured          : {LastBill.HasInsurance}");
            Console.WriteLine($"Consultation Fee : {LastBill.ConsultationFee}");
            Console.WriteLine($"Lab Charges      : {LastBill.LabCharges}");
            Console.WriteLine($"Medicine Charges : {LastBill.MedicineCharges}");
            Console.WriteLine($"Gross Amount     : {LastBill.GrossAmount}");
            Console.WriteLine($"Discount Amount  : {LastBill.DiscountAmount}");
            Console.WriteLine($"Final Payable    : {LastBill.FinalPayable}");
            Console.WriteLine("--------------------------------");
        }
    }
}
