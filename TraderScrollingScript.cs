using Comfort.Common;
using EFT.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TraderScrolling
{
    public class TraderScrollingScript : MonoBehaviour
    {
        private static ScrollRect _referenceScrollRect;
        private void Awake()
        {
            var traderCards = GameObject.Find("TraderCards");
			var countCards = traderCards.transform.childCount;
            
            if (countCards <= 9)
            {
                // If you have default amount of traders or less dont do anything.
                return;
            }
            
            var menuUI = Singleton<MenuUI>.Instance.gameObject;
            var list = menuUI.GetComponentsInChildren<RectTransform>(true).ToList();
            var container = list.FirstOrDefault(x => x.name == "Container");
            
            var scrollrect = traderCards.AddComponent<ScrollRect>();
            var traderCardsRect = traderCards.GetComponent<RectTransform>();
            var containerRect = container.GetComponent<RectTransform>();
            
            var count = countCards - 9;
            
            // THIS IS DEFAULT
            traderCardsRect.anchorMin = new Vector2(0.595f, 1f);
            
            // extra traders
            var newAnchorMin = 0.595f + (-0.065f * count);
            
            traderCardsRect.anchorMin = new Vector2((newAnchorMin), 1f);
            
            traderCardsRect.anchorMax = new Vector2(1f, 1f);
            containerRect.anchorMax = new Vector2(1f, 1f);
            containerRect.anchorMin = new Vector2(0.01f, 0f);
            scrollrect.content = traderCardsRect;
            scrollrect.vertical = false;
            scrollrect.movementType = ScrollRect.MovementType.Elastic;
            scrollrect.viewport = containerRect;
            scrollrect.scrollSensitivity = TraderScrolling.ScrollWheelSpeed.Value;
            _referenceScrollRect = scrollrect;
            
            TraderScrolling.ScrollWheelSpeed.SettingChanged += (a, b) => AdjustScrollSpeed();
		}

        private static void AdjustScrollSpeed()
        {
            if (_referenceScrollRect ==  null)
                return;
            
            _referenceScrollRect.scrollSensitivity = TraderScrolling.ScrollWheelSpeed.Value;
        }
    }
}
