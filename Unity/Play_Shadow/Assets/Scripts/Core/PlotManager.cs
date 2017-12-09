using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public Button bgBtn;
	public Text desc;
	public Image image;

	List<string> descList = new List<string> ();
	List<string> iconList = new List<string> ();
	int curId = 0;

	// Use this for initialization
	void Start () {
		string ss = CommLang.plot1;
		bgBtn = gameObject.transform.Find ("BgBtn").GetComponent<Button> ();
		image = gameObject.transform.Find ("Image").GetComponent<Image> ();
		desc = gameObject.transform.Find ("Desc").GetComponent<Text> ();


		descList.Add (Data.Instance.PlotDesc1);
		descList.Add (Data.Instance.PlotDesc2);
		descList.Add (Data.Instance.PlotDesc3);
		iconList.Add (Data.Instance.PlotIcon1);
		iconList.Add (Data.Instance.PlotIcon2);
		iconList.Add (Data.Instance.PlotIcon3);

		curId = 0;
		ShowStory ();

		bgBtn.onClick.AddListener (delegate() {
			NextPlot();		
		});
	}

	public void ShowStory(){
		
		desc.text = descList [curId];
		image.sprite = CommFun.Instance.LoadImage (iconList [curId]);
		image.SetNativeSize ();
	}

	public void NextPlot(){
		Debug.Log ("!!!!!!!!!!NextPlot");
		curId++;
		if (curId >= descList.Count) {
			//继续游戏
			Gamer.Instance.StartGame();
			Destroy (gameObject);
			//return;
		} else {
			ShowStory ();
		}
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
