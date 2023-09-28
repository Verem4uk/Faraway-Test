using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneChangeSpeed = 5.0f;
    public float swipeThreshold = 50.0f;
    public int minLane = 0;
    public int maxLane = 2;
    public SwipeDirection swipeDirection = SwipeDirection.None;

    private int currentLane = 1;
    private int targetLane = 1;
    private float laneWidth = 2.0f;
    private bool isMoving = false;

    private void Update()
    {
        if (!isMoving)
        {
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
            float laneOffset = (targetLane - currentLane) * laneWidth;
            Vector3 targetPosition = transform.position + new Vector3(laneOffset, 0, 0);
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

            yield return null; // Добавьте эту строку для обновления кадра
        }

        transform.position = targetPosition;
        isMoving = false;
    }

    public void SetSwipeDirection(SwipeDirection direction)
    {
        swipeDirection = direction;
    }

    public enum SwipeDirection
    {
        None,
        Left,
        Right
    }
}
