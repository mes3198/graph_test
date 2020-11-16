using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GraphBuild : MonoBehaviour
{
    private int[,] cases = {{5,42,57251,100343,23555,12565,14067,33943,45650,212273},{0,16,18684,108200,38732,13468,13536,25767,39817,105325},{0, 0, 455, 5660, 2374, 472, 173, 161, 176, 878 } };
    public GameObject DataPoint;
   
    // Start is called before the first frame update
    void Start()
    {
        Renderer grapthRender = gameObject.GetComponent(typeof(Renderer)) as Renderer;
        Vector3 graphSize = grapthRender.bounds.size;
        float maxElement = cases.Cast<int>().Max();
        for (int z = 0; z < cases.Length/10; z++)
        {
            for (int x = 0; x < 10; x++)
            {
                GameObject dataPoint = Instantiate(DataPoint, new Vector3(0,0,0), Quaternion.identity);
                float dataPointXscale = (float)(graphSize.x/((cases.Length)));
                float dataPointYscale = (float)(graphSize.y/maxElement) * cases[z,x];
                float dataPointZscale = (float)(graphSize.z/((cases.Length)));

                dataPoint.transform.localScale = new Vector3(dataPointXscale, dataPointYscale, dataPointZscale);
                dataPoint.transform.parent = gameObject.transform;
                Vector3 dataPointSize = dataPoint.transform.localScale;
                float dataPointXpos = (-1/2f)+(dataPointSize.x/2f);
                float dataPointYpos = (-1/2f)+(dataPointSize.y/2f);
                float dataPointZpos = (-1/2f)+(dataPointSize.z/2f);
                dataPoint.transform.localPosition = new Vector3(dataPointXpos + ((dataPoint.transform.localScale.x*2)*x), dataPointYpos, dataPointZpos + ((dataPoint.transform.localScale.z*2)*z));
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
