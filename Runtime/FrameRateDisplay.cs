using UnityEngine;

namespace radiants.IngameConsole.View
{
	public class FrameRateDisplay : MonoBehaviour
	{
		[SerializeField]
		private SpriteDigits.SpriteDigitsFloat Digits;

		[SerializeField]
		private float MeanSeconds = 0.2f;

		private int MeanFrameCount
		{ get; set; } = 0;
		private float TimeCount
		{ get; set; } = 0f;

		private void Update()
		{
			TimeCount += Time.unscaledDeltaTime;
			MeanFrameCount++;

			if (TimeCount < MeanSeconds) return;

			Digits.Value = MeanFrameCount / TimeCount;

			MeanFrameCount = 0;
			TimeCount = 0f;
		}
	}
}