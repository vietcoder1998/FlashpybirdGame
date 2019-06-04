using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeReborn : MonoBehaviour
{

    [SerializeField]
    private float number_reborn;

    [SerializeField]
    private GameObject pipeHolder;

    private float y;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_spawndPipe());
    }

    // Update is called once per frame
    void Update()
    {
        _CheckAlive();
    }

    IEnumerator _spawndPipe()
    {
        yield return new WaitForSeconds(1);
        y = pipeHolder.transform.position.y;
        Instantiate(pipeHolder, new Vector3(4, Random.Range(y - 2.5f, y + 2.5f), 0), Quaternion.identity);
        StartCoroutine(_spawndPipe());
    }

    private void _CheckAlive()
    {
        if (BirdObject.isAlive == false)
        {
            Destroy(this, 0);
        }
    }
}
