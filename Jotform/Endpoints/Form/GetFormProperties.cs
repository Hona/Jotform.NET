namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Get a list of all properties (https://api.jotform.com/docs/properties/index.php) on a form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public Task<JotformResult<FormProperties>?> GetFormPropertiesAsync(string formId, CancellationToken cancellationToken = default)
        => GetResultAsync<FormProperties>($"form/{formId}/properties",
            cancellationToken);
}

public class Coupon
{
    [JsonPropertyName("apply")]
    public string Apply { get; set; } = null!;

    [JsonPropertyName("code")]
    public string Code { get; set; } = null!;

    [JsonPropertyName("gatewayType")]
    public string GatewayType { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("limit")]
    public string Limit { get; set; } = null!;

    [JsonPropertyName("products")]
    public string Products { get; set; } = null!;

    [JsonPropertyName("rate")]
    public string Rate { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
}

public class Email
{
    [JsonPropertyName("body")]
    public string Body { get; set; } = null!;

    [JsonPropertyName("branding21Email")]
    public bool Branding21Email { get; set; }

    [JsonPropertyName("dirty")]
    public string Dirty { get; set; } = null!;

    [JsonPropertyName("from")]
    public string From { get; set; } = null!;

    [JsonPropertyName("hideEmptyFields")]
    public bool HideEmptyFields { get; set; }

    [JsonPropertyName("html")]
    public bool Html { get; set; }

    [JsonPropertyName("lastQuestionID")]
    public string LastQuestionID { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("pdfattachment")]
    public bool Pdfattachment { get; set; }

    [JsonPropertyName("pdfId")]
    public string PdfId { get; set; } = null!;

    [JsonPropertyName("replyTo")]
    public string ReplyTo { get; set; } = null!;

    [JsonPropertyName("sendOnEdit")]
    public bool SendOnEdit { get; set; }

    [JsonPropertyName("sendOnSubmit")]
    public bool SendOnSubmit { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = null!;

    [JsonPropertyName("to")]
    public string To { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("uniqueID")]
    public string UniqueID { get; set; } = null!;

    [JsonPropertyName("uploadAttachment")]
    public string UploadAttachment { get; set; } = null!;

    [JsonPropertyName("attachment")]
    public string Attachment { get; set; } = null!;

    [JsonPropertyName("sendDate")]
    public string SendDate { get; set; } = null!;
}

public class PaymentListSetting
{
    [JsonPropertyName("minTotalOrderAmount")]
    public int MinTotalOrderAmount { get; set; }

    [JsonPropertyName("productCategories")]
    public string ProductCategories { get; set; } = null!;

    [JsonPropertyName("productListLayout")]
    public string ProductListLayout { get; set; } = null!;

    [JsonPropertyName("showCategory")]
    public bool ShowCategory { get; set; }

    [JsonPropertyName("showCategoryTitle")]
    public bool ShowCategoryTitle { get; set; }

    [JsonPropertyName("showMinTotalOrderAmount")]
    public bool ShowMinTotalOrderAmount { get; set; }

    [JsonPropertyName("showSearch")]
    public bool ShowSearch { get; set; }

    [JsonPropertyName("showSorting")]
    public bool ShowSorting { get; set; }
}
public class Product
{
    [JsonPropertyName("connectedCategories")]
    public string ConnectedCategories { get; set; } = null!;

    [JsonPropertyName("connectedProducts")]
    public string ConnectedProducts { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("fitImageToCanvas")]
    public bool FitImageToCanvas { get; set; }

    [JsonPropertyName("hasExpandedOption")]
    public string HasExpandedOption { get; set; } = null!;

    [JsonPropertyName("hasQuantity")]
    public string HasQuantity { get; set; } = null!;

    [JsonPropertyName("hasSpecialPricing")]
    public string HasSpecialPricing { get; set; } = null!;

    [JsonPropertyName("icon")]
    public string Icon { get; set; } = null!;

    [JsonPropertyName("images")]
    public string Images { get; set; } = null!;

    [JsonPropertyName("isLowStockAlertEnabled")]
    public bool IsLowStockAlertEnabled { get; set; }

    [JsonPropertyName("isStockControlEnabled")]
    public bool IsStockControlEnabled { get; set; }

