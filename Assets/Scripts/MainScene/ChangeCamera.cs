using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    public Camera main;
    public Camera battle;
    private void Awake()
    {
        main.enabled = true;
        battle.enabled = false;
    }
    private void OnMouseDown()
    {
        main.enabled = false;
        battle.enabled = true;
    }
}
