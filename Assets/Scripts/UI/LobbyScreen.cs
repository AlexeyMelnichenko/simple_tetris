using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class LobbyScreen : ScreenBase, IPointerClickHandler
    {
        private TaskCompletionSource<ScreenResult> _taskCompletionSource;

        public Task<ScreenResult> Result => _taskCompletionSource.Task;

        public override void Open()
        {
            _taskCompletionSource = new TaskCompletionSource<ScreenResult>();

            base.Open();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _taskCompletionSource.SetResult(ScreenResult.Ok);

            Close();
        }
    }

    public enum ScreenResult
    {
        None, Ok, Close
    }
}