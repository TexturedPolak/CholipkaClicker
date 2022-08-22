using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private RectTransform shop;
    [SerializeField] private RectTransform content;
    [SerializeField] private ShopItemUI shopItemUI;

    public void AddItem(Item item)
    {
        var newItem = Instantiate(shopItemUI, content);
        newItem.UpdateUI(item);
    }
    public void OpenShop()
    {
        shop.gameObject.SetActive(true);
    }
    public void CloseShop()
    {
        shop.gameObject.SetActive(false);
    }
}
