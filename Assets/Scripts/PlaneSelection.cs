using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "RadarLine")
        {
            Debug.Log("Player Touched Plane ID: " + collision.gameObject.GetComponent<PlaneType>().getID());
        }
    }

    public void AlliedAnswer()
    {

    }

    public void AxisAnswer()
    {

    }

}
