namespace WeeklyTest
{
    public class CalculateBill
    {
        public bool HasInsurance{get; set;}
        public double ConsultationFee{get; set;}
        public double LabCharges{get; set;}
        public double MedicineCharges{get; set;}
        public double GrossAmount{get; set;}
        public double DiscountAmount{get; set;}
        public double FinalPayable {get; set;}

        public CalculateBill(bool hasInsurance, double consultationFee, double labCharges, double medicineCharges)
        {
            this.HasInsurance = hasInsurance;
            this.ConsultationFee = consultationFee;
            this.LabCharges = labCharges;
            this.MedicineCharges = medicineCharges;
        }

        public double GetGrossAmount()
        {
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;
            return GrossAmount;
        }

        public double GetDiscountAmount()
        {
            if (HasInsurance)
            {
                DiscountAmount = GrossAmount * 0.10; 
            }
            else
            {
                DiscountAmount = 0;
            }
            return DiscountAmount;
        }

        public double GetPayableAmount()
        {
            FinalPayable = GrossAmount - DiscountAmount;
            return FinalPayable;
        }
    }
}
