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
		//		CanvasGroup canvas = getResourceBg.transform.GetComponent<CanvasGroup> ();
		//		canvas.alpha = 1;
		//		getResourceBg.gameObject.SetActive (true);
		//		float posY = getResource.transform.localPosition.y;
		//		Sequence mySeq = DOTween.Sequence ();
		//		mySeq.AppendInterval (0.5f);
		//		mySeq.Append (getResource.transform.DOLocalMoveY( posY + 200,0.3f));
		//		mySeq.Join (DOTween.To (
		//			() => {
		//				return canvas.alpha;
		//			},
		//			x => {
		//				canvas.alpha = x;	
		//			}, 0, 0.2f));
		//		mySeq.AppendCallback (() => {
		//			canvas.alpha = 0;
		//			showTipObj.SetActive (false);
		//			getResource.transform.localPosition = new Vector3(getResource.transform.localPosition.x, posY, 0);
		//		});



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
