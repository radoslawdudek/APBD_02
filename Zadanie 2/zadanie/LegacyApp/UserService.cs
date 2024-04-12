using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private ICreditService _creditService;
        private UserValidationService _userValidationService;

        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditService = new UserCreditService();
            _userValidationService = new UserValidationService();
        }

        public UserService(IClientRepository clientRepository, ICreditService creditService, UserValidationService userValidationService)
        {
            _clientRepository = clientRepository;
            _creditService = creditService;
            _userValidationService = userValidationService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidationService.IsFullNameValid(firstName, lastName)) return false;
            
            if (!_userValidationService.IsEmailValid(email)) return false;
            
            if (!_userValidationService.IsUserOldEnough(dateOfBirth)) return false;
            
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            _userValidationService.DetermineCreditLimit(user, client, _creditService);
            
            if (!_userValidationService.IsCreditLimitValid(user)) return false;
            
            UserDataAccess.AddUser(user);
            return true;
        }
    }
}