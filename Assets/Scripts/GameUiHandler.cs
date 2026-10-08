using UnityEngine;
using TMPro;


public class GameUiHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private EncapsulatedStringSO textContainer;
    [SerializeField] private PlayerController playerscript;

    private void Start()
    {
        int hp = playerscript.playerHealth;
        displayText.text = textContainer.UserInputText + "'s Healh: " + hp;
    }

    private void Update()
    {
        int hp = playerscript.playerHealth;
        displayText.text = textContainer.UserInputText + "'s Healh: " + hp;
    }
}
