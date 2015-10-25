using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {
	public Rect bounds;

	// Use this for initialization
	void Start () {

		bounds = new Rect (BoundsMin (Camera.main), BoundsMax (Camera.main));
		//bounds = new Rect(Camera.main.transform.position,new Vector2(cameraHeight * screenAspect, cameraHeight));
	}
	
	public static Vector2 BoundsMin(Camera camera)
	{
		return (Vector2)camera.transform.position - Extents(camera);
	}

	public static Vector2 BoundsMax(Camera camera)
	{
		return (Vector2)Extents(camera) * 2;
	}

	public static Vector2 Extents(Camera camera)
	{
		float aspectRatio = Screen.width / Screen.height;
		return new Vector2 (camera.orthographicSize * aspectRatio, camera.orthographicSize);
	}

	// Update is called once per frame
	void Update () {


	}


}
