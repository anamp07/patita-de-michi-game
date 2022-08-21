﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    [SerializeField] private Key.KeyType keyType;

    

    private void Awake() {
        
    }

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor() {
        print("Abrida la puerta");
    }

    public void PlayOpenFailAnim() {
        
    }

}
