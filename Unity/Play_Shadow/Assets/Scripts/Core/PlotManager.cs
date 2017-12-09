using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour {
	protected static PlotManager _instance = null;
	public static PlotManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new PlotManager();
			}
			return _instance;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
