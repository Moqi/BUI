using UnityEngine;
using System.Collections;

public enum BUStretchStyle
{
	None,
	Vertical,
	Horizontal,
	Both,
	KeepAspectRatioWithHeight,
}

[ExecuteInEditMode()]
[RequireComponent (typeof(BUSprite))]
public class BUStretch : MonoBehaviour
{
	public BUSprite Container = null;
	public BUStretchStyle Style = BUStretchStyle.Horizontal;
	public Vector2 RelativeSize = Vector2.one;

	private BUSprite sprite;

	void Awake()
	{
		sprite = GetComponent<BUSprite>();
	}

	void Update()
	{
		var prev_size = sprite.ViewNormalizedSize;
		var new_size = (Container == null) ? Vector2.one : Container.ViewNormalizedSize;
		switch (Style)
		{
		case BUStretchStyle.None:
			return;
		case BUStretchStyle.Horizontal:
			new_size.x *= RelativeSize.x;
			new_size.y = prev_size.y;
			break;
		case BUStretchStyle.Vertical:
			new_size.x *= prev_size.x;
			new_size.y = RelativeSize.y;
			break;
		case BUStretchStyle.Both:
			new_size.x *= RelativeSize.x;
			new_size.y *= RelativeSize.y;
			break;
		case BUStretchStyle.KeepAspectRatioWithHeight:
			new_size.y *= RelativeSize.y;
			new_size.x = new_size.y / BUCamera.CurrentCamera.WindowAspectRatio * sprite.AspectRatio;
			break;
		}
		sprite.ViewNormalizedSize = new_size;
	}
}
