using System.Text.Json.Serialization;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/notificationtype
[JsonConverter(typeof(JsonStringEnumConverter<NotificationType>))]
public enum NotificationType
{
    CONSUMPTION_REQUEST,
    DID_CHANGE_RENEWAL_PREF,
    DID_CHANGE_RENEWAL_STATUS,
    DID_FAIL_TO_RENEW,
    DID_RENEW,
    EXPIRED,
    EXTERNAL_PURCHASE_TOKEN,
    GRACE_PERIOD_EXPIRED,
    METADATA_UPDATE,
    MIGRATION,
    OFFER_REDEEMED,
    ONE_TIME_CHARGE,
    PRICE_CHANGE,
    PRICE_INCREASE,
    REFUND,
    REFUND_DECLINED,
    REFUND_REVERSED,
    RENEWAL_EXTENDED,
    RENEWAL_EXTENSION,
    REVOKE,
    SUBSCRIBED,
    TEST
}
