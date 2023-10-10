using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoloController : MonoBehaviour
{
    public GameObject thank_vote;

    public float totalTime;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = totalTime;
    }

   
    void Update()
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
                GetComponent<Animator>().Play("Shake");
            }
        }
    }


    public void OnAnimationEndAndThank()
    {
        GetComponent<Animator>().Play("Rest");
        thank_vote.SetActive(true);
    }

    public void OnAnimationEnd()
    {
        GetComponent<Animator>().Play("Rest");
    }


}
