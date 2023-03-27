using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get; private set; }
    
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private TextMeshProUGUI playerWinText;
    
    [SerializeField] private string lobbySceneName = "MatchMaking";

    private void Awake()
    {
        Instance = this;
    }

    public void EnableGameOverPanel(string playerName)
    {
        gameoverPanel.SetActive(true);
        playerWinText.text = playerName + " wins!";
    }
    
    public void BackToLobby()
    {
        SceneManager.LoadScene(lobbySceneName);
    }
}
