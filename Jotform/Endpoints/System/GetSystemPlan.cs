namespace Jotform;

public partial class JotformClient
{
    public Task<JotformResult<SystemPlan>?> GetSystemPlanAsync(SystemPlanType plan, CancellationToken cancellationToken = default)
        => GetResultAsync<SystemPlan>($"system/plan/{plan.ToString()
            .ToUpper()}", cancellationToken);
}

public enum SystemPlanType
{
    Free,
    Bronze,
    Silver,
    Gold,
    Platinum
}

public class AnnualPlans
    {
        [JsonPropertyName("monthly")]
        public int? Monthly { get; set; }

        [JsonPropertyName("yearly")]
        public int? Yearly { get; set; }

        [JsonPropertyName("biyearly")]
        public int? Biyearly { get; set; }
    }

    public class Campaigns
    {
        [JsonPropertyName("annualPlans")]
        public AnnualPlans AnnualPlans { get; set; }
    }

    public class Emails
    {
        [JsonPropertyName("reminderEmailBlocks")]
        public int? ReminderEmailBlocks { get; set; }
    }

    public class FastSpringURLs
    {
        [JsonPropertyName("monthly")]
        public string Monthly { get; set; }

        [JsonPropertyName("yearly")]
        public string Yearly { get; set; }

        [JsonPropertyName("biyearly")]
        public string Biyearly { get; set; }
    }

    public class Limits
    {
        [JsonPropertyName("submissions")]
        public int? Submissions { get; set; }

        [JsonPropertyName("overSubmissions")]
        public int? OverSubmissions { get; set; }

        [JsonPropertyName("sslSubmissions")]
        public int? SslSubmissions { get; set; }

        [JsonPropertyName("payments")]
        public int? Payments { get; set; }

        [JsonPropertyName("uploads")]
        public long? Uploads { get; set; }

        [JsonPropertyName("tickets")]
        public int? Tickets { get; set; }

        [JsonPropertyName("subusers")]
        public int? Subusers { get; set; }

        [JsonPropertyName("api-daily-limit")]
        public int? ApiDailyLimit { get; set; }

        [JsonPropertyName("views")]
        public int? Views { get; set; }

        [JsonPropertyName("formCount")]
        public int? FormCount { get; set; }

        [JsonPropertyName("hipaaCompliance")]
        public bool? HipaaCompliance { get; set; }

        [JsonPropertyName("emails")]
        public Emails Emails { get; set; }

        [JsonPropertyName("signedDocuments")]
        public int? SignedDocuments { get; set; }
    }

    public class NonProfit
    {
        [JsonPropertyName("monthly")]
        public double? Monthly { get; set; }

        [JsonPropertyName("yearly")]
        public int? Yearly { get; set; }

        [JsonPropertyName("biyearly")]
        public int? Biyearly { get; set; }
    }

    public class OnSale
    {
        [JsonPropertyName("prices")]
        public Prices Prices { get; set; }

        [JsonPropertyName("plimusIDs")]
        public PlimusIDs PlimusIDs { get; set; }

        [JsonPropertyName("nonProfit")]
        public NonProfit NonProfit { get; set; }

        [JsonPropertyName("campaigns")]
        public Campaigns Campaigns { get; set; }
    }

    public class PlimusIDs
    {
        [JsonPropertyName("monthly")]
        public int? Monthly { get; set; }

        [JsonPropertyName("yearly")]
        public int? Yearly { get; set; }

        [JsonPropertyName("biyearly")]
        public int? Biyearly { get; set; }

        [JsonPropertyName("biyearly-single")]
        public int? BiyearlySingle { get; set; }
    }

    public class Prices
    {
        [JsonPropertyName("monthly")]
        public int? Monthly { get; set; }

        [JsonPropertyName("yearly")]
        public int? Yearly { get; set; }

        [JsonPropertyName("biyearly")]
        public int? Biyearly { get; set; }
    }

    public class SystemPlan
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("limits")]
        public Limits Limits { get; set; }

        [JsonPropertyName("prices")]
        public Prices Prices { get; set; }

        [JsonPropertyName("fastSpringURLs")]
        public FastSpringURLs FastSpringURLs { get; set; }

        [JsonPropertyName("onSale")]
        public OnSale OnSale { get; set; }

        [JsonPropertyName("planType")]
        public string PlanType { get; set; }

        [JsonPropertyName("currentPlanType")]
        public string CurrentPlanType { get; set; }
    }