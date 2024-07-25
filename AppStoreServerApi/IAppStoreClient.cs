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

    // https://developer.apple.com/documentation/appstoreserverapi/get_all_subscription_statuses
    Task<StatusResponse> GetAllSubscriptionStatusesAsync(string transactionId,
        IReadOnlyCollection<Status>? status = null,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/send_consumption_information
    Task SendConsumptionInformationAsync(string transactionId,
        AccountTenure accountTenure,
        string appAccountToken,
        ConsumptionStatus consumptionStatus,
        bool customerConsented,
        DeliveryStatus deliveryStatus,
        LifetimeDollarsPurchased lifetimeDollarsPurchased,
        LifetimeDollarsRefunded lifetimeDollarsRefunded,
        Platform platform,
        PlayTime playTime,
        RefundPreference refundPreference,
        bool sampleContentProvided,
        UserStatus userStatus,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/look_up_order_id
    Task<OrderLookupResponse> LookUpOrderIdAsync(string orderId, CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/get_refund_history
    Task<RefundHistoryResponse> GetRefundHistoryAsync(string transactionId,
        string? revision = null,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/extend_a_subscription_renewal_date
    Task<ExtendRenewalDateResponse> ExtendSubscriptionRenewalDateAsync(string originalTransactionId,
        int extendByDays,
        ExtendReasonCode extendReasonCode,
        string requestIdentifier,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/extend_subscription_renewal_dates_for_all_active_subscribers
    Task<MassExtendRenewalDateResponse> ExtendSubscriptionRenewalDatesForAllActiveSubscribersAsync(
        string requestIdentifier,
        int extendByDays,
        ExtendReasonCode extendReasonCode,
        string productId,
        IEnumerable<string>? storefrontCountryCodes = null,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/get_status_of_subscription_renewal_date_extensions
    Task<MassExtendRenewalDateStatusResponse> GetStatusOfSubscriptionRenewalDateExtensionsAsync(
        string productId,
        string requestIdentifier,
        CancellationToken ct = default);

    // https://developer.apple.com/documentation/appstoreserverapi/get_notification_history
    Task<NotificationHistoryResponse> GetNotificationHistoryAsync(
        DateTime startDate,
        DateTime endDate,
        NotificationType? notificationType = null,
        NotificationSubtype? notificationSubtype = null,
        bool onlyFailures = false,
        string? transactionId = null,
        string? paginationToken = null,
        CancellationToken ct = default);
}