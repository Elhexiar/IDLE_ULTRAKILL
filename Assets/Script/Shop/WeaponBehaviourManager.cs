using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponBehaviourManager : MonoBehaviour
{

    //Weapon reference
    public List<GameObject> weaponsRefList;
    public List<Weapon> weaponList;
    public List<string> weaponNamesList;
    public List<int> weaponInitialPricesList;
    public List<int> weaponMultiplierList;
    public List<TextMeshProUGUI> ui_weaponPriceRefList;
    public List<TextMeshProUGUI> ui_weaponMultiplierList;
    public List<TextMeshProUGUI> ui_weaponQTYRefList;

    // A noter j'aurais clairement du utiliser des scriptable object mais la je suis trop loin dans la sunk cost fallacy et ca a l'air de marcher meme si c'est ignoble

    public ScoreManager scoreManager;
    public ShopManager shopManager;

    public int weaponSelectionIndex = 0;




    // Start is called before the first frame update
    void Start()
    {
        


        for (int i = 0; i < weaponsRefList.Count; i++)
        {
            weaponList.Add(new Weapon());
            weaponList[i].weaponGameObject = weaponsRefList[i];
            weaponList[i].name = weaponNamesList[i];
            weaponList[i].visible = false;
            weaponList[i].index = i;
            weaponList[i].multiplier = weaponMultiplierList[i];
            weaponList[i].price = weaponInitialPricesList[i];
            weaponList[i].ui_price = ui_weaponPriceRefList[i];
            weaponList[i].ui_multiplier = ui_weaponMultiplierList[i];
            weaponList[i].ui_quantity = ui_weaponQTYRefList[i];

            weaponList[i].Update_UI();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWeapon(int index)
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            if(index == i)
            {
                weaponList[i].visible = true;
                weaponList[i].weaponGameObject.SetActive(true);
                weaponSelectionIndex = i;
            }
            else
            {
                weaponList[i].visible = false;
                weaponList[i].weaponGameObject.SetActive(false);
            }
        }
    }

    public void BuySelectedWeapon()
    {

        if (scoreManager.score >= weaponList[weaponSelectionIndex].price)
        {
            
            scoreManager.score-= weaponList[weaponSelectionIndex].price;
            scoreManager.UpdateUI();

            shopManager.IncreaseCoinMultiplier(weaponList[weaponSelectionIndex].multiplier);

            weaponList[weaponSelectionIndex].price *= 2;
            weaponList[weaponSelectionIndex].quantity++;
            weaponList[weaponSelectionIndex].Update_UI();



        }

    }
    
}

public class Weapon : ScriptableObject{

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

//Il y a une maniere plus propre et scalable de faire ca avec des array et/ou des objet de type arme mais vu qu'ici j'en ai que 4 je pense comme ca ca passe

/*
public void ShowShotgun()
{
    shotgun.SetActive(true);
    railgun.SetActive(false);
    nailgun.SetActive(false);
    cannongun.SetActive(false);

    shotgunVisible = true;
    railgunVisible = false;
    nailgunVisible = false;
    cannongunVisible = false;
}

public void ShowRailgun()
{
    shotgun.SetActive(false);
    railgun.SetActive(true);
    nailgun.SetActive(false);
    cannongun.SetActive(false);

    shotgunVisible = false;
    railgunVisible = true;
    nailgunVisible = false;
    cannongunVisible = false;
}

public void ShowNailGun()
{
    shotgun.SetActive(false);
    railgun.SetActive(false);
    nailgun.SetActive(true);
    cannongun.SetActive(false);

    shotgunVisible = false;
    railgunVisible = false;
    nailgunVisible = true;
    cannongunVisible = false;
}

public void ShowCannonGun()
{
    shotgun.SetActive(false);
    railgun.SetActive(false);
    nailgun.SetActive(false);
    cannongun.SetActive(true);

    shotgunVisible = false;
    railgunVisible = false;
    nailgunVisible = false;
    cannongunVisible = true;
}
*/