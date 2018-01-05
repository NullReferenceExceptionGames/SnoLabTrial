using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;
    public TextAsset textfile;
    public string[] textLines;
    private int currentLine;
    public int endAtLine;

    // Use this for initialization
    void Start()
    {
        if (textfile != null)
        {
            textLines = (textfile.text.Split('\n'));


        }
        if (endAtLine == 0) {
            endAtLine = textLines.Length - 1;
        }

    }

    void Update()
    {
        theText.text = textLines[currentLine];
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return))
        {
            currentLine += 1;
			if (currentLine == textLines.Length)
				Destroy (transform.parent.gameObject);
        }
    }
}