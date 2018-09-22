﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class side3Palawan : MonoBehaviour {

    // Use this for initialization
    public string[] questTitle;
    public string[] questDesc;
    public string[] questProg;
    public bool[] isCompleted;
    public bool questActive;
    public int questIndex;
    public QuestManager qm;
    public Image questupdated;
    private DialogueManager dMan;
    public experienceManager xpm;
    public Image questcomp;
    public bool kapDefeated;
    public zoneController zct;
    public GameObject sct;
    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();

        questProg = new string[questTitle.Length];
        isCompleted = new bool[questTitle.Length];
        kapDefeated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(kapDefeated == true)
        {
            sct.SetActive(false);
            zct.zone1State(true);
            questCompleted();
            kapDefeated = false;
        }

    }

    public void questCompleted()
    {
        if (questIndex == questTitle.Length)
        {
            questcomp.gameObject.SetActive(true);
        }
        else
        {
            questupdated.gameObject.SetActive(true);
        }
        xpm.currentExperience += 10;
        isCompleted[questIndex] = true;
        questIndex++;

        Debug.Log(questIndex);

    }

    public void onClickSide1()
    {
        Debug.Log("clicked");
        if (!questActive)
        {
            qm.questTitle.text = "";
            qm.questDesc.text = "Quest currently inactive";
            qm.questProg.text = "";
        }
        else
        {
            if (questIndex < questTitle.Length)
            {
                qm.questTitle.text = questTitle[questIndex];
                qm.questDesc.text = questDesc[questIndex];
                qm.questProg.text = questProg[questIndex];

            }
            else if (questIndex == questTitle.Length)
            {
                qm.questTitle.text = "";
                qm.questDesc.text = "Quest Completed";
                qm.questProg.text = "";
            }

        }
    }
}