    [JsonPropertyName("lowStockValue")]
    public string LowStockValue { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("options")]
    public string Options { get; set; } = null!;

    [JsonPropertyName("pid")]
    public string Pid { get; set; } = null!;

    [JsonPropertyName("price")]
    public string Price { get; set; } = null!;

    [JsonPropertyName("required")]
    public bool Required { get; set; }

    [JsonPropertyName("selected")]
    public bool Selected { get; set; }
}

public class FormProperties
{
    [JsonPropertyName("activeRedirect")]
    public string ActiveRedirect { get; set; } = null!;

    [JsonPropertyName("alignment")]
    public string Alignment { get; set; } = null!;

    [JsonPropertyName("allowSubmissionEdit")]
    public bool AllowSubmissionEdit { get; set; }

    [JsonPropertyName("attachInvoice")]
    public bool AttachInvoice { get; set; }

    [JsonPropertyName("background")]
    public string Background { get; set; } = null!;

    [JsonPropertyName("cardThemeID")]
    public string CardThemeID { get; set; } = null!;

    [JsonPropertyName("clearFieldOnHide")]
    public string ClearFieldOnHide { get; set; } = null!;

    [JsonPropertyName("creationLanguage")]
    public string CreationLanguage { get; set; } = null!;

    [JsonPropertyName("datetimeMigrationStatus")]
    public string DatetimeMigrationStatus { get; set; } = null!;

    [JsonPropertyName("defaultAutoResponderEmailAssigned")]
    public bool DefaultAutoResponderEmailAssigned { get; set; }

    [JsonPropertyName("defaultEmailAssigned")]
    public bool DefaultEmailAssigned { get; set; }

    [JsonPropertyName("defaultTheme")]
    public string DefaultTheme { get; set; } = null!;

    [JsonPropertyName("emailsToAttachInvoice")]
    public string EmailsToAttachInvoice { get; set; } = null!;

    [JsonPropertyName("errorNavigation")]
    public bool ErrorNavigation { get; set; }

    [JsonPropertyName("expireDate")]
    public string ExpireDate { get; set; } = null!;

    [JsonPropertyName("font")]
    public string Font { get; set; } = null!;

    [JsonPropertyName("fontcolor")]
    public string Fontcolor { get; set; } = null!;

    [JsonPropertyName("fontsize")]
    public string Fontsize { get; set; } = null!;

    [JsonPropertyName("formStringsChanged")]
    public bool FormStringsChanged { get; set; }

    [JsonPropertyName("formType")]
    public string FormType { get; set; } = null!;

    [JsonPropertyName("formWidth")]
    public int FormWidth { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; } = null!;

    [JsonPropertyName("hideEmptySubmissionFields")]
    public bool HideEmptySubmissionFields { get; set; }

    [JsonPropertyName("hideMailEmptyFields")]
    public string HideMailEmptyFields { get; set; } = null!;

    [JsonPropertyName("hideNonInputSubmissionFields")]
    public bool HideNonInputSubmissionFields { get; set; }

    [JsonPropertyName("hideSubmissionHeader")]
    public bool HideSubmissionHeader { get; set; }

    [JsonPropertyName("highlightLine")]
    public string HighlightLine { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("injectCSS")]
    public string InjectCSS { get; set; } = null!;

    [JsonPropertyName("invoiceEnabled")]
    public bool InvoiceEnabled { get; set; }

    [JsonPropertyName("isEncrypted")]
    public bool IsEncrypted { get; set; }

    [JsonPropertyName("isPaymentStoreInBasicFields")]
    public bool IsPaymentStoreInBasicFields { get; set; }

    [JsonPropertyName("labelWidth")]
    public int LabelWidth { get; set; }

    [JsonPropertyName("lastQuestionID")]
    public string LastQuestionID { get; set; } = null!;

    [JsonPropertyName("limitSubmission")]
    public string LimitSubmission { get; set; } = null!;

    [JsonPropertyName("lineSpacing")]
    public int LineSpacing { get; set; }

    [JsonPropertyName("messageOfLimitedForm")]
    public string MessageOfLimitedForm { get; set; } = null!;

    [JsonPropertyName("mobileGoButton")]
    public string MobileGoButton { get; set; } = null!;

