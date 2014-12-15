
using System;
using System.Collections.Generic;
namespace CodeSnippets.Samples.IDisposable {
    public class Dog : Animal, System.IDisposable {

        public IList<string> Tricks { get; set; }

        public override void Speak() {
            base.Speak();

            Console.WriteLine("Tricks:");
            foreach (var trick in Tricks) {
                Console.WriteLine(trick);
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Dispose all managed resources here.
        /// </summary>
        protected override void DisposeManagedResources() {

            if (Tricks != null) {
                Tricks.Clear();
                Tricks = null;
            }

            base.DisposeManagedResources();

        }

        /// <summary>
        /// Dispose all unmanaged resources here.
        /// </summary>
        protected override void DisposeUnmanagedResources() {

            base.DisposeUnmanagedResources();


        }

        #endregion


    }
}