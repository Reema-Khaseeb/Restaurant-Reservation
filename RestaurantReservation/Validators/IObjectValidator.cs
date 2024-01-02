namespace RestaurantReservation.Validators
{
    public interface IObjectValidator
    {
        void ValidateObjectNotNull(object objectName);
        void ValidatePositiveObjectId(int id);
    }
}
