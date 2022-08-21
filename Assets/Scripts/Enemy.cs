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
    [SerializeField] string facingDirection;
    Vector3 baseScale;
    [SerializeField] bool upDown = false;
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        if (upDown)
            facingDirection = UP;
        else
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
            print(facingDirection);
            float velocityY = speed;

            if (facingDirection == DOWN)
                velocityY = -speed;

            print(velocityY);

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
            
            if (facingDirection == UP)
            {
                print("entras?");
                ChangeFacingDirection(DOWN);
            }else if(facingDirection == DOWN)
            {
                print("hitted a wall down");
                ChangeFacingDirection(UP);
            }
        }
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if (newDirection == LEFT)
            newScale.x = -baseScale.x;
        else if (newDirection == RIGHT)
            newScale.x = baseScale.x;
        else if (newDirection == UP)
            newScale.y = baseScale.y;
        else if (newDirection == DOWN)
            newScale.y = -baseScale.y;

        transform.localScale = newScale;

        facingDirection = newDirection;
        print("this is the new direction " + facingDirection);
    }

    bool IsHittingWall()
    {
        bool hit = false;
        float castDistance = baseCastDistance;
        //Define cast distance for left an right
        if(facingDirection == LEFT || facingDirection == DOWN)
        {
            castDistance = -baseCastDistance;
        }

        Vector3 targetPosition = castPos.position;
        if(upDown)
            targetPosition.y += castDistance;
        else
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
