using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piecesScript : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 rightPosition;
    public bool InRightPosition;
    public bool selected;
    
    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(-10f,-2.9f), Random.Range(-5.8f,-9f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightPosition)<0.5f) {
            if (!selected) {
                if (!InRightPosition) {
                    transform.position = rightPosition;
                    InRightPosition = true;    
                    mainCamera.GetComponent<dragAndDrop>().scorePosition = true;        
                    GetComponent<SortingGroup>().sortingOrder = 0;                                                            
                }                                 
            }            
        }        
                         
    }
}
