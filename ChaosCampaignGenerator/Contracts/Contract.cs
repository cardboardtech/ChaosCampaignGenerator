using ChaosCampaignGenerator.Employers;

namespace ChaosCampaignGenerator.Contracts;

public abstract class Contract
{
    public Employer Employer { get; set; }
    public int Length { get; set; }
    public int BasePay { get; set; }
    public int CommandRights { get; set; }
    public int SalvageRights { get; set; }
    public int SupportRights { get; set; }
    public int TransportationTerms { get; set; }
    public virtual int BasePayModifier { get; }
    public virtual int CommandRightsModifier { get; }
    public virtual int SalvageRightsModifier { get; }
    public virtual int SupportRightsModifier { get; }
    public virtual int TransportationTermsModifier { get; }

    public Contract()
    {
        Employer = new Self();
    }

    public override string ToString()
    {
        return $@"
Employer: {Employer}
Type of Action: {GetType().Name}
Length of Contract: {Length} months
Base Pay: {Tables.ContractTermsTable.BasePaySteps[BasePay]} ({BasePay})
Support: {Tables.ContractTermsTable.SupportRightsSteps[SupportRights]} ({SupportRights})
Transportation: {Tables.ContractTermsTable.TransportationTermsSteps[TransportationTerms]} ({TransportationTerms})
Salvage Rights: {Tables.ContractTermsTable.SalvageRightsSteps[SalvageRights]} ({SalvageRights})
Command Rights: {Tables.ContractTermsTable.CommandRightsSteps[CommandRights]} ({CommandRights})";
    }
}
