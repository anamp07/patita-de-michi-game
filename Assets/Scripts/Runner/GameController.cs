using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    public int score;
    public int obstacleCount;    
    
    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        if(score>10) {
            Destroy(player.gameObject);
            panel.SetActive(true);

        }
        
        if(obstacleCount>3 && score>0) {
            score--;
            obstacleCount=0;
        }        
        
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.transform.CompareTag("Close")) {
                SceneManager.LoadScene("2nd_Frame");
            }
        }        
    }
}
