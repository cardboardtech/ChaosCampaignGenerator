using ChaosCampaignGenerator.Contracts;

namespace ChaosCampaignGenerator.Generators;

public class TrackGenerator
{
    private readonly Dice _dice;

    public TrackGenerator(Dice dice)
    {
        _dice = dice;
    }

    public void GenerateTracks(Contract contract)
    {
        int numberOfTracks = GetNumberOfTracks();

        for (int i = 0; i < numberOfTracks; i++)
        {
            Track track = contract switch
            {
                Raid => CreateRaidTrack(),
                Expedition => CreateExpeditionTrack(),
                Garrison => CreateGarrisonTrack(),
                Invasion => CreateInvasionTrack(),
                _ => throw new Exception()
            };
            track.Month = SetMonth();
            track.Mapsheets.AddRange(SetMapsheets());
            contract.Tracks.Add(track);
        }

        if (contract is PirateHunt pirateHunt)
        {
            GeneratePirateHuntRaidTracks(pirateHunt);
        }

        if (numberOfTracks == 0
            && contract is Garrison
            && contract.OpposingContract != null)
        {
            GenerateTracks(contract.OpposingContract);
        }

        //Local Functions
        int GetNumberOfTracks()
        {
            int roll = _dice.Roll(2);
            return contract switch
            {
                Raid or Expedition => roll switch
                {
                    <= 8 => 1,
                    >= 9 and <= 11 => 2,
                    >= 12 => 3
                },
                Garrison => roll switch
                {
                    <= 4 => 0,
                    >= 5 and <= 6 => 1,
                    >= 7 and <= 8 => 2,
                    >= 9 and <= 10 => 3,
                    11 => 4,
                    >= 12 => 5
                },
                Invasion => roll switch
                {
                    <= 5 => 2,
                    >= 6 and <= 7 => 3,
                    >= 8 and <= 9 => 4,
                    >= 10 and <= 11 => 5,
                    >= 12 => 6
                },
                _ => 0,
            };
        }

        void GeneratePirateHuntRaidTracks(PirateHunt pirateHunt)
        {
            for (int i = 0; i < numberOfTracks - 1; i++)
            {
                Track track = CreateRaidTrack();
                pirateHunt.RaidTracks.Add(track);
            }
        }

        int SetMonth()
        {
            int month = _dice.Roll(maxValue: contract.Length);
            if (contract.Tracks.Count(x => x.Month == month) >= 3)
            {
                return SetMonth();
            }

            return month;
        }

        IEnumerable<int> SetMapsheets()
        {
            List<int> maps = [1, 2, 3, 4, 5, 6];
            List<int> results = [];

            var random = new Random();
            for (int i = 0; i < contract.Scale; i++)
            {
                int sheet = random.Next(maps.Count - 1);
                results.Add(maps[sheet]);
                maps.RemoveAt(sheet);
            }

            return results;
        }
    }

    public Track CreateRaidTrack()
    {
        int attackerRoll = _dice.Roll();
        var track = new Track
        {
            TrackType = _dice.Roll() switch
            {
                1 => TrackType.Pushback,
                2 => TrackType.Breakthrough,
                3 => TrackType.Recon,
                4 => TrackType.Strike,
                5 or 6 => TrackType.ObjectiveRaid,
                _ => throw new Exception()
            },
            Attacker = attackerRoll >= 2 ? AttackerDefender.Primary : AttackerDefender.Opposition,
            Defender = attackerRoll >= 2 ? AttackerDefender.Opposition : AttackerDefender.Primary
        };
        return track;
    }

    public Track CreateExpeditionTrack()
    {
        var track = new Track
        {
            TrackType = _dice.Roll() switch
            {
                1 or 2 => TrackType.Recon,
                3 => TrackType.Pursuit,
                4 => TrackType.Flank,
                5 => TrackType.Strike,
                6 => TrackType.Retreat,
                _ => throw new Exception()
            }
        };

        track.Attacker = track.TrackType is TrackType.Recon or TrackType.Strike ? AttackerDefender.Primary : AttackerDefender.Opposition;
        track.Defender = track.Attacker == AttackerDefender.Primary ? AttackerDefender.Opposition : AttackerDefender.Primary;

        return track;
    }

    public Track CreateGarrisonTrack()
    {
        int attackerRoll = _dice.Roll();
        var track = new Track
        {
            TrackType = _dice.Roll() switch
            {
                1 or 6 => TrackType.Pursuit,
                2 => TrackType.MeetingEngagement,
                3 => TrackType.Recon,
                4 => TrackType.Pushback,
                5 => TrackType.Strike,
                _ => throw new Exception()
            },
            Attacker = attackerRoll >= 2 ? AttackerDefender.Opposition : AttackerDefender.Primary,
            Defender = attackerRoll >= 2 ? AttackerDefender.Primary : AttackerDefender.Opposition
        };
        return track;
    }

    public Track CreateInvasionTrack()
    {
        int attackerRoll = _dice.Roll();
        var track = new Track
        {
            TrackType = _dice.Roll() switch
            {
                1 => TrackType.Assault,
                2 => TrackType.Breakthrough,
                3 => TrackType.Flank,
                4 or 5 => TrackType.MeetingEngagement,
                6 => TrackType.Pushback,
                _ => throw new Exception()
            },
            Attacker = attackerRoll >= 3 ? AttackerDefender.Primary : AttackerDefender.Opposition,
            Defender = attackerRoll >= 3 ? AttackerDefender.Opposition : AttackerDefender.Primary
        };
        return track;
    }
}