    [JsonPropertyName("newPaymentUIForNewCreatedForms")]
    public bool NewPaymentUIForNewCreatedForms { get; set; }

    [JsonPropertyName("optioncolor")]
    public string Optioncolor { get; set; } = null!;

    [JsonPropertyName("pageColor")]
    public string PageColor { get; set; } = null!;

    [JsonPropertyName("pagetitle")]
    public string Pagetitle { get; set; } = null!;

    [JsonPropertyName("pageTitleChanged")]
    public bool PageTitleChanged { get; set; }

    [JsonPropertyName("paymentStringsChanged")]
    public bool PaymentStringsChanged { get; set; }

    [JsonPropertyName("preventCloningForm")]
    public bool PreventCloningForm { get; set; }

    [JsonPropertyName("responsive")]
    public bool Responsive { get; set; }

    [JsonPropertyName("sendpostdata")]
    public bool Sendpostdata { get; set; }

    [JsonPropertyName("showJotFormLogo")]
    public bool ShowJotFormLogo { get; set; }

    [JsonPropertyName("showProgressBar")]
    public string ShowProgressBar { get; set; } = null!;

    [JsonPropertyName("styleJSON")]
    public string StyleJSON { get; set; } = null!;

    [JsonPropertyName("styles")]
    public string Styles { get; set; } = null!;

    [JsonPropertyName("submissionHeaders")]
    public string SubmissionHeaders { get; set; } = null!;

    [JsonPropertyName("submitError")]
    public string SubmitError { get; set; } = null!;

    [JsonPropertyName("thanktext")]
    public string Thanktext { get; set; } = null!;

    [JsonPropertyName("thankYouDownloadPDF")]
    public bool ThankYouDownloadPDF { get; set; }

    [JsonPropertyName("thankYouEditSubmission")]
    public bool ThankYouEditSubmission { get; set; }

    [JsonPropertyName("thankYouFillAgain")]
    public bool ThankYouFillAgain { get; set; }

    [JsonPropertyName("thankYouIconSrc")]
    public string ThankYouIconSrc { get; set; } = null!;

    [JsonPropertyName("thankYouImageSrc")]
    public string ThankYouImageSrc { get; set; } = null!;

    [JsonPropertyName("thankYouPageLayout")]
    public string ThankYouPageLayout { get; set; } = null!;

    [JsonPropertyName("thankYouSelectedPDFs")]
    public bool ThankYouSelectedPDFs { get; set; }

    [JsonPropertyName("themeID")]
    public string ThemeID { get; set; } = null!;

    [JsonPropertyName("unique")]
    public string Unique { get; set; } = null!;

    [JsonPropertyName("uniqueField")]
    public string UniqueField { get; set; } = null!;

    [JsonPropertyName("usesNewPDF")]
    public bool UsesNewPDF { get; set; }

    [JsonPropertyName("v4")]
    public bool V4 { get; set; }

    [JsonPropertyName("coupons")]
    public List<Coupon> Coupons { get; } = new List<Coupon>();

    [JsonPropertyName("emails")]
    public List<Email> Emails { get; } = new List<Email>();

    [JsonPropertyName("paymentListSettings")]
    public List<PaymentListSetting> PaymentListSettings { get; } = new List<PaymentListSetting>();

    [JsonPropertyName("paymentStrings")]
    public Dictionary<int, string> PaymentStrings { get; } = new();

    [JsonPropertyName("products")]
    public List<Product> Products { get; } = new List<Product>();

    [JsonPropertyName("submissionSettings")]
    public List<object> SubmissionSettings { get; } = new List<object>();

    [JsonPropertyName("integrations")]
    public List<object> Integrations { get; } = new List<object>();

    [JsonPropertyName("slug")]
    public string Slug { get; set; } = null!;

    [JsonPropertyName("owner")]
    public string Owner { get; set; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("height")]
    public string Height { get; set; } = null!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("formOwnerAccountType")]
    public string FormOwnerAccountType { get; set; } = null!;

    [JsonPropertyName("formOwnerName")]
    public string FormOwnerName { get; set; } = null!;

    [JsonPropertyName("isHIPAA")]
    public string IsHIPAA { get; set; } = null!;

    [JsonPropertyName("isEUForm")]
    public string IsEUForm { get; set; } = null!;
}