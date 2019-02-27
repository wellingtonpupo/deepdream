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
        var rectFilhos = gameObject.GetComponentsInChildren<RectTransform>();
        jumpRect = rectFilhos[0];
        //atackRect = d[1];
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            var p = RectTransformUtility.RectangleContainsScreenPoint(jumpRect, Input.GetTouch(i).position);
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (p)
                    ValorJump = true;
            }else
                ValorJump = false;
        }    
    }
   
}
