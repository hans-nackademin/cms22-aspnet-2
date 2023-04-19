using WebApp.Helpers.Repositories;

namespace WebApp.Helpers.Services
{
    public class AddressManager
    {
        private readonly AddressRepository _addressRepository;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressManager(AddressRepository addressRepository, UserAddressRepository userAddressRepository)
        {
            _addressRepository = addressRepository;
            _userAddressRepository = userAddressRepository;
        }
    }
}
