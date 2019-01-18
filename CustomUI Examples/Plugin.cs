using CustomUI.GameplaySettings;
using CustomUI.MenuButton;
using CustomUI.Settings;
using IllusionPlugin;
using System;
using UnityEngine.SceneManagement;

namespace CustomUI_Examples
{
    public class Plugin : IPlugin
    {
        public string Name => "CustomUI Examples";
        public string Version => "4.2.0";
        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }


        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {

        }

        //SETTINGS UI EXAMPLE, MUST BE IN SCENELOADED and Adding new buttons and toggles
        bool toggles = false;
        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            //Creating the UI is incredibly simple.
            if (arg0.name == "Menu") //Only run this in the Menu
            {
                //Essentials
                SubMenu settingsSubmenu = SettingsUI.CreateSubMenu("Example");

                //Selecting and Setting Integers
                IntViewController testInt = settingsSubmenu.AddInt("Test Int", 0, 100, 1); //First int is the minimum, second is the maximum, and third is the step
                testInt.GetValue += delegate { return ModPrefs.GetInt(Name, "Test Int", 0, true); }; //GetInt comes first, Name is the name of the area in ModPrefs, 0 is default value
                testInt.SetValue += delegate (int value) { ModPrefs.SetInt(Name, "Test Int", value); }; //SetInt comes second, sets it to ModPrefs

                AddingUIElsewhere.OnLoad();

                MenuButtonUI.AddButton("NUT", delegate { Console.WriteLine("[" + Name + "] There's a nut button?!"); }); //Adds a button to the menu
                MenuButtonUI.AddButton("View Controller Test", MenuCreation.CreateNewMenu); //Adds a button to the menu

                //Adding a Toglge Option in the game settings
                ToggleOption toggle = GameplaySettingsUI.CreateToggleOption("Test Option", "This is a short description of the option, which will be displayed as a tooltip when you hover over it");
                toggle.AddConflict("Another Gameplay Option"); //Specifiying what the Toggle might/does conflict with.
                toggle.GetValue = toggles;
                toggle.OnToggle += ((bool x) =>
                {
                    toggles = x;
                });
            }

            if (arg0.name == "GameCore")
            {
                AddingUIElsewhereTwo.OnLoad();
            }
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
}
