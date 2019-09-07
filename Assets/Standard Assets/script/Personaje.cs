using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upforce = 200f;
    private Rotacion rotateBird;
    private void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateBird = GetComponent<Rotacion>();
    }
	void Update () {
		if(isDead)return;
            if (Input.GetMouseButtonDown(0)){
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * upforce);
            anim.SetTrigger("Flap");
            SoundSystem.instance.PlayAleteo();
        }
        }
    private void OnCollisionEnter2D(Collision2D collision){
        isDead = true;
        anim.SetTrigger("Die");
        rotateBird.enabled = false;
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayGameOver();
    }
}
