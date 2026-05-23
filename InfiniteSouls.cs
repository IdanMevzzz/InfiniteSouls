using MelonLoader;
using UnityEngine;
using Il2Cpp;
using System.Collections;
using System.IO;

[assembly: MelonInfo(typeof(InfiniteSouls.InfiniteSoulsMod), "InfiniteSouls", "1.0.0", "WzoUK")]
[assembly: MelonGame("", "Revolution Idle")]

namespace InfiniteSouls
{
    public class InfiniteSoulsMod : MelonMod
    {
        // Path to flag file - prevents mod from running more than once
        private string _flagFile = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile),
            "InfiniteSouls", "done.txt"
        );

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "MAIN" && !File.Exists(_flagFile))
            {
                MelonLogger.Msg("[InfiniteSouls] Main scene loaded, starting soul loop.");
                MelonCoroutines.Start(AddSoulsLoop());
            }
            else if (sceneName == "MAIN")
            {
                MelonLogger.Msg("[InfiniteSouls] Already ran. Delete done.txt to run again.");
            }
        }

        private IEnumerator AddSoulsLoop()
        {
            // Wait for game to fully load
            yield return new WaitForSeconds(10f);

            var all = Resources.FindObjectsOfTypeAll<DisplayDebug>();
            if (all.Count > 0)
            {
                MelonLogger.Msg("[InfiniteSouls] Found DisplayDebug. Adding souls...");

                // Each AddSouls() call adds 1,000,000 souls
                // 500 calls = 500,000,000 (500 million) souls
                // Change the number below to add more or less
                for (int i = 0; i < 500; i++)
                {
                    all[0].AddSouls();
                    yield return null; // Wait one frame between calls
                }

                // Write flag file so mod doesnt run again on next launch
                Directory.CreateDirectory(Path.GetDirectoryName(_flagFile)!);
                File.WriteAllText(_flagFile, "done");
                MelonLogger.Msg("[InfiniteSouls] Done! 500 million souls added!");
                MelonLogger.Msg("[InfiniteSouls] Delete done.txt to run again.");
            }
            else
            {
                MelonLogger.Msg("[InfiniteSouls] DisplayDebug not found!");
            }
        }
    }
}
