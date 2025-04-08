using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Domain.Events
{
    public abstract class BookingEvent : DomainEvent
    {
        public Guid BookingId { get; }
        public Guid EventId { get; }
        public Guid CustomerId { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }

        protected BookingEvent(Booking booking)
        {
            BookingId = booking.Id;
            EventId = booking.EventId;
            CustomerId = booking.CustomerId;
            Quantity = booking.Quantity;
            TotalPrice = booking.TotalPrice;
        }
    }
    public class BookingCreatedDomainEvent : BookingEvent
    {
        public BookingCreatedDomainEvent(Booking booking) : base(booking) { }
    }

    public class BookingConfirmedDomainEvent : BookingEvent
    {
        public BookingConfirmedDomainEvent(Booking booking) : base(booking) { }
    }
}
