using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippets.Samples {
    public class DisposableDerivedClass : DisposableBaseClass {


        #region IDisposable Members

        private bool _isDisposed = false;

        public virtual void Dispose(bool canDisposeManagedResources) {
            if (_isDisposed) {
                return;
            }

            if (canDisposeManagedResources) {
                try {
                    DisposeManagedResources();
                } catch (Exception ex) {

                }
            }

            try {
                DisposeUnmanagedResources();
            } catch (Exception ex) {

            }

            _isDisposed = true;
        }

        private void DisposeManagedResources() {

        }

        private void DisposeUnmanagedResources() {

        }

        /// <summary>
        /// This should be the first statement in all public members of this object.
        /// </summary>
        private void CheckIfDisposeAndRaiseException() {
            if (_isDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);

        }

        #endregion


    }
}