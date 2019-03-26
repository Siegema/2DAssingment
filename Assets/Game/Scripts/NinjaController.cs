using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class NinjaController : MonoBehaviour
{
    public KeyCode attackKey;

    public float speed = 5.0f;
    public float movementThreshold = 0.5f;

    public GameObject fireBall;
    public Transform projectileSpawnPos;

    public Transform startingPoint;

    public eDirection direction;

    private Vector2 inputDirection;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
 
    void OnEnable()
    {
        InputManager.Instance.OnSwipe += OnSwipe;
    }

    void OnDisable()
    {
        InputManager.Instance.OnSwipe -= OnSwipe;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        switch (direction)
        {
            case eDirection.UP:
                inputDirection = Vector2.up;
                break;
            case eDirection.DOWN:
                inputDirection = Vector2.down;
                break;
            case eDirection.LEFT:
                inputDirection = Vector2.left;
                break;
            case eDirection.RIGHT:
                inputDirection = Vector2.right;
                break;
            case eDirection.NONE:
                inputDirection = Vector2.zero;
                break;
            default:
                break;
        }

        if (inputDirection.magnitude > movementThreshold)
        {
            _rigidbody2D.velocity = new Vector2(inputDirection.x * speed, inputDirection.y * speed);

            // Set the input values on the animator
            _animator.SetFloat("inputX", inputDirection.x);
            _animator.SetFloat("inputY", inputDirection.y);
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2();
            _animator.SetBool("isWalking", false);
        }
    }

    private void Fire(eDirection dir)
    {
        GameObject gObj = Instantiate(fireBall, projectileSpawnPos.position, Quaternion.identity);
        FireBall fb = gObj.GetComponent<FireBall>();

        fb.direction = dir;
    }

    private void OnSwipe(Touch fTouch, Touch lTouch)
    {
        //Positions
        Vector2 fPos = fTouch.position;
        Vector2 lPos = lTouch.position;

        if (Mathf.Abs(lPos.x - fPos.x) > Mathf.Abs(lPos.y - fPos.y))
        {
            if (lPos.x > fPos.x)
            {
                Fire(eDirection.RIGHT);
            }
            else
            {
                Fire(eDirection.LEFT);
            } 
        }
        else
        {
            if (lPos.y > fPos.y)
            {
                Fire(eDirection.UP);
            }
            else
            {
                Fire(eDirection.DOWN); 
            } 
        } 
    }

    public void Die()
    {
        transform.position = startingPoint.position;
    }
}
