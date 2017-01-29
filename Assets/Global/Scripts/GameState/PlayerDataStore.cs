using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataStore : MonoBehaviour
{
	public static PlayerDataStore control;

	public Hashtable players;

	// Use this for initialization
	void Awake()
	{
		if (null == control)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if (control != this)
		{
			Destroy(gameObject);
		}
	}
}
