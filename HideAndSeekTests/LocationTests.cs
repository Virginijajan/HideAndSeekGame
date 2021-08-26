using HideAndSeek;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HideAndSeekTests
{
    [TestClass]
    public class LocationTests
    {
        private Location center;
        [TestInitialize]
        public void Initialize()
        {
            center = new Location("Center Room");
            Assert.AreSame("Center Room", center.ToString());
            Assert.AreEqual(0, center.ExitList.Count());

            center.AddExit(Direction.North, new Location("North Room"));
            center.AddExit(Direction.Northeast, new Location("Northeast Room"));
            center.AddExit(Direction.Northwest, new Location("Northwest Room"));
            center.AddExit(Direction.South, new Location("South Room"));
            center.AddExit(Direction.Southwest, new Location("Southwest Room"));
            center.AddExit(Direction.Southeast, new Location("Southeast Room"));
            center.AddExit(Direction.West, new Location("West Room"));
            center.AddExit(Direction.East, new Location("East Room"));
            center.AddExit(Direction.Up, new Location("Upper Room"));
            center.AddExit(Direction.Out, new Location("Outside Room"));
            center.AddExit(Direction.Down, new Location("Downstairs Room"));
            center.AddExit(Direction.In, new Location("Inside Room"));

            Assert.AreEqual(12, center.ExitList.Count());
        }
        [TestMethod]
        public void TestGetExit()
        {
            var eastRoom = center.GetExit(Direction.East);
            Assert.AreEqual("East Room", eastRoom.Name);
            Assert.AreSame(center, eastRoom.GetExit(Direction.West));
            Assert.AreSame(eastRoom, eastRoom.GetExit(Direction.Up));
        }
        [TestMethod]
        public void TestExitList()
        {
            List<string> exitList = new List<string>();
            exitList.Add("the North Room is to the North");
            exitList.Add("the South Room is to the South");
            exitList.Add("the East Room is to the East");
            exitList.Add("the West Room is to the West");
            exitList.Add("the Northeast Room is to the Northeast");
            exitList.Add("the Southwest Room is to the Southwest");
            exitList.Add("the Southeast Room is to the Southeast");
            exitList.Add("the Northwest Room is to the Northwest");   
            exitList.Add("the Upper Room is Up");
            exitList.Add("the Downstairs Room is Down");
            exitList.Add("the Inside Room is In");
            exitList.Add("the Outside Room is Out");
           


            Assert.AreEqual(exitList[0], center.ExitList.ToList()[0]);
            Assert.AreEqual(exitList[1], center.ExitList.ToList()[1]);
            Assert.AreEqual(exitList[2], center.ExitList.ToList()[2]);
            Assert.AreEqual(exitList[3], center.ExitList.ToList()[3]);
            Assert.AreEqual(exitList[4], center.ExitList.ToList()[4]);
            Assert.AreEqual(exitList[5], center.ExitList.ToList()[5]);
            Assert.AreEqual(exitList[6], center.ExitList.ToList()[6]);
            Assert.AreEqual(exitList[7], center.ExitList.ToList()[7]);
            Assert.AreEqual(exitList[8], center.ExitList.ToList()[8]);
            Assert.AreEqual(exitList[9], center.ExitList.ToList()[9]);
            Assert.AreEqual(exitList[10], center.ExitList.ToList()[10]);
            Assert.AreEqual(exitList[11], center.ExitList.ToList()[11]);

            Assert.AreEqual(exitList.Count, center.ExitList.ToList().Count);



            Assert.AreEqual(string.Join(" ",exitList), string.Join(" ",center.ExitList.ToList()));

        }
        [TestMethod]
        public void TestReturnExits()
        {
            var newEastRoom = new Location("New East Room");
            center.AddExit(Direction.East, newEastRoom );
            Assert.AreSame(center, newEastRoom.GetExit(Direction.West));
            
        }
        [TestMethod]
        public void TestAddHall()
        {
            var hall = new Location("Hall");
            var hall1 = new Location("Hall-1");
            var eastRoom = center.GetExit(Direction.East);
            center.GetExit(Direction.East).AddExit(Direction.East, hall);
            center.GetExit(Direction.East).GetExit(Direction.East).AddExit(Direction.East, hall1);

            Assert.AreEqual(2, hall.Exits.Count);
            Assert.AreEqual(1, hall1.Exits.Count);
            Assert.AreEqual(12, center.Exits.Count);
            Assert.AreEqual(2, eastRoom.Exits.Count);
            Assert.AreSame(eastRoom, hall.GetExit(Direction.West));
            Assert.AreSame(hall, hall1.GetExit(Direction.West));
            Assert.AreSame(center, eastRoom.GetExit(Direction.West));
        }
    }
}
