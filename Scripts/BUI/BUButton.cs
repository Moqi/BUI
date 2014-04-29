using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent (typeof(BUSprite))]
public class BUButton : MonoBehaviour
{
	void Update()
	{
//		collider.
	}

	void OnMouseDown()
	{
		gameObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
	}

	void OnMouseEnter()
	{
		gameObject.SendMessage("OnHover", true, SendMessageOptions.DontRequireReceiver);
	}

	void OnMouseExit()
	{
		gameObject.SendMessage("OnHover", false, SendMessageOptions.DontRequireReceiver);
	}
}
