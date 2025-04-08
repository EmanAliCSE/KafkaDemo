using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class SeatNotAvailableException : Exception
    {
        public string SeatNumber { get; }

        public SeatNotAvailableException(string seatNumber)
            : base($"Seat {seatNumber} is not available")
        {
            SeatNumber = seatNumber;
        }
    }
}
