using System.Text.Json.Serialization;

using AppStoreServerApi.Json;

namespace AppStoreServerApi.Models;

// https://developer.apple.com/documentation/appstoreservernotifications/subtype
[JsonConverter(typeof(RawStringConverter<Subtype>))]
public record Subtype(string RawValue) : IRawString<Subtype>
{
    public static readonly Subtype Accepted = new("ACCEPTED");
    public static readonly Subtype AutoRenewDisabled = new("AUTO_RENEW_DISABLED");
    public static readonly Subtype AutoRenewEnabled = new("AUTO_RENEW_ENABLED");
    public static readonly Subtype BillingRecovery = new("BILLING_RECOVERY");
    public static readonly Subtype BillingRetry = new("BILLING_RETRY");
    public static readonly Subtype Downgrade = new("DOWNGRADE");
    public static readonly Subtype Failure = new("FAILURE");
    public static readonly Subtype GracePeriod = new("GRACE_PERIOD");
    public static readonly Subtype InitialBuy = new("INITIAL_BUY");
    public static readonly Subtype Pending = new("PENDING");
    public static readonly Subtype PriceIncrease = new("PRICE_INCREASE");
    public static readonly Subtype ProductNotForSale = new("PRODUCT_NOT_FOR_SALE");
    public static readonly Subtype Resubscribe = new("RESUBSCRIBE");
    public static readonly Subtype Summary = new("SUMMARY");
    public static readonly Subtype Upgrade = new("UPGRADE");
    public static readonly Subtype Unreported = new("UNREPORTED");
    public static readonly Subtype Voluntary = new("VOLUNTARY");

    static Subtype IRawString<Subtype>.FromRaw(string rawValue) => new(rawValue);
    string IRawString<Subtype>.IntoRaw() => RawValue;
}
