using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_Option : MonoBehaviour {
    private float attackspeed;
    [SerializeField]
    private GameObject attack;
    [SerializeField]
    private GameObject charge;
    [SerializeField]
    private GameObject surrender;
    [SerializeField]
    private GameObject escape;
    [SerializeField]
    private GameObject provoke;
    [SerializeField]
    private GameObject relax;
    [SerializeField]
    private GameObject defend;
    private GameObject player;//玩家信息
    private GameObject monster;//怪物信息
    private Battebehaviour behaviour;//行为方法
    private GameObject maincharacter;//玩家实体
    private GameObject monster_battle;//怪物实体
    private void Start()
    {
        attackspeed = 0.5f;
        player = GameObject.FindWithTag("Player");
        monster = GameObject.FindWithTag("monster(battle)").GetComponent<Battlecharacter>().character;
        behaviour = GameObject.FindWithTag("battlebehaviour").GetComponent<Battebehaviour>();
        maincharacter = GameObject.FindWithTag("maincharacter(battle)");
        monster_battle = GameObject.FindWithTag("monster(battle)");

    }//赋予各变量初值（实验阶段放于start中，之后会进行更改）
    private void OnMouseDown()
    {
        if (this.gameObject == attack)
        {
            behaviour.attack(player, monster);
            GameObject.FindWithTag("act").GetComponent<Main_Option>().Clear_rect();
            StartCoroutine(attack_act(maincharacter, monster_battle));
        }
    }//点击各个按钮产生反馈
    IEnumerator attack_act(GameObject active, GameObject passive)
    {
        bool isattack = false;
        float origin = active.transform.position.y;
        if (active.transform.position.y > passive.transform.position.y)
        {
            while (active.transform.position.y > passive.transform.position.y)
            {
                print("hehe");
                active.transform.Translate(0, -attackspeed, 0);
                yield return null;
            }
            isattack = true;
            while (isattack && active.transform.position.y < origin)
            {
                active.transform.Translate(0, attackspeed, 0);
                yield return null;
            }
        }
        else
        {
            while (active.transform.position.y < passive.transform.position.y)
            {
                active.transform.Translate(0, attackspeed, 0);
                yield return null;
            }
            isattack = true;
            while (isattack && active.transform.position.y > origin)
            {
                active.transform.Translate(0, -attackspeed, 0);
                yield return null;
            }
        }        
    }//攻击动作协程
}
