using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "Best Score : " + ScoreManager.Instance.HighScoreName + " : " + ScoreManager.Instance.HighScore;
        nameField.text = ScoreManager.Instance.CurrentName;

        nameField.onEndEdit.AddListener(delegate
        {
            UpdateCurrentName(nameField);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateCurrentName(TMP_InputField field)
    {
        ScoreManager.Instance.CurrentName = field.text;
        ScoreManager.Instance.SaveAllData();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
