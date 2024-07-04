using Iyzipay.Model;
using Iyzipay.Request;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Domain.Settings;
using Microsoft.Extensions.Options;
using Options = Iyzipay.Options;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class IyzicoPaymentManager : IPaymentService
    {
        private readonly Options _options;

        public IyzicoPaymentManager(IOptions<IyzicoSettings> settings)
        {
            _options = new Options
            {
                ApiKey = settings.Value.ApiKey,
                SecretKey = settings.Value.SecretKey,
                BaseUrl = settings.Value.BaseUrl
            };
        }

        public async Task<object> CreateCheckoutFormAsync(CancellationToken cancellationToken)
        {
            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "100";
            request.PaidPrice = "100";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B123456";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "http://localhost:5262/payment-success";

            List<int> enabledInstallments = new List<int>();

            enabledInstallments.Add(3);

            enabledInstallments.Add(6);

            enabledInstallments.Add(9);

            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "Alper";
            buyer.Surname = "Tunga";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "IconBuilderAI 10 credits";
            firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            firstBasketItem.Price = "100";
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, _options);

            return checkoutFormInitialize;
        }
    }
}