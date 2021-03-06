using UnityEngine;
using System;
using System.Collections;
using KBEngine;

public class clientapp : MonoBehaviour {
	public static KBEngineApp gameapp = null;
	
	void Awake() 
	 {
		DontDestroyOnLoad(transform.gameObject);
	 }
 
	// Use this for initialization
	void Start () 
	{
		MonoBehaviour.print("clientapp::start()");
			
		gameapp = new KBEngineApp();
		KBEngineApp.url = "http://127.0.0.1";
		KBEngineApp.app.clientType = 5;
		KBEngineApp.app.ip = "127.0.0.1";
		KBEngineApp.app.port = 20013;
		
		//gameapp.autoImportMessagesFromServer(true);
	}
	
	void OnDestroy()
	{
		MonoBehaviour.print("clientapp::OnDestroy(): begin");
		KBEngineApp.app.destroy();
		MonoBehaviour.print("clientapp::OnDestroy(): over, isbreak=" + gameapp.isbreak + ", over=" + gameapp.kbethread.over);
	}
	
	void FixedUpdate () {
		KBEUpdate();
	}
		
	void KBEUpdate()
	{
		KBEngine.Event.processOutEvents();
	}
}
