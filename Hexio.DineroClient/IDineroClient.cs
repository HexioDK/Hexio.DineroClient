using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Hexio.DineroClient.Auth;
using Hexio.DineroClient.Authorization;
using Hexio.DineroClient.Models;
using Hexio.DineroClient.Models.Accounts;
using Hexio.DineroClient.Models.Contacts;
using Hexio.DineroClient.Models.CreditNotes;
using Hexio.DineroClient.Models.Invoices;
using Hexio.DineroClient.Models.Ledger;
using Hexio.DineroClient.Models.ManualVoucher;
using Hexio.DineroClient.Models.Products;
using Hexio.DineroClient.Models.PurchaseVouchers;
using Hexio.DineroClient.Models.Sales;
using RestEase;

namespace Hexio.DineroClient
{
    public interface IDineroClient
    {
        [Path("organizationId")]
        int OrganizationId { get; set; }
        
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("v1/organizations?fields=name,email,isPro,VatNumber,id,phone,street,city,zipCode,attPerson")]
        Task<IList<OrganizationReadModel>> GetOrganizations();
        
        [Get("v1/{organizationId}/accounts/entry")]
        Task<IList<AccountModel>> GetAccounts();

        [Post("v1/{organizationId}/accounts/entry")]
        Task CreateEntryAccount([Body] CreateAccountModel model);

        [Get("/v1/{organizationId}/products")]
        Task<CollectionWrapper<ProductReadModel>> GetProducts([RawQueryString] QueryCreator<ProductReadModel> queryCreator);
        
        [Get("/v1/{organizationId}/contacts")]
        Task<CollectionWrapper<ContactReadModel>> GetContacts([RawQueryString] QueryCreator<ContactReadModel> queryCreator);
        
        [Get("v1/{organizationId}/contacts/{contactGuid}")]
        Task<ContactReadModel> GetContactByGuid([Path] Guid contactGuid);
        
        [Post("v1/{organizationId}/contacts")]
        Task<ContactReadModel> CreateContact([Body] CreateContactModel model);
        
        [Put("v1/{organizationId}/contacts/{contactGuid}")]
        Task<ContactReadModel> UpdateContact([Path] Guid contactGuid, [Body] CreateContactModel model);
        
        [Post("v1/{organizationId}/vouchers/manuel")]
        Task<ManualVoucherReadModel> CreateManualVoucher([Body] CreateManualVoucherModel model);
        
        [Post("v1/{organizationId}/vouchers/manuel/{voucherGuid}/book")]
        Task BookManualVoucher([Path] Guid voucherGuid, [Body] BookVoucherModel model);
        
        [Get("v1/{organizationId}/vouchers/manuel/{guid}")]
        Task<ManualVoucherReadModel> GetManualVoucher([Path] Guid guid);

        [Get("v1/{organizationId}/vouchers/purchase/{guid}")]
        Task<PurchaseVoucherReadModel> GetPurchaseVoucher([Path] Guid guid);

        [Post("v1.1/{organizationId}/vouchers/purchase")]
        Task<PurchaseVoucherReadModel> CreatePurchaseVoucher([Body] CreatePurchaseVoucherModel model);

        [Post("v1/{organizationId}/vouchers/purchase/{guid}/book")]
        Task<PurchaseVoucherReadModel> BookPurchaseVoucher([Body] BookVoucherModel model, [Path] Guid guid);
        
        [Delete("v1/{organizationId}/vouchers/purchase/{guid}")]
        Task DeletePurchaseVoucher([Path] Guid guid, [Body] DeletePurchaseVoucherModel model);

        [Post("v1/{organizationId}/vouchers/purchase/{guid}/generate-creditnote")]
        Task<PurchaseVoucherReadModel> CreateCreditNoteFromPurchaseVoucher([Path] Guid guid, [Body] CreateCreditNoteFromPurchaseVoucerModel model);
        
        [Post("v1/{organizationId}/vouchers/purchase/creditnotes")]
        Task<Response<DocumentCreatedModel>> CreatePurchaseVoucherCreditNote([Body] CreatePurchaseVoucherCreditNoteModel model);
        
        [Put("v1/{organizationId}/vouchers/purchase/creditnotes/{guid}")]
        Task UpdatePurchaseVoucherCreditNote([Path] Guid guid, [Body] CreatePurchaseVoucherCreditNoteModel model);
        
