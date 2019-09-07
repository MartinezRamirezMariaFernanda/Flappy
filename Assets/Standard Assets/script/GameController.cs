using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public GameObject gameOverText;
    public bool gameOver;
    public float scrollSpeed = -1.5f;
    private int score;
    public Text scoreText;

    public void Awake() {
        if (GameController.instance == null) {
            GameController.instance = this;
        } else if (GameController.instance != this) {
            Destroy(gameObject);
            Debug.LogWarning("GameController Ha Sido Instanciado Por Segunda Vez, Esto No Deberia Pasar.");
        }
    }
    public void BirdScored(){
        if (gameOver) return;
        score++;
        scoreText.text = "Puntos: " + score;
        SoundSystem.instance.PlayCoin();
    }
    public void BirdDie(){
        gameOverText.SetActive(true);
        gameOver = true;
    }
    void WaitinMethod(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update(){
        if (gameOver && Input.GetMouseButtonDown(0)){
            Invoke("WaitinMethod", 0.5f);
        }
    }
        private void OnDestroy(){
        if (GameController.instance == this){
            GameController.instance = null;
        }
    }
}
