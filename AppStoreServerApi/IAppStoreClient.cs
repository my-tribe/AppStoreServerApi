using AppStoreServerApi.Models;

namespace AppStoreServerApi;

public interface IAppStoreClient
{
    // https://developer.apple.com/documentation/appstoreserverapi/get_transaction_history
    Task<HistoryResponse> GetTransactionHistoryAsync(string transactionId,
        string? revision = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? productId = null,
        IReadOnlyCollection<ProductType>? productType = null,
        InAppOwnershipType? inAppOwnershipType = null,
        SortOrder? sort = null,
        bool? revoked = null,
        IReadOnlyCollection<string>? subscriptionGroupIdentifier = null,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/get_transaction_info
    Task<TransactionInfoResponse> GetTransactionInfoAsync(string transactionId, CancellationToken ct = default);
}