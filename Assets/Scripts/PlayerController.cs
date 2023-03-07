using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Vector3 moveDir = Vector3.zero;
    
    // 점프 관련
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDelayTime;
    private bool jumpDelay;

    
    
    // 컴포넌트
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    private Rigidbody playerRb;
    
    // 공격 관련
    [SerializeField] private float attackDelayTime;
    private bool attackDelay;
    
    // 피격 관련
    private bool onDead;
    
    // 바닥 충돌 레이
    public GameObject foot;
    public LayerMask ground;
    private bool onGrounded;
    
    
    void Start()
    {
        playerSprite = this.GetComponent<SpriteRenderer>();
        playerAnim = this.GetComponent<Animator>();
        playerRb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        CheckGround();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontal, vertical, 0).normalized;

        if (moveDir.x > 0)
        {
            playerSprite.flipX = false;
        }
        else if (moveDir.x == 0)
        {
            
        }
        else
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
        
        Debug.Log(onGrounded);
        
        playerAnim.SetFloat("speed", moveDir.magnitude);
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

    
    /// <summary>
    /// 레이캐스트 이용, 바닥과 충돌했는지 지속적인 체크, 바닥과 충돌했을 경우에만, 점프 가능
    /// </summary>
    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(foot.transform.position, Vector3.down, out hit, 0.3f, ground))
        {
            onGrounded = true;
        }
        else
        {
            onGrounded = false;
        }
    }


}