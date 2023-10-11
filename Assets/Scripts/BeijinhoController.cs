using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeijinhoController : MonoBehaviour
{

    public GameHandler gameHandler; 

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

            
            bool isPlayingSide = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ToSide");
            bool isPlayingSelect = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SelectShakeBeijinho");



            if (!isPlayingSide && !isPlayingSelect)
            {
                GetComponent<Animator>().Play("ShakeBeijinho");
            }

        }
    }

    public void OnAnimationEndAndThank()
    {
        GetComponent<Animator>().Play("Rest");
    }

    public void OnSelectedBeijinho()
    {
        gameHandler.ShowPoints();
    }

}
