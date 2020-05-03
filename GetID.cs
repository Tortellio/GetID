using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.IO;
using Environment = System.Environment;
using Logger = Rocket.Core.Logging.Logger;

namespace GetID
{
    public class GetID : RocketPlugin
    {
        public static GetID Instance;
        public static string PluginName = "GetID";
        public static string PluginVersion = " 1.0.0";

        public string itemFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/ItemIDs.txt";
        public string vehicleFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/VehicleIDs.txt";
        public string resourceFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/ResourceIDs.txt";
        public string animalFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/AnimalIDs.txt";
        public string itemDFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/DItemIDs.txt";
        public string vehicleDFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/DVehicleIDs.txt";
        public string resourceDFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/DResourceIDs.txt";
        public string animalDFilePath = $"{Environment.CurrentDirectory}/Plugins/GetID/DAnimalIDs.txt";
        public StreamWriter itemStream;
        public StreamWriter vehicleStream;
        public StreamWriter resourceStream;
        public StreamWriter animalStream;
        public StreamWriter itemDStream;
        public StreamWriter vehicleDStream;
        public StreamWriter resourceDStream;
        public StreamWriter animalDStream;

        protected override void Load()
        {
            Instance = this;

            if (!File.Exists(itemFilePath)) File.CreateText(itemFilePath);
            if (!File.Exists(itemDFilePath)) File.CreateText(itemDFilePath);
            if (!File.Exists(vehicleFilePath)) File.CreateText(vehicleFilePath);
            if (!File.Exists(vehicleDFilePath)) File.CreateText(vehicleDFilePath);
            if (!File.Exists(resourceFilePath)) File.CreateText(resourceFilePath);
            if (!File.Exists(resourceDFilePath)) File.CreateText(resourceDFilePath);

            itemStream = File.AppendText(itemFilePath);
            vehicleStream = File.AppendText(vehicleFilePath);
            resourceStream = File.AppendText(resourceFilePath);
            animalStream = File.AppendText(animalFilePath);
            itemDStream = File.AppendText(itemDFilePath);
            vehicleDStream = File.AppendText(vehicleDFilePath);
            resourceDStream = File.AppendText(resourceDFilePath);
            animalDStream = File.AppendText(animalDFilePath);

            Logger.Log("GetID has been loaded!");
            Logger.Log(PluginName + PluginVersion, ConsoleColor.Yellow);
            Logger.Log("Made by Tortellio", ConsoleColor.Yellow);
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.Log("GetID has been unloaded!");
            Logger.Log("Visit Tortellio Discord for more! https://discord.gg/pzQwsew", ConsoleColor.Yellow);
        }

        public void GetItemID(string status)
        {
            itemStream.WriteLine("ITEM ID; NAME");
            itemDStream.WriteLine("ITEM ID; NAME; TYPE; RARITY");
            foreach (ItemAsset item in Assets.find(EAssetType.ITEM)) 
            { 
                if (item != null && item.itemName != string.Empty && item.itemName != "")
                    if (status == "detailed")
                    {
                        itemDStream.WriteLine(item.id.ToString() + "; " + item.itemName + "; " + item.type + "; " + item.rarity);
                    }
                    else if (status == "normal")
                    {
                        itemStream.WriteLine(item.id.ToString() + "; " + item.itemName);
                    }
                    else if (status == "both")
                    {
                        itemStream.WriteLine(item.id.ToString() + "; " + item.itemName);
                        itemDStream.WriteLine(item.id.ToString() + "; " + item.itemName + "; " + item.type + "; " + item.rarity);
                    }
                    else
                    {
                        Logger.Log("Wrong command!");
                        return;
                    }
            }
            Logger.Log("File complete!");
            return;
        }

