using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnnemieClicker : MonoBehaviour 
{
    public string ennemieName;
    public Texture2D texture;
    public int initialPrice;
    public int price;
    public int quantity;
    public float speed;
    public bool autoclick_activated = false;
    public ScoreManager scoreManager;

    public TextMeshProUGUI ui_priceRef;
    public TextMeshProUGUI ui_quantityRef;
    public TextMeshProUGUI ui_speedRef;

    public void UpdateUISelf()
    {
        ui_priceRef.text = price.ToString();
        ui_quantityRef.text = quantity.ToString();
        ui_speedRef.text = speed.ToString();
    }

    public void Buy()
    {
        
        if(scoreManager.score >= price)
        {
            StartSelfAutoclickerCheck();
            quantity++;
            scoreManager.score -= price;
            price += initialPrice;
            scoreManager.UpdateUI();
            UpdateUISelf();
        }
        
    }

    public void StartSelfAutoclickerCheck()
    {
        if(autoclick_activated == false)
        {
            autoclick_activated = true;
            StartCoroutine(SelfAutoCliker());
        }
        
    }

    public IEnumerator SelfAutoCliker() 
    {

        while (true)
        {
            scoreManager.score += quantity;
            scoreManager.UpdateUI();
            yield return new WaitForSeconds(speed);
        }
        
    }

}
