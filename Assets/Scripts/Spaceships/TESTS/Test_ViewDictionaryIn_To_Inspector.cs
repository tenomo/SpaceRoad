using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace UI

{
//	[Serializable]
	public class Test_ViewDictionaryIn_To_Inspector: MonoBehaviour//,ISerializationCallbackReceiver
	{


		 
			/*public List<int> _keys = new List<int> { 3, 4, 5};
			public List<string> _values = new List<string> { "I", "Love", "Unity"};

		[Serializable]
			//Unity doesn'timerAmendment  know how to serialize a Dictionary
			public Dictionary<int,string>  _myDictionary = new Dictionary<int,string>();

			public void OnBeforeSerialize()
			{
			 	//_keys.Clear();
				 //_values.Clear();
				foreach(var kvp in _myDictionary)
				{
					_keys.Add(kvp.Key);
					_values.Add(kvp.Value);
				}
			}

			public void OnAfterDeserialize()
			{
				_myDictionary = new Dictionary<int,string>();
				for (int i=0; i!= Math.Min(_keys.Count,_values.Count); i++)
					_myDictionary.Add(_keys[i],_values[i]);
			}

		void Start ()
		{
			OnAfterDeserialize ();
			foreach (var item in _myDictionary) {
				
				Debug.Log (item);
			}

		}
	*/
		public	NamedImage [] test  = new NamedImage[10];

		//void Start ()
		//{
		//	Debug.Log (transform.lossyScale);
		//}
	}

	[Serializable]
	public struct NamedImage {
		public string name;
		public Texture2D image;
	}
}
