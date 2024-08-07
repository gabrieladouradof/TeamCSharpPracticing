using System.Diagnostics.Contracts;

namespace PaymentContext.Domain.Entities
{
    public class Subscription 
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set;}
        public DateTime LastUpdateDate { get; private set;}
        public DateTime? ExpireDate { get; private set;}
        public bool Active {get; private set;}
        public List<Payment>? Payments { get; private set; }

        public void AddPayment(Payment payment)
        {
            AddNotification(new Contract()
                .Requires
                .IsGreaterThan(DateTime.Now, payment,PaidDate, "Subscription.Payments", "A data do ")
            );
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}