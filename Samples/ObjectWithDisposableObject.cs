
using System;
namespace CodeSnippets.Samples {
    public sealed class ObjectWithDisposableObject  {

        private DisposableSealedObject _disposableObject;

        public ObjectWithDisposableObject() {
            _disposableObject = new DisposableSealedObject();
        }

        public ObjectWithDisposableObject(DisposableSealedObject disposableObject) {
            _disposableObject = disposableObject;
        }

        #region IDisposable Members

        private bool _isDisposed = false;

        ~ObjectWithDisposableObject() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool canDisposeManagedResources) {
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

            if (_disposableObject != null) {
                _disposableObject.Dispose();
                _disposableObject = null;
			}

		}
    
		private void DisposeUnmanagedResources() {
    
		}
    
		/// <summary>
		/// This should be in all public functions and properties as the first call.
		/// </summary>
        private void CheckIfDisposeAndRaiseException() {
            if (_isDisposed)
                throw new ObjectDisposedException(@"BothTypeOfResourcesClass");

        }

        #endregion

              

    }
}
