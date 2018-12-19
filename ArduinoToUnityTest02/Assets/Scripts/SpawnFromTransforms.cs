using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromTransforms : MonoBehaviour {

    public Transform[] spawn;
    public Transform[] prefab;
    public int maxSpawns;
    private int amntOfSpawns;

    public float timerLength;
    public float timer;

    public bool spawnNow;

	// Use this for initialization
	void Start () {
        timer = 0;
        spawnNow = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if ((timer >= timerLength && amntOfSpawns < maxSpawns) || spawnNow) {
            Instantiate(prefab[Mathf.FloorToInt(Random.Range(0, prefab.Length))], 
                spawn[Mathf.FloorToInt(Random.Range(0, spawn.Length))].transform.position, Quaternion.identity);
            amntOfSpawns++;
            spawnNow = false;
            timer = 0;

        }
    }
}
