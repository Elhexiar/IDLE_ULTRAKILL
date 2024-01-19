using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AutoSenderManager autoClickerManager;
    public CoinThrower leftCoinThrower;
    public CoinThrower rightCoinThrower;
    public TextMeshProUGUI CoinMultiplierTextRef, coinMultiplierPriceTextRef;
    public int coinMultiplier = 1;
    public int coinMultiplierPrice = 20;

    public int shotgunInitialPrice;
    public int nailGunInitialPrice;
    public int railgunInitialPrice;
    public int cannonGunInitialPrice;

    public GameObject ShopUI;
    public GameObject EnnemieUI;

    public CameraBehaviour cameraRef;

    // Start is called before the first frame update
    void Start()
    {
        CoinMultiplierTextRef.text = coinMultiplier.ToString();
        leftCoinThrower.amoutToRaise = coinMultiplier;
        rightCoinThrower.amoutToRaise = coinMultiplier;

        ShopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Je sais que c'est pas hyper bien d'avoir ca dans l'update a chaque fois
        // mais j'avoue avoir pour l'instant un peu la flemme
        // Mathis du futur c'est pour toi
        if(cameraRef._isPlaying == true)
        {
            EnnemieUI.SetActive(false);
            ShopUI.SetActive(false);
        }
        else
        {
            if(cameraRef._onShop == true)
            {
                ShopUI.SetActive(true);


            }
            else
            {
                EnnemieUI.SetActive(true);
                updateMultUI();
            }

        }

    }

    public void BuyAV1()
    {
        if(scoreManager.score >= 20)
        {
            scoreManager.score -= 20;
            autoClickerManager.AutoClickers.Add(true);
            scoreManager.UpdateUI();
        }
        

    }

    public void CheckToIncreaseMult(int amount)
    {
        if (scoreManager.score >= coinMultiplierPrice)
        {
            IncreaseCoinMultiplier(amount);
            scoreManager.score -= coinMultiplierPrice;
            coinMultiplierPrice = coinMultiplierPrice + coinMultiplierPrice * coinMultiplier;
        }
    }
    public void IncreaseCoinMultiplier(int amount)
    {
        Debug.Log("Try to increase multiplier");
        
            
            scoreManager.UpdateUI();

            coinMultiplier += amount;
            Debug.Log("Mult increased by" + amount);
            CoinMultiplierTextRef.text = coinMultiplier.ToString();
            leftCoinThrower.amoutToRaise = coinMultiplier;
            rightCoinThrower.amoutToRaise = coinMultiplier;
            coinMultiplierPriceTextRef.text = coinMultiplierPrice.ToString();
        
    }

    public void updateMultUI()
    {
        CoinMultiplierTextRef.text = coinMultiplier.ToString();
        coinMultiplierPriceTextRef.text = coinMultiplierPrice.ToString();
    }
}
