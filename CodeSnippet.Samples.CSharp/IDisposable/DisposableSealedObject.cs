
using System;
using System.Collections.Generic;

namespace CodeSnippets.Samples {
    public sealed class DisposableSealedObject : IDisposable {

        private IntPtr handle;
        private List<String> peoples = new List<string>();

        public DisposableSealedObject(IntPtr handle) {
            CreatePeopleListForNoReason();
            this.handle = handle;
        }

        private void CreatePeopleListForNoReason() {
            for (int i = 0; i < 1000; i++) {
                peoples.Add(i.ToString());
            }
        }

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

            if (peoples != null) {
                peoples.Clear();
                peoples = null;
            }

        }

        private void DisposeUnmanagedResources() {
            CloseHandle(handle);
            handle = IntPtr.Zero;
        }

        /// <summary>
        /// This should be in all public functions and properties as the first call.
        /// </summary>
        private void CheckIfDisposeAndRaiseException() {
            if (_isDisposed)
                throw new ObjectDisposedException(@"BothTypeOfResourcesClass");

        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        #endregion


    }
}