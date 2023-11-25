using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Validators
{
    public interface IObjectValidator
    {
        void ValidateObjectNotNull(object objectName);
        void ValidatePositiveObjectId(int id);
    }
}
