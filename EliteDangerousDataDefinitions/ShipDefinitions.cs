﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace EliteDangerousDataDefinitions
{
    public class ShipDefinitions
    {
        private static Dictionary<long, Ship> ShipsByEliteID = new Dictionary<long, Ship>()
        {
            { 128049267, new Ship(128049267, "Adder", "Zorgon Peterson", "Adder", ShipSize.Small) },
            { 128049363, new Ship(128049363, "Anaconda", "Faulcon DeLacy", "Anaconda", ShipSize.Large) },
            { 128049303, new Ship(128049303, "Asp", "Lakon Spaceways", "Asp Explorer", ShipSize.Medium) },
            { 128672276, new Ship(128672276, "Asp_Scout", "Lakon Spaceways", "Asp Scout", ShipSize.Medium) },
            { 111, new Ship(111, "BelugaLiner", "Saud Kruger", "Beluga", ShipSize.Large) },
            { 128049279, new Ship(128049279, "CobraMkIII", "Faulcon DeLacy", "Cobra Mk. III", ShipSize.Small) },
            { 128672262, new Ship(128672262, "CobraMkIV", "Faulcon DeLacy", "Cobra Mk. IV", ShipSize.Small) },
            { 128671831, new Ship(128671831, "DiamondbackXL", "Lakon Spaceways", "Diamondback Explorer", ShipSize.Small) },
            { 128671217, new Ship(128671217, "Diamondback", "Lakon Spaceways", "Diamondback Scout", ShipSize.Small) },
            { 128049255, new Ship(128049255, "Eagle", "Core Dynamics", "Eagle", ShipSize.Small) },
            { 128672145, new Ship(128672145, "Federation_Dropship_MkII", "Core Dynamics", "Federal Assault Ship", ShipSize.Medium) },
            { 128049369, new Ship(128049369, "Federation_Corvette", "Core Dynamics", "Federal Corvette", ShipSize.Large) },
            { 128049321, new Ship(128049321, "Federation_Dropship", "Core Dynamics", "Federal Dropship", ShipSize.Medium) },
            { 128672152, new Ship(128672152, "Federation_Gunship", "Core Dynamics", "Federal Gunship", ShipSize.Medium) },
            { 128049351, new Ship(128049351, "FerDeLance", "Zorgon Peterson", "Fer-de-Lance", ShipSize.Medium) },
            { 128049315, new Ship(128049315, "Empire_Trader", "Gutamaya", "Imperial Clipper", ShipSize.Large) },
            { 128671223, new Ship(128671223, "Empire_Courier", "Gutamaya", "Imperial Courier", ShipSize.Small) },
            { 128049375, new Ship(128049375, "Cutter", "Gutamaya", "Imperial Cutter", ShipSize.Large) },
            { 128672138, new Ship(128672138, "Empire_Eagle", "Gutamaya", "Imperial Eagle", ShipSize.Small) },
            { 128049261, new Ship(128049261, "Hauler", "Zorgon Peterson", "Hauler", ShipSize.Small) },
            { 128672269, new Ship(128672269, "Independant_Trader", "Lakon Spaceways", "Keelback", ShipSize.Medium) },
            { 128049327, new Ship(128049327, "Orca", "Saud Kruger", "Orca", ShipSize.Large) },
            { 128049339, new Ship(128049339, "Python", "Faulcon DeLacy", "Python", ShipSize.Medium )},
            { 128049249, new Ship(128049249, "Sidewinder", "Faulcon DeLacy", "Sidewinder", ShipSize.Small) },
            { 128049285, new Ship(128049285, "Type6", "Lakon Spaceways", "Type-6 Transporter", ShipSize.Medium) },
            { 128049297, new Ship(128049297, "Type7", "Lakon Spaceways", "Type-7 Transporter", ShipSize.Large) },
            { 128049333, new Ship(128049333, "Type9", "Lakon Spaceways", "Type-9 Heavy", ShipSize.Large) },
            { 128049273, new Ship(128049273, "Viper", "Faulcon DeLacy", "Viper Mk. III", ShipSize.Small) },
            { 128672255, new Ship(128672255, "Viper_MkIV", "Faulcon DeLacy", "Viper Mk. IV", ShipSize.Small) },
            { 128049309, new Ship(128049309, "Vulture", "Core Dynamics", "Vulture", ShipSize.Small) },
        };

        public static List<string> ShipModels = ShipsByEliteID.Select(kp => kp.Value.model).ToList();

        private static Dictionary<string, Ship> ShipsByModel = ShipsByEliteID.ToDictionary(kp => kp.Value.model.ToLowerInvariant(), kp => kp.Value);
        private static Dictionary<string, Ship> ShipsByEDModel = ShipsByEliteID.ToDictionary(kp => kp.Value.EDName.ToLowerInvariant(), kp => kp.Value);

        /// <summary>Obtain details of a ship given its Elite ID</summary>
        public static Ship FromEliteID(long id)
        {
            Ship Ship = new Ship();
            Ship Template;
            if (ShipsByEliteID.TryGetValue(id, out Template))
            {
                Ship.EDID = Template.EDID;
                Ship.EDName = Template.EDName;
                Ship.manufacturer = Template.manufacturer;
                Ship.model = Template.model;
                Ship.size = Template.size;
            }
            // All ships default to 100% health
            Ship.health = 100;

            return Ship;
        }

        /// <summary>Obtain details of a ship given its model</summary>
        public static Ship FromModel(string model)
        {
            if (model == null)
            {
                return null;
            }

            Ship Ship = new Ship();
            Ship Template;
            if (ShipsByModel.TryGetValue(model.ToLowerInvariant(), out Template))
            {
                Ship.EDID = Template.EDID;
                Ship.EDName = Template.EDName;
                Ship.manufacturer = Template.manufacturer;
                Ship.model = Template.model;
                Ship.size = Template.size;
            }
            else
            {
                Ship.model = model;
            }
            return Ship;
        }

        /// <summary>Obtain details of a ship given its Elite:Dangerous model</summary>
        public static Ship FromEDModel(string model)
        {
            if (model == null)
            {
                return null;
            }
            Ship Ship = new Ship();
            Ship Template;
            if (ShipsByEDModel.TryGetValue(model.ToLowerInvariant(), out Template))
            {
                Ship.EDID = Template.EDID;
                Ship.EDName = Template.EDName;
                Ship.manufacturer = Template.manufacturer;
                Ship.model = Template.model;
                Ship.size = Template.size;
            }
            else
            {
                Logging.Info("Failed to find ship");
                Ship.model = model;
            }
            return Ship;
        }
    }
}
