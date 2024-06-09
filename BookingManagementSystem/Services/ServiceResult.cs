// ServiceResult.cs

namespace BookingManagementSystem.Models
{
    public class ServiceResult
    {
        public bool Success { get; }
        public string Message { get; }

        public ServiceResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
