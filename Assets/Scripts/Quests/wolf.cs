﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour {

    public EnemyHealthManager[] ehm;
    public questMainPalawan qmp;

	// Use this for initialization
	void Start () {
        for (int x = 0; x < ehm.Length; x++){
            ehm[x].isQuestMonster = true;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (qmp.questIndex == 5)
        {
            for (int x = 0; x < ehm.Length; x++)
            {
                ehm[x].isQuestActive = true;
            }
            
        }
        else{
  
                for (int x = 0; x < ehm.Length; x++)
                {
                    ehm[x].isQuestActive = false;
                }
            
        }

	}
}
