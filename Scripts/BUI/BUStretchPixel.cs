using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
[RequireComponent (typeof(BUSprite))]
public class BUStretchPixel : MonoBehaviour
{
	public int PixelFixedWidth = 40;
	public int PixelFixedHeight = 40;
	
	private BUSprite sprite;
	
	void Awake()
	{
		sprite = GetComponent<BUSprite>();
	}
	
	void Update()
	{
		var size = Vector2.one;
		var window = BUCamera.CurrentCamera.PixelWindowSize;
		size.x = (float)PixelFixedWidth / window.x;
		size.y = (float)PixelFixedHeight / window.y;
		sprite.ViewNormalizedSize = size;
	}
}
