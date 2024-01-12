using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AutoClickerManager autoClickerManager;
    public CoinThrower leftCoinThrower;
    public CoinThrower rightCoinThrower;
    public TextMeshProUGUI CoinMultiplierTextRef, coinMultiplierPriceTextRef;
    public int coinMultiplier = 1;
    public int coinMultiplierPrice = 20;

    public GameObject ShopUI;
    public GameObject EnnemieUI;

    public CameraBehaviour cameraRef;

    // Start is called before the first frame update
    void Start()
    {
        CoinMultiplierTextRef.text = coinMultiplier.ToString();
        leftCoinThrower.amoutToRaise = coinMultiplier;
        rightCoinThrower.amoutToRaise = coinMultiplier;

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

    public void IncreaseCoinMultiplier()
    {
        if (scoreManager.score >= coinMultiplierPrice)
        {
            scoreManager.score -= coinMultiplierPrice;
            scoreManager.UpdateUI();

            coinMultiplier++;
            CoinMultiplierTextRef.text = coinMultiplier.ToString();
            leftCoinThrower.amoutToRaise = coinMultiplier;
            rightCoinThrower.amoutToRaise = coinMultiplier;
            coinMultiplierPrice = coinMultiplierPrice + coinMultiplierPrice * coinMultiplier;
            coinMultiplierPriceTextRef.text = coinMultiplierPrice.ToString();
        }
        



    }
}
