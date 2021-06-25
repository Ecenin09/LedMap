using System;
using UniRx;

namespace SignalsFramework {
   /// <summary>
   /// Simple signal for receiving/sending messages to disconnected components in the application
   /// Serves purpose for decoupling logic without getting into retarded Zenject memory/CPU issues
   /// </summary>
   public class Signal : IObservable<Unit> {
      #region [Fields]

      private readonly Subject<Unit> _signalStream = new Subject<Unit>();

      #endregion

      public void Fire() { _signalStream.OnNext(Unit.Default); }

      public IDisposable Subscribe(IObserver<Unit> observer) { return _signalStream.Subscribe(observer.OnNext); }
   }

   /// <summary>
   /// Typed signal that passes typed data via stream same way as signal does 
   /// </summary>
   public class Signal<T> : IObservable<T> {
      #region [Fields]

      private readonly Subject<T> _signalStream = new Subject<T>();

      #endregion

      public void Fire(T data) { _signalStream.OnNext(data); }

      public IDisposable Subscribe(IObserver<T> observer) { return _signalStream.Subscribe(observer.OnNext); }
   }

   /// <summary>
   /// Typed signal that passes typed data via stream same way as signal does 
   /// </summary>
   public class Signal<T, T1> : IObservable<NonAllocTuple<T, T1>> {
      private readonly Subject<NonAllocTuple<T, T1>> _signalStream = new Subject<NonAllocTuple<T, T1>>();

      public IDisposable Subscribe(IObserver<NonAllocTuple<T, T1>> observer) {
         return _signalStream.Subscribe(observer.OnNext);
      }

      public void Fire(T data, T1 data2) {
         _signalStream.OnNext(new NonAllocTuple<T, T1> {X1 = data, X2 = data2});
      }
   }
   
   /// <summary>
   /// Typed signal that passes typed data via stream same way as signal does 
   /// </summary>
   public class Signal<T, T1, T2> : IObservable<NonAllocTruple<T, T1, T2>> {
      private readonly Subject<NonAllocTruple<T, T1, T2>> _signalStream = new Subject<NonAllocTruple<T, T1, T2>>();

      public IDisposable Subscribe(IObserver<NonAllocTruple<T, T1, T2>> observer) {
         return _signalStream.Subscribe(observer.OnNext);
      }

      public void Fire(T data, T1 data2, T2 data3) {
         _signalStream.OnNext(new NonAllocTruple<T, T1, T2> {X1 = data, X2 = data2, X3 = data3});
      }
   }

   public struct NonAllocTuple<T, T1> {
      public T X1;
      public T1 X2;
   }

   public struct NonAllocTruple<T, T1, T2> {
      public T X1;
      public T1 X2;
      public T2 X3;
   }
}