using UnityEngine;
using System.Collections;
using System;
using SunPos;

public class Position : MonoBehaviour {
	void Start(){
			renderer.material.color = Color.yellow;
		}
	
	string[] text = {"0.0000", "0.0000", "0", "0", "0", "0", "0", "0"};

	void OnGUI(){
		GUI.Box (new Rect (2, 2, 224, 260), "Sun Calculator");
		GUI.Label (new Rect (6, 24, 70, 20), "Longitude:");
		text [0] = GUI.TextArea (new Rect (80, 24, 142, 20), text[0], 15);
		GUI.Label (new Rect (6, 46, 70, 20), "Latitude:");
		text [1] = GUI.TextArea (new Rect (80, 46, 142, 20), text[1], 15);
		GUI.Label (new Rect (6, 68, 70, 20), "Day:");
		text [2] = GUI.TextArea (new Rect (80, 68, 142, 20), text[2], 2);
		GUI.Label (new Rect (6, 90, 70, 20), "Month:");
		text [3] = GUI.TextArea (new Rect (80, 90, 142, 20), text[3], 2);
		GUI.Label (new Rect (6, 112, 70, 20), "Year:");
		text [4] = GUI.TextArea (new Rect (80, 112, 142, 20), text[4], 4);
		GUI.Label (new Rect (6, 134, 70, 20), "Hour:");
		text [5] = GUI.TextArea (new Rect (80, 134, 142, 20), text[5], 2);
		GUI.Label (new Rect (6, 156, 70, 20), "Minut:");
		text [6] = GUI.TextArea (new Rect (80, 156, 142, 20), text[6], 2);
		GUI.Label (new Rect (6, 178, 70, 20), "Second:");
		text [7] = GUI.TextArea (new Rect (80, 178, 142, 20), text[7], 2);
		if (GUI.Button (new Rect (42, 210, 142, 46), "Calculate")) {
			SunCoord Sun = new SunCoord();
			double[] result = Sun.Calculate(Convert.ToDouble(text[1]), Convert.ToDouble(text[0]), Convert.ToInt32(text[4]), Convert.ToInt32(text[3]),
			                                Convert.ToInt32(text[2]), Convert.ToInt32(text[5]), Convert.ToInt32(text[6]), Convert.ToInt32(text[7]));
			Debug.Log("Elevation: "+result[0]+"\nZenith: "+result[1]+"\nAzimuth: "+result[2]);
			transform.position = new Vector3((float)(10.0*Math.Sin(result[1]*Math.PI/180.0)*Math.Sin(result[2]*Math.PI/180.0)),
		                                 (float)(10.0*Math.Cos(result[1]*Math.PI/180.0)),(float)(10.0*Math.Sin(result[1]*Math.PI/180.0)*Math.Cos(result[2]*Math.PI/180.0)));
			}
	}
}
