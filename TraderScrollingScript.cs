using Comfort.Common;
using EFT.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TraderScrolling
{
    public class TraderScrollingScript : MonoBehaviour
    {
        private void Awake()
        {
            var traderCards = GameObject.Find("TraderCards");
            var menuUI = GameObject.Find("Menu UI");
            var list = menuUI.GetComponentsInChildren<RectTransform>(true).ToList();
            var container = list.FirstOrDefault(x => x.name == "Container");
            var scrollrect = traderCards.AddComponent<ScrollRect>();
            var traderCardsRect = traderCards.GetComponent<RectTransform>();
            var containerRect = container.GetComponent<RectTransform>();

            var countCards = traderCards.transform.childCount;

            var count = countCards - 10;
            //THIS IS DEFAULT anchorMin For anything below 11
            traderCardsRect.anchorMin = new Vector2(0.595f, 1f);

            if (count > 0)
            {
                var offset = -0.065f * count;
                traderCardsRect.anchorMin = new Vector2((0.595f + offset), 1f);
            }

            traderCardsRect.anchorMax = new Vector2(1f, 1f);
            containerRect.anchorMax = new Vector2(1f, 1f);
            containerRect.anchorMin = new Vector2(0.01f, 0f);
            scrollrect.content = traderCardsRect;
            scrollrect.vertical = false;
            scrollrect.movementType = ScrollRect.MovementType.Elastic;
            scrollrect.viewport = containerRect;
        }
    }
}