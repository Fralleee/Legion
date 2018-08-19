using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAsset_UI : MonoBehaviour {

    public TextAsset textFile;

	// Use this for initialization
	void Start () {

        GetComponent<Text>().text = textFile.text;
	}
}
