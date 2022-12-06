﻿using TrackerLibrary.DataAccess.TextHelpers;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

public class TextConnector : IDataConnection
{
    private const string PrizesFile = "PrizeModels.csv";

    // TODO - Wire up the CreatePrize for text files.
    public PrizeModel CreatePrize(PrizeModel model)
    {
        // Load the text file and convert the text to List<PrizeModel>
        List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConcertToPrizeModels();

        // Find the max ID
        int currentId = 1;

        if (prizes.Count > 0)
        {
            currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
        }

        model.Id = currentId;

        // Add the new record with the new ID (max + 1)
        prizes.Add(model);

        // Convert the prizes to List<string>
        // Save the List<string> to the text file
        prizes.SaveToPrizeFile(PrizesFile);

        return model;
    }
}
