using BepInEx;

namespace TraderScrolling
{
    [BepInPlugin("com.kaeno.TraderScrolling", "Kaeno-TraderScrolling", "1.1.0")]
    public class TraderScrolling : BaseUnityPlugin
    {
        private void Awake()
        {
            new TraderScrollingPatch().Enable();
            new PlayerCardPatch().Enable();
        }
    }
}