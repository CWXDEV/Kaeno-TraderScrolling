using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TraderScrolling
{
    public class PlayerCardScript : MonoBehaviour
    {

        private void Awake()
        {
            //Adjusts Money position
            var rightPerson = GameObject.Find("Right Person");
            
            var list = rightPerson.GetComponentsInChildren<RectTransform>(true).ToList();
            var money = list.FirstOrDefault(x => x.name == "Money");
            var moneyRect = money.GetComponent<RectTransform>();
            moneyRect.anchoredPosition = new Vector2(moneyRect.anchoredPosition.x + 60f, moneyRect.anchoredPosition.y);
            //End of Money position Change

            // Change spacing
            var list2 = rightPerson.GetComponentsInChildren<HorizontalLayoutGroup>(true).ToList();
            var money2 = list2.FirstOrDefault(x => x.name == "Money");
            money2.spacing = 10;
            // End of Money Spacing

            // Make tile simple
            var tile = rightPerson.GetComponentsInChildren<Image>(true).ToList();
            var tileImage = tile.FirstOrDefault(x => x.name == "Background Tile");
            tileImage.type = Image.Type.Simple;

            var foundObject = rightPerson.transform.Find("Background Tile");
            foundObject.gameObject.SetActive(true);

            var tileList = rightPerson.GetComponentsInChildren<RectTransform>(true).ToList();
            var tileRect = tileList.FirstOrDefault(x => x.name == "Background Tile");
            tileRect.sizeDelta = new Vector2(500f, 0);


            // Change Colour alpha to max for background
            var background = tile.FirstOrDefault(x => x.name == "Background");
            background.color = new Color(0, 0, 0, 1);

        }
    }
}
