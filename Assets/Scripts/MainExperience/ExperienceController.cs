using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*

PARA CARGAR ESCENAS ->
En canvas > (n)frame > Play Mini Game (button) > OnClick() > pasar nombre de escena a cargar (debe estar 'open additive' en la escena ppal)
CLICK DERECHO SOBRE ESCENA > Open Scene Additive > en la jerarquia, click derecho > unload scene 

En cada escena debería haber un button que la cierre para volver a la ppal
Intente en la escena del runner pero no logro que me de click el button D:
*/

public class ExperienceController : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject frame;
    
    private float timer = 0f;
    
    private int lastFrame = 0;
    private int currentFrame = 0;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;                
        frame.SetActive(false);                
    }

    // Update is called once per frame
    void Update()
    {        
        if (sceneName == "1st_Frame") {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit && hit.transform.CompareTag("Start")) {
                    StartGame();
                }                
            }            
        } else {
            NextFrame();                 
        }    
    }

    void StartGame() {
        frame.SetActive(true);
        StartPanel.SetActive(false);
    }

    void NextFrame() {
        frame.SetActive(true);
    }
   
}
