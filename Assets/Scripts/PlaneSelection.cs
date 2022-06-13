using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private RawImage rawImageObj;

    private int count;
    private int score;

    private GameObject scoreText;
    private GameObject planeData;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreText");         
        count = 0;
        score = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "RadarLine")
        {
            Debug.Log("Player Touched Plane ID: " + collision.gameObject.GetComponent<PlaneType>().getID());
            planeData = collision.gameObject;
            rawImageObj.texture = collision.gameObject.GetComponent<PlaneType>().getTexture();
            //Destroy(collision.gameObject);
            panel.SetActive(true);
        }
    }

    public void AlliedAnswer()
    {

        if (planeData.GetComponent<PlaneType>().getFaction() == "allied")
        {
            // give score if correct
            score++;
            count++;
            scoreText.GetComponent<Text>().text = "Score: " + score + "/" + count;

        }
        else
        {
            // no points
            count++;
            scoreText.GetComponent<Text>().text = "Score: " + score + "/" + count;
        }
        panel.SetActive(false);
    }

    public void AxisAnswer()
    {
        // give score if correct
        if (planeData.GetComponent<PlaneType>().getFaction() == "axis")
        {
            // give score if correct
            score++;
            count++;
            scoreText.GetComponent<Text>().text = "Score: " + score + "/" + count;
        }
        else
        {
            // no points
            count++;

            scoreText.GetComponent<Text>().text = "Score: " + score + "/" + count;
        }
        panel.SetActive(false);
    }

}
