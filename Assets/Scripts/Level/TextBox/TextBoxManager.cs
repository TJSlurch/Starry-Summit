using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    // defines the game objects and respective variables
    [SerializeField] private PlayerLocationTracker tracker;
    [SerializeField] private GameObject TextboxUI;
    [SerializeField] private GameObject TextUI;
    [SerializeField] private GameObject ImageUI;
    [SerializeField] private List<Sprite> expressions;
    private GameObject textbox;
    private TextMeshProUGUI text;
    private Image image;


    void Start()
    {
        // assigns the game objects to their variable
        textbox = TextboxUI;
        text = TextUI.GetComponent<TextMeshProUGUI>();
        image = ImageUI.GetComponent<Image>();
    }

    // public mutator methods to alter textbox
    public void setVisible(bool visibility)
    {
        textbox.SetActive(visibility);
    }
    public void setText(string sentence)
    {
        text.text = sentence;
    }
    public void setImage(int value)
    {
        image.sprite = expressions[value];
    }
    
}
