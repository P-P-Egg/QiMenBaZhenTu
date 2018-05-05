using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Option : MonoBehaviour {
    public int button_type;//按钮属性（用数字记录）
    public double movespeed;//框体移动速度
    public bool isuse = false;//是否已经触碰
    private Vector3 ori_pos;
    private void Start()
    {
        ori_pos = GameObject.FindWithTag("information(option)").GetComponent<RectTransform>().position;
    }//赋予变量初值
    private void OnMouseDown()
    {
        switch (button_type)
        {
            case 1:
                Clear_rect();
                StartCoroutine(Move_act_option());
                break;
            case 2:
                Clear_rect();
                StartCoroutine(Move_spell_option());
                break;
            case 3:
                Clear_rect();
                StartCoroutine(Move_item_option());
                break;
            case 4:
                Clear_rect();
                StartCoroutine(Move_information_option());
                break;
            case 5:
                break;
        }
    }//按钮反馈
    IEnumerator Move_act_option()
    {
        this.isuse = true;
        Transform rect = GameObject.FindWithTag("act(option)").GetComponent<RectTransform>();
        while (rect.position.x <= 0)
        {
            rect.Translate((float)movespeed, 0, 0);
            yield return null;
        }            
    }
    IEnumerator Move_spell_option()
    {
        this.isuse = true;
        Transform rect = GameObject.FindWithTag("spell(option)").GetComponent<RectTransform>();
        while (rect.position.x <= 0)
        {
            rect.Translate((float)movespeed, 0, 0);
            yield return null;
        }
    }
    IEnumerator Move_item_option()
    {
        this.isuse = true;
        Transform rect = GameObject.FindWithTag("item(option)").GetComponent<RectTransform>();
        while (rect.position.x <= 0)
        {
            rect.Translate((float)movespeed, 0, 0);
            yield return null;
        }
    }
    IEnumerator Move_information_option()
    {
        this.isuse = true;
        Transform rect = GameObject.FindWithTag("information(option)").GetComponent<RectTransform>();
        while (rect.position.x <= 0)
        {
            rect.Translate((float)movespeed, 0, 0);
            yield return null;
        }
    }//每个按钮框移到屏幕中间的动画协程

    public void Clear_rect()
    {
        if (GameObject.FindWithTag("information").GetComponent<Main_Option>().isuse)
        {
            GameObject.FindWithTag("information(option)").GetComponent<RectTransform>().position = ori_pos;
        }
        if (GameObject.FindWithTag("act").GetComponent<Main_Option>().isuse)
        {
            GameObject.FindWithTag("act(option)").GetComponent<RectTransform>().position = ori_pos;
        }
        if (GameObject.FindWithTag("item").GetComponent<Main_Option>().isuse)
        {
            GameObject.FindWithTag("item(option)").GetComponent<RectTransform>().position = ori_pos;
        }
        if (GameObject.FindWithTag("spell").GetComponent<Main_Option>().isuse)
        {
            GameObject.FindWithTag("spell(option)").GetComponent<RectTransform>().position = ori_pos;
        }
    }//用于清除屏幕中央按钮框的方法
}
