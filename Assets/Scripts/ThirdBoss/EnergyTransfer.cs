﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTransfer : MonoBehaviour {
    float angleToShip = 0;
    float step = 0;
    float speed = 8;
    public GameObject lightningPortal;
    bool instantiatedPortal = false;

	void Start () {
		
	}

	void Update () {
        step = speed * Time.deltaTime;
        Vector3 vectorToTarget = GameObject.Find("PlayerSpaceShip").transform.position - transform.position;
        angleToShip = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.position += new Vector3(Mathf.Cos(angleToShip * Mathf.Deg2Rad), Mathf.Sin(angleToShip * Mathf.Deg2Rad), 0) * step;
        transform.rotation = Quaternion.Euler(0,0,angleToShip);
        if (Mathf.Sqrt(Mathf.Pow(vectorToTarget.x, 2) + Mathf.Pow(vectorToTarget.y, 2)) < 0.1 && instantiatedPortal == false)
        {
            Instantiate(lightningPortal, GameObject.Find("PlayerSpaceShip").transform.position, Quaternion.identity);
            instantiatedPortal = true;
            Destroy(this.gameObject);
        }

    }
}
