using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MovieBookingService.Exceptions
{
    public class BookingExceptions : Exception
    {
        public BookingExceptions(BookingExceptionType type)
        {
            string message;
            switch(type)
            {
                case BookingExceptionType.Unknown:
                    message = "Unknown Error Occured";
                    break;
                case BookingExceptionType.InvalidBookingDetails:
                    message = "Invalid booking details";
                    break;
                default:
                    break;
            }
        }

        private void ThrowException()
        {

        }
    }
}