        [Get("v1/{organizationId}/vouchers/purchase/creditnotes/{guid}")]
        Task<PurchaseVoucherCreditNoteReadModel> GetPurchaseVoucherCreditNote([Path] Guid guid);
        
        [Post("v1/{organizationId}/vouchers/purchase/creditnotes/{guid}/book")]
        Task BookPurchaseVoucherCreditNote([Path] Guid guid, [Body] BookVoucherModel model);
        
        [Get("v1/{organizationId}/invoices")]
        Task<CollectionWrapper<InvoiceCollectionReadModel>> ListInvoices([RawQueryString] QueryCreator<InvoiceCollectionReadModel> queryCreator = null);
        
        [Get("v1/{organizationId}/invoices/{guid}")]
        Task<InvoiceReadModel> GetInvoice([Path] Guid guid);
        
        [Get("v1/{organizationId}/invoices/{guid}")]
        [Header("Accept", "application/octet-stream")]
        Task<Stream> GetInvoicePdf([Path] Guid guid);

        [Post("/v1/{organizationId}/invoices")]
        [AllowAnyStatusCode]
        Task<Response<DocumentCreatedModel>> CreateInvoice([Body] CreateInvoiceModel model);
        
        [Post("/v1/{organizationId}/invoices/fetch")]
        [AllowAnyStatusCode]
        Task<Response<InvoiceReadModel>> GetInvoiceTotals([Body] CreateInvoiceModel model);

        [Put("v1.2/{organizationId}/invoices/{invoiceGuid}")]
        [AllowAnyStatusCode]
        Task<Response<DocumentCreatedModel>> UpdateInvoice([Path] Guid invoiceGuid, [Body] CreateInvoiceModel model);
        
        [Delete("v1/{organizationId}/invoices/{invoiceGuid}")]
        [AllowAnyStatusCode]
        Task<Response<DocumentCreatedModel>> DeleteInvoice([Path] Guid invoiceGuid);

        [Post("/v1/{organizationId}/invoices/{guid}/book")]
        [AllowAnyStatusCode]
        Task<HttpResponseMessage> BookInvoice([Path] Guid guid, [Body] BookDocumentModel model);
        
        [Get("/v2/{organizationId}/invoices/{guid}/email/template")]
        [AllowAnyStatusCode]
        Task<Response<InvoiceEmailTemplateModel>> GetInvoiceEmailTemplate([Path] Guid guid);

        [Post("/v1/{organizationId}/invoices/{guid}/email")]
        [AllowAnyStatusCode]
        Task<Response<SendInvoiceResponse>> SendInvoice([Path] Guid guid, [Body] SendInvoiceEmailModel model);
        
        [Post("v2/{organizationId}/invoices/{guid}/e-invoice")]
        [AllowAnyStatusCode]
        Task<Response<SendInvoiceResponse>> SendInvoiceWithEan([Path] Guid guid, [Body] SendInvoiceWithEanModel model);
        
        [Post("v3/{organizationId}/invoices/{guid}/e-invoice")]
        [AllowAnyStatusCode]
        Task<Response<SendInvoiceResponse>> SendElectronicInvoice([Path] Guid guid, [Body] SendElectronicInvoiceModel model);

        [Post("v1/{organizationId}/invoices/{invoiceGuid}/payments")]
        [AllowAnyStatusCode]
        Task<DocumentCreatedModel> AddPaymentToInvoice([Path] Guid invoiceGuid, [Body] CreatePaymentModel model);
        
        [Get("v1/{organizationId}/sales/creditnotes")]
        [AllowAnyStatusCode]
        Task<CollectionWrapper<CreditNoteReadModel>> ListCreditNotes([RawQueryString] QueryCreator<CreditNoteReadModel> queryCreator = null);

        [Get("v1/{organizationId}/sales/creditnotes/{creditNoteGuid}")]
        [AllowAnyStatusCode]
        Task<CreditNoteReadModel> GetCreditNote([Path] Guid creditNoteGuid);
        
        [Get("/v1/{organizationId}/sales/creditnotes/{guid}/pdf")]
        Task<Stream> GetCreditnotePdf([Path] Guid guid);
        
