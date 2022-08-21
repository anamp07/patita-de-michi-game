using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";
    const string UP = "up";
    const string DOWN = "down";
    
    [SerializeField] Transform castPos;
    [SerializeField] float baseCastDistance;
    Rigidbody2D body2D;
    [SerializeField] float speed = 5;
    string facingDirection;
    Vector3 baseScale;
    [SerializeField] bool upDown = false;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (upDown)
        {
            facingDirection = UP;
            float velocityY = speed;

            if (facingDirection == DOWN)
                velocityY = -speed;

            body2D.velocity = new Vector2(body2D.velocity.x, velocityY);
        }
        else
        {
            float velocityX = speed;

            if (facingDirection == LEFT)
                velocityX = -speed;

            body2D.velocity = new Vector2(velocityX, body2D.velocity.y);
        }
        
        
        if (IsHittingWall())
        {
            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }else if(facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;
        if(newDirection == LEFT)
            newScale.x = -baseScale.x;
        else if(newDirection == RIGHT)
            newScale.x = baseScale.x;
        else if(newDirection == DOWN)
            newScale.y = -baseScale.y;
        else if(newDirection == UP)
            newScale.y = baseScale.y;

        transform.localScale = newScale;

        facingDirection = newDirection;
    }

    bool IsHittingWall()
    {
        bool hit = false;
        float castDistance = baseCastDistance;
        //Define cast distance for left an right
        if(facingDirection == LEFT)
        {
            castDistance = -baseCastDistance;
        }

        Vector3 targetPosition = castPos.position;
        targetPosition.x += castDistance;

        Debug.DrawLine(castPos.position, targetPosition, Color.magenta);

        if(Physics2D.Linecast(castPos.position, targetPosition, 1 << LayerMask.NameToLayer("UI")))
        {
            hit = true;
        }
        else
        {
            hit = false;
        }

        return hit;
    }
}
