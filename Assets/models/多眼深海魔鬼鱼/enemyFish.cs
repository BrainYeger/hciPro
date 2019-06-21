using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFish : MonoBehaviour
{
    // Start is called before the first frame update

    float CreatTime = 5f;
    GameObject Wolfs; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CreatTime -= Time.deltaTime;    //开始倒计时
        if (CreatTime <= 0)    //如果倒计时为0 的时候
        {
            CreatTime = Random.Range(3, 10);     //随机3到9秒内
            GameObject obj = (GameObject)Resources.Load("prefab/ghostFish");    //加载预制体到内存
            Wolfs = Instantiate<GameObject>(obj);    //实例化敌人
            Wolfs.transform.position = new Vector3(Random.Range(-40f, 37f), Random.Range(-10f, 10f), Random.Range(27f, 37f));    //随机生成狼的位置
        }

    }
}
