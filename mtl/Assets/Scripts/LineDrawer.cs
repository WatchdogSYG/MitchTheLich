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
        LRend.SetPosition(0, gameObject.transform.position);
        LRend.SetPosition(1, endpoint);
        yield return new WaitForSeconds(0.3f);
        LRend.SetPosition(0, new Vector3(0, 0, 0));
        LRend.SetPosition(1, new Vector3(0, 0, 0));
    }
}
