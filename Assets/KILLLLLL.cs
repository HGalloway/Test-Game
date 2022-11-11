using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLLLLL : MonoBehaviour {
    public GameObject Player;
    void onCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player") {
            Debug.Log("Bonk");       
            Player.transform.position = new Vector3(-0.38f, 3.26f, -17.11f);
        }
    }
}
