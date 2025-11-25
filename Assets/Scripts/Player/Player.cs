using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Movements")]
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2 (-.1f, 0);
    public float speed;
    public float speedRun;
    private float _currentSpeed;
    public float forceJump = 2;

    [Header("Animation")]
    public float jumpScaleX = .7f;
    public float jumpScaleY = 1.5f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Player Animation")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    public HealthBase healthBase;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }
    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }
    private void Update()
    {
       HandleMovement();
       HandleJump();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
          _currentSpeed = speedRun;    
        else 
        _currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.linearVelocity= new Vector2(-_currentSpeed, myRigidbody.linearVelocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(boolRun,true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.linearVelocity= new Vector2(_currentSpeed, myRigidbody.linearVelocity.y);
           if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            } 
            animator.SetBool(boolRun,true);
        }
        else
        {
            animator.SetBool(boolRun,false);
        }

        if (myRigidbody.linearVelocity.x > 0)
        {
            myRigidbody.linearVelocity += friction;
        }
         else if (myRigidbody.linearVelocity.x < 0)
        {
            myRigidbody.linearVelocity -= friction;
        }
    }

private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity= Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        } 
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleY(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
