using ChaosCampaignGenerator.Contracts;

namespace ChaosCampaignGenerator;

public class ContractWriter
{
    private const string _trackFormat = "{0, -5} {1,-18} {2, -12} {3, -12} {4}";

    public void WriteToConsole(List<Contract> contracts)
    {
        int contractNumber = 1;
        foreach (Contract contract in contracts)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Primary Contract {contractNumber} - {contract}");

            WriteContract(contract);

            if (contract.OpposingContract != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Opposing Contract {contractNumber} - {contract.OpposingContract}");

                WriteContract(contract.OpposingContract);
            }

            Console.WriteLine();
            contractNumber++;
        }

        Console.WriteLine("--------------------");

        //Local Function
        void WriteContract(Contract contract)
        {
            string contractTermsString = GetContractTermsString(contract);
            Console.WriteLine(contractTermsString);

            if (contract.Tracks.Count > 0)
            {
                PirateHunt? pirateHunt = contract as PirateHunt;

                Console.WriteLine();
                Console.WriteLine(string.Format(_trackFormat, "Month", pirateHunt == null ? "Tracks" : "Expedition Tracks", "Attacker", "Defender", "Mapsheets"));
                foreach (Track track in contract.Tracks.OrderBy(x => x.Month))
                {
                    Console.WriteLine(GetTrackString(track, contract.Terrain));
                }

                if (pirateHunt != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Raid Tracks");
                    foreach (Track track in pirateHunt.RaidTracks)
                    {
                        Console.WriteLine(GetTrackString(track, contract.Terrain));
                    }
                }
            }
        }
    }

    private static string GetContractTermsString(Contract contract)
    {
        string contractString =
$@"Employer: {contract.Employer}
Type of Action: {contract}
Length of Contract: {contract.Length} months
Location (Primary Terrain): {contract.Terrain}
Intensity (Number of Tracks): {contract.Tracks.Count}

Base Pay: {Tables.ContractTermsTable.BasePaySteps[contract.BasePay]} ({contract.BasePay})
Support: {Tables.ContractTermsTable.SupportRightsSteps[contract.SupportRights]} ({contract.SupportRights})
Transportation: {Tables.ContractTermsTable.TransportationTermsSteps[contract.TransportationTerms]} ({contract.TransportationTerms})
Salvage Rights: {Tables.ContractTermsTable.SalvageRightsSteps[contract.SalvageRights]} ({contract.SalvageRights})
Command Rights: {Tables.ContractTermsTable.CommandRightsSteps[contract.CommandRights]} ({contract.CommandRights})";

        return contractString;
    }

    private static string GetTrackString(Track track, TerrainType terrain)
    {
        string trackString = string.Format(_trackFormat,
            track.Month,
            track.TrackType,
            track.Attacker,
            track.Defender,
            string.Join(" | ", track.Mapsheets.Select(x => Tables.TerrainTables.Terrain[terrain][x])));

        return trackString;
    }
}
