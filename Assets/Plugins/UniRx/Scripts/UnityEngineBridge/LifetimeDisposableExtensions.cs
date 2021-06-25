using System;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

namespace UniRx
{
    public static partial class DisposableExtensions
    {
        /// <summary>Dispose self on target gameObject has been destroyed. Return value is self disposable.</summary>
        public static T AddTo<T>(this T disposable, GameObject gameObject)
            where T : IDisposable
        {
            if (!gameObject.TryGetComponent(out ObservableDestroyTrigger trigger))
            {
                trigger = gameObject.AddComponent<ObservableDestroyTrigger>();
            }

            trigger.AddDisposableOnDestroy(disposable);
            return disposable;
        }

        /// <summary>Dispose self on target gameObject has been destroyed. Return value is self disposable.</summary>
        public static T AddTo<T>(this T disposable, Component gameObjectComponent)
            where T : IDisposable
        {
            return AddTo(disposable, gameObjectComponent.gameObject);
        }

        /// <summary>
        /// <para>Add disposable(self) to CompositeDisposable(or other ICollection) and Dispose self on target gameObject has been destroyed.</para>
        /// <para>Return value is self disposable.</para>
        /// </summary>
        public static T AddTo<T>(this T disposable, ICollection<IDisposable> container, GameObject gameObject)
            where T : IDisposable
        {
            return disposable.AddTo(container).AddTo(gameObject);
        }

        /// <summary>
        /// <para>Add disposable(self) to CompositeDisposable(or other ICollection) and Dispose self on target gameObject has been destroyed.</para>
        /// <para>Return value is self disposable.</para>
        /// </summary>
        public static T AddTo<T>(this T disposable, ICollection<IDisposable> container, Component gameObjectComponent)
            where T : IDisposable
        {
            return disposable.AddTo(container).AddTo(gameObjectComponent);
        }
    }
}