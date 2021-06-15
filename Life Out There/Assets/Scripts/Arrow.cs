using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowHead;
    public GameObject arrowNode;
    public int arrowNodeNum;
    public float scaleFactor = 1f;


    private RectTransform origin;
    private List<RectTransform> arrowNodes = new List<RectTransform>();
    private List<Vector2> controlPoints = new List<Vector2>();
    private readonly List<Vector2> controlPointFactors = new List<Vector2> { new Vector2(-0.3f, 0.8f), new Vector2(0.1f, 1.4f) };

    // Start is called before the first frame update
    void Start()
    {
        origin = this.GetComponent<RectTransform>();

        for (int i = 0; i < arrowNodeNum; i++)
        {
           arrowNodes.Add(Instantiate(arrowNode, this.transform).GetComponent<RectTransform>());
        }

        arrowNodes.Add(Instantiate(arrowHead, this.transform).GetComponent<RectTransform>());

        arrowNodes.ForEach(a => a.GetComponent<RectTransform>().position = new Vector2(-1000, -1000));

        for (int i = 0; i < 4; i++)
        {
            controlPoints.Add(Vector2.zero);
        }
    }


    // Update is called once per frame
    void Update()
    {
       controlPoints[0] = new Vector2(origin.position.x, origin.position.y);

       controlPoints[3] = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

       controlPoints[1] = controlPoints[0] + (controlPoints[3] - controlPoints[0]) *controlPoints[0];
       controlPoints[2] = controlPoints[0] + (controlPoints[3] - controlPoints[0]) * controlPoints[1];

        for (int i = 0; i < arrowNodes.Count; i++)
        {
            var t = Mathf.Log(1f * i / (arrowNodes.Count - 1) + 1f, 2f);

            arrowNodes[i].position =
                Mathf.Pow(1 - t, 3) * controlPoints[0] +
                3 * Mathf.Pow(1 - t, 2) * controlPoints[1] +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2] +
                  Mathf.Pow(t, 3) * controlPoints[3];
           // Vector3 localPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f);
            //arrowNodes[i].position = Camera.main.WorldToScreenPoint(localPosition);
            Debug.Log("Mouse position<" + Input.mousePosition.x + "," + Input.mousePosition.y + ">");
            Debug.Log(arrowNodes[i].position);

            if (i > 0)
            {
                var euler = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, arrowNodes[i].position - arrowNodes[i - 1].position));
                 arrowNodes[i].rotation = Quaternion.Euler(euler);
            }

            var scale = scaleFactor * (1f - 0.03f * (arrowNodes.Count - 1 - i));
            arrowNodes[i].localScale = new Vector3(scale, scale, 1f);
        }

        arrowNodes[0].transform.rotation = arrowNodes[1].transform.rotation;
    }
}
