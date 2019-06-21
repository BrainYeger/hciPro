using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int MaxHP = 100;
    public Slider slider;
    //private Slider blood_slider;
    public int CurrentHP;
    // Use this for initialization

    private Transform player;
    public GameObject bullet;
    public float attackDistance = 0;
    private Animator _animator;
    public float speed;
    public float b_speed;
    private CharacterController cc;
    public float attackTime = 3;   //设置定时器时间 3秒攻击一次
    private float attackCounter = 0; //计时器变量

    private int isDead = Animator.StringToHash("isDead");
    private int attacked = Animator.StringToHash("attacked");
    private int attack = Animator.StringToHash("attack");

    private void Start()
    {
        CurrentHP = MaxHP;
        player = GameObject.FindGameObjectWithTag("player").transform;
        slider = GameObject.FindObjectOfType<Slider>();
        cc = this.GetComponent<CharacterController>();
        _animator = this.GetComponent<Animator>();
        attackCounter = attackTime;
        speed = 0.5f;
        attackDistance = 10;
        b_speed = 50f;
        Vector3 Pos_World = this.transform.position;
        Pos_World.y += cc.height * 2.5f;
        //blood_slider = (Slider)Instantiate(Slider);
        //blood_slider.transform.parent = GameObject.Find("Canvas").gameObject.transform;
    }


    void Update()
    {
        Vector3 Pos_World = this.transform.position;
        Pos_World.y += cc.height * 2.5f;

        Vector3 Pos = Camera.main.WorldToScreenPoint(Pos_World);

        //Debug.Log (cc.height);
        //blood_slider.transform.position = Pos;

        Vector3 targetPos = player.position;

        targetPos.y = transform.position.y;

        transform.LookAt(targetPos);

        float distance = Vector3.Distance(targetPos, transform.position);
        //Debug.Log (distance);
        if (distance <= attackDistance)

        {

            attackCounter += Time.deltaTime;

            if (attackCounter > attackTime)

            {
                GameObject clone;
                Vector3 shoot_pos = transform.position;
                shoot_pos += transform.forward * 4f;
                clone = (GameObject)Instantiate(bullet, shoot_pos, transform.rotation);
                clone.GetComponent<Rigidbody>().velocity = transform.forward * b_speed;

                _animator.SetTrigger(attack); //攻击动画
                attackCounter = 0;
            }


        }

        else

        {

            attackCounter = attackTime;

            cc.Move(transform.forward * speed);

            // animator.SetBool("Walk ", true);//播放跑步动画

        }



    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        ShowHPSlider();
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            //Destroy(blood_slider.gameObject);
            _animator.SetBool(isDead, true);
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -100.0f, 0), ForceMode.Force);
            Destroy(this.gameObject, 3.0f);

        }
        else
        {
            _animator.SetTrigger(attacked);
        }
    }
    public void ShowHPSlider()
    {
        slider.value = CurrentHP / (float)MaxHP;
    }
}

