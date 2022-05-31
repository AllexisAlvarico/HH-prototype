using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float timer;
    private float timerMax;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timerMax = 1f;
        timer = 0f;
        color = new Color(1, 1, 1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        color.a = Mathf.Lerp(timerMax, 0f, timer / timerMax);
        spriteRenderer.color = color;

        if (timer >= timerMax)
        {
            Destroy(gameObject);
        }

    }
}
