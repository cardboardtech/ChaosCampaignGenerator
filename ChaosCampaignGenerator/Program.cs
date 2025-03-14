using ChaosCampaignGenerator;

var generator = new ContractGenerator(new Dice());
var contract = generator.GenerateContract();

Console.WriteLine($@"
""Some new contracts just came our way, Commander. Take a look.""
{contract}");
