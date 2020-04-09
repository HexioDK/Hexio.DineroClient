namespace Hexio.DineroClient.Models.Invoices
{
    public class CreatePaymentModel
    {
        public string Timestamp { get; set; }
        public int DepositAccountNumber { get; set; } = 55000;
        public bool RemainderIsFee { get; set; }
        public string ExternalReference { get; set; }
        public string PaymentDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountInForeignCurrency { get; set; }
    }
}