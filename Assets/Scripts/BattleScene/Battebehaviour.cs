using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battebehaviour : MonoBehaviour {
    public void attack(GameObject active,GameObject passive)
    {
        PlayerAttribute active_att = active.GetComponent<PlayerAttribute>();
        PlayerAttribute passive_att = passive.GetComponent<PlayerAttribute>();
        int damage = (int)(active_att.attack - (passive_att.attack * 0.2f));
        active_att.health -= 20;
        active_att.speed -= 2;
        passive_att.health -= damage;
        endcheck(active, passive);
    }//攻击反馈

    public void endcheck(GameObject active, GameObject passive)
    {
        PlayerAttribute active_att = active.GetComponent<PlayerAttribute>();
        PlayerAttribute passive_att = passive.GetComponent<PlayerAttribute>();
        if (active_att.health <= 0)
        {
            print("you lose");
        }
        if (passive_att.health <= 0)
        {
            print("you win");
        }
    }//用于检验更正每次操作后的溢出及溢出反馈
}
