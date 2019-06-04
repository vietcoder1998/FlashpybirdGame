using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float h_screen = sr.bounds.size.y;
        float w_screen = sr.bounds.size.x;

        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width/ Screen.height;
        tempScale.y = height / h_screen;
        tempScale.x = width / w_screen;

        Debug.Log(tempScale);

        transform.localScale = tempScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
