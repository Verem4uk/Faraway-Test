using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float laneChangeSpeed = 5.0f;
    
    [SerializeField]
    private int minLane = 0;
    
    [SerializeField]
    private int maxLane = 2;
    
    [SerializeField]
    private float laneWidth = 2.0f;

    [SerializeField]
    private float swipeSensivity = 25f;
    
    private SwipeDirection swipeDirection = SwipeDirection.None;

    private int currentLane = 1;
    private int targetLane = 1;
    private bool isMoving = false;
    Vector2 touchStart = Vector2.zero;

    private void Update()
    {
        if (!isMoving)
        {
            swipeDirection = GetSwipeDirection();
            
            if (Input.GetKeyDown(KeyCode.LeftArrow) || swipeDirection == SwipeDirection.Left)
            {
                MoveLane(-1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || swipeDirection == SwipeDirection.Right)
            {
                MoveLane(1);
            }
        }

    }

    private void MoveLane(int direction)
    {
        targetLane = Mathf.Clamp(targetLane + direction, minLane, maxLane);

        if (targetLane != currentLane)
        {
            Vector3 targetPosition = transform.position + new Vector3(direction * laneWidth, 0, 0);
            StartCoroutine(MoveToLane(targetPosition));
            currentLane = targetLane;
        }
    }

    private IEnumerator MoveToLane(Vector3 targetPosition)
    {
        isMoving = true;
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        float startTime = Time.time;
        float journeyDuration = journeyLength / laneChangeSpeed;

        while (Time.time - startTime < journeyDuration)
        {
            float distanceCovered = Time.time - startTime;
            float fractionOfJourney = distanceCovered / journeyDuration;
            transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);
            yield return null; 
        }

        transform.position = targetPosition;
        isMoving = false;
    }

    public void MovePlayerTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveToLane(targetPosition));
    }
    
    private SwipeDirection GetSwipeDirection()
    {
        Vector2 touchEnd = Vector2.zero;

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchEnd = Input.mousePosition;
            Vector2 swipeDirection = touchEnd - touchStart;

            if (swipeDirection.magnitude >= swipeSensivity)
            {
                if (swipeDirection.x > 0)
                {
                    return SwipeDirection.Right;
                }

                if (swipeDirection.x < 0)
                {
                    return SwipeDirection.Left;
                }
            }
        }
        
        return SwipeDirection.None;
    }

    public enum SwipeDirection
    {
        None,
        Left,
        Right
    }
}
