using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxColliderManager : MonoBehaviour
{
    [SerializeField] private TextBoxManager textbox;
    [SerializeField] private string sentence;
    [SerializeField] private int expression;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textbox.setVisible(true);
        textbox.setText(sentence);
        textbox.setImage(expression);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textbox.setVisible(false);
    }
}
