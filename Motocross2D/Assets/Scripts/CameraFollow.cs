using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform player;
	public Vector3 offset;
	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);

		if (bounds)
        {

			transform.position = new Vector3 (Mathf.Clamp (transform.position.x,minCameraPos.x,maxCameraPos.x),
				Mathf.Clamp (transform.position.y,minCameraPos.y,maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		
		}
	}
}
