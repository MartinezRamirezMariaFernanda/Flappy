﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columnas : MonoBehaviour {
    public int columnPoolSize = 5;
    public GameObject columnPrefabs;
    public float ColumnMin = -1.75f;
    public float ColumnMax = 0.2f;
    private float spawnXPosition = 10f;
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-14, 0);
    private float timeSinceLastSpawned;
    public float spawnRate;
    private int currentColumn;
	void Start () {
        columns = new GameObject[columnPoolSize];
        for(int i=0; i<columnPoolSize; i++){
            columns[i] = Instantiate(columnPrefabs, objectPoolPosition, Quaternion.identity);
        }
        SpawnColumn();
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;
        if(!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate){
            timeSinceLastSpawned = 0;
            SpawnColumn();
        }
     }
    void SpawnColumn(){
        float spawnYPosition = Random.Range(ColumnMin, ColumnMax);
        columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentColumn++;
        if (currentColumn >= columnPoolSize){
            currentColumn = 0;
        }
    }
}