using Main_Scene;
using TMPro;
using UnityEngine;

namespace Store
{
    public class StoreController : MonoBehaviour
    {
        private int _money;
        private Item _clickedItem;
        
        [SerializeField] private TMP_Text moneyText;
        public GameObject buyButton;
        public GameObject changeButton;
        
        

        private void Start()
        {
            if (PlayerPrefs.GetInt("yellow") != (int) Purchasing.Purchased)
            {
                PlayerPrefs.SetInt("yellow", (int) Purchasing.Purchased);
            }

            

            moneyText.text = FileManager.Instance.GetIntData("money") + "$";
            CheckSelectedItem();
            CheckPurchasedItem();
        }

        //TODO: Button Click Audio
        //TODO: Money controller
        public void Buy()
        {
            if (_clickedItem.price <= _money)
            {
                _money -= _clickedItem.price;
                PlayerPrefs.SetInt("money", _money);
                moneyText.text = _money + "$";
                PlayerPrefs.SetInt(_clickedItem.itemName, (int)Purchasing.Purchased);
                print(_clickedItem.itemName+" has been purchased");
                PlayerPrefs.Save();
                buyButton.SetActive(false);
                changeButton.SetActive(true);
            }
        }

        //TODO: Button Click Audio
        public void OnClickChangeButton()
        {
            ChangeSelectedItem(PlayerPrefs.GetString("selectedItem", "yellow"), _clickedItem.selectedText);
            PlayerPrefs.SetString("selectedItem", _clickedItem.itemName);
            PlayerPrefs.SetString("selectedColor", ColorUtility.ToHtmlStringRGBA(_clickedItem.color));
            PlayerPrefs.Save();
            changeButton.SetActive(false);
        }

        private void ChangeSelectedItem(string itemToClose, GameObject itemToOpen)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var item = transform.GetChild(i).GetComponent<Item>();
                if (itemToClose == item.itemName)
                {
                    changeButton.SetActive(false);
                    item.selectedText.SetActive(false);
                }
            }
            itemToOpen.SetActive(true);
        }

        private void CheckSelectedItem()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                var item = transform.GetChild(i).GetComponent<Item>();
                if (PlayerPrefs.GetString("selectedItem", "yellow") != item.itemName) continue;
                item.selectedText.SetActive(true);
            }
        }

        
        private void CheckPurchasedItem()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var item = transform.GetChild(i).GetComponent<Item>();
                if (PlayerPrefs.GetInt(item.itemName) == (int)Purchasing.Purchased)
                {
                    buyButton.SetActive(false);
                }
            }
        
        }

        public void OnClickItem(Item clickedItem)
        {
            print(clickedItem.itemName);
            
            var selectedItem = PlayerPrefs.GetString("selectedItem", "yellow");
            print(selectedItem);
            if (selectedItem == clickedItem.itemName)
            {
                print(1);
                buyButton.SetActive(false);
                changeButton.SetActive(false);
                clickedItem.selectedText.SetActive(true);
            }
            else if(PlayerPrefs.GetInt(clickedItem.itemName) == (int)Purchasing.Purchased || clickedItem.itemName == "yellow")
            {
                print(2);
                buyButton.SetActive(false);
                changeButton.SetActive(true);
                clickedItem.selectedText.SetActive(false);
            }
            else
            {
                print(3);
                buyButton.SetActive(true);
                changeButton.SetActive(false);
                clickedItem.selectedText.SetActive(false);
            }
            _clickedItem = clickedItem;

        }
    }

    enum Purchasing
    {
        NotPurchased,
        Purchased
    }
}