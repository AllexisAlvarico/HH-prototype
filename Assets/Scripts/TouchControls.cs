using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{

    [SerializeField]
    private GameObject activeBox;       //Used to set positions and check wether or not the hitbox is active
    [SerializeField]
    private float maxActiveTime = 0.1f;
    
    private Touch touchInput;
    private float activeCounter = 0.0f;
    private Vector3 touchPosition;

    void Start()
    {
        activeBox.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touchInput = Input.GetTouch(0);

            //Move and activate hit box at first touch posiiton
            if (!activeBox.GetComponent<BoxCollider2D>().enabled)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touchInput.position);
                touchPosition.z = 0.0f;
                activeBox.transform.position = touchPosition;
                activeBox.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        //Sets box inactive afer a period of time
        if (activeBox.GetComponent<BoxCollider2D>().enabled)
        {
            activeCounter += Time.deltaTime;
            if(activeCounter > maxActiveTime)
            {
                activeCounter = 0.0f;
                activeBox.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }



}
