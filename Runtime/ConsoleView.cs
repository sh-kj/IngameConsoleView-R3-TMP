using System.Collections.Generic;
using UnityEngine;
using R3;
using R3.Triggers;
using TMPro;
using System.Text;

namespace radiants.IngameConsole.View
{
	public class ConsoleView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text Text;

		[SerializeField]
		private TMP_InputField Input;

		[SerializeField]
		private UnityEngine.UI.Button DisplayToggleButton;

		[SerializeField]
		private GameObject[] DisplayObjects;

		private bool Display
		{ get; set; } = true;

		private CompositeDisposable Disposables = new CompositeDisposable();

		private void Start()
		{
			Text.text = "";
			Console.LogUpdateAsObservable
				.Subscribe(_log => UpdateText(_log))
				.AddTo(Disposables);

			Input.onSubmit.AddListener(OnSubmitInput);			

			DisplayToggleButton.OnClickAsObservable()
				.Subscribe(_ => ToggleDisplay())
				.AddTo(Disposables);
		}


		private void OnDestroy()
		{
			Disposables.Dispose();
			Input.onSubmit.RemoveListener(OnSubmitInput);
		}

		private void UpdateText(List<string> logs)
		{
			StringBuilder builder = new StringBuilder();
			foreach (var log in logs)
			{
				builder.Append(log);
				builder.Append("\n");
			}

			Text.SetText(builder);
		}

		private void OnSubmitInput(string input)
		{
			Input.text = "";
			Console.Command(input);
		}

		private void ToggleDisplay()
		{
			Display = !Display;
			foreach (var obj in DisplayObjects)
			{
				obj.SetActive(Display);
			}
		}
	}
}