using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInZoomOut : MonoBehaviour
{

	Camera mainCamera;

	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

	Vector2 firstTouchPrevPos, secondTouchPrevPos;
	Vector2 camPos;
	Vector2 camCS, camCJ, mapCS, mapCJ;

	[SerializeField]
	float zoomModifierSpeed = 0.1f;
	public float scratchSpeed = 0.2f;
	float x;

	[SerializeField]
	//Text text;

	// Use this for initialization
	void Start()
	{
		mainCamera = GetComponent<Camera>();
		mapCJ.x = 17.379f;
		mapCJ.y = -12.627f;
		mapCS.x = -17.67f;
		mapCS.y = 12.402f;
	}
	
	void Update()
	{
		
		if(Input.touchCount==1)
        {
			Touch tch=Input.GetTouch(0);
			Vector3 aux;
			aux.x= tch.deltaPosition.x;
			aux.y = tch.deltaPosition.y;
			aux.z = 0;
			mainCamera.transform.position -= aux * Time.deltaTime * scratchSpeed;
			aux.x = Mathf.Clamp(mainCamera.transform.position.x, -31f, 31f);
			aux.y = Mathf.Clamp(mainCamera.transform.position.y, -5.6f, 5.6f);
			mainCamera.transform.position = aux;
			
			/*
			if (Mathf.Abs(mainCamera.transform.position.x)<= 31f && Mathf.Abs(mainCamera.transform.position.y) <= 5.6f)
            {
				//aux.x += Mathf.Sign(mainCamera.transform.position.x);
				//aux.y += Mathf.Sign(mainCamera.transform.position.y);
				mainCamera.transform.position -= aux*Time.deltaTime*scratchSpeed;

            }
			else
            {
				if(Mathf.Abs(mainCamera.transform.position.x) > 31f)
				{
					aux.x = Mathf.Clamp(mainCamera.transform.position.x, -31f, 31f);
					mainCamera.transform.position -= aux;
				}
				if(Mathf.Abs(mainCamera.transform.position.y) > 5.6f)
                {
					aux.y = 0;
					aux.y += Mathf.Sign(mainCamera.transform.position.y);
					mainCamera.transform.position -= aux;
				}
            }
			*/	
				
			
		}
		
		if (Input.touchCount == 2)
		{

			Touch firstTouch = Input.GetTouch(0);
			Touch secondTouch = Input.GetTouch(1);

			firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
			secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

			//camPos.x = (Mathf.Min(firstTouch.position.x, secondTouch.position.x) + 0.5f * Mathf.Max(firstTouch.position.x, secondTouch.position.x) - Mathf.Min(firstTouch.position.x, secondTouch.position.x)) / 1170;
			//camPos.y = (Mathf.Min(firstTouch.position.y, secondTouch.position.y) + 0.5f * Mathf.Max(firstTouch.position.y, secondTouch.position.y) - Mathf.Min(firstTouch.position.y, secondTouch.position.y)) / 1170;
			//mainCamera.transform.position = camPos;

			touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
			touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

			zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

			if (touchesPrevPosDifference > touchesCurPosDifference)
				mainCamera.orthographicSize += zoomModifier;
			if (touchesPrevPosDifference < touchesCurPosDifference)
				mainCamera.orthographicSize -= zoomModifier;
			//if(Mathf.Abs(mainCamera.transform.position.x-camPos.x) >10 && Mathf.Abs(mainCamera.transform.position.y-camPos.y)>10)
			//if(mainCamera.transform.position.x!=camPos.x && mainCamera.transform.position.y != camPos.y)
			//{
			//	mainCamera.transform.position+=transform.forward*Time.deltaTime;
			//}
			/*
			Vector3 aux;
			aux.x = firstTouch.deltaPosition.x;
			aux.y = firstTouch.deltaPosition.y;
			aux.z = 0;
			mainCamera.transform.position += aux;
			*/
		}

		mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 3f, 10f);
		//text.text = "Camera size " + mainCamera.orthographicSize;

	}
}