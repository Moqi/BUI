using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BUSprite))]
[RequireComponent (typeof(BUButton))]
public class BUButtonColor : MonoBehaviour
{
	public Color MainColor = Color.white;
	public Color HoverColor = Color.gray;
	public Color ActiveColor = Color.blue;
	public Color ActiveHoverColor = Color.blue;
	
	public bool Active
	{
		get {return _active;}
		set
		{
			_active = value;
			UpdateColor();
		}
	}

	private bool _active = false;
	private bool _hover = false;
	private BUSprite sprite;
	
	void Awake()
	{
		sprite = GetComponent<BUSprite>();
		sprite.UpdateColor(MainColor);
	}

	void OnHover(bool hover)
	{
		_hover = hover;
		UpdateColor();
	}

	void UpdateColor()
	{
		if (_hover)
		{
			sprite.UpdateColor(Active ? ActiveHoverColor : HoverColor);
		}
		else
		{
			sprite.UpdateColor(Active ? ActiveColor : MainColor);
		}
	}
}
