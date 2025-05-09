using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/notificationtype
[JsonConverter(typeof(RawStringConverter<NotificationType>))]
public record NotificationType(string RawValue) : IRawString<NotificationType>
{
    public static readonly NotificationType ConsumptionRequest = new("CONSUMPTION_REQUEST");
    public static readonly NotificationType DidChangeRenewalPref = new("DID_CHANGE_RENEWAL_PREF");
    public static readonly NotificationType DidChangeRenewalStatus = new("DID_CHANGE_RENEWAL_STATUS");
    public static readonly NotificationType DidFailToRenew = new("DID_FAIL_TO_RENEW");
    public static readonly NotificationType DidRenew = new("DID_RENEW");
    public static readonly NotificationType Expired = new("EXPIRED");
    public static readonly NotificationType ExternalPurchaseToken = new("EXTERNAL_PURCHASE_TOKEN");
    public static readonly NotificationType GracePeriodExpired = new("GRACE_PERIOD_EXPIRED");
    public static readonly NotificationType MetadataUpdate = new("METADATA_UPDATE");
    public static readonly NotificationType Migration = new("MIGRATION");
    public static readonly NotificationType OfferRedeemed = new("OFFER_REDEEMED");
    public static readonly NotificationType OneTimeCharge = new("ONE_TIME_CHARGE");
    public static readonly NotificationType PriceChange = new("PRICE_CHANGE");
    public static readonly NotificationType PriceIncrease = new("PRICE_INCREASE");
    public static readonly NotificationType Refund = new("REFUND");
    public static readonly NotificationType RefundDeclined = new("REFUND_DECLINED");
    public static readonly NotificationType RefundReversed = new("REFUND_REVERSED");
    public static readonly NotificationType RenewalExtended = new("RENEWAL_EXTENDED");
    public static readonly NotificationType RenewalExtension = new("RENEWAL_EXTENSION");
    public static readonly NotificationType Revoke = new("REVOKE");
    public static readonly NotificationType Subscribed = new("SUBSCRIBED");
    public static readonly NotificationType Test = new("TEST");

    static NotificationType IRawString<NotificationType>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<NotificationType>.IntoRaw() => RawValue;
}
