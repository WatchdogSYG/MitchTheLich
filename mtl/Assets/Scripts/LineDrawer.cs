using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {

    private LineRenderer LRend;
	// Use this for initialization
	void Start () {
        LRend = gameObject.GetComponent<LineRenderer>();
        LRend.SetPosition(0, new Vector3(0, 0, 0));
        LRend.SetPosition(1, new Vector3(0, 0, 0));
	}
	
	public void DrawLine(Vector3 impact)
    {
        StartCoroutine(DrawReset(impact));
    }

    IEnumerator DrawReset(Vector3 endpoint)
    {
        Vector3 drawPoint = Vector3.Scale(endpoint, new Vector3(0, 1, 1));
        LRend.SetPosition(1, drawPoint);
        yield return new WaitForSeconds(0.2f);
        LRend.SetPosition(1, new Vector3(0, 0, 0));
    }
}
