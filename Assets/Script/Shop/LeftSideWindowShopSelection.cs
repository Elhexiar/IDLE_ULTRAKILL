using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideWindowShopSelection : MonoBehaviour
{

    public GameObject arsenal;
    public bool arsenal_selected;
    public WeaponBehaviourManager weaponBehaviourManager;

    public GameObject bestiarie;
    public bool bestiarie_selected;
    public EnnemieManager ennemieManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        ShowArsenal();

    }

    public void toggleShop()
    {
        if(arsenal_selected)
        {
            ShowBestiarie();
        }
        else
        {
            ShowArsenal();
        }
    }
    public void ShowBestiarie()
    {
        arsenal_selected = false;
        arsenal.SetActive(false);
        bestiarie_selected = true;
        bestiarie.SetActive(true);
        ennemieManager.ShowDefaultSelectedEnnemie();
        weaponBehaviourManager.HideSelectedWeapon();
    }

    public void ShowArsenal()
    {
        arsenal_selected = true;
        arsenal.SetActive(true);
        bestiarie_selected = false;
        bestiarie.SetActive(false);
        ennemieManager.HideDefaultSelectedEnnemie();
        weaponBehaviourManager.ShowSelectedWeapon();
    }
}
