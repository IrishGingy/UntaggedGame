using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject prompt;

    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(false);
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowPrompt()
    {
        prompt.SetActive(true);
    }

    public void HidePrompt()
    {
        prompt.SetActive(false);
    }
}
