using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    private void Awake(){
        groundCollider = GetComponent<BoxCollider2D>();
    }
    void Start () {
        groundHorizontalLength = groundCollider.size.x;
	}
    private void RepositionBackground(){
        transform.Translate(Vector2.right * groundHorizontalLength * 2);
    }
	void Update () {
		if(transform.position.x < -groundHorizontalLength){
            RepositionBackground();
        }
	}
}
