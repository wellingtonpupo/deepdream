using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoyDirecoes : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public Transform left;
    public Transform right;
    public Canvas canvas;
    public int espacoNoCentroOriginalvalor;
    public static float ValorInput { get; private set; }

    public virtual void OnPointerDown(PointerEventData e)
    {
        var dentroDaRec = RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(),
                                                                        e.position,
                                                                        e.enterEventCamera,
                                                                        out Vector2 wordPoint);
        if (dentroDaRec)
        {
            int joyEspacoNoCentro = 1;
            joyEspacoNoCentro = wordPoint.x > 0 ? espacoNoCentroOriginalvalor : espacoNoCentroOriginalvalor * -1;

            if (wordPoint.x > joyEspacoNoCentro && wordPoint.x > 0)
                ValorInput = 1;
            else if (wordPoint.x < joyEspacoNoCentro && wordPoint.x < 0)
                ValorInput = -1;
            else
                ValorInput = 0;
        }

        Debug.Log(ValorInput);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ValorInput = 0;
    }
}
