using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviourManager : MonoBehaviour
{

    //Weapon reference
    public List<GameObject> weaponsRefList;
    public List<Weapon> weaponList;
    public List<string> weaponNamesList;




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
            }
            else
            {
                weaponList[i].visible = false;
                weaponList[i].weaponGameObject.SetActive(false);
            }
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
}

public class Weapon : ScriptableObject{

    public GameObject weaponGameObject;
    public int index;
    public string weaponName;
    public bool visible;

}
