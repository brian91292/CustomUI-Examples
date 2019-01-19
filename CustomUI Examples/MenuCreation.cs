using CustomUI.BeatSaber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI_Examples
{
    class MenuCreation : MonoBehaviour
    {
        public static CustomMenu TestMenu = null;
        public static void CreateNewMenu()
        {
            if (TestMenu == null)
            {
                //Creating the view controller with a BACK BUTTON!!!
                TestMenu = BeatSaberUI.CreateCustomMenu<CustomMenu>("Testing New Menu"); //Required, the string here is the name that will appear at the top of the view controller
                var viewController = BeatSaberUI.CreateViewController<CustomViewController>(); //Required
                TestMenu.SetMainViewController(viewController, true, (firstActivation, type) => //Required
                {
                    //Content you want on the view controller

                    Button bigboibutton = viewController.CreateUIButton("SoloFreePlayButton", new Vector2(60f, 20f));
                        bigboibutton.SetButtonText("Big Boi (with icon!)");
                    //bigboibutton.SetButtonIcon(UIUtilities.LoadSpriteFromResources("CustomUI_Examples.Resources.IMAGE.png")); this button is for setting a new icon. 
                    //You'll want to add the image as a resoures and set it to embed on build.

                    //Text Element
                    TextMeshProUGUI randomtext = viewController.CreateText("<b>Bold Button</b>", new Vector2(0f, 34f)); //Text Mesh Pro supports rich text!!!
                    randomtext.fontSize = 10f; //Change font, font is different from the font size of buttons
                    randomtext.alignment = TextAlignmentOptions.Center; //Changing Alignment
                });
            }
            TestMenu.Present(); //Required
        }
    }
}
