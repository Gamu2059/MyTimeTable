using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(RectTransform))]
public class TimeTableController : MonoBehaviour
{
    [Serializable]
    public struct TimeTableElementParam
    {
        public Vector2Int Point;
        public int Num;
    }

    public const int DAY_OF_WEEK_NUM = 7;
    public const int TIME_NUM = 5;

    [SerializeField]
    private GameObject m_TimeTableElementPrefab;

    [SerializeField]
    private GameObject m_EmptyTimeTableElementPrefab;

    [SerializeField]
    private TimeTableElementParam[] m_ElementParams;

    private bool[,] m_TimeTableArray;

    private void Start()
    {
        m_TimeTableArray = new bool[TIME_NUM,DAY_OF_WEEK_NUM];

        foreach(var param in m_ElementParams)
        {
            var obj = Instantiate(m_TimeTableElementPrefab);
            var rectT = obj.GetComponent<RectTransform>();

            rectT.SetParent(transform);

            float minX = (float)param.Point.x / DAY_OF_WEEK_NUM;
            float maxX = (float)(param.Point.x + 1) / DAY_OF_WEEK_NUM;
            float minY = (float)(TIME_NUM - param.Point.y - param.Num) / TIME_NUM;
            float maxY = (float)(TIME_NUM - param.Point.y) / TIME_NUM;
            rectT.anchorMin = new Vector2(minX, minY);
            rectT.anchorMax = new Vector2(maxX, maxY);
            rectT.sizeDelta = Vector2.zero;
            rectT.anchoredPosition = Vector2.zero;

            for(int i=0;i<param.Num;i++)
            {
                m_TimeTableArray[param.Point.y + i, param.Point.x] = true;
            }
        }

        for(int i=0;i<TIME_NUM;i++)
        {
            for(int j=0;j<DAY_OF_WEEK_NUM;j++)
            {
                if (m_TimeTableArray[i,j])
                {
                    continue;
                }

                var obj = Instantiate(m_EmptyTimeTableElementPrefab);
                var rectT = obj.GetComponent<RectTransform>();

                rectT.SetParent(transform);

                float minX = ((float)j) / DAY_OF_WEEK_NUM;
                float maxX = (float)(j + 1) / DAY_OF_WEEK_NUM;
                float minY = (float)(TIME_NUM - i - 1) / TIME_NUM;
                float maxY = (float)(TIME_NUM - i) / TIME_NUM;
                rectT.anchorMin = new Vector2(minX, minY);
                rectT.anchorMax = new Vector2(maxX, maxY);
                rectT.sizeDelta = Vector2.zero;
                rectT.anchoredPosition = Vector2.zero;
            }
        }
    }
}
