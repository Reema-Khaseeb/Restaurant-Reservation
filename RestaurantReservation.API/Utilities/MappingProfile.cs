using AutoMapper;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDTO>().ReverseMap();
        }
    }
}