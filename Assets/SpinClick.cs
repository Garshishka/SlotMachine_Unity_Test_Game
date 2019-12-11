using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpinClick : MonoBehaviour
{
    public static event Action SpinClicked = delegate { };

    [SerializeField]
    Slider SpinsLeft;
    [SerializeField]
    BetButtonClick bBut;

    public bool SpinDone;

    private void Start()
    {
         SpinDone = true;
    }

    public void onClick() //Checking if we have spins and then we throw the action to rolls and main logic
    {
        if (SpinsLeft.value > bBut.betAmount-1)
        {
            SpinDone = false;
            gameObject.GetComponent<Button>().interactable = false; //not interacteble until the spin is over
            SpinClicked();
        }
    }


    private void Update()
    {
        if (SpinDone) { gameObject.GetComponent<Button>().interactable = true; }
    }
    
}
