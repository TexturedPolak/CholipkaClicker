using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private ClickerUI clickerUi;
    [SerializeField] private Button clickerButton;
    [SerializeField] private AudioSource click;
    [Header("Shop")]
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private List<Item> items;
    public double cholipkiToK = 0;
    public double cholipkiToM = 0;
    private double cholipki = 0;
    [Header("Other")]
    public double cholipkiPerClick = 1;
    public static UnityEvent<int, int> OnItemBought = new UnityEvent<int, int>();
    private void Start()
    {
        clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        clickerButton.onClick.AddListener(AddCholipki);

        shopUI.CloseShop();
        openButton.onClick.AddListener(shopUI.OpenShop);
        closeButton.onClick.AddListener(shopUI.CloseShop);
        foreach(Item item in items)
        {
            shopUI.AddItem(item);
        }

        OnItemBought.AddListener(BuyItem);
    }

    private void BuyItem(int ItemPrice, int ItemPower)
    {
        if(ItemPrice < 1000)
        {
            if (ItemPrice <= cholipki)
            {
                cholipkiPerClick += ItemPower;
                cholipki -= ItemPrice;
                clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
            }
        }
        if(ItemPrice >= 1000 && ItemPrice < 1000000)
        {
            ItemPrice = ItemPrice / 1000;
            if (ItemPrice <= cholipkiToK)
            {
                cholipkiPerClick += ItemPower;
                cholipkiToK -= ItemPrice;
                clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
            }
        }
    }

    private void AddCholipki()
    {
        Debug.Log(cholipkiToM);
        
        if (cholipkiToK == 0 && cholipkiToM == 0)
        {
            cholipki += cholipkiPerClick;
            click.Play();
            clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        }
        if (cholipkiToK != 0 && cholipkiToM ==0)
        {
            cholipkiToK += cholipkiPerClick / 1000;
            click.Play();
            clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        }
        if (cholipkiToM != 0)
        {
            cholipkiToM += cholipkiPerClick / 1000000;
            click.Play();
            Debug.Log("debug"+cholipkiToM);
            clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        }
        if (cholipki >= 1000 && cholipkiToK == 0)
        {
            cholipkiToK = cholipki / 1000;
            cholipki = 0;
        }
        if (cholipkiToK >= 1000 && cholipkiToM == 0)
        {
            cholipkiToM = cholipkiToK / 1000;
            cholipkiToK = 0;
        }
        if (cholipkiToK == 0)
        {
            clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        }
        else if (cholipkiToK != 0 && cholipkiToM ==0)
        {
            clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        }
        else if (cholipkiToM != 0)
        {
            clickerUi.UpdateUI(cholipki, cholipkiToK, cholipkiToM);
        }
        
    }
}
