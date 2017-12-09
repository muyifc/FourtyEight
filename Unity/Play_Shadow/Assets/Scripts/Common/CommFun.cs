using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

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
		path = string.Format("Assets/Art/{0}.jpg",path);
		Texture2D tex = getAsset(path) as Texture2D;
		if(tex == null) {
			return null;
		}
		return Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f,0.5f));
	}



	public Object getAsset(string path){
		if(!File.Exists(path)){
			Debug.LogErrorFormat("不存在该资源:{0}",path);
			return null;
		}
		// 编辑器中相对于项目的路径
		Object asset = AssetDatabase.LoadAssetAtPath<Object>(path);
		if(asset == null){
			Debug.LogErrorFormat("检查该资源是否设置AssetBundleName:{0}",path);
		}
		return asset;
	}
}
