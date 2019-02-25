using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyBotoes : MonoBehaviour
{
    private RectTransform jumpRect;
    public static bool ValorJump { get; private set; }
    void Start()
    {
        var d = gameObject.GetComponentsInChildren<RectTransform>();
        jumpRect = d[0];
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {

            var d = Input.GetTouch(i).position;
            var p = RectTransformUtility.RectangleContainsScreenPoint(jumpRect, d);
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (p)
                {
                    Debug.Log("dentro");
                    ValorJump = true;
                }
            }else
                ValorJump = false;
        }    
    }
   
}
