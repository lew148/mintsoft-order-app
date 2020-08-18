namespace mintsoft_order_app
{
    public static class MintSoftConstants
    {
        // these have been listed as constants by MintSoft
        public const int ProductId = 10587;
        public const int Quantity = 1;
        public const string Warehouse = "Main Warehouse";
        public const string CourierService = "DPD Next Day";
    }

    public static class ApiConstants
    {
        public const string ContentType = "application/json";
        public const string AuthQueryParams = "?ApiKey=";

        public const string MintSoftApiBaseUrl = "https://api.mintsoft.co.uk/api";
        public const string OrderUrl = MintSoftApiBaseUrl + "/Order";
        public const string AllCountriesUrl = MintSoftApiBaseUrl + "/RefData/Countries";
    }
}