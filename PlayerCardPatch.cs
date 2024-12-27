using SPT.Reflection.Patching;
using SPT.Reflection.Utils;
using EFT.UI;
using System.Reflection;
using UnityEngine;

namespace TraderScrolling
{
    public class PlayerCardPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(DisplayMoneyPanelTMPText).GetMethod("Show", PatchConstants.PublicFlags);
        }

        [PatchPostfix]
        public static void PatchPostFix()
        {
            var gameObject = GameObject.Find("Menu UI");
            var check = gameObject.GetComponentInChildren<PlayerCardScript>();

            if (check != null)
            {
                return;
            }

            gameObject.AddComponent<PlayerCardScript>();
        }
    }
}