using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private Transform sweepTransform;
    private float rotationSpeed;
    private float radarDist;
    private List<Collider2D> colliderList;
    
    // Start is called before the first frame update
    void Start()
    {
        sweepTransform = transform.Find("RadarLine");
        rotationSpeed = 45.0f;
        radarDist = 100f;
        colliderList = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float prevoiusRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        float currentRotation = (sweepTransform.eulerAngles.z % 360) - 180;

        if(prevoiusRotation < 0 && currentRotation >= 0)
        {
            colliderList.Clear();
        }

        RaycastHit2D raycastHit2D= Physics2D.Raycast(transform.position, GetVectorFromAngle(sweepTransform.eulerAngles.z), radarDist);
        if(raycastHit2D.collider != null)
        {
            if (!colliderList.Contains(raycastHit2D.collider))
            {
                //hit
                colliderList.Add(raycastHit2D.collider);
                Debug.Log("Pinged");
                Debug.Log("name: " + transform.ToString());
            }
        }
    }


    static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }
}
