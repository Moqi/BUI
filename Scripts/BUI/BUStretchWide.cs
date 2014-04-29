using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
[RequireComponent (typeof(BUSprite))]
public class BUStretchWide : MonoBehaviour
{
	public float RelativeWidth = 1.0f;
	public int PixelFixedHeight = 40;

	private BUSprite sprite;
	
	void Awake()
	{
		sprite = GetComponent<BUSprite>();
	}

	void Update()
	{
		var size = Vector2.one;
		size.x = RelativeWidth;
		size.y = (float)PixelFixedHeight / BUCamera.CurrentCamera.PixelWindowSize.y;
		sprite.ViewNormalizedSize = size;
	}
}
