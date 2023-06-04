using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Queries.GetById
{
    public class AddressGetByIdQueryHandler : IRequestHandler<AddressGetByIdQuery, AddressGetByIdDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressGetByIdQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<AddressGetByIdDto> Handle(AddressGetByIdQuery request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.Include(x => x.Country).Include(x => x.City)
                .FirstOrDefault(x => x.Id == request.Id);

            if (address is null)
                throw new InvalidOperationException("The address was not found");

            var addressDto =  new AddressGetByIdDto
            {
                Name = address.Name,
                CountryId = address.CountryId,
                CountryName = address.Country.Name,
                CityId = address.CityId,
                CityName = address.City.Name,
                District = address.District,
                PostCode = address.PostCode,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressType = address.AddressType
            };

            return addressDto;
        }
    }
}
