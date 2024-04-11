using UnityEngine;
using R3;

namespace radiants.IngameConsole.View
{
	[RequireComponent(typeof(UnityEngine.UI.Button))]
	public class ShortcutButton : MonoBehaviour
	{
		[SerializeField]
		private string commandName;

		private CompositeDisposable Disposables = new CompositeDisposable();

		void Start()
		{
			UnityEngine.UI.Button myButton = GetComponent<UnityEngine.UI.Button>();
			myButton.OnClickAsObservable().Subscribe(_ =>
			{
				Console.Command(commandName);
			}).AddTo(Disposables);
		}

		private void OnDestroy()
		{
			Disposables.Dispose();
		}
	}
}