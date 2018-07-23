using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using UnityEngine;
using UnityEngine.UI;

namespace CustomLoadScreen
{
    [HarmonyPatch(typeof(uGUI_SceneLoading))]
    [HarmonyPatch("Init")]
    public static class uGUI_SceneLoadingPatch
    {
        public static void Postfix(uGUI_SceneLoading __instance)
        {
            Sprite img = ImageUtils.LoadSprite(Environment.CurrentDirectory + "/QMods/CustomLoadScreen/image.png");
            Image[] graphics = __instance.loadingBackground.GetComponentsInChildren<Image>();

            foreach(Image graphic in graphics)
            {
                graphic.sprite = img;
            }
        }
    }
}
