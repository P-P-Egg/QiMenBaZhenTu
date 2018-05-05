using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunction : MonoBehaviour {
    public Camera main;
    public Camera battle;
    private void Start()
    {
        firstpos();
    }
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0)&&main.enabled==true)//当处于main摄像头时点击才会执行此if
        { 
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            GameObject blick_zhen = hit.collider.gameObject;
            if (hit.collider.gameObject.tag == "zhen" && canMove(blick_zhen))
            {
                foreach (GameObject zhen in GameObject.FindGameObjectsWithTag("zhen"))
                {
                    zhen.GetComponent<ZhenAttribute>().isplayer = false;
                    zhen.GetComponent<ZhenAttribute>().player = null;
                }
                hit.collider.gameObject.GetComponent<ZhenAttribute>().isplayer = true;
                hit.collider.gameObject.GetComponent<ZhenAttribute>().isopen = true;
                hit.collider.gameObject.GetComponent<ZhenAttribute>().player = GameObject.FindGameObjectWithTag("Player");
                hittype(hit.collider.gameObject);
            }
            else
            {
                print("error");
            }           
        }
    }//角色移动
    private bool canMove(GameObject blick_zhen)
    {
        bool istrue = false;
        GameObject pos_zhen = null;
        foreach(GameObject zhen in GameObject.FindGameObjectsWithTag("zhen"))
        {
            if (zhen.GetComponent<ZhenAttribute>().isplayer)
            {
                pos_zhen = zhen;
            }
        }
        Vector2 pos_up = new Vector2(pos_zhen.GetComponent<ZhenAttribute>().coordinate.x, pos_zhen.GetComponent<ZhenAttribute>().coordinate.y + 1);
        Vector2 pos_down = new Vector2(pos_zhen.GetComponent<ZhenAttribute>().coordinate.x, pos_zhen.GetComponent<ZhenAttribute>().coordinate.y - 1);
        Vector2 pos_left = new Vector2(pos_zhen.GetComponent<ZhenAttribute>().coordinate.x - 1, pos_zhen.GetComponent<ZhenAttribute>().coordinate.y);
        Vector2 pos_right = new Vector2(pos_zhen.GetComponent<ZhenAttribute>().coordinate.x + 1, pos_zhen.GetComponent<ZhenAttribute>().coordinate.y);
        if(blick_zhen.GetComponent<ZhenAttribute>().coordinate== pos_up|| blick_zhen.GetComponent<ZhenAttribute>().coordinate ==pos_down|| blick_zhen.GetComponent<ZhenAttribute>().coordinate ==pos_left|| blick_zhen.GetComponent<ZhenAttribute>().coordinate == pos_right)
        {
            istrue = true;
        }
        return istrue;
    }//判断角色可否移动
    private void firstpos()
    {
        int first_pos = Random.Range(1, 8);
        foreach(GameObject zhen in GameObject.FindGameObjectsWithTag("zhen"))
        {
            if (zhen.GetComponent<ZhenAttribute>().isdoor)
            {
                switch (first_pos)
                {
                    case 1:
                        if(zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(4, 1))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 2:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(8, 1))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 3:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(1, 4))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 4:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(11, 4))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 5:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(1, 8))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 6:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(11, 8))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 7:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(4, 11))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                    case 8:
                        if (zhen.GetComponent<ZhenAttribute>().coordinate == new Vector2(8, 11))
                        {
                            zhen.GetComponent<ZhenAttribute>().isplayer = true;
                            zhen.GetComponent<ZhenAttribute>().isopen = true;
                        }
                        break;
                }
            }
        }
    }//角色起始位置
    private void hittype(GameObject hit)
    {
        if (hit.GetComponent<ZhenAttribute>().zhen_type == GameObject.FindWithTag("monsterexi"))
        {
            changetobattle();
        }
        if(hit.GetComponent<ZhenAttribute>().zhen_type == GameObject.FindWithTag("event"))
        {

        }
        if(hit.GetComponent<ZhenAttribute>().zhen_type == GameObject.FindWithTag("weapon"))
        {

        }
    }//走到新的阵会触发的反馈
    public void changetobattle()
    {
        main.enabled = false;
        battle.enabled = true;
    }//改变到战斗场景
    public void changetomain()
    {
        battle.enabled = false;
        main.enabled = true;
    }//改变的主场景
}