        [Post("/v1/{organizationId}/sales/creditnotes")]
        [AllowAnyStatusCode]
        Task<Response<DocumentCreatedModel>> CreateCreditNote([Body] CreateCreditNoteModel model);

        [Post("v1/{organizationId}/sales/creditnotes/{credtiNoteGuid}/book")]
        [AllowAnyStatusCode]
        Task<HttpResponseMessage> BookCreditNote([Path] Guid credtiNoteGuid, [Body] BookDocumentModel model);
        
        [Delete("/v1/{organizationId}/sales/creditnotes/{guid}")]
        [AllowAnyStatusCode]
        Task<Response<DocumentCreatedModel>> DeleteCreditNote([Path] Guid guid);
        
        [Post("/v1/{organizationId}/files")]
        [AllowAnyStatusCode]
        Task<FileUploadedResponse> UploadFile([Body] HttpContent content);
        
        [Post("/v1/{organizationId}/ledgerItems/ledgers")]
        [AllowAnyStatusCode]
        Task<Response<List<LedgerItemModel>>> GetLedgerItems([Body] List<LedgerItemsModelReadModel> model);

        [Post("/v1.2/{organizationId}/ledgerItems")]
        [AllowAnyStatusCode]
        Task<Response<List<LedgerItemsModelReadModel>>> AddLedgerItems([Body] List<LedgerItemModel> model);
        
        [Post("/v1/{organizationId}/ledgerItems/book")]
        [AllowAnyStatusCode]
        Task<Response<HttpResponseMessage>> BookLedgerItems([Body] List<LedgerItemsModelReadModel> model);
        
        [Delete("/v1/{organizationId}/ledgerItems/delete")]
        [AllowAnyStatusCode]
        Task<Response<HttpResponseMessage>> DeleteLedgerItems([Body] List<LedgerItemsModelReadModel> model);
        
        [Get("/v1/{organizationId}/sales/settings")]
        Task<DefaultInvoiceSettings> GetDefaultInvoiceSettings();
        
        [Post("https://connect.visma.com/connect/token")]
        [AllowAnyStatusCode]
        Task<Response<TokenResponse>> GetTokenForTenant([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> body);
    }

    public static class DineroClientExtensions
    {
        public static async Task SetAuthorizationHeader(this IDineroClient client, IDineroAuthClient authClient, string apiKey, int organizationId)
        {
            var accessToken = await authClient.Authenticate(new AuthRequest(apiKey, apiKey));
            
            client.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);

            client.OrganizationId = organizationId;
        }
        
        public static void SetAuthorizationHeader(this IDineroClient client, string token, int organizationId)
        {
            client.Authorization = new AuthenticationHeaderValue("Bearer", token);

            client.OrganizationId = organizationId;
        }
        
        public static async Task SetAuthorizationHeader(this IDineroClient client, VismaConnectSettings vismaConnectSettings, Guid tenantId, int organizationId)
        {
            var response = await client.GetTokenForTenant(new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"client_id", vismaConnectSettings.ClientId},
                {"client_secret", vismaConnectSettings.ClientSecret},
                {"tenant_id", tenantId.ToString()},
            });
            
            if (!response.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get token for tenant with error {response.StringContent}");
            }

            client.Authorization = new AuthenticationHeaderValue("Bearer", response.GetContent().AccessToken);

            client.OrganizationId = organizationId;
        }

        public static async Task BookManualVoucher(this IDineroClient client, Guid voucherGuid, string timestamp)
        {
            await client.BookManualVoucher(voucherGuid, new BookVoucherModel
            {
                TimeStamp = timestamp
            });
        }

        public static async Task<FileUploadedResponse> UploadFile(this IDineroClient client, Stream steam, string fileName = "file.pdf", string contentType = "application/pdf")
        {
            if (!contentType.Contains("pdf") && !contentType.Contains("image"))
            {
                throw new Exception("Not a valid content type, e.g. application/pdf");
            }

            if (steam.CanSeek)
            {
                steam.Seek(0, SeekOrigin.Begin);
            }

            var content = new MultipartFormDataContent();

            var fileContent = new StreamContent(steam);
            
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                FileName = fileName
            };
            
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            
            content.Add(fileContent);

            return await client.UploadFile(content);
        }
    }
}