﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {

        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Hit");
                //Destroy(other.gameObject);
            }
        }
    }
}