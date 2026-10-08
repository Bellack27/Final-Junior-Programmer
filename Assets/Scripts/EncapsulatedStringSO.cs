using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "SharedStringData", menuName = "Data/Encapsulated String")]
public class EncapsulatedStringSO : ScriptableObject
{
    [SerializeField] private string _userInputText;

    public string UserInputText
    {
        get // ENCAPSULATION
        {
            return _userInputText;
        }
        set // ENCAPSULATION
        {
            if (string.IsNullOrEmpty(value))    
            {
                Debug.LogWarning("Attempted to set an empty string. Defaulting to 'Unknown Player'.");
                _userInputText = "Unknown Player";
            }
            else
            {
                _userInputText = value;
            }
        }
    }
}