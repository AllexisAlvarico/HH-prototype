using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneType : MonoBehaviour
{
    private int planeType;
    private string factionType;
    private string aircraftName;
    private Sprite planeSprite;
    private GameObject planeManager;
    public int planeID;
    public bool spotted;

    // Start is called before the first frame update
    void Start()
    {
        planeManager = GameObject.Find("aircraftManager");
        randomizer();
        Debug.Log("faction: " + factionType);
        spotted = false;
    }


    private void Update()
    {
        //put box here when it clicking on the radar
    }

    private void randomizer()
    {
        planeType = Random.Range(0, 5);

        if (spotted)
        {
            switch (planeType)
            {
                case 0:
                    aircraftName = "F6F Hellcat";
                    factionType = "allied";
                    planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                    break;
                case 1:
                    aircraftName = "P-38 Lightning";
                    factionType = "allied";
                    planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                    break;
                case 2:
                    aircraftName = "B-17 Flying Fortress";
                    factionType = "allied";
                    planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                    break;
                case 3:
                    aircraftName = "Messerschmit 'ME. 110'";
                    factionType = "axis";
                    planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                    break;
                case 4:
                    aircraftName = "Heinkel 'HE.111'";
                    factionType = "axis";
                    planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                    break;
                case 5:
                    aircraftName = "Focke-wulf 'F.W.200'";
                    factionType = "axis";
                    planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(planeType);
                    break;
                default:
                    //Debug.Log("");
                    break;
            }
        }
        else
        {
            aircraftName = "No visual";
            //planeSprite = planeManager.GetComponent<aircraftManager>().setSprite(put "no visual" sprite);
        }
    }

    public string getName()
    {
        return aircraftName;
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

    public Texture getTexture()
    {
        return planeSprite.texture;
    }

    public int getID()
    {
        return planeID;
    }

    public void spawnPlane(GameObject _object, Vector3 _postion, int _id)
    {
        planeID = _id;
        Instantiate(_object, _postion, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Plane")
        {
            transform.position = new Vector3(Random.Range(-3.91f, 3.79f), Random.Range(-3.92f, 3.75f), 0);
        }
    }
}