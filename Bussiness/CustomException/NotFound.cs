namespace Bussiness.CustomException
{
    public class NotFound : Exception
    {
        public NotFound():base("Bulunamadı.")
        {
            
        }

        public NotFound(string? message) : base(message)
        {

        } 
        
        public NotFound(string? message, Exception? innException) : base(message, innException)
        {

        }
    }
}
