using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSamples.Creational
{
    internal class BuilderPattern
    {
        public static string GetBuilding(Building builder)
        {
            builder.BuildRooms(2);
            builder.BuildWindows(4);
            builder.BuildDoors(5);
            return builder.GetBuilding();
        }
    }

    internal abstract class Building
    {
        protected int rooms;

        protected int windows;

        protected int doors;

        public abstract void BuildRooms(int noOfRooms);

        public abstract void BuildDoors(int noOfDoors);

        public abstract void BuildWindows(int noOfWindows);

        public abstract string GetBuilding();
    }

    internal class Home : Building
    {
        public override void BuildDoors(int noOfDoors)
        {
            this.doors = noOfDoors + 1;
        }

        public override void BuildRooms(int noOfRooms)
        {
            this.rooms = noOfRooms;
        }

        public override void BuildWindows(int noOfWindows)
        {
            this.windows = noOfWindows;
        }

        public override string GetBuilding()
        {
            return $"Home have Doors:{this.doors}, Rooms: {this.rooms}, Windows: {this.windows}";
        }
    }

    internal class Library : Building
    {
        public override void BuildDoors(int noOfDoors)
        {
            this.doors = noOfDoors + 2;
        }

        public override void BuildRooms(int noOfRooms)
        {
            this.rooms = noOfRooms;
        }

        public override void BuildWindows(int noOfWindows)
        {
            this.windows = noOfWindows + 1;
        }

        public override string GetBuilding()
        {
            return $"Library have doors:{this.doors}, rooms:{this.rooms}, windows:{this.windows}";
        }
    }
}
