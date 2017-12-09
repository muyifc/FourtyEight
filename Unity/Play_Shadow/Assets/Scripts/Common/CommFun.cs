using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CommFun  {
	private static CommFun _instance;
	public static CommFun Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new CommFun();
			}
			return _instance;
		}
	}

	public Sprite LoadImage(string path){
		Texture2D tex = Resources.Load<Texture2D>(path);
		if(tex == null) {
			return null;
		}
		return Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f));
	}

	public AudioClip LoadAudio(string path) {
		return Resources.Load<AudioClip>(path);
	}

	public Object getAsset(string path){
		if(!File.Exists(path)){
			Debug.LogErrorFormat("不存在该资源:{0}",path);
			return null;
		}
		// 编辑器中相对于项目的路径
		Object asset = null;
#if UNITY_EDITOR
		asset = AssetDatabase.LoadAssetAtPath<Object>(path);
#endif
		if(asset == null){
			Debug.LogErrorFormat("检查该资源是否设置AssetBundleName:{0}",path);
		}
		return asset;
	}
}
