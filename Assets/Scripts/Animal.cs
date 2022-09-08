using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float explosionForce = 1000f;
    // Update is called once per frame
    public void go()
    {
        StartCoroutine(Jump());
    }


    public IEnumerator Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(3f);
        rb.AddExplosionForce(explosionForce,new Vector3(transform.position.x+ Random.Range(-0.1f,0.1f), transform.position.y + Random.Range(-0.1f, 0.1f), transform.position.z + Random.Range(-0.1f, 0.1f)), 1f, 1f, ForceMode.Force);
        gameObject.tag = "Player";
        print("wee");
    }
}
