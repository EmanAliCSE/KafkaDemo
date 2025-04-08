using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;
using Domain.Events;

namespace Domain.Entities
{
    public class Booking : Entity<Guid>, IAggregateRoot
    {
        public Guid EventId { get; private set; }
        public Guid CustomerId { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime BookingDate { get; private set; }

        private readonly List<Seat> _seats = new();
        public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();

        protected Booking() { }

        public Booking(Guid eventId, Guid customerId, int quantity, decimal totalPrice, List<Seat> seats)
        {
            EventId = eventId;
            CustomerId = customerId;
            Quantity = quantity;
            TotalPrice = totalPrice;
            _seats = seats;
            Status = BookingStatus.Pending;
            BookingDate = DateTime.UtcNow;

            //AddDomainEvent(new BookingCreatedDomainEvent(this));
        }

        //public void ConfirmBooking()
        //{
        //    Status = BookingStatus.Confirmed;
        //    AddDomainEvent(new BookingConfirmedDomainEvent(this));
        //}

        //public void CancelBooking()
        //{
        //    Status = BookingStatus.Cancelled;
        //    AddDomainEvent(new BookingCancelledDomainEvent(this));
        //}
    }
}
