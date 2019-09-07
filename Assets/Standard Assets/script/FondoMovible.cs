﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovible : MonoBehaviour {
    private Rigidbody2D rb2d;
    private void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start () {
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
	}
    void Update() {
        if (GameController.instance.gameOver){
            rb2d.velocity = Vector2.zero;
        }
	}
}
