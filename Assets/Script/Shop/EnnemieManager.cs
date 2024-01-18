using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class EnnemieManager : MonoBehaviour
{

    
    public List<TextMeshProUGUI> ui_priceRefList;
    public List<TextMeshProUGUI> ui_quantityRefList;
    public List<TextMeshProUGUI> ui_speedRefList;

    public List<EnnemieClicker> EnnemiesList;

    public int selectedEnnemie = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EnnemiesList.Count; i++)
        {
            EnnemiesList[i].ui_priceRef = ui_priceRefList[i];
            EnnemiesList[i].ui_quantityRef = ui_quantityRefList[i];
            EnnemiesList[i].ui_speedRef = ui_speedRefList[i];

            EnnemiesList[i].UpdateUISelf();
            EnnemiesList[i].HideModel();

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectEnnemie(int index)
    {

        selectedEnnemie = index;

        for (int i = 0; i < EnnemiesList.Count; i++)
        {
            if (i == selectedEnnemie)
            {
                EnnemiesList[i].ShowModel();
            }
            else
            {
                EnnemiesList[i].HideModel();
            }
        }

    }

    public void ShowDefaultSelectedEnnemie()
    {
        EnnemiesList[selectedEnnemie].ShowModel();
    }
    public void HideDefaultSelectedEnnemie()
    {
        EnnemiesList[selectedEnnemie].HideModel();
    }

    public void BuySelectedEnnemie()
    {
        EnnemiesList[selectedEnnemie].Buy();
    }
}
