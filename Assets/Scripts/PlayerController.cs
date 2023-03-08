using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 관련 변수
    [SerializeField] private float speed;
    private Vector3 moveDir = Vector3.zero;
    private bool lookLeft;
    private Transform hand;
    
    // 컴포넌트
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    private Rigidbody playerRb;
    
    // 점프 관련
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDelayTime;
    private bool jumpDelay;
    
    // 공격 관련
    [SerializeField] private float attackDelayTime;
    private bool attackDelay;
    
    // 피격 관련
    private bool onDead;
    
    // 바닥 충돌 레이
    private Transform foot;
    public LayerMask ground;
    private bool onGrounded;
    
    

    
    

    void Awake()
    {
        playerSprite = this.GetComponent<SpriteRenderer>();
        playerAnim = this.GetComponent<Animator>();
        playerRb = this.GetComponent<Rigidbody>();
        foot = GetComponentInChildren<Transform>();
        hand = GetComponentInChildren<Transform>();
    }

   

    void Update()
    {
        CheckGround();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        
        if (horizontal < 0)
        {
            direction = true;
        }
        else if (horizontal > 0)
        {
            direction = false;
        }

        // 반향 전환
        if (moveDir.x > 0)
        {
            playerSprite.flipX = false;
        }
        else if (moveDir.x < 0)
        {
            playerSprite.flipX = true;
        }
        
        
        // 공격 했을 때
        if (Input.GetMouseButtonDown(0))
        {
            if (attackDelay != true)
            {
                attackDelay = true;
                StartCoroutine(Attack());
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            OnDead();
        }
        
        // 점프 했을 때
        if (Input.GetKeyDown(KeyCode.Space) && onGrounded == true)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bullet = BulletManager.Instance.LoadBullet(); 
            bullet.transform.position = hand.position;

            if (direction == true )
            {
                bullet.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else
            {
                bullet.transform.eulerAngles = new Vector3(0, 0, -90);
            }
            Instantiate(bullet);
        }

        playerAnim.SetFloat("speed", moveDir.magnitude);
        moveDir = new Vector3(horizontal, vertical, 0).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    IEnumerator Attack()
    {
        playerAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelayTime);
        attackDelay = false;
    }

    void Jump()
    {
        playerAnim.SetTrigger("Jump");
        playerRb.AddForce(Vector3.up * jumpPower);
    }
    
    void OnDead()
    {
        playerAnim.SetTrigger("Dead");
    }
    
    // 레이캐스트 이용, 바닥과 충돌했는지 지속적인 체크, 바닥과 충돌했을 경우에만, 점프 가능
    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(foot.transform.position, Vector3.down,
                out hit, 0.3f, ground))
        {
            onGrounded = true;
        }
        else
        {
            onGrounded = false;
        }
    }


}