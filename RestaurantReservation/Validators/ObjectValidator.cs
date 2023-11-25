using RestaurantReservation.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Validators
{
    public class ObjectValidator : IObjectValidator
    {
        public void ValidateObjectNotNull(object objectName)
        {
            ValidationManager.ValidateNotNull(objectName, nameof(objectName));
        }

        public void ValidatePositiveObjectId(int id)
        {
            ValidationManager.ValidatePositiveInteger(id, nameof(id));
        }
    }
}
