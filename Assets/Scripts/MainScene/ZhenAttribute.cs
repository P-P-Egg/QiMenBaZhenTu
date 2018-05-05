using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhenAttribute : MonoBehaviour {
	public Vector2 coordinate;//坐标
	public bool isplayer;//是否是主角位置
    public bool isopen;//是否已经走过
    public bool isdoor;//是否是门
    public GameObject player;//用于存放主角属性
    public GameObject zhen_type;//用于存放阵的种类
}
