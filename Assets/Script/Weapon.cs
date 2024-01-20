using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : ScriptableObject
{

    public GameObject weaponGameObject;
    public int index;
    public string weaponName;
    public bool visible;
    public int quantity = 0;

    public int price;
    public int multiplier;

    public TextMeshProUGUI ui_multiplier;
    public TextMeshProUGUI ui_price;
    public TextMeshProUGUI ui_quantity;

    public void Update_UI()
    {
        ui_multiplier.text = multiplier.ToString();
        ui_price.text = price.ToString();
        ui_quantity.text = quantity.ToString();
    }

}
