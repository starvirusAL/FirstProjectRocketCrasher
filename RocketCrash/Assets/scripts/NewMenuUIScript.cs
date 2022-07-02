using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMenuUIScript : MonoBehaviour
{
   
    [SerializeField]
    private Canvas menu, optionsMenu;
    [SerializeField]
    private Dropdown monitorOptions;
    public void MethodOptions()
    {if(menu != null) { menu.GetComponent<Canvas>().enabled = false; }
        
        optionsMenu.GetComponent<Canvas>().enabled = true;
    }
    public void MethodOptionsClose()
    {
        if (menu != null) {menu.GetComponent<Canvas>().enabled = true; }
        optionsMenu.GetComponent<Canvas>().enabled = false;
    }
    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }
    public void Exit()
    {

        Application.Quit(); ;
    }

   public void ChangeOptionsMonitor()
    {
        if (monitorOptions.value == 1)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (monitorOptions.value == 0)
        {
            Screen.SetResolution(1366, 768, true);
            
        }
        else if (monitorOptions.value == 2)
        {
            Screen.SetResolution(1024, 768, true);
        }
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))  // если нажата клавиша Esc (Escape)
        {
            Exit();  // закрыть приложение
        }
    }
}
