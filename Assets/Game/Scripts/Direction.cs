using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Direction : MonoBehaviour
{
    public eDirection dir;
    public NinjaController ninja;

    // Start is called before the first frame update 
    private void OnEnable()
    {
        InputManager.Instance.OnTap += OnTap; 
        InputManager.Instance.OnTapEnded += OnTapEnded; 
    }
    private void OnDisable()
    {
        InputManager.Instance.OnTap -= OnTap; 
        InputManager.Instance.OnTapEnded -= OnTapEnded; 
    }

    private void OnTap(List<RaycastResult> results)
    {
        if (!(results.Count > 0))
        {
            return;
        }

        RaycastResult obj = results[0];
        if (obj.gameObject != null)
        {
            if (obj.gameObject == this.gameObject)
            {
                ninja.direction = dir;
            }
        }
    }

    private void OnTapEnded(List<RaycastResult> results)
    {
        ninja.direction = eDirection.NONE;
    }
}
