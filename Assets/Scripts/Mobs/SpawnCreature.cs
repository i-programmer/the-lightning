using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class SpawnCreature : MonoBehaviour {
        
    public GameObject[] objects;

    private float leftBorder,
        rightBorder,
        topBorder,
        bottomBorder;
	

	void Awake () {     
        var dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;	   
	}
	

    public Creature Create() {        
        Vector3 spawnLocation = new Vector3(Random.Range(leftBorder / 1.5f, rightBorder / 1.5f), Random.Range(topBorder / 1.5f, bottomBorder / 1.5f), 0);
        int objectToSpawn = Random.Range(0, objects.Length);        
        GameObject go = Instantiate(objects[objectToSpawn], spawnLocation, transform.rotation) as GameObject;

        if (go != null) {            
            CreatureType creatureType = Helper.GetRandomEnum<CreatureType>();
            
            return Creature.Create(go, spawnLocation, creatureType);
        }

        return null;
    }
}
