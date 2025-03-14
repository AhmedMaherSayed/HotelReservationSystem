using HotelReservationSystem.Data.Entities;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services
{
    public class OfferService
    {
        private readonly IGenericRepository<Offer> _genericRepo;

        public OfferService(IGenericRepository<Offer> genericRepo)
        {
            _genericRepo = genericRepo;
        }


    }
}
