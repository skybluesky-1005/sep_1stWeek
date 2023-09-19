using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputPlayerName : MonoBehaviour
{
    public Text playerNameInput;
    public GameObject panel;
    private string playerName;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }


    public void ConfirmName()
    {
        playerName = playerNameInput.text;

        if (playerName.Length >= 2 && playerName.Length <= 10)
        {
            PlayerPrefs.SetString("Name", playerName);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main");
        }
        else
            panel.SetActive(true);
    }

    public void RecreateName()
    {
        panel.SetActive(false);
    }
}
