using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    public delegate void Gesture(List<RaycastResult> result);
    public delegate void Swipe(Touch firstTouch, Touch lastTouch);
    public Gesture OnTap;
    public Gesture OnTapEnded;
    public Swipe OnSwipe;

    public Canvas canvas;

    bool hasMoved;

    Touch touch;
    Vector3 touchPosition;

    [SerializeField]
    private float touchTime;

    GraphicRaycaster ray;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    Touch firstTouch;
    Touch lastTouch;

    void Start()
    {
        ray = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = canvas.GetComponent<EventSystem>();

        hasMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        TouchUpdt();
    }

    private void TouchUpdt()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = touch.position;
            List<RaycastResult> results = new List<RaycastResult>();
            ray.Raycast(pointerEventData, results);

            if (touch.phase == TouchPhase.Began)
            { 
                firstTouch.position = touch.position;
                OnTap(results);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                OnTapEnded(results);
            }

            if (hasMoved && touch.phase == TouchPhase.Ended)
            {
                lastTouch.position = touch.position;
                OnSwipe(firstTouch, lastTouch);
                hasMoved = false; 
            }

            if (touch.phase == TouchPhase.Moved)
            {
                hasMoved = true;
            }
        }
    }
}
