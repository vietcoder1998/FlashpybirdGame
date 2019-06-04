using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Text score, endScoreText, bestScoreText;
    // Start is called before the first frame update

    [System.Obsolete]
    private void Awake()
    {
    }

    [System.Obsolete]
    public void _PlayGame()
    {
        Debug.Log("i`m changing now");
        Application.LoadLevel("flashpy");
    }
}
