using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhenFunction : MonoBehaviour {
    private Color ori_color;
    private void Start()
    {
        ori_color = GetComponent<SpriteRenderer>().color;
        Zhen_type();
    }
    private void Update()
    {
        if (GameObject.FindWithTag("cameracontrol").GetComponent<ChangeCamera>().main.enabled == true)
        {
            ChangeColor();
        }
    }
    private void ChangeColor()
    {
        if (GetComponent<ZhenAttribute>().isplayer)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            GetComponent<ZhenAttribute>().player = GameObject.FindGameObjectWithTag("Player");
        }
        if (!GetComponent<ZhenAttribute>().isplayer && !GetComponent<ZhenAttribute>().isopen)
        {
            GetComponent<SpriteRenderer>().color = ori_color;
        }
        if (GetComponent<ZhenAttribute>().isopen && !GetComponent<ZhenAttribute>().isplayer&& !GetComponent<ZhenAttribute>().isdoor)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        if(GetComponent<ZhenAttribute>().isopen && !GetComponent<ZhenAttribute>().isplayer && GetComponent<ZhenAttribute>().isdoor)
        {
            GetComponent<SpriteRenderer>().color = ori_color;
        }
    }//改变颜色来区分阵的属性

    private void Zhen_type()
    {
        int type_num = Random.Range(1, 4);
        switch (type_num)
        {
            case 1:
                GetComponent<ZhenAttribute>().zhen_type = GameObject.FindWithTag("weapon");
                break;
            case 2:
                GetComponent<ZhenAttribute>().zhen_type = GameObject.FindWithTag("event");
                break;
            case 3:
                GetComponent<ZhenAttribute>().zhen_type = GameObject.FindWithTag("monsterexi");
                break;
        }
    }//随机分配阵的种类
}
