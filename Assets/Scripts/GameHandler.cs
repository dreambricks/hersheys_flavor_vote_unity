using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public ArduinoCommunicationReceiver arduinoCommunicationReceiver;

    public Text pt_bolo_txt;
    public Text pt_beijinho_txt;

    private int pt_bolo;
    private int pt_beijinho;

    int perc_bolo;
    int perc_beijinho;

    public BeijinhoController beijinho;
    public BoloController bolo;

    public string data;

    public float cooldownTime;
    public bool canPressButton = true;
    private float cooldownTimer;

    private void Start()
    {
        LoadData();
    }

    void Update()
    {
        GetArduinoData();
    }

    private void GetArduinoData()
    {
        data = arduinoCommunicationReceiver.GetLastestData();

        //if (canPressButton && Input.GetKeyDown(KeyCode.A))
        if (canPressButton && data == "A")
        {

            IncreaseBolo();
            UpdatePercentage();
            SaveData();
            SelectBolo();

            canPressButton = false;
            cooldownTimer = cooldownTime;
        }


        //if (canPressButton && Input.GetKeyDown(KeyCode.B))
        if (canPressButton && data == "B")

        {
            IncreaseBeijinho();
            UpdatePercentage();
            SaveData();
            SelectBeijinho();

            canPressButton = false;
            cooldownTimer = cooldownTime;
        }


        if (!canPressButton)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                canPressButton = true;
            }
        }
    }

    private void IncreaseBolo()
    {
        pt_bolo += 1;
    }

    private void IncreaseBeijinho()
    {
        pt_beijinho += 1;
    }

    private void UpdatePercentage()
    {
        perc_bolo = (int)Math.Round(pt_bolo * 100.0 / (pt_bolo + pt_beijinho));
        perc_beijinho = 100 - perc_bolo;


        pt_bolo_txt.text = perc_bolo.ToString() + "%";
        pt_beijinho_txt.text = perc_beijinho.ToString() + "%";

        print(pt_bolo.ToString());
        print(pt_beijinho.ToString());
    }

    private void SaveData()
    {
        FlavorData data = new FlavorData();
        data.pt_bolo = pt_bolo;
        data.pt_beijinho =  pt_beijinho;
        FlavorData.SaveToJson(data);
    }

    private void LoadData()
    {
        FlavorData data = FlavorData.LoadFromJson();
        if (data != null)
        {
            pt_bolo = data.pt_bolo;
            pt_beijinho = data.pt_beijinho;

            UpdatePercentage();

        }
    }

    public void SelectBeijinho()
    {
        beijinho.GetComponent<Animator>().Play("SelectShakeBeijinho");
    }

    public void SelectBolo()
    {
        bolo.GetComponent<Animator>().Play("SelectShakeBolo");
    }

    public void ShowPoints()
    {
        beijinho.GetComponent<Animator>().Play("ToSide");
        bolo.GetComponent<Animator>().Play("ToSide");
    }

}
