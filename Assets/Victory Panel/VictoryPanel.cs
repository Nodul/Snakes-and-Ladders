using TMPro;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public GameObject VictoryPanelElement;
    public TextMeshProUGUI VictoryTextElement;

    private void Awake()
    {
        VictoryPanelElement.SetActive(false);   
    }

    public void ShowVictoryPanel(string winnerName) 
    {
        VictoryTextElement.text = $"{winnerName} wins!";
        VictoryPanelElement.SetActive(true);
    }
}
