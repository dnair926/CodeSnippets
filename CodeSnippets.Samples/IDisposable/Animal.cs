
using System;
using System.Collections.Generic;

namespace CodeSnippets.Samples.IDisposable {
    public class Animal : System.IDisposable {
        public string Name { get; set; }

        public IList<string> Pictures { get; set; }

        public virtual void Speak() {
            CheckIfDisposeAndRaiseException();

            Console.WriteLine("Name: {0}", Name);
        }


        #region IDisposable Members

        // --------------------------------------------
        // NOTE: Implement IDisposable for the class
        // --------------------------------------------

        private bool _isDisposed = false;

        /// <summary>
        /// Finalize method to dispose resources when object goes out of scope.
        /// </summary>
        /// <remarks>
        /// This code should be used as-is for the Dispose functionality.
        /// </remarks>
        ~Animal() {
            Dispose(false);
        }

        /// <summary>
        /// Method that will be called explicitly to dispose the resources in this object.
        /// </summary>
        /// <remarks>
        /// This code should be used as-is for the Dispose functionality.
        /// </remarks>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method that handles the logic to dispose object when it goes out of scope and when disposed explicitly.
        ///  Also, handles the redundant object disposal.
        /// </summary>
        /// <remarks>
        /// This code should be used as-is for the Dispose functionality and should be overridden by derived classes.
        /// </remarks>
        private void Dispose(bool canDisposeManagedResources) {
            if (this._isDisposed) {
                return;
            }

            if (canDisposeManagedResources) {
                try {
                    this.DisposeManagedResources();
                } catch (Exception ex) {

                }
            }

            try {
                this.DisposeUnmanagedResources();
            } catch (Exception ex) {

            }

            this._isDisposed = true;
        }

        /// <summary>
        /// Dispose all managed resources here.
        /// </summary>
        protected virtual void DisposeManagedResources() {

            if (Pictures != null) {
                Pictures.Clear();
                Pictures = null;
            }

        }

        /// <summary>
        /// Dispose all the unmanaged resources here.
        /// </summary>
        protected virtual void DisposeUnmanagedResources() {

        }

        /// <summary>
        /// This should be the first statement in all public members of this object.
        /// </summary>
        protected void CheckIfDisposeAndRaiseException() {

            if (this._isDisposed) {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

        }

        #endregion

    }
}