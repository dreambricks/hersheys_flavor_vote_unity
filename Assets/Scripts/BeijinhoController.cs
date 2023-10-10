using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeijinhoController : MonoBehaviour
{
    public float totalTime;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        Countdown();
    }


    public void Countdown()
    {
        currentTime -= Time.deltaTime;
      
        if (currentTime <= 0)
        {
            int randomInt = Random.Range(2, 6);
            currentTime = totalTime + randomInt;

            
            bool isPlaying = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ToSide");

           
            if (!isPlaying)
            {
                GetComponent<Animator>().Play("ShakeBeijinho");
            }

        }
    }

    public void OnAnimationEndAndThank()
    {
        GetComponent<Animator>().Play("Rest");
    }

}