        public void GetVehicleID(string status)
        {
            vehicleStream.WriteLine("VEHICLE ID; NAME");
            vehicleDStream.WriteLine("VEHICLE ID; NAME; ENGINE; RARITY; AIR STEER MAX; AIR STEER MIN; AIR TURN RESPONSIVENESS BATTERY BURN RATE; BATTERY CHARGE RATE; BRAKE; CAM FOLLOW DISTANCE; FUEL; FUEL BURN RATE; GUID; HAS CRAWLER; HAS HEADLIGHTS; HAS HOOK; HAS SIRENS; HAS SLEDS; HAS TRACTION; HAS ZIP; HEALTH; RECLINED; VULNERABLE; SPEED MAX; SPEED MIN; STEER MAX; STEER MIN; TRUNK X; TRUNK Y");

            foreach (VehicleAsset vehicle in Assets.find(EAssetType.ITEM))
            {
                if (vehicle != null && vehicle.vehicleName != string.Empty && vehicle.vehicleName != "")
                    if (vehicle != null)
                    if (status == "detailed")
                    {
                        vehicleDStream.WriteLine(vehicle.id.ToString() + "; " + vehicle.vehicleName + "; " + vehicle.engine + "; " + vehicle.rarity + "; " + vehicle.airSteerMax + "; " + vehicle.airSteerMin + "; " + vehicle.airTurnResponsiveness + "; " + vehicle.batteryBurnRate + "; " + vehicle.batteryChargeRate + "; " + vehicle.brake + "; " + vehicle.camFollowDistance + "; " + vehicle.fuel + "; " + vehicle.fuelBurnRate
                            + "; " + vehicle.GUID + "; " + vehicle.hasCrawler + "; " + vehicle.hasHeadlights + "; " + vehicle.hasHook + "; " + vehicle.hasSirens + "; " + vehicle.hasSleds + "; " + vehicle.hasTraction + "; " + vehicle.hasZip + "; " + vehicle.health + "; " + vehicle.isReclined + "; " + vehicle.isVulnerable + "; "
                            + vehicle.speedMax + "; " + vehicle.speedMin + "; " + vehicle.steerMax + "; " + vehicle.steerMin + "; " + vehicle.trunkStorage_X + "; " + vehicle.trunkStorage_Y);
                    }
                    else if (status == "normal")
                    {
                        vehicleStream.WriteLine(vehicle.id.ToString() + "; " + vehicle.vehicleName);
                    }
                    else if (status == "both")
                    {
                        vehicleDStream.WriteLine(vehicle.id.ToString() + "; " + vehicle.vehicleName + "; " + vehicle.engine + "; " + vehicle.rarity + "; " + vehicle.airSteerMax + "; " + vehicle.airSteerMin + "; " + vehicle.airTurnResponsiveness + "; " + vehicle.batteryBurnRate + "; " + vehicle.batteryChargeRate + "; " + vehicle.brake + "; " + vehicle.camFollowDistance + "; " + vehicle.fuel + "; " + vehicle.fuelBurnRate
                            + "; " + vehicle.GUID + "; " + vehicle.hasCrawler + "; " + vehicle.hasHeadlights + "; " + vehicle.hasHook + "; " + vehicle.hasSirens + "; " + vehicle.hasSleds + "; " + vehicle.hasTraction + "; " + vehicle.hasZip + "; " + vehicle.health + "; " + vehicle.isReclined + "; " + vehicle.isVulnerable + "; "
                            + vehicle.speedMax + "; " + vehicle.speedMin + "; " + vehicle.steerMax + "; " + vehicle.steerMin + "; " + vehicle.trunkStorage_X + "; " + vehicle.trunkStorage_Y);
                        vehicleStream.WriteLine(vehicle.id.ToString() + "; " + vehicle.vehicleName);
                    }
                    else
                    {
                        Logger.Log("Wrong command!");
                        return;
                    }
            }
            Logger.Log("File complete!");
            return;
        }

