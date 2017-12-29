using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class painting : MonoBehaviour {
    public GameObject bluepaint;
	public bool boolToggleButton;
	public GUISkin MyGUISkin;
	public GameObject ButtonPaint;

	void Start(){
		ButtonPaint = GameObject.Find ("PaintBtn");
		boolToggleButton = false;
	}

	// Update is called once per frame
	void Update () {
		if (boolToggleButton) {
			// DO SOMETHING HERE
			Debug.Log("Button Pressed");
			draw ();
		}

	}

	public void loadScene()
	{
		SceneManager.LoadScene("one");

	}

	bool ispressed = false;
	public  void OnPointerDown()
	{
		ispressed = true;
	}

	public  void OnPointerUp()
	{
		ispressed = false;
	}

	public void draw()
	{
		GameObject newObject = Instantiate(bluepaint, transform.position, transform.rotation);
		newObject.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void clear(){
		foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("foo")) {
			if (fooObj.name == "1(Clone)") {
				Destroy (fooObj);
			}
		}
	}

	public void OnGUI(){

		if (Input.GetKey (KeyCode.F7)) {
			Debug.Log ("PAINT");
			draw ();
		}


		
		if (boolToggleButton == false) {
			boolToggleButton = true;
			Text txt = ButtonPaint.GetComponent<Text>() as Text;

			ButtonPaint.GetComponentInChildren<Text>().text = "Off Ink";
		} else {
			boolToggleButton = false;
			Text txt = ButtonPaint.GetComponent<Text> () as Text;

			ButtonPaint.GetComponentInChildren<Text>().text = "On Ink";
		}
	}
}
