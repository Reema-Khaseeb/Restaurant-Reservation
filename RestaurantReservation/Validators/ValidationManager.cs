namespace RestaurantReservation.Validators
{
    public class ValidationManager
    {
        public static void ValidateNotNull(object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
        
        public static void ValidatePositiveInteger(int value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Invalid {paramName}: {value}");
            }
        }
    }
}
