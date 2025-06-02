using BookLibrary.Data.Interfaces;
using BookLibrary.Logic.Interfaces;
using BookLibrary.Logic.Services;

namespace BookLibrary.Logic.Services.Objects
{
    internal class BusinessLogic : ILogic
    {

        private IServiceCatalog _servicecatalog;
        private IServiceUser _serviceUser;

        public BusinessLogic(IDataRepository dataRepository) 
        {
            _servicecatalog = new ServiceCatalog(dataRepository);
            _serviceUser = new ServiceUser(dataRepository);
        }

        public IServiceUser ServiceUser => _serviceUser;

        public IServiceCatalog ServiceCatalog => _servicecatalog;
    }
}
