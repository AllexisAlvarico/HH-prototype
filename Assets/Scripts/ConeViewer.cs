using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeViewer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlaneType>().spotted = true;
        Debug.Log("Plane ID: " + collision.gameObject.GetComponent<PlaneType>().getID());
    }
}
