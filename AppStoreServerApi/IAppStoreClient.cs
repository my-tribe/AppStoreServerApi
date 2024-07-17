using AppStoreServerApi.Models;

namespace AppStoreServerApi;

public interface IAppStoreClient
{
    // https://developer.apple.com/documentation/appstoreserverapi/get_transaction_info
    Task<TransactionInfoResponse> GetTransactionInfoAsync(string transactionId, CancellationToken ct = default);
}