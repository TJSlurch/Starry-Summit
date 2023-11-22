using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // MenuManager script
    [SerializeField] MenuManager menu;
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
