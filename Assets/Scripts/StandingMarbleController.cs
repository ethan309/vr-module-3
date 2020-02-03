using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandingMarbleController : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject centerpoint;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        rb = GetComponent<Rigidbody>();
        centerpoint = GameObject.FindGameObjectsWithTag("Centerpoint")[0];
    }

    private void FixedUpdate()
    {
        float separation = Vector3.Distance(centerpoint.transform.position, transform.position);
        if(separation > 6.1)
        {
            active = false;
            transform.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target Object"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
