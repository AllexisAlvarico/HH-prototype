using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotationSpeed;
    [SerializeField]
    private GameObject visualCone;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 60.0f;
        visualCone = GameObject.Find("visionCone");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            visualCone.transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            visualCone.transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        }

    }



}
