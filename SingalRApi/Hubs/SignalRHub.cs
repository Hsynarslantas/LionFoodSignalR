using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.SignalR;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;

namespace SingalRApi.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly ITableService _tableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ITableService tableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _tableService = tableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("RecieveCategoryCount",value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("RecieveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("RecieverActiveProductCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("RecieverPassiveProductCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("RecieveProductCountByCategoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("RecieveProductCountByCategoryNameDrink", value6);
            
            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("RecieveProductPriceAvg", value7);

            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("RecieveProductNameByMaxPrice", value8);

            var value9 = _productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("RecieveProductPriceByHamburger", value9);

            var value10 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("RecieveTotalOrderCount", value10);

            var value11 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("RecieveActiveOrderCount", value11);

            var value12 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("RecieveLastOrderPrice", value12);

            var value13 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("RecieveProductNameByMinPrice", value13);

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", value14);

            var value15 = _tableService.TRestaurantTableCount();
            await Clients.All.SendAsync("RecieveRestaurantTableCount", value15);
        }

        public async Task SendProgressBar()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", value.ToString("0.00")+"₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("RecieveActiveOrderCount", value2);

            var value3 = _tableService.TRestaurantTableCount();
            await Clients.All.SendAsync("RecieveRestaurantTableCount", value3);

            var value5 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("RecieveProductPriceAvg", value5);

            var value6 = _productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("RecieveProductPriceByHamburger", value6);

            var value7 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("RecieveProductCountByCategoryNameDrink", value7);

            var value8 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("RecieveTotalOrderCount", value8);

            var value9=_productService.TProductPriceBySmashBurger();
            await Clients.All.SendAsync("RecieveProductPriceBySmashBurger", value9);

            var value10 = _productService.TTotalPriceByDrinkCategory();
            await Clients.All.SendAsync("RecieveTotalPriceByDrinkCategory", value10);

            var value11 = _productService.TTotalPriceByPizzaCategory();
            await Clients.All.SendAsync("RecieveTotalPriceByPizzaCategory", value11);


        }
        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("RecieveBookingList",values);
        }
        public async Task SendNotification()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("RecieveNotificationCountByStatusFalse", values);

            var values2 = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("RecieveGetAllNotificationByFalse", values2);
        }

        public async Task GetRestaurantTableStatus()
        {
            var value = _tableService.TGetListAll();
            await Clients.All.SendAsync("RecieveRestaurantTableStatus",value);
        }
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("RecieveMessage",user,message);
        }
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount",clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
           clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
