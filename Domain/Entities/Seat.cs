using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Exceptions;

namespace Domain.Entities
{
   
        public class Seat : Entity<Guid>
        {
            public Guid EventId { get; private set; }
            public string SeatNumber { get; private set; }
            public string Zone { get; private set; }
            public decimal Price { get; private set; }
            public bool IsAvailable { get; private set; }
            public Guid? BookingId { get; private set; }

            // EF Core constructor
            private Seat() { }

            public Seat(Guid eventId, string seatNumber, string zone, decimal price)
            {
                EventId = eventId;
                SeatNumber = seatNumber;
                Zone = zone;
                Price = price;
                IsAvailable = true;
            }

            public void Reserve(Guid bookingId)
            {
                if (!IsAvailable)
                    throw new SeatNotAvailableException(SeatNumber);

                BookingId = bookingId;
                IsAvailable = false;
            }

            public void Release()
            {
                BookingId = null;
                IsAvailable = true;
            }
        }
    }
