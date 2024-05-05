using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Collections;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DCDmoneycheat
{
    public class ModInfo
    {
        public const string name = "DCD Money Cheat";
        public const string guid = "magelock.dcdmc";
        public const string version = "1.0.0";
    }

    [BepInPlugin(ModInfo.guid, ModInfo.name, ModInfo.version)]
    public class Main : BaseUnityPlugin
    {
        private bool isMkeyDown = false;
        private bool isRkeyDown = false;
        public GameObject duckE;

        void Update()
        {
            if (SceneManager.GetActiveScene().name == "City")
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    isRkeyDown = true;
                    FindDucksCar();
                }
                if (Input.GetKeyDown(KeyCode.M))
                {
                    isMkeyDown = true;
                    GiveMoneyToCar();
                }
            }
        }

        private void FindDucksCar()
        {
            duckE = GameObject.Find("PlayerController(Clone)");
        }

        private void GiveMoneyToCar()
        {
            if (duckE != null)
            {
                Car sillygoose = duckE.GetComponent<Car>();
                if (sillygoose != null)
                {
                    sillygoose.money += 100000;
                    Debug.Log("Gave 100000 money to the car!");
                }
            }
        }
    }
}
