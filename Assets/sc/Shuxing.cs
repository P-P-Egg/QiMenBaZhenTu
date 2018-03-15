using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuxing : MonoBehaviour {
    public bool ischaracter;
    public Vector2 zhuobiao;//坐标
    public bool isdoor;
    public Color gezi_color;
    private void Start()//开始调用
    {
        gezi_color = GetComponent<Renderer>().material.color;
    }
    private void Update()//每一帧调用
    {
        characterposition();
        blick_gezi();
    }
    private void characterposition()
    {
        if (ischaracter == true)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = gezi_color;
        }
    }//角色位置
    private void blick_gezi()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))

            {
                //if (hit.collider.tag == "gezi"|| hit.collider.tag=="men")
                //{
                    //hit.collider.GetComponent<Shuxing>().ischaracter = true;
                //}
            }
        }
    }
}
  

		
