using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float walkspeed;
    public float runspeed;
    public float speed;
    private float maxhp;
    private float currenthp;
    private float maxsprintgauge;
    private float currentsprintgauge;

    float Horizontal;
    float Vertical;

    public Slider hpbar;
    public Slider sprintbar;

    private void Start()
    {
        maxhp = 100;
        currenthp = maxhp;
        hpbar.value = (float)currenthp / (float)maxhp;

        maxsprintgauge = (float)currentsprintgauge / (float)maxsprintgauge;
    }


    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runspeed;
            currentsprintgauge -= 1;
            HandleSprint();
        }
        else
        {
            speed = walkspeed;
        }

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(Horizontal, Vertical, 0);

        transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitPlayer();
    }

    void HitPlayer()
    {
        currenthp = currenthp - ZombieMove.attack;

        HandleHp();
        
        if(currenthp < 0)
        {
            GameManager.instance.OpenEndMenu();
        }
    }

    void HandleHp()
    {
        hpbar.value = (float)currenthp / (float)maxhp;
    }

    void HandleSprint()
    {
        sprintbar.value = (float)currenthp / (float)maxsprintgauge;
    }
}
