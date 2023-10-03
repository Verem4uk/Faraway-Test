using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float LaneChangeSpeed = 5.0f;
    
    [SerializeField]
    private int MinLane = 0;
    
    [SerializeField]
    private int MaxLane = 2;
    
    [SerializeField]
    private float LaneWidth = 2.0f;

    [SerializeField]
    private float SwipeSensivity = 25f;
    
    private ESwipeDirection SwipeDirection = ESwipeDirection.None;

    private int CurrentLane = 1;
    private int TargetLane = 1;
    private bool IsMoving = false;
    Vector2 TouchStart = Vector2.zero;

    private void Update()
    {
        if (!IsMoving)
        {
            SwipeDirection = GetSwipeDirection();
            
            if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeDirection == ESwipeDirection.Left)
            {
                MoveLane(-1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeDirection == ESwipeDirection.Right)
            {
                MoveLane(1);
            }
        }

    }

    private void MoveLane(int direction)
    {
        TargetLane = Mathf.Clamp(TargetLane + direction, MinLane, MaxLane);

        if (TargetLane != CurrentLane)
        {
            Vector3 targetPosition = transform.position + new Vector3(direction * LaneWidth, 0, 0);
            StartCoroutine(MoveToLane(targetPosition));
            CurrentLane = TargetLane;
        }
    }

    private IEnumerator MoveToLane(Vector3 targetPosition)
    {
        IsMoving = true;
        float journeyLength = Vector3.Distance(transform.position, targetPosition);
        float startTime = Time.time;
        float journeyDuration = journeyLength / LaneChangeSpeed;

        while (Time.time - startTime < journeyDuration)
        {
            float distanceCovered = Time.time - startTime;
            float fractionOfJourney = distanceCovered / journeyDuration;
            transform.position = Vector3.Lerp(transform.position, targetPosition, fractionOfJourney);
            yield return null; 
        }

        transform.position = targetPosition;
        IsMoving = false;
    }

    public void MovePlayerTo(Vector3 targetPosition)
    {
        StartCoroutine(MoveToLane(targetPosition));
    }
    
    private ESwipeDirection GetSwipeDirection()
    {
        Vector2 touchEnd = Vector2.zero;

        if (Input.GetMouseButtonDown(0))
        {
            TouchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchEnd = Input.mousePosition;
            Vector2 swipeDirection = touchEnd - TouchStart;

            if (swipeDirection.magnitude >= SwipeSensivity)
            {
                if (swipeDirection.x > 0)
                {
                    return ESwipeDirection.Right;
                }

                if (swipeDirection.x < 0)
                {
                    return ESwipeDirection.Left;
                }
            }
        }
        
        return ESwipeDirection.None;
    }

    public enum ESwipeDirection
    {
        None,
        Left,
        Right
    }
}
