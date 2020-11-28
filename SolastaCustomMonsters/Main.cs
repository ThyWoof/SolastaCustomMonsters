using System;
using System.Reflection;
using UnityModManagerNet;
using HarmonyLib;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SolastaCustomMonsters
{
    public class Main
    {
        // [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(string msg)
        {
            if (logger != null) logger.Log(msg);
        }

        public static void Error(Exception ex)
        {
            if (logger != null) logger.Error(ex.ToString());
        }

        public static void Error(string msg)
        {
            if (logger != null) logger.Error(msg);
        }

        public static UnityModManager.ModEntry.ModLogger logger;
        public static bool enabled;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                logger = modEntry.Logger;
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }
            return true;
        }

        [HarmonyPatch(typeof(MainMenuScreen), "RuntimeLoaded")]
        static class MainMenuScreen_RuntimeLoaded_Patch
        {
            static void Postfix()
            {
                JObject config = JObject.Parse(File.ReadAllText(UnityModManager.modsPath + @"/SolastaCustomMonsters/Monsters.json"));

                try
                {
                    JObject packages = (JObject)config.GetValue("packages");
                    ParsePackages(packages);

                }
                catch
                {
                    Log("items entry not found");
                }
                try
                {
                    JObject monsters = (JObject)config.GetValue("monsters");
                    ParseMonsters(monsters);

                }
                catch {
                    Log("monsters entry not found");
                }
            }

            static void ParsePackages(JObject monsters)
            {
                Log("parse items not implemented yet");
            }

            static void ParseMonsters(JObject monsters)
            {
                foreach (var monster in monsters)
                {
                    MonsterDefinition monsterDefinition;
                    try
                    {
                        monsterDefinition = DatabaseRepository.GetDatabase<MonsterDefinition>().GetElement(monster.Key);
                        Log("Found monster: " + monster.Key);
                    }
                    catch
                    {
                        Log("Monster not found: " + monster.Key);
                        continue;
                    }
                    foreach (var item in (JObject) monster.Value)
                    {
                        // should do something here...
                    }

                    }
                }
            }
        }
    }