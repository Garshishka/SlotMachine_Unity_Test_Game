using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScript : MonoBehaviour //Main logic
{
    public int Coins; //how much money we have
    int bAmount; //for local bet

    [SerializeField]
    SpinRollScript[] SpinRoll;

    [SerializeField]
    Slider SpinsLeft;

    [SerializeField]
    Text SpinsLeftText;

    [SerializeField]
    Text SpinsTimeText;

    [SerializeField]
    Text CoinsText;

    [SerializeField]
    SpinClick SpinC;

    [SerializeField]
    BetButtonClick bBut;

    public int[] winNumbers = new int[3];
    bool rechargeSpins; //a bool to stop new recharges while one is already happening

    void Start()
    {
        bAmount = 1;
        Coins = 0;
        rechargeSpins = true;
        SpinClick.SpinClicked += AskResults; //Subscribing to spin button click
        SpinsTimeText.text = " ";
    }

    void AskResults()
    {
        SpinsLeft.value = SpinsLeft.value - bBut.betAmount; //decreasing spins
        SpinsLeftText.text = SpinsLeft.value + "/50";
        bAmount = bBut.betAmount;
        StartCoroutine(Spinning());
    }

    IEnumerator Spinning()
    {
        //THIS PART IS ASK SERVER - GET RESULTS----------------------------
        winNumbers[0] = Random.Range(0, 9);
        winNumbers[1] = Random.Range(0, 9);
        winNumbers[2] = Random.Range(0, 9);

        Debug.Log("result: " + winNumbers[0]+ winNumbers[1]+ winNumbers[2]);
        //-----------------------------------------------------------------

        // 0 - lemon, 1 - cherry, 2 - watermelon, 3 - banana, 4 - bar, 5 - plum, 6 - big win, 7 - orange, 8 - seven

        //THIS PART CALCULATES RESULTS AND THIS IS JUST AN EXAMPLE OF CALCULATING RESULTS SYSTEM
        //PayTable.PNG in the root shows how it pays out----------------------------------------
        int coinPayout = 0;
        switch (winNumbers[0])
        {
            case 0:
                coinPayout = 10;
                break;
            case 1:
                coinPayout = 20;
                break;
            case 2:
                coinPayout = 30;
                break;
            case 3:
                coinPayout = 40;
                break;
            case 5:
                coinPayout = 50;
                break;
            case 7:
                coinPayout = 60;
                break;

        }
        if (winNumbers[0] == winNumbers[1])
        {
            coinPayout = coinPayout * 2;
            if (winNumbers[1] == winNumbers[2])
            {
                coinPayout = coinPayout * 2;
                switch (winNumbers[0])
                {
                    case 4:
                        coinPayout = 500;
                        break;
                    case 6:
                        coinPayout = 700;
                        break;
                    case 8:
                        coinPayout = 1000;
                        break;
                }
            }
        }
        //--------------------------------------------------------------------------------------

        yield return new WaitForSeconds(3f);
               
        for (int i = 0; i < 3; i++) //sending the results to rolls to stop spinning
        {
            SpinRoll[i].resulToShow = winNumbers[i]; //where to stop
            SpinRoll[i].resultsAreIn = true; //and that is time to stop

            while (SpinRoll[i].Spinning)
            {
                yield return new WaitForSeconds(0.1f); //waiting for rolls to stop spinning
            }
            yield return new WaitForSeconds(0.5f); //a little pause between every roll stopping
        }
        SpinC.SpinDone = true;
        for(int i = 0; i < bAmount; i++) //to show the amount won in a little fun way 
        {
            Coins += coinPayout;
            CoinsText.text = Coins + " coins"; //Showing the coins won
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

    void Update()
    {
        if (SpinsLeft.value < 50 && rechargeSpins)
        {
            StartCoroutine(RechargeSpinTime());
            rechargeSpins = false; 
        }
    }

    IEnumerator RechargeSpinTime()
    {
        for (int i = 60; i > 0; i--) //it takes 60 seconds to recharge 5 spins
        {
            SpinsTimeText.text = "5 spins in: " + i;
            yield return new WaitForSeconds(1f);
        }
        SpinsTimeText.text = " ";

        SpinsLeft.value = SpinsLeft.value + 5;
        if (SpinsLeft.value > 50)
        {
            SpinsLeft.value = 50;
        }
        SpinsLeftText.text = SpinsLeft.value + "/50";
        rechargeSpins = true; //we can recharge again
        yield break;
    }
}
