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

}
