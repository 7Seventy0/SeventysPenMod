using BepInEx;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Utilla;

namespace SeventysPenMod
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        Vector3 cubeScale = new Vector3(0.15f,0.15f,0.15f);
        GameObject penInstance;
        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
            Utilla.Events.GameInitialized -= OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            StartCoroutine(SeventysStart());
        }
        GameObject row1;
        GameObject randomColorButton;
        IEnumerator SeventysStart()
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Yay");
            var fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SeventysPenMod.Assets.penbundle");
            var bundleLoadRequest = AssetBundle.LoadFromStreamAsync(fileStream);
            yield return bundleLoadRequest;
            Debug.Log("More Yay!!!");
            var myLoadedAssetBundle = bundleLoadRequest.assetBundle;
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                yield break;
            }

            var assetLoadRequest = myLoadedAssetBundle.LoadAssetAsync<GameObject>("GorillaPen");
            yield return assetLoadRequest;

            GameObject pen = assetLoadRequest.asset as GameObject;
            penInstance = Instantiate(pen);

            assetLoadRequest = myLoadedAssetBundle.LoadAssetAsync<GameObject>("GorillaPenRack");
            yield return assetLoadRequest;

            GameObject rack = assetLoadRequest.asset as GameObject;
            Instantiate(rack);

            assetLoadRequest = myLoadedAssetBundle.LoadAssetAsync<GameObject>("GorillaPenSettings");
            yield return assetLoadRequest;

            GameObject settingstab = assetLoadRequest.asset as GameObject;
            Instantiate(settingstab);


            //penInstance.transform.SetParent(GameObject.Find("palm.01.R").transform);
            //penInstance.transform.localPosition = new Vector3(0, 0.03f, - 0.04f);
            //penInstance.transform.localEulerAngles = new Vector3(20.4477f, 343.6663f, 193.303f);
            penInstance.transform.position = new Vector3(-63.921f, 12.624f, -85.498f);
            penInstance.transform.localScale = new Vector3(0.01f,0.01f, 0.01f);
            penInstance.AddComponent<PenLogic>();
            penInstance.AddComponent<PenGrabLogic>();
            row1 = GameObject.Find("PenColorRowOne");
            
            GameObject cubeLightBlue = GameObject.Find("CubeLightBlue");
            cubeLightBlue.AddComponent<ColorPickableClass>().color = new Color(0, 255, 255);
            cubeLightBlue.transform.localScale = cubeScale;
            
            GameObject cubeGreen = GameObject.Find("CubeGreen");
            cubeGreen.AddComponent<ColorPickableClass>().color = new Color(0, 255, 0);
            cubeGreen.transform.localScale = cubeScale;

            GameObject cubeRed = GameObject.Find("CubeRed");
            cubeRed.AddComponent<ColorPickableClass>().color = new Color(255, 0, 0);
            cubeRed.transform.localScale = cubeScale;

            GameObject cubePink = GameObject.Find("CubePink");
            cubePink.AddComponent<ColorPickableClass>().color = new Color(213, 0, 255);
            cubePink.transform.localScale = cubeScale;

            GameObject cubeblue = GameObject.Find("CubeOrange");
            cubeblue.AddComponent<ColorPickableClass>().color = new Color(0, 0, 255);
            cubeblue.transform.localScale = cubeScale;

            GameObject cubeyel = GameObject.Find("CubeYel");
            cubeyel.AddComponent<ColorPickableClass>().color = new Color(255,11,0);
            cubeyel.transform.localScale = cubeScale;

            GameObject cubePurp = GameObject.Find("CubePurp");
            cubePurp.AddComponent<ColorPickableClass>().color = new Color(0.572f, 0, 0.901f);
            cubePurp.transform.localScale = cubeScale;

            GameObject cubewhite = GameObject.Find("CubeWHITE");
            cubewhite.AddComponent<ColorPickableClass>().color = new Color(1f, 1f, 1f);
            cubewhite.transform.localScale = cubeScale;

            GameObject cubeblack = GameObject.Find("CubeBlack");
            cubeblack.AddComponent<ColorPickableClass>().color = new Color(0f, 0f, 0f);
            cubeblack.transform.localScale = cubeScale;


            randomColorButton = GameObject.Find("RandomColorButton");
            randomColorButton.AddComponent<ColorPickableClass>();
            randomColorButton.AddComponent<RandomColorClass>();

            //GameObject cubeLightRed = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cubeLightRed.AddComponent<ColorPickableClass>().color = new Color(255, 129, 129);
            //cubeLightRed.transform.SetParent(row2.transform,false);

            //cubeLightRed.transform.localScale = cubeScale;

            //GameObject cubeLightGreen = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cubeLightRed.AddComponent<ColorPickableClass>().color = new Color(168, 255, 177);
            //cubeLightRed.transform.SetParent(row2.transform, false);
            //cubeLightRed.transform.localScale = cubeScale;

            GameObject.Find("Button5").AddComponent<StartWidthDecrease>();
            GameObject.Find("Button6").AddComponent<StartWidthIncrease>();

            GameObject.Find("Button1").AddComponent<MinVertexDecrease>();
            GameObject.Find("Button2").AddComponent<MinVertexIncrease>();

            GameObject.Find("Button3").AddComponent<EndWidthDecrease>();
            GameObject.Find("Button4").AddComponent<EndWidthIncrease>();



            GameObject.Find("Reset1").AddComponent<ResetStartWidth>();
            GameObject.Find("Reset2").AddComponent<ResetEndWidth>();
            GameObject.Find("Reset3").AddComponent<ResetMinVertex>();




            GameObject.Find("PenLostZone").AddComponent<LostButton>();



        }

        void Update()
        {
            /* Code here runs every frame when the mod is enabled */
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
