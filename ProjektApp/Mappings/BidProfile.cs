using AutoMapper;
using ProjectApp.Core;
using ProjectApp.Persistence;

namespace ProjectApp.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            // Default mapping when property names are same
            CreateMap<BidDb, Bid>()
                .ReverseMap();
        }
    }
}
