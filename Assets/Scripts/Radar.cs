using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform radarPing;
    private float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(radarPing, collision.transform.position, Quaternion.identity).GetComponent<RadarPing>();
    }
}
