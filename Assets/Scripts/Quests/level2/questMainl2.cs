﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questMainl2 : MonoBehaviour
{
    public string[] questTitle;
    public string[] questDesc;
    public string[] questProg;
    public bool[] isCompleted;
    public bool questActive;
    public int questIndex;
    public QuestManager qm;
    public Image questupdated;

    public int wolfcount;
    public int recruitCount;


    private DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    public bool istriggered;

    private experienceManager xpm;
    public Image questcomp;
    private musicController mc;
    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        xpm = FindObjectOfType<experienceManager>();
        questProg = new string[questTitle.Length];
        isCompleted = new bool[questTitle.Length];
        qm.mainqactive = true;
        qm.questActivated();
        qm.buttonMain.gameObject.SetActive(true);
        questActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mc== null)
        {
            mc = FindObjectOfType<musicController>();
        }

        if (questIndex == 2)
        {

            if (wolfcount == 10)
            {
                StartCoroutine("restoretownstate");
            }
        }

        if (questIndex == 3)
        {

            if (recruitCount == 3)
            {
                questCompleted();
            }
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

        if (questIndex == questTitle.Length)
        {
            xpm.currentExperience += questTitle.Length * 10 / 2;


        }

    }

    public void onClickMain()
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
            qm.questTitle.text = questTitle[questIndex];
            qm.questDesc.text = questDesc[questIndex];
            qm.questProg.text = questProg[questIndex];

            if (questIndex == 2)
            {
                questProg[questIndex] = "Pirates Defeated : " + wolfcount + "/10";
                qm.questProg.text = questProg[questIndex];

            }
            else if (questIndex == questTitle.Length)
            {
                qm.questTitle.text = "Quest Completed";
                qm.questDesc.text = "Rewards: " + "\n" + questTitle.Length * 10 / 2 + " xp";
                qm.questProg.text = "";
            }
        }
    }

    IEnumerator restoretownstate()
    {
        questCompleted();
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();


        yield return StartCoroutine(sf.FadeToBlack());

        npcController npCont = GameObject.FindObjectOfType<npcController>().GetComponent<npcController>();
        npCont.set1State(true);
        npCont.set2State(false);
        mc.switchTrack(1);
        yield return StartCoroutine(sf.FadeToClear());

    }
}
