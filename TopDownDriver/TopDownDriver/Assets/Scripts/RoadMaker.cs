using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour {

	public float lastRoadXPosition;
	public List<Transform> roadParts;
	public float time;
	public static RoadMaker instance;


	void Awake(){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;

	}

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaceNew(){
		Transform oldPart = roadParts [0];
		roadParts.RemoveAt (0);
		oldPart.localPosition = new Vector3 (lastRoadXPosition + 40, oldPart.localPosition.y, oldPart.localPosition.z);
		roadParts.Add (oldPart);
		lastRoadXPosition += 40;
	}
}
