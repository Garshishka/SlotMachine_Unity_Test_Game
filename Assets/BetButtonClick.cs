using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetButtonClick : MonoBehaviour
{
    [SerializeField]
    Text BetText;

    public int betAmount;

    private void Start()
    {
        betAmount = 1;
    }

    public void BetClick()
    {
        gameObject.GetComponent<Button>().interactable = false; //just to be safe
        switch (betAmount) //bet amount just cycles through
        {
            case 1:
                betAmount = 2;
                break;
            case 2:
                betAmount = 5;
                break;
            case 5:
                betAmount = 10;
                break;
            case 10:
                betAmount = 1;
                break;
        }
        BetText.text = "Bet X" + betAmount;
        gameObject.GetComponent<Button>().interactable = true ;
    }

}
