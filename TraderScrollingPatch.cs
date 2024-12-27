using System.Reflection;
using SPT.Reflection.Patching;
using SPT.Reflection.Utils;
using EFT.UI;
using HarmonyLib;
using UnityEngine;

namespace TraderScrolling
{
    public class TraderScrollingPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(TraderScreensGroup), nameof(TraderScreensGroup.Show));
        }

        [PatchPostfix]
        public static void PatchPostFix()
        {
            var gameObject = GameObject.Find("Menu UI");
            var check = gameObject.GetComponentInChildren<TraderScrollingScript>();


            if (check != null)
            {
                return;
            }
            gameObject.AddComponent<TraderScrollingScript>();
        }
    }
}