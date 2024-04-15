
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class OrderInProgressViewComponent : ViewComponent
    {
        private readonly IServicesManager _manager;


        public OrderInProgressViewComponent(IServicesManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager
            .OrderService
           .NumberOfInProcess
           .ToString();
           
        }

    }
}