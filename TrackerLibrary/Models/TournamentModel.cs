﻿namespace TrackerLibrary.Models;

/// <summary>
/// Represents one tournament, with all of the rounds, mathcups, prizes and outcomes.
/// </summary>
public class TournamentModel
{
    public event EventHandler<DateTime> OnTournamentComplete;

    /// <summary>
    /// The unique identifier for the torunament.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name given to this tournament.
    /// </summary>
    public string TournamentName { get; set; }
    /// <summary>
    /// The amount of money each team needs to put up to enter.
    /// </summary>
    public decimal EntryFee { get; set; }
    /// <summary>
    /// The set of teams that have entered.
    /// </summary>
    public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
    /// <summary>
    /// The list of prizes for the various places.
    /// </summary>
    public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
    /// <summary>
    /// The metchups per round.
    /// </summary>
    public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

    public void CompleteTournament()
    {
        OnTournamentComplete?.Invoke(this, DateTime.Now);
    }
}