        public void GetResourceID(string status)
        {
            resourceStream.WriteLine("RESOURCE ID; NAME");
            resourceDStream.WriteLine("RESOURCE ID; NAME; HEALTH; DEBRIS; DIRTY; FORAGE; SPEED TREE; LOG; STICK");
            foreach (ResourceAsset resource in Assets.find(EAssetType.RESOURCE))
            {
                if (resource != null)
                    if (status == "detailed")
                    {
                        resourceDStream.WriteLine(resource.id.ToString() + "; " + resource.resourceName + "; " + resource.health.ToString() + "; " + resource.hasDebris.ToString() + "; " + resource.isDirty.ToString() + "; " + resource.isForage.ToString() + "; " + resource.isSpeedTree.ToString() + "; " + resource.log.ToString() + "; " + resource.stick.ToString());
                    }
                    else if (status == "normal")
                    {
                        resourceStream.WriteLine(resource.id.ToString() + "; " + resource.resourceName);
                    }
                    else if (status == "both")
                    {
                        resourceStream.WriteLine(resource.id.ToString() + "; " + resource.resourceName);
                        resourceDStream.WriteLine(resource.id.ToString() + "; " + resource.resourceName + "; " + resource.health.ToString() + "; " + resource.hasDebris.ToString() + "; " + resource.isDirty.ToString() + "; " + resource.isForage.ToString() + "; " + resource.isSpeedTree.ToString() + "; " + resource.log.ToString() + "; " + resource.stick.ToString());
                    }
                    else
                    {
                        Logger.Log("Wrong command!");
                        return;
                    }
            }
            Logger.Log("File complete!");
            return;
        }

        public void GetAnimalID(string status)
        {
            animalStream.WriteLine("ANIMAL ID; NAME");
            animalDStream.WriteLine("ANIMAL ID; NAME; HEALTH; DEBRIS; DIRTY; FORAGE; SPEED TREE; LOG; STICK");
            foreach (AnimalAsset animal in Assets.find(EAssetType.ANIMAL))
            {
                if (animal != null)
                    if (status == "detailed")
                    {
                        resourceDStream.WriteLine(animal.id.ToString() + "; " + animal.animalName + "; " + animal.health.ToString() + "; " + animal.behaviour.ToString() + "; " + animal.meat.ToString() + "; " + animal.pelt.ToString() + "; " + animal.speedRun.ToString() + "; " + animal.speedWalk.ToString());
                    }
                    else if (status == "normal")
                    {
                        resourceStream.WriteLine(animal.id.ToString() + "; " + animal.animalName);
                    }
                    else if (status == "both")
                    {
                        resourceStream.WriteLine(animal.id.ToString() + "; " + animal.animalName);
                        resourceDStream.WriteLine(animal.id.ToString() + "; " + animal.animalName + "; " + animal.health.ToString() + "; " + animal.behaviour.ToString() + "; " + animal.meat.ToString() + "; " + animal.pelt.ToString() + "; " + animal.speedRun.ToString() + "; " + animal.speedWalk.ToString());
                    }
                    else
                    {
                        Logger.Log("Wrong command!");
                        return;
                    }
            }
            Logger.Log("File complete!");
            return;
        }

        public SkinAsset SkinUtil(ushort skinID)
        {
            Asset skin = Assets.find(EAssetType.SKIN, skinID);
            if (skin != null)
            {
                return ((SkinAsset)skin);
            }

            return null;
        }

        public SpawnAsset SpawnUtil(ushort spawnID)
        {
            Asset spawn = Assets.find(EAssetType.SPAWN, spawnID);
            if (spawn != null)
            {
                return ((SpawnAsset)spawn);
            }

            return null;
        }

        public ObjectAsset ObjectUtil(ushort objectID)
        {
            Asset objecta = Assets.find(EAssetType.OBJECT, objectID);
            if (objecta != null)
            {
                return ((ObjectAsset)objecta);
            }

            return null;
        }

        public ObjectNPCAsset NPCUtil(ushort npcID)
        {
            Asset npc = Assets.find(EAssetType.NPC, npcID);
            if (npc != null)
            {
                return ((ObjectNPCAsset)npc);
            }

            return null;
        }

        public MythicAsset MythicUtil(ushort mythicID)
        {
            Asset mythic = Assets.find(EAssetType.MYTHIC, mythicID);
            if (mythic != null)
            {
                return ((MythicAsset)mythic);
            }

            return null;
        }

        public EffectAsset EffectUtil(ushort effectID)
        {
            Asset effect = Assets.find(EAssetType.EFFECT, effectID);
            if (effect != null)
            {
                return ((EffectAsset)effect);
            }

            return null;
        }

        public void ResetFile()
        {
            File.Delete(itemFilePath);
            File.Delete(itemDFilePath);
            File.Delete(vehicleDFilePath);
            File.Delete(vehicleFilePath);
            File.Delete(resourceDFilePath);
            File.Delete(resourceFilePath);
            Logger.Log("Reset complete!");
        }
    }
}
