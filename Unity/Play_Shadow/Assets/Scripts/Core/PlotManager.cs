using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
	public GameObject cover;
	public Button begin;
	AudioSource audioSource;
	CanvasGroup canvas;
	List<string> descList = new List<string> ();
	List<string> iconList = new List<string> ();
	int curId = 0;
	void Awake(){
	
	}

	// Use this for initialization
	void Start () {
		string ss = CommLang.plot1;
		bgBtn = gameObject.transform.Find ("Canvas/BgBtn").GetComponent<Button> ();
		image = gameObject.transform.Find ("Canvas/Image").GetComponent<Image> ();
		desc = gameObject.transform.Find ("Canvas/Desc").GetComponent<Text> ();
		audioSource = gameObject.transform.Find ("Audio").GetComponent<AudioSource> ();
		cover = gameObject.transform.Find ("Cover").gameObject;
		begin = gameObject.transform.Find ("Cover/Button").GetComponent<Button> ();

		descList.Add (Data.Instance.PlotDesc1);
		descList.Add (Data.Instance.PlotDesc2);
		descList.Add (Data.Instance.PlotDesc3);
		iconList.Add (Data.Instance.PlotIcon1);
		iconList.Add (Data.Instance.PlotIcon2);
		iconList.Add (Data.Instance.PlotIcon3);

		curId = 0;

		canvas = gameObject.transform.Find("Canvas").GetComponent<CanvasGroup> ();
		desc.text = descList [curId];
		image.sprite = CommFun.Instance.LoadImage (iconList [curId]);
		image.SetNativeSize ();
		canvas.alpha = 0;
		Sequence mySeq = DOTween.Sequence ();
		mySeq.AppendInterval (0.2f);
		mySeq.Append (DOTween.To (
			() => {
				return canvas.alpha;
			},
			x => {
				canvas.alpha = x;	
			}, 1, 0.6f));
		
		mySeq.AppendCallback (()=>{
			
			audioSource.clip = CommFun.Instance.LoadAudio(Data.Instance.PlotAudio1);
			Debug.Log("!!!!!!!  加载音频");
			audioSource.Play();
		});

		begin.onClick.AddListener (delegate() {
			StartGame();
		});


		bgBtn.onClick.AddListener (delegate() {
			NextPlot();		
		});
	}

	public void StartGame(){
		
		CanvasGroup coverCanvas = cover.GetComponent<CanvasGroup> ();

		coverCanvas.alpha = 1;
		Sequence mySeq = DOTween.Sequence ();
		mySeq.Append (DOTween.To (
			() => {
				return coverCanvas.alpha;
			},
			x => {
				coverCanvas.alpha = x;	
			}, 0, 0.8f));
		mySeq.AppendCallback (() => {
			cover.SetActive(false);
			coverCanvas.alpha = 0;
			desc.text = descList [curId];
			image.sprite = CommFun.Instance.LoadImage (iconList [curId]);
			image.SetNativeSize ();

			if(curId == 0){
				audioSource.clip = CommFun.Instance.LoadAudio(Data.Instance.PlotAudio1);
				audioSource.Play();
			}
		});

		canvas.alpha = 0;
		mySeq.AppendInterval (0.4f);
		mySeq.Append (DOTween.To (
			() => {
				return canvas.alpha;
			},
			x => {
				canvas.alpha = x;	
			}, 1, 0.6f));



	}

	public void ShowStory(){
//		CanvasGroup canvas = gameObject.transform.Find("Canvas").GetComponent<CanvasGroup> ();
		canvas.alpha = 1;

		Sequence mySeq = DOTween.Sequence ();
		mySeq.Append (DOTween.To (
			() => {
				return canvas.alpha;
			},
			x => {
				canvas.alpha = x;	
			}, 0, 0.8f));
		mySeq.AppendCallback (() => {
			canvas.alpha = 0;
			desc.text = descList [curId];
			image.sprite = CommFun.Instance.LoadImage (iconList [curId]);
			image.SetNativeSize ();

			if(curId == 0){
				audioSource.clip = CommFun.Instance.LoadAudio(Data.Instance.PlotAudio1);
				audioSource.Play();
			}else if(curId == 1){
				audioSource.clip = CommFun.Instance.LoadAudio(Data.Instance.PlotAudio2);
				audioSource.Play();
			}else if(curId == 2){
				audioSource.clip = CommFun.Instance.LoadAudio(Data.Instance.PlotAudio3);
				audioSource.Play();
			}
		});

		mySeq.AppendInterval (0.4f);
		mySeq.Append (DOTween.To (
			() => {
				return canvas.alpha;
			},
			x => {
				canvas.alpha = x;	
			}, 1, 0.6f));

	}

	public void NextPlot(){
		Debug.Log ("!!!!!!!!!!NextPlot");
		curId++;
		if (curId >= iconList.Count) {
			Close ();
		} else {
			ShowStory ();
		}
	}

	public void Close(){
		//继续游戏
		Gamer.Instance.StartGame();
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
