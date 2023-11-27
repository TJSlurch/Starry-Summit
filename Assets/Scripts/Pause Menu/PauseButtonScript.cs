using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    // MenuManager script
    [SerializeField] PauseMenuManager menu;
    // button destination (set in inspector)
    [SerializeField] string nextMenu;

    void Start()
    {
        // get components
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // MenuManager script changes active screen
        menu.NewMenuScreen(nextMenu);
    }
}

