using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aircraftManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    public Sprite[] aircraftSprite;
    Vector3 position;

    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            position = new Vector3(Random.Range(-3.91f, 3.79f), Random.Range(-3.92f, 3.75f), 0);
            Instantiate(plane, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public Sprite setSprite(int type)
    {
        return aircraftSprite[type];
    }
}
