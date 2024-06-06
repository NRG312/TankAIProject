using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour {

    public GameObject explosion;
    Rigidbody rb;

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "tank") {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    void Start() {

        rb = GetComponent<Rigidbody>();
    }

    void Update() {


        this.transform.forward = rb.velocity;
    }
}