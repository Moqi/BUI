using UnityEngine;
using System.Collections;

public enum BUSpriteOrigin
{
	Center,
	BottomLeft,
}

[ExecuteInEditMode()]
[RequireComponent (typeof(SpriteRenderer))]
public class BUSprite : MonoBehaviour
{
	public BUSpriteOrigin Origin = BUSpriteOrigin.Center;
	
	public Vector2 ViewNormalizedPosition
	{
		get
		{
			return BUCamera.CurrentCamera.CalculateRelativePosition(transform.position);
		}
		set
		{
			var pos = BUCamera.CurrentCamera.CalculateAbsolutePosition(value);
			if (Origin == BUSpriteOrigin.BottomLeft)
			{
				var offset = sprite.bounds.extents;
				offset.Scale(transform.localScale);
				pos += new Vector2(offset.x, offset.y);
			}
			transform.position = pos;
		}
	}
	public Vector2 ViewNormalizedSize
	{
		get
		{
			var scale = transform.localScale;
			var window_size = BUCamera.CurrentCamera.AbsoluteWindowSize;
			var x = OriginalAbsoluteSize.x * scale.x / window_size.x;
			var y = OriginalAbsoluteSize.y * scale.y / window_size.y;
			return new Vector2(x, y);
		}
		set
		{
			var scale = Vector2.one;
			var window_size = BUCamera.CurrentCamera.AbsoluteWindowSize;
			scale.x = value.x * window_size.x / OriginalAbsoluteSize.x;
			scale.y = value.y * window_size.y / OriginalAbsoluteSize.y;
			transform.localScale = scale;
		}
	}

	public Vector2 PixelSize
	{
		get
		{
			var size = ViewNormalizedSize;
			var window = BUCamera.CurrentCamera.PixelWindowSize;
			return new Vector2(size.x * window.x, size.y * window.y);
		}
	}

	public float AspectRatio
	{
		get
		{
			var size = OriginalAbsoluteSize;
			return size.x / size.y;
		}
	}

	public void UpdateColor(Color color)
	{
		GetComponent<SpriteRenderer>().color = color;
	}

	protected Sprite sprite = null;
	public Vector2 OriginalAbsoluteSize {get; private set;}

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>().sprite;
		OriginalAbsoluteSize = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
	}

	void Update()
	{
		if (sprite == null)
		{
			sprite = GetComponent<SpriteRenderer>().sprite;
		}
		OriginalAbsoluteSize = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
	}
}
