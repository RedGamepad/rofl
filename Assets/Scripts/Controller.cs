using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    //Описание переменных
    public Rigidbody2D rgd; //Тело для перемещения
    public float maxSpeed = 10f; //Максимальная скорость ясен красен
    //переменная для определения направления персонажа вправо/влево
    private bool isFacingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    //Функция используется для поворота персонажа
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 vctr = transform.localScale;
        vctr.x *= -1;
        transform.localScale = vctr;
    }



	void Start () {
		
	}
	

	void Update () {
        rgd = GetComponent<Rigidbody2D>();
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // ПОСМОТРИ СЮДА - ВИДИШЬ КЛАВИШУ SPACE? ЭТО МОЖНО БУДЕТ ПЕРЕНАЗНАЧИТЬ ЧИ НЕ?
        {
            rgd.AddForce(new Vector2(0, 700));
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        float move = Input.GetAxis("Horizontal"); //Влево возвращает -1 вправо 1
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
        if (!isGrounded)
            return;
        rgd.velocity = new Vector2(move * maxSpeed, rgd.velocity.y);
        
    }

}
