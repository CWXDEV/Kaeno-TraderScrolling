using System.Reflection;
using SPT.Reflection.Patching;
using EFT.UI;
using HarmonyLib;
using Comfort.Common;

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
            var gameObject = Singleton<MenuUI>.Instance.gameObject;
            var check = gameObject.GetComponentInChildren<TraderScrollingScript>();


            if (check != null)
            {
                return;
            }
            gameObject.AddComponent<TraderScrollingScript>();
        }
    }
}
