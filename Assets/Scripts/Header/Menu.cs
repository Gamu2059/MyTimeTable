using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Menu : MonoBehaviour
{
    private RectTransform m_SelfRect;

    private void Awake()
    {
        m_SelfRect = GetComponent<RectTransform>();

        Rect rect = m_SelfRect.rect;
        m_SelfRect.sizeDelta = new Vector2(rect.height,0);
    }
}
