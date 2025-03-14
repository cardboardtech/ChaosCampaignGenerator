using ChaosCampaignGenerator.Contracts;
using ChaosCampaignGenerator.Employers;

namespace ChaosCampaignGenerator;

public class ContractGenerator
{
    private readonly Dice _dice;

    public ContractGenerator(Dice dice)
    {
        _dice = dice;
    }

    public Contract GenerateContract()
    {
        Contract contract = GetContractType();
        Employer employer = GetEmployer();

        contract.Employer = employer;
        contract.BasePay = GetBasePay(contract.BasePayModifier, employer.BasePayModifier);
        contract.CommandRights = GetCommandRights(contract.CommandRightsModifier, employer.CommandRightsModifier);
        contract.SalvageRights = GetSalvageRights(contract.SalvageRightsModifier, employer.SalvageRightsModifier);
        contract.SupportRights = GetSupportRights(contract.SupportRightsModifier, employer.SupportRightsModifier);
        contract.TransportationTerms = GetTransportationTerms(contract.TransportationTermsModifier, employer.TransportationTermsModifier);

        return contract;
    }

    private Contract GetContractType()
    {
        Contract contractType = _dice.Roll(2) switch
        {
            <= 4 => GetExpeditionType(),
            >= 5 and <= 6 => GetGarrisonType(),
            >= 7 and <= 9 => new Raid(),
            >= 10 => new Invasion()
        };
        return contractType;

        //local functions
        Contract GetExpeditionType()
        {
            Contract expedition = _dice.Roll(2) switch
            {
                <= 8 => new Expedition(),
                >= 9 and <= 11 => new PirateHunt(),
                >= 12 => new GuerillaOperation()
            };
            return expedition;
        }

        Contract GetGarrisonType()
        {
            Contract garrison = _dice.Roll(2) switch
            {
                <= 5 => new CadreDuty(),
                >= 6 => new Garrison()
            };
            return garrison;
        }
    }

    private Employer GetEmployer()
    {
        Employer employer = _dice.Roll(2) switch
        {
            2 => new CivilianOrganization(),
            3 or 10 => new PlanetaryGovernment(),
            4 or 12 => new MercenarySubcontract(),
            5 or 9 => new Corporation(),
            6 or 7 or 11 => new HouseGovernment(),
            8 => new Noble(),
            _ => throw new Exception()
        };
        return employer;
    }

    private int GetBasePay(int contractModfier, int employerModifier)
    {
        int payRateStep = _dice.Roll(2) switch
        {
            <= 3 => 3,
            >= 4 and <= 5 => 4,
            >= 6 and <= 7 => 5,
            >= 8 and <= 9 => 6,
            >= 10 and <= 11 => 7,
            >= 12 => 8
        };

        return payRateStep + contractModfier + employerModifier;
    }

    private int GetCommandRights(int contractModifier, int employerModifier)
    {
        int commandRightsStep = _dice.Roll(2) switch
        {
            <= 5 => 3,
            >= 6 and <= 7 => 7,
            >= 8 and <= 9 => 8,
            >= 10 => 11
        };
        int adjustedStep = commandRightsStep + contractModifier + employerModifier;

        return adjustedStep switch
        {
            <= 3 => 3,
            >= 4 and <= 7 => 7,
            >= 8 and <= 11 => 8,
            >= 11 => 11
        };
    }

    private int GetSalvageRights(int contractModfier, int employerModifier)
    {
        int salvageRightsStep = _dice.Roll(2) switch
        {
            <= 5 => 3,
            >= 6 and <= 7 => 4,
            >= 8 and <= 9 => 5,
            >= 10 and <= 11 => 6,
            >= 12 => 7
        };
        int adjustedStep = salvageRightsStep + contractModfier + employerModifier;

        return adjustedStep switch
        {
            < 1 => 1,
            2 => 3,
            _ => adjustedStep
        };
    }

    private int GetSupportRights(int contractModfier, int employerModifier)
    {
        int supportRightsStep = _dice.Roll(2) switch
        {
            <= 5 => 3,
            >= 6 and <= 7 => 4,
            >= 8 and <= 9 => 5,
            >= 10 and <= 11 => 6,
            >= 12 => 7
        };
        int adjustedStep = supportRightsStep + contractModfier + employerModifier;

        return adjustedStep;
    }

    private int GetTransportationTerms(int contractModfier, int employerModifier)
    {
        int transportationTermsStep = _dice.Roll(2) switch
        {
            <= 5 => 5,
            >= 6 and <= 7 => 6,
            >= 8 and <= 9 => 7,
            >= 10 and <= 11 => 8,
            >= 12 => 9
        };
        int adjustedStep = transportationTermsStep + contractModfier + employerModifier;

        return adjustedStep switch
        {
            < 5 => 5,
            > 9 => 9,
            _ => adjustedStep
        };
    }
}
