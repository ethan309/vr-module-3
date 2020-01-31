using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleController : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject otherBall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float dist = Vector3.Distance(otherBall.transform.position, transform.position);
        print("Distance to other: " + dist);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target Object"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
