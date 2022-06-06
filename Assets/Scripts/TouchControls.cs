using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private GameObject touchBoxBase;    //Used to set up the hit/touchbox
    private GameObject activeBox;       //Used to set positions and wether or not it's active;
    private Touch touchInput;
    private float activeCounter = 0.0f;
    private Vector3 touchPosition;

    public Vector2 boxSize = new Vector2(0.32f,0.32f);
    public float maxActiveTime = 0.1f;

    void Start()
    {
        touchBoxBase = new GameObject();
        touchBoxBase.AddComponent<PlaneSelection>();
        touchBoxBase.AddComponent<BoxCollider2D>();
        touchBoxBase.GetComponent<BoxCollider2D>().size = boxSize;    //Size is double the plane size
        touchBoxBase.SetActive(false);                                                  //Inactive by default
        activeBox = Instantiate(touchBoxBase, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        activeBox.SetActive(false);
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touchInput = Input.GetTouch(0);

            //Move and activate hit box at first touch posiiton
            if (!activeBox.activeSelf)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(touchInput.position);
                touchPosition.z = 0.0f;
                activeBox.transform.position = touchPosition;
                activeBox.SetActive(true);
            }
        }
        //Sets box inactive afer a period of time
        if (activeBox.activeSelf)
        {
            activeCounter += Time.deltaTime;
            if(activeCounter > maxActiveTime)
            {
                activeCounter = 0.0f;
                activeBox.SetActive(false);
            }
        }
    }
}
