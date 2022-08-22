using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button buyButton;

    public void UpdateUI(Item item)
    {
        nameText.text = item.name;
        powerText.text = "+ " + item.ItemPower.ToString() + " do kliku";
        if(item.name == "Cholipka")
        {
            powerText.text = "End Game";
        }
        priceText.text = item.ItemPrice.ToString();

        buyButton.onClick.AddListener(delegate { BuyFunction(item.ItemPrice, item.ItemPower); });
    }

    private void BuyFunction(int ItemPrice, int ItemPower)
    {
        ClickerManager.OnItemBought?.Invoke(ItemPrice, ItemPower);
    }
}
