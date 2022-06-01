using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneType : MonoBehaviour
{
    private int planeType;
    private string factionType;
    private Sprite planeSprite;
    private GameObject planeManager;

    // Start is called before the first frame update
    void Start()
    {
        planeManager = GameObject.Find("aircraftManager"); 
        randomizer();
        Debug.Log("faction: " + factionType);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("plane type: " + planeType);
            Debug.Log("plane faction: " + factionType);
        }
    }

    private void randomizer()
    {
        planeType = Random.Range(0, 5);

        switch (planeType){
            case 0:
                //Debug.Log("hellcat");
                factionType = "allied";
                planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                break;
            case 1:
                //Debug.Log("lightning");
                factionType = "allied";
                planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                break;
            case 2:
                //Debug.Log("fortress");
                factionType = "allied";
                planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                break;
            case 3:
                //Debug.Log("messerschmit");
                factionType = "axis";
                planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                break;
            case 4:
                //Debug.Log("heinkel");
                factionType = "axis";
                planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                break;
            case 5:
                //Debug.Log("fockwulf");
                factionType = "axis";
                planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                break;
            default:
                //Debug.Log("");
                break;
        }
 
    }

    public int getPlaneType()
    {
        return planeType;
    }

    public string getFaction()
    {
        return factionType;
    }

    public Sprite getSprite()
    {
        return planeSprite;
    }

}
