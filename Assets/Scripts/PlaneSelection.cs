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

    [SerializeField]
    private Text scoreText;

    private string planeData;

    private float maxTimer = 3.0f;
    private float timer = 0;

    bool timerStart = false;

    private void Start()
    {     
        count = 0;
        score = 0;
    }

    private void Update()
    {
        if(timerStart)
        {
            timer += Time.deltaTime;
        }

        if (timer > maxTimer)
        {
            panel.SetActive(false);
            timerStart = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "RadarLine")
        {
            Debug.Log("Player Touched Plane ID: " + collision.gameObject.GetComponent<PlaneType>().getID());
            planeData = collision.gameObject.GetComponent<PlaneType>().getFaction();
            rawImageObj.texture = collision.gameObject.GetComponent<PlaneType>().getTexture();
            Destroy(collision.gameObject);
            panel.SetActive(true);
        }
    }

    public void AlliedAnswer()
    {

        if (planeData == "allied")
        {
            // give score if correct
            score++;
            count++;
            scoreText.text = "Score: " + score + "/" + count;

        }
        else
        {
            // no points
            count++;
            scoreText.text = "Score: " + score + "/" + count;
        }
        timerStart = true;
    }

    public void AxisAnswer()
    {
        // give score if correct
        if (planeData == "axis")
        {
            // give score if correct
            score++;
            count++;
            scoreText.text = "Score: " + score + "/" + count;
        }
        else
        {
            // no points
            count++;

            scoreText.text = "Score: " + score + "/" + count;
        }
        timerStart = true;

    }

    public int getCount()
    {
        return count;
    }

    public int getScore()
    {
        return score;
    }
    public void resetScore()
    {
        score = 0;
        count = 0;
    }



}
