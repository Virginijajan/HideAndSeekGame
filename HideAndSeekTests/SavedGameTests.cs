using HideAndSeek;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeekTests
{
    [TestClass]
    public class SavedGameTests
    {
        GameController gameController;
        [TestInitialize]
        public void Initialize()
        {
            gameController = new GameController();
        }
        [TestMethod]
        public void TestSaveLoadGame()
        {
            House.ClearHidingPlaces();
            var bathroom = House.GetLocationByName("Bathroom") as LocationWithHidingPlace;
            bathroom.Hide(gameController.Opponents.ToList()[0]);

            var kitchen = House.GetLocationByName("Kitchen") as LocationWithHidingPlace;
            kitchen.Hide(gameController.Opponents.ToList()[1]);

            var attic = House.GetLocationByName("Attic") as LocationWithHidingPlace;
            attic.Hide(gameController.Opponents.ToList()[2]);

            var garage = House.GetLocationByName("Garage") as LocationWithHidingPlace;
            garage.Hide(gameController.Opponents.ToList()[3]);

            var pantry = House.GetLocationByName("Pantry") as LocationWithHidingPlace;
            pantry.Hide(gameController.Opponents.ToList()[4]);

            gameController.ParseInput("Out");
            gameController.ParseInput("check");

            Assert.AreEqual("You are in the Garage. You see the following exits:" +
            Environment.NewLine + " - the Entry is In" +
            Environment.NewLine + "Someone could hide behind the car" +
            Environment.NewLine + "You have found 1 of 5 opponents: Owen",
            gameController.Status);

            Assert.AreEqual("Saved current game to file_name1", gameController.ParseInput("Save    file_name1 "));

            Assert.AreEqual("Garage", gameController.savedGame.PlayersLocation);
            Assert.AreEqual(4, gameController.savedGame.HidingOpponents.Count);
            Assert.AreEqual("Bathroom", gameController.savedGame.HidingOpponents["Joe"]);
            Assert.AreEqual("Kitchen", gameController.savedGame.HidingOpponents["Bob"]);
            Assert.AreEqual("Owen", gameController.savedGame.FoundOpponentsNames[0]);
            Assert.AreEqual(1, gameController.savedGame.FoundOpponentsNames.Count);
            Assert.AreEqual(3, gameController.savedGame.MoveNumber);

            Assert.AreEqual("You are in the Entry. You see the following exits:" +
            Environment.NewLine + " - the Hallway is to the East" +
            Environment.NewLine + " - the Garage is Out" +
            Environment.NewLine + "You have not found any opponents",
            gameController.Status);

            Assert.AreEqual("1: Which direction do you want to go (or type 'check'): ", gameController.Prompt);
            Assert.AreEqual("Entry", gameController.CurrentLocation.Name);
            Assert.AreEqual(1, gameController.MoveNumber);


            House.ClearHidingPlaces();

            Assert.AreEqual("Invalid file name", gameController.ParseInput("Load file_name2"));
            Assert.AreEqual("Loaded game from file_name1", gameController.ParseInput("Load file_name1  "));
           

            Assert.AreEqual("Garage", gameController.CurrentLocation.Name);
            Assert.AreEqual(1, gameController.foundOpponents.Count);
            Assert.AreEqual(5, gameController.Opponents.Count());
            Assert.AreEqual("Owen", gameController.foundOpponents[0].Name);

            var location = House.GetLocationByName("Bathroom");
        Assert.AreEqual("Joe",(location as LocationWithHidingPlace).Opponents[0].Name);

            var location1 = House.GetLocationByName("Kitchen");
        Assert.AreEqual("Bob", (location1 as LocationWithHidingPlace).Opponents[0].Name);

            var location2 = House.GetLocationByName("Attic");
        Assert.AreEqual("Ana", (location2 as LocationWithHidingPlace).Opponents[0].Name);

            var location3 = House.GetLocationByName("Pantry");
        Assert.AreEqual("Jimmy", (location3 as LocationWithHidingPlace).Opponents[0].Name);

            Assert.AreEqual(3, gameController.MoveNumber);

            Assert.AreEqual("You are in the Garage. You see the following exits:" +
            Environment.NewLine + " - the Entry is In" +
            Environment.NewLine + "Someone could hide behind the car" +
            Environment.NewLine + "You have found 1 of 5 opponents: Owen",
            gameController.Status);


            Assert.AreEqual("Saved current game to file_name1", gameController.ParseInput("Save file_name1"));

           Assert.AreEqual("You are in the Entry. You see the following exits:" +
           Environment.NewLine + " - the Hallway is to the East" +
           Environment.NewLine + " - the Garage is Out" +
           Environment.NewLine + "You have not found any opponents",
           gameController.Status);

            Assert.AreEqual("Loaded game from file_name1", gameController.ParseInput("Load file_name1"));

           Assert.AreEqual("You are in the Garage. You see the following exits:" +
           Environment.NewLine + " - the Entry is In" +
           Environment.NewLine + "Someone could hide behind the car" +
           Environment.NewLine + "You have found 1 of 5 opponents: Owen",
           gameController.Status);
        }

        

    }
}
