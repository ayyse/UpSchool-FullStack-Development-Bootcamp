using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.Update
{
    public class AddressUpdateCommandHandler : IRequestHandler<AddressUpdateCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public AddressUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Id == request.Id);

            if (address is null)
                throw new InvalidOperationException("The address was not found");

            address.Name = request.Name != default ? request.Name : address.Name;
            address.CountryId = request.CountryId != default ? request.CountryId : address.CountryId;
            address.CityId = request.CityId != default ? request.CityId : address.CityId;    
            address.District = request.District != default ? request.District : address.District;
            address.PostCode = request.PostCode != default ? request.PostCode : address.PostCode;
            address.AddressLine1 = request.AddressLine1 != default ? request.AddressLine1 : address.AddressLine1;
            address.AddressLine2 = request.AddressLine2 != default ? request.AddressLine2 : address.AddressLine2;
            address.AddressType = request.AddressType != default ? request.AddressType : address.AddressType;
            address.ModifiedOn = DateTimeOffset.Now;
            address.ModifiedByUserId = null;

            //_applicationDbContext.Addresses.Update(address);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"The address \"{address.Name}\" was successfully updated.");
        }
    }
}
