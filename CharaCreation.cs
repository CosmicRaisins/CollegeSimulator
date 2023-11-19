using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreationMenu : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text pointsRemainingText;
    public TMP_Text strengthValueText;
    public TMP_Text dexterityValueText;
    public TMP_Text constitutionValueText;
    public TMP_Text intelligenceValueText;
    public TMP_Text wisdomValueText;
    public TMP_Text charismaValueText;
    
    public Button plusStrengthButton;
    public Button minusStrengthButton;
    public Button plusDexterityButton;
    public Button minusDexterityButton;
    public Button plusConstitutionButton;
    public Button minusConstitutionButton;
    public Button plusIntelligenceButton;
    public Button minusIntelligenceButton;
    public Button plusWisdomButton;
    public Button minusWisdomButton;
    public Button plusCharismaButton;
    public Button minusCharismaButton;
    public Button confirmCharacterButton;

    private string characterName;
    private int pointsRemaining = 15;
    private int strengthValue;
    private int dexterityValue;
    private int constitutionValue;
    private int intelligenceValue;
    private int wisdomValue;
    private int charismaValue;

    // Use this for initialization
    void Start()
    {
        // Initialize default values
        strengthValue = 10; // Set initial value
        dexterityValue = 10;
        constitutionValue = 10;
        intelligenceValue = 10;
        wisdomValue = 10;
        charismaValue = 10;

        // Set up button click listeners
        plusStrengthButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Strength", 1); });
        minusStrengthButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Strength", -1); });
        plusDexterityButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Dexterity", 1); });
        minusDexterityButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Dexterity", -1); });
        plusConstitutionButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Constitution", 1); });
        minusConstitutionButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Constitution", -1); });
        plusIntelligenceButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Intelligence", 1); });
        minusIntelligenceButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Intelligence", -1); });
        plusWisdomButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Wisdom", 1); });
        minusWisdomButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Wisdom", -1); });
        plusCharismaButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Charisma", 1); });
        minusCharismaButton.onClick.AddListener(delegate { OnAttributeButtonClicked("Charisma", -1); });
        confirmCharacterButton.onClick.AddListener(delegate { CreateCharacter(); });

        // Update UI text
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can add more real-time updates here
    }

    // Method to update UI text
    void UpdateUI()
    {
        pointsRemainingText.text = "Points Remaining: " + pointsRemaining;
        strengthValueText.text = "STR: " + strengthValue.ToString();
        dexterityValueText.text = "DEX: " + dexterityValue.ToString();
        constitutionValueText.text = "CON: " + constitutionValue.ToString();
        intelligenceValueText.text = "INT: " + intelligenceValue.ToString();
        wisdomValueText.text = "WIS: " + wisdomValue.ToString();
        charismaValueText.text = "CHA: " + charismaValue.ToString();
    }

    // Event handler for attribute buttons
    public void OnAttributeButtonClicked(string attributeName, int modifier)
    {
        int newValue = GetAttributeValue(attributeName) + modifier;

        // Check if the new value is within the valid range
        if (newValue >= 8 && newValue <= 15)
        {
            // Calculate the difference in points
            int pointDifference = newValue - GetAttributeValue(attributeName);

            // Check if there are enough points remaining
            if (pointsRemaining - pointDifference >= 0)
            {
                // Update the attribute value
                SetAttributeValue(attributeName, newValue);

                // Update points remaining
                pointsRemaining -= pointDifference;

                // Update UI
                UpdateUI();
            }
        }
    }

    // Method to get the current value of an attribute
    int GetAttributeValue(string attributeName)
    {
        switch (attributeName)
        {
            case "Strength":
                return strengthValue;
            case "Dexterity":
                return dexterityValue;
            case "Constitution":
                return constitutionValue;
            case "Intelligence":
                return intelligenceValue;
            case "Wisdom":
                return wisdomValue;
            case "Charisma":
                return charismaValue;
            default:
                return 0;
        }
    }

    // Method to set the value of an attribute
    void SetAttributeValue(string attributeName, int value)
    {
        switch (attributeName)
        {
            case "Strength":
                strengthValue = value;
                break;
            case "Dexterity":
                dexterityValue = value;
                break;
            case "Constitution":
                constitutionValue = value;
                break;
            case "Intelligence":
                intelligenceValue = value;
                break;
            case "Wisdom":
                wisdomValue = value;
                break;
            case "Charisma":
                charismaValue = value;
                break;
        }
    }

    // Method to create the character
    public void CreateCharacter()
    {
        // Perform character creation logic here
        characterName = nameInputField.text;
        
        Debug.Log("Character Created:");
        Debug.Log("Name: " + characterName);
        Debug.Log("Strength: " + strengthValue);
        Debug.Log("Dexterity: " + dexterityValue);
        Debug.Log("Constitution: " + constitutionValue);
        Debug.Log("Intelligence: " + intelligenceValue);
        Debug.Log("Wisdom: " + wisdomValue);
        Debug.Log("Charisma: " + charismaValue);

        
        // Create a new player character
        Player player = new Player(characterName, 4.0f, 60, strengthValue, dexterityValue, constitutionValue, intelligenceValue, wisdomValue, charismaValue, null);
        Debug.Log("Created character's name is " + player.getName());
        // Optionally, you can instantiate a player character or save the data to use later
    }
}
