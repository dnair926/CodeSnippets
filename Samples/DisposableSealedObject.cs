
using System;

namespace CodeSnippets.Samples {
    public class DisposableSealedObject : IDisposable {

        #region IDisposable Members

        private bool _isDisposed = false;

        ~DisposableSealedObject() {
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
