using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Ennemie", menuName ="Ennemie", order = 0)]

//Est ce que en c++ ici ca serait considerer comme ce qui est mis dans le header ?
public class Ennemie : ScriptableObject
{

    public string ennemieName;
    public Texture2D texture;
    public int initailPrice;
    public int quantity = 0;
    public float speed;

    public TextMeshProUGUI ui_priceRef;
    public TextMeshProUGUI ui_quantityRef;
    public TextMeshProUGUI ui_speedRef;


}

// puis ca ensuite l'objet déclarer dans le .cpp ?
// et la raison pour laquel on fait ca est pour avoir un qui est mutable et l'autre non ?
public class EnnemieClicker
{
    public string ennemieName;
    public Texture2D texture;
    public int price;
    public int quantity;
    public float speed;

}