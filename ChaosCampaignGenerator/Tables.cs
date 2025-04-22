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

    public static class TerrainTables
    {
        public static Dictionary<TerrainType, Dictionary<int, string>> Terrain => new()
        {
            { TerrainType.Alien, Alien },
            { TerrainType.Desert, Desert },
            { TerrainType.Grasslands, Grasslands },
            { TerrainType.Hills, Hills },
            { TerrainType.LightUrban, LightUrban },
            { TerrainType.Mountains, Mountains },
            { TerrainType.Savannahs, Savannahs },
            { TerrainType.Urban, Urban },
            { TerrainType.Wetlands, Wetlands },
            { TerrainType.Wooded, Wooded }
        };

        public static Dictionary<int, string> Alien => new()
        {
            {1, "Fungal Crevasse (MP: Alien Worlds)"},
            {2, "Caustic Valley (MP: Alien Worlds)"},
            {3, "Crystalline Canyon (MP: Alien Worlds)"},
            {4, "Lunar Base (MP: Alien Worlds)"},
            {5, "Crystalline Canyon (MP: Alien Worlds)"},
            {6, "Caustic Valley (MP: Alien Worlds)"}
        };

        public static Dictionary<int, string> Desert => new()
        {
            {1, "Badlands #1 (MP: Deserts)"},
            {2, "Badlands #2 (MP: Deserts)"},
            {3, "Desert #2 (AGOAC)"},
            {4, "Sand Drifts #1 (MP: Deserts)"},
            {5, "Barren Lands #1 (CI)"},
            {6, "Barren Lands #2 (CI)"}
        };

        public static Dictionary<int, string> Grasslands => new()
        {
            {1, "Grassland #1 (BB)"},
            {2, "Grassland #2 (AGOAC)"},
            {3, "Grassland #3 (AGOAC)"},
            {4, "Desert #1 (BB)"},
            {5, "Open Terrain #2 (MP: Grasslands)"},
            {6, "Open Terrain #3 (MP: Grasslands)"}
        };

        public static Dictionary<int, string> Hills => new()
        {
            {1, "Hilltops #1 (CI)"},
            {2, "Hilltops #2 (CI)"},
            {3, "Rolling Hills #1 (MP: Grasslands)"},
            {4, "Rolling Hills #2 (MP: Grasslands, CI)"},
            {5, "Rolling Hills #3 (MP: Grasslands)"},
            {6, "Rolling HIlls #4 (MP: Grasslands)"}
        };

        public static Dictionary<int, string> LightUrban => new()
        {
            {1, "River CommCenter (MP: Grasslands)"},
            {2, "Park District (MP: City)"},
            {3, "Central Park (MP: City)"},
            {4, "AeroBase #1 (MP: Deserts)"},
            {5, "AeroBase #2 (MP: Deserts)"},
            {6, "Roundabout (MP: City)"}
        };

        public static Dictionary<int, string> Mountains => new()
        {
            {1, "Foothills #1 (MP: Grasslands)"},
            {2, "Foothills #2 (MP: Grasslands)"},
            {3, "Washout #1 (MP: Deserts)"},
            {4, "Washout #2 (MP: Deserts)"},
            {5, "Mines #1 (MP: Deserts)"},
            {6, "Mines #2 (MP: Deserts)"}
        };

        public static Dictionary<int, string> Savannahs => new()
        {
            {1, "River Delta / Drainage Basin #1 (MP: Savannahs)"},
            {2, "River Delta / Drainage Basin #2 (MP: Savannahs)"},
            {3, "Large Lakes #1 (MP: Savannahs)"},
            {4, "Large Lakes #2 (MP: Savannahs)"},
            {5, "BattleTech (MP: Savannahs)"},
            {6, "City Ruins (MP: Savannahs)"}
        };

        public static Dictionary<int, string> Urban => new()
        {
            {1, "Corporate Campus (MP: City)"},
            {2, "Family Quarters (MP: City)"},
            {3, "HPG Heliport (MP: City)"},
            {4, "Business District (MP: City)"},
            {5, "Shopping District (MP: City)"},
            {6, "HPG Offices (MP: City)"}
        };

        public static Dictionary<int, string> Wetlands => new()
        {
            {1, "Streams (MP: Grasslands)"},
            {2, "Wide River (MP: Savannahs)"},
            {3, "Lakes (MP: Grasslands)"},
            {4, "Grasslands #2 (AGOAC)"},
            {5, "Oasis (MP: Deserts)"},
            {6, "Open Terrain #3 (MP: Grasslands)"}
        };

        public static Dictionary<int, string> Wooded => new()
        {
            {1, "Woodland (MP: Grasslands)"},
            {2, "Scattered Woods (MP: Grasslands)"},
            {3, "Grassland #3 (AGOAC)"},
            {4, "Rolling Hills #2 (MP: Grasslands, CI)"},
            {5, "Desert #3 (AGOAC)"},
            {6, "Rolling Hills #1 (MP: Grasslands)"}
        };
    }
}
