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
            // Find the trader cards GameObject and the menu UI
            var traderCards = GameObject.Find("TraderCards");
            var menuUI = GameObject.Find("Menu UI");

            // Get all RectTransforms in menuUI and find the Container RectTransform
            var list = menuUI.GetComponentsInChildren<RectTransform>(true).ToList();
            var container = list.FirstOrDefault(x => x.name == "Container");

            // Add ScrollRect component to traderCards
            var scrollrect = traderCards.AddComponent<ScrollRect>();
            var traderCardsRect = traderCards.GetComponent<RectTransform>();
            var containerRect = container.GetComponent<RectTransform>();

            // Get the number of child elements in traderCards
            var countCards = traderCards.transform.childCount;

            // Calculate the number of extra cards beyond the initial set of 10
            var count = countCards - 10;

            // Adjust the default anchorMin to make the cards start more to the left
            float initialAnchorMinX = 0.1f;  // Adjust this value to start more to the left
            traderCardsRect.anchorMin = new Vector2(initialAnchorMinX, 1f);

            // Adjust anchorMin based on the number of extra cards
            if (count > 0)
            {
                var offset = -0.065f * count;
                traderCardsRect.anchorMin = new Vector2((initialAnchorMinX + offset), 1f);
            }

            // Set the anchors for traderCardsRect and containerRect
            traderCardsRect.anchorMax = new Vector2(1f, 1f);
            containerRect.anchorMax = new Vector2(1f, 1f);
            containerRect.anchorMin = new Vector2(0.01f, 0f);

            // Configure scrollrect for horizontal scrolling
            scrollrect.content = traderCardsRect;
            scrollrect.vertical = false;
            scrollrect.movementType = ScrollRect.MovementType.Elastic;
            scrollrect.viewport = containerRect;

            // Adjust scroll sensitivity to make scrolling faster
            scrollrect.scrollSensitivity = 20.0f;  // Increase this value for faster scrolling
        }
    }
}
