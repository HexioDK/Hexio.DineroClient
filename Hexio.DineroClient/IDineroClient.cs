using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Hexio.DineroClient.Auth;
using Hexio.DineroClient.Models;
using Hexio.DineroClient.Models.Accounts;
using Hexio.DineroClient.Models.Contacts;
using Hexio.DineroClient.Models.Invoices;
using Hexio.DineroClient.Models.ManualVoucher;
using Hexio.DineroClient.Models.Products;
using Hexio.DineroClient.Models.PurchaseVouchers;
using RestEase;

namespace Hexio.DineroClient
{
    public interface IDineroClient
    {
        [Path("organizationId")]
        int OrganizationId { get; set; }
        
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }
        
        [Get("v1/{organizationId}/accounts/entry")]
        Task<IList<AccountModel>> GetAccounts();

        [Post("v1/{organizationId}/accounts/entry")]
        Task CreateEntryAccount([Body] CreateAccountModel model);

        [Get("/v1/{organizationId}/products")]
        Task<CollectionWrapper<ProductReadModel>> GetProducts([RawQueryString] QueryCreator<ProductReadModel> queryCreator);
        
        [Get("/v1/{organizationId}/contacts")]
        Task<CollectionWrapper<ContactReadModel>> GetContacts([RawQueryString] QueryCreator<ContactReadModel> queryCreator);
        
        [Post("v1/{organizationId}/contacts")]
        Task<CreateContactModel> CreateContact([Body] CreateContactModel model);
        
        [Post("v1/{organizationId}/vouchers/manuel")]
        Task<ManualVoucherCreatedModel> CreateManualVoucher([Body] CreateManualVoucherModel model);
        
        [Post("v1/{organizationId}/vouchers/manuel/{voucherGuid}/book")]
        Task BookManualVoucher([Path] Guid voucherGuid, [Body] BookVoucherModel model);

        [Get("v1/{organizationId}/vouchers/purchase/{guid}")]
        Task<PurchaseVoucherReadModel> GetPurchaseVoucher([Path] Guid guid);

        [Post("v1.1/{organizationId}/vouchers/purchase")]
        Task<PurchaseVoucherReadModel> CreatePurchaseVoucher([Body] CreatePurchaseVoucherModel model);

        [Post("v1/{organizationId}/vouchers/purchase/{guid}/book")]
        Task<PurchaseVoucherReadModel> BookPurchaseVoucher([Body] BookVoucherModel model, [Path] Guid guid);
        
        [Delete("v1/{organizationId}/vouchers/purchase/{guid}")]
        Task DeletePurchaseVoucher([Path] Guid guid, [Body] DeletePurchaseVoucherModel model);

        [Post("/v1/{organizationId}/invoices")]
        [AllowAnyStatusCode]
        Task<Response<InvoiceCreatedModel>> CreateInvoice([Body] CreateInvoiceModel model);

        [Post("/v1/{organizationId}/invoices/{guid}/book")]
        [AllowAnyStatusCode]
        Task BookInvoice([Path] Guid guid, [Body] BookInvoiceModel model);
        
        [Post("/v1/{organizationId}/invoices/{guid}/email")]
        [AllowAnyStatusCode]
        Task SendInvoice([Path] Guid guid, [Body] SendInvoiceEmailModel model);
    }

    public static class DineroClientExtensions
    {
        public static async Task SetAuthorizationHeader(this IDineroClient client, IDineroAuthClient authClient, string apiKey, int organizationId)
        {
            var accessToken = await authClient.Authenticate(new AuthRequest(apiKey, apiKey));
            
            client.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);

            client.OrganizationId = organizationId;
        }

        public static async Task BookManualVoucher(this IDineroClient client, Guid voucherGuid, string timestamp)
        {
            await client.BookManualVoucher(voucherGuid, new BookVoucherModel
            {
                TimeStamp = timestamp
            });
        }
    }
}