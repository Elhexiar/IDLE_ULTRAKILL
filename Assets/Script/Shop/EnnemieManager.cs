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

    public List<EnnemieClicker> ennemieList;

    public int selectedEnnemieIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ennemieList.Count; i++)
        {
            ennemieList[i].ui_priceRef = ui_priceRefList[i];
            ennemieList[i].ui_quantityRef = ui_quantityRefList[i];
            ennemieList[i].ui_speedRef = ui_speedRefList[i];

            ennemieList[i].UpdateUISelf();
            ennemieList[i].HideModel();

        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectEnnemie(int index)
    {

        selectedEnnemieIndex = index;

        for (int i = 0; i < ennemieList.Count; i++)
        {
            if (i == selectedEnnemieIndex)
            {
                ennemieList[i].ShowModel();
            }
            else
            {
                ennemieList[i].HideModel();
            }
        }

    }

    public void ShowDefaultSelectedEnnemie()
    {
        ennemieList[selectedEnnemieIndex].ShowModel();
    }
    public void HideDefaultSelectedEnnemie()
    {
        ennemieList[selectedEnnemieIndex].HideModel();
    }

    public void BuySelectedEnnemie()
    {
        ennemieList[selectedEnnemieIndex].Buy();
    }
}
