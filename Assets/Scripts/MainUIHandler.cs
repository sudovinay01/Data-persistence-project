using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MainUIHandler : MonoBehaviour
{

    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private TextMeshProUGUI warningText, bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        warningText.text = "";
        bestScoreText.text = "";
        if (GameManager.Instace.bestScorePlayer != "")
        {
            bestScoreText.text = $"Best Score by : {GameManager.Instace.bestScorePlayer} : {GameManager.Instace.bestScore}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (playerNameInputField.text.Trim() == "")
        {
            warningText.text = "Enter your name below.....";
            return;
        }
        else
        {
            GameManager.Instace.currentPlayerName = playerNameInputField.text.Trim();
            SceneManager.LoadScene("main");
        }
    }

    public void ViewHighScore()
    {
        SceneManager.LoadScene("highScore");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
