using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRollScript : MonoBehaviour
{
    public bool Spinning;

    public bool resultsAreIn;
    public int resulToShow;

    void Start()
    {
        Spinning = false;
        resultsAreIn = false;
        SpinClick.SpinClicked += StartRotating; //Subscribing to Spin button click
    }

   void StartRotating()
    {
        StartCoroutine(Rotating());
    }

    IEnumerator Rotating()
    {
        Spinning = true;
        while (!resultsAreIn) //just rotating until we get results
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+62, transform.localPosition.z);
            if(transform.localPosition.y  > 1375f) {
                transform.localPosition = new Vector3(transform.localPosition.x, -1400f, transform.localPosition.z);
            }
            yield return new WaitForSeconds(0.02f);
        }
        for(int i = 0; i < 10; i++) // a little spin after getting results
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 62, transform.localPosition.z);
            if (transform.localPosition.y > 1375f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -1400f, transform.localPosition.z);
            }
            yield return new WaitForSeconds(0.02f);
        }
        while(transform.localPosition.y!= -1400 + (resulToShow * 310)) //Stopping on a picture based on its number
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 62, transform.localPosition.z);
            if (transform.localPosition.y > 1375f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -1400f, transform.localPosition.z);
            }
            yield return new WaitForSeconds(0.02f);
        }
        Spinning = false;
        resultsAreIn = false;
        yield break;
    }

}
