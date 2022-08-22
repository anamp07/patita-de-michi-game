using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class dragAndDrop : MonoBehaviour
{
    public GameObject selectedPiece;
    int OIL = 1;  
    
    private int score; 
    public bool scorePosition;
    private bool showText;

    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.transform.CompareTag("puzzle")) {
                if (!hit.transform.GetComponent<piecesScript>().InRightPosition) {
                    selectedPiece = hit.transform.gameObject;      
                    selectedPiece.GetComponent<piecesScript>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;    

                    if (scorePosition) {
                        score=score+1;
                        scorePosition = false;
                    }                     
                } 
            }                      
        }  

        if(score==41) {            
            showText = true;
        }

        if(showText) {
            canvas.SetActive(true);
            showText = false;
        }

        if (selectedPiece!=null && Input.GetMouseButtonUp(0) ) {
            selectedPiece.GetComponent<piecesScript>().selected = false;            
            
            selectedPiece = null;
        }

        if (selectedPiece != null) {
            Vector3 MousePoint =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y,0);            
        }
        
    }
}
