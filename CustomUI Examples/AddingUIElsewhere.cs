using CustomUI.BeatSaber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI_Examples
{
    //ADDING BUTTONS TO A MENU BUTTON
    public class AddingUIElsewhere : MonoBehaviour
    {
        public static void OnLoad() //Just create a method that you call when you load a scene
        {
            new GameObject("AddingUIElsewhere").AddComponent<AddingUIElsewhere>(); //Creating the GameObject
        }

        public void Awake() //This is where you call another method which creates the UI (This is what I do, you don't have to follow this exact method of doing things
        {
            CreateUI();
        }

        public void CreateUI() 
        {
            //References the GameplaySetupViewController so you can attach stuff to it. You can do this with any active view controller.
            RectTransform gpmanager = Resources.FindObjectsOfTypeAll<GameplaySetupViewController>().First(x => x.name == "GameplaySetupViewController").transform as RectTransform;
            Button noninteractablebutton = BeatSaberUI.CreateUIButton(gpmanager, "QuitButton", new Vector2(40f, -24f)); //QuitButton is the reference/template that this button will use. The Vector2 references the location
            noninteractablebutton.SetButtonText("Press for $$$");
            noninteractablebutton.SetButtonTextSize(3f);
            noninteractablebutton.interactable = false; //Boolean value. This will grey out the button.
            //noninteractablebutton.onClick.AddListener(METHODNAME); If you'll be changing the interactable statate, you'll probably want the button to lead somewhere

            noninteractablebutton.ToggleWordWrapping(false); //QuitButton has "issues" with properly wrapping so do this.

        }
    }

    //ADDING BUTTONS AND TEXT TO THE PAUSE MENU
    public class AddingUIElsewhereTwo : MonoBehaviour
    {
        public static void OnLoad()
        {
            new GameObject("AddingUIElsewhere2").AddComponent<AddingUIElsewhereTwo>();
        }

        public void Awake()
        {
            CreateUI();
        }

        public void CreateUI()
        {
            //References the Pause Menu. Find the Canvas so it can be attached to it. Pause Menu is a bit different from the rest of the menus so you need to reference it a bit differently
            RectTransform pauseMenuUI = Resources.FindObjectsOfTypeAll<Transform>().First(x => x.name == "PauseMenu").GetComponentsInChildren<RectTransform>(true).First(x => x.name == "Canvas");
            Button ragequit = BeatSaberUI.CreateUIButton(pauseMenuUI, "CreditsButton", new Vector2(40f, 30f)); //CreditsButton is the reference/template that this button will use
            ragequit.SetButtonText("<color=#ff0000>RAGE QUIT</color>");
            ragequit.SetButtonTextSize(5f);
            ragequit.onClick.AddListener(RageQuit);
            ragequit.gameObject.GetComponentInChildren<Image>().color = Color.red; //Sets the color of the button
        }

        void RageQuit()
        {
            Application.Quit();
        }
    }
}
