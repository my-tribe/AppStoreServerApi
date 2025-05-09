using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/subtype
[JsonConverter(typeof(JsonStringEnumConverter<Subtype>))]
public enum Subtype
{
    ACCEPTED,
    AUTO_RENEW_DISABLED,
    AUTO_RENEW_ENABLED,
    BILLING_RECOVERY,
    BILLING_RETRY,
    DOWNGRADE,
    FAILURE,
    GRACE_PERIOD,
    INITIAL_BUY,
    PENDING,
    PRICE_INCREASE,
    PRODUCT_NOT_FOR_SALE,
    RESUBSCRIBE,
    SUMMARY,
    UPGRADE,
    UNREPORTED,
    VOLUNTARY
}
