using UnityEngine;
using UnityEngine.UI;

public class UIDateTime : MonoBehaviour {

	[Header("TEXTS")]
	public Text timeText;
	public Text dateText;
	public Text amPmText;

	[Header("LOCK SCREEN")]
	public Text hourText;
	public Text minuteText;

	[Header("SETTINGS")]
	public bool amPmFormat = true;
    public bool dontSeperate;
    public bool seperateAmPm;

	void Update () 
	{ 
        if (seperateAmPm)
        {
            amPmText.text = System.DateTime.Now.ToString("tt");
        }

        if (amPmFormat && dontSeperate == false)
        {
            timeText.text = System.DateTime.Now.ToString("h:mm tt");
            dateText.text = System.DateTime.Now.ToString("M.d.yyyy");
        }

        else if (amPmFormat == false && dontSeperate == false)
        {
            timeText.text = System.DateTime.Now.ToString("h:mm");
            dateText.text = System.DateTime.Now.ToString("M.d.yyyy");
        }

        else if (amPmFormat && dontSeperate)
        {
            timeText.text = System.DateTime.Now.ToString("hmm tt");
            dateText.text = System.DateTime.Now.ToString("Mdyyyy");
        }

        else if (amPmFormat == false && dontSeperate)
        {
            if (amPmText.text == "PM")
            {
                timeText.text = System.DateTime.Now.ToString("✦<b>hh</b>mm");
                dateText.text = System.DateTime.Now.ToString("Mdyyyy");
            }
            else
            {
                timeText.text = System.DateTime.Now.ToString("☀<b>hh</b>mm");
                dateText.text = System.DateTime.Now.ToString("Mdyyyy");
            }
        }
    }
}
