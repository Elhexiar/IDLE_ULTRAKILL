using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponBehaviourManager : MonoBehaviour
{

    //Weapon references for object construction
    public List<GameObject> weaponsRefList;
    public List<Weapon> weaponList;
    public List<string> weaponNamesList;
    public List<int> weaponInitialPricesList;
    public List<int> weaponMultiplierList;

    public List<TextMeshProUGUI> ui_weaponPriceRefList;
    public List<TextMeshProUGUI> ui_weaponMultiplierList;
    public List<TextMeshProUGUI> ui_weaponQTYRefList;

    //NOTE FR Mathis : A noter j'aurais clairement du utiliser des scriptable object ou des prefab
    //mais la je suis trop loin dans la sunk cost fallacy et ca a l'air de marcher meme si c'est ignoble

    public ScoreManager scoreManager;
    public ShopManager shopManager;

    public int weaponSelectionIndex = 0;




    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < weaponsRefList.Count; i++)
        {
            weaponList.Add(new Weapon());
            weaponList[i] = ConstructWeapon(weaponList[i], i);

        }
    }


    public Weapon ConstructWeapon(Weapon weapon, int index)
    {
        weapon.weaponGameObject = weaponsRefList[index];
        weapon.name = weaponNamesList[index];
        weapon.visible = false;
        weapon.index = index;
        weapon.multiplier = weaponMultiplierList[index];
        weapon.price = weaponInitialPricesList[index];
        weapon.ui_price = ui_weaponPriceRefList[index];
        weapon.ui_multiplier = ui_weaponMultiplierList[index];
        weapon.ui_quantity = ui_weaponQTYRefList[index];

        weapon.Update_UI();

        return weapon;
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

    public void ShowSelectedWeapon()
    {
        weaponList[weaponSelectionIndex].visible = true;
        weaponList[weaponSelectionIndex].weaponGameObject.SetActive(true);
    }

    public void HideSelectedWeapon()
    {
        weaponList[weaponSelectionIndex].visible = false;
        weaponList[weaponSelectionIndex].weaponGameObject.SetActive(false);
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



//how not to do it

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