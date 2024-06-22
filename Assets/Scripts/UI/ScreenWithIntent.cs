using System;
namespace Assets.Scripts.UI
{
    public class ScreenWithIntent<TIntent> : ScreenBase, IIntentContainer<TIntent> where TIntent : EmptyIntent
    {
        public TIntent Intent { get; private set; }

        void IIntentContainer<TIntent>.SetIntent(TIntent intent)
        {
            Intent = intent;
            OnScreenInitialized();
        }

        protected virtual void OnScreenInitialized() { }
    }

    public class EmptyIntent
    {
    }
}
