
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class UserSummaryViewComponent : ViewComponent
    {
    private readonly IServicesManager _manager;

        public UserSummaryViewComponent(IServicesManager manager)
        {
            _manager = manager;
        }

        public string Invoke(){
            return _manager
            .AuthService
            .GetAllUsers()
            .Count()
            .ToString();
        }
    }
}