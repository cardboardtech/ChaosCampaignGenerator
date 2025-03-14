namespace ChaosCampaignGenerator;

public static class Tables
{
    public static class ContractTermsTable
    {
        public static Dictionary<int, string> BasePaySteps => new()
        {
            {1, "50%"},
            {2, "55%"},
            {3, "60%"},
            {4, "70%"},
            {5, "80%"},
            {6, "90%"},
            {7, "100%"},
            {8, "110%"},
            {9, "120%"},
            {10, "130%"},
            {11, "150%"},
            {12, "175%"},
            {13, "200%"}
        };

        public static Dictionary<int, string> CommandRightsSteps => new()
        {
            {3, "Integrated"},
            {7, "House"},
            {8, "Liaison"},
            {11, "Independent"}
        };

        public static Dictionary<int, string> SalvageRightsSteps => new()
        {
            {1, "None"},
            {3, "Exchange"},
            {4, "10%"},
            {5, "20%"},
            {6, "30%"},
            {7, "40%"},
            {8, "50%"},
            {9, "60%"},
            {10, "70%"},
            {11, "80%"},
            {12, "90%"},
            {13,"100%"}
        };

        public static Dictionary<int, string> SupportRightsSteps => new()
        {
            {1, "None"},
            {2, "Straight/20%"},
            {3, "Straight/40%"},
            {4, "Straight/60%"},
            {5, "Straight/80%"},
            {6, "Straight/100%"},
            {7, "Battle/10%"},
            {8, "Battle/20%"},
            {9, "Battle/30%"},
            {10, "Battle/40%"},
            {11, "Battle/50%"},
            {12, "Battle/75%"},
            {13,"Battle/100%"}
        };

        public static Dictionary<int, string> TransportationTermsSteps => new()
        {
            {5, "0%"},
            {6, "25%"},
            {7, "50%"},
            {8, "75%"},
            {9, "100%"}
        };
    }
}
