using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float speed;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _pipeMoveMent();
    }

    void _pipeMoveMent()
    {
        if (BirdObject.isAlive == true)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
