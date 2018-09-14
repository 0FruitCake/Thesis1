﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionDialogRange : MonoBehaviour {

    private CompanionController npcmove;
    public bool triggeractive;
    private Vector3 playerPos;
    // Use this for initialization
    void Start () {
        npcmove = GetComponentInParent<CompanionController>();
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        playerPos = other.transform.position;

        if (other.gameObject.tag == "Player")
        {
            if (playerPos.y > transform.position.y)
            {
                GetComponentInParent<SpriteRenderer>().sortingOrder = 1;
            }
            else
            {
                GetComponentInParent<SpriteRenderer>().sortingOrder = 0;
            }
        }

        if (other.gameObject.tag == "Player" && npcmove.incutscene == false && triggeractive== true)
            {
                npcmove.canMove = false;
                npcmove.myRigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
        
         
     }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && npcmove.incutscene == false && triggeractive == true)
        {
            npcmove.canMove = true;
            npcmove.myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
