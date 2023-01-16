using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameManager gm;

    [Header("UI")]
    [SerializeField] Image prompt;
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;

        canvas = FindObjectOfType<Canvas>();
        prompt.enabled = false;
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowPrompt()
    {
        prompt.enabled = true;
    }
}
