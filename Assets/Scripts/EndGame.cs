using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject hitBox;

    [SerializeField]
    private GameObject endScreen;

    [SerializeField]
    private Text endingText;

    [SerializeField]
    private Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if(hitBox.GetComponent<PlaneSelection>().getCount() == this.gameObject.GetComponent<aircraftManager>().GetAmountOfPlane())
        {
            endScreen.SetActive(true);
            scoreText.gameObject.SetActive(false);
            endingText.gameObject.SetActive(true);
            endingText.text =  "Final Score: " + hitBox.GetComponent<PlaneSelection>().getScore() + "/" + hitBox.GetComponent<PlaneSelection>().getCount();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("RadarScene");
    }
}
