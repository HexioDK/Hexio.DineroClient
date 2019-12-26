using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hexio.DineroClient.Models;
using RestEase;

namespace Hexio.DineroClient
{
    public interface IDineroClient
    {
        [Path("organizationId")]
        int OrganizationId { get; set; }
        
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }
        
        [Post("/v1/{organizationId}/invoices")]
        [AllowAnyStatusCode]
        Task<Response<CreatedResponse>> CreateInvoice([Body] CreateInvoiceModel model);

        [Post("/v1/{organizationId}/invoices/{guid}/book")]
        [AllowAnyStatusCode]
        Task BookInvoice([Path] Guid guid, [Body] BookInvoiceModel model);
        
        [Post("/v1/{organizationId}/invoices/{guid}/email")]
        [AllowAnyStatusCode]
        Task SendInvoice([Path] Guid guid, [Body] SendInvoiceEmailModel model);

        [Get("/v1/{organizationId}/products")]
        Task<CollectionWrapper<ProductModel>> GetProducts([Query] string queryFilter, [Query] string fields = "Name,ProductGuid");
        
        [Get("/v1/{organizationId}/contacts")]
        Task<CollectionWrapper<ContactModel>> GetContacts([Query] string queryFilter, [Query] string fields = "Name,ContactGuid,VatNumber");
        
        [Post("v1/{organizationId}/contacts")]
        Task<ContactModel> CreateContact([Body] ContactModel model);

        [Get("v1/{organizationId}/vouchers/purchase/{guid}")]
        Task<PurchaseVoucherModel> GetPurchaseVoucher([Path] Guid guid);

        [Post("v1.1/{organizationId}/vouchers/purchase")]
        Task<PurchaseVoucherModel> CreatePurchaseVoucher([Body] CreatePurchaseVoucherModel model);

        [Post("v1/{organizationId}/vouchers/purchase/{guid}/book")]
        Task<PurchaseVoucherModel> BookPurchaseVoucher([Body] BookVoucherModel model, [Path] Guid guid);
        
        [Delete("v1/{organizationId}/vouchers/purchase/{guid}")]
        Task DeletePurchaseVoucher([Path] Guid guid, [Body] TimestampModel model);
        
        [Post("v1/{organizationId}/vouchers/manuel")]
        Task<ManualVoucherResponseModel> CreateManualVoucher([Body] ManualVoucherCreateModel model);
        
        [Post("v1/{organizationId}/vouchers/manuel/{voucherGuid}/book")]
        Task BookManualVoucher([Path] Guid voucherGuid, [Body] BookVoucherModel model);

        [Get("v1/{organizationId}/accounts/entry")]
        Task<IList<AccountModel>> GetAccounts();

        [Post("v1/{organizationId}/accounts/entry")]
        Task CreateEntryAccount([Body] CreateEntryAccountModel model);
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