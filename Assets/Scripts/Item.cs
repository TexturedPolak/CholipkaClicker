using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Shop/New Item")]
public class Item : ScriptableObject
{
    [Header("General")]
    public string ItemName;
    public int ItemPower;
    public int ItemPrice;
    public int ItemPriceToM;
    public int ItemPowerToM;
}
