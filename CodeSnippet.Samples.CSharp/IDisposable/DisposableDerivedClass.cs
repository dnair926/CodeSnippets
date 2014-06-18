using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippets.Samples {
    public class DisposableDerivedClass : DisposableBaseClass {

        #region IDisposable Members

        /// <summary>
        /// Dispose all managed resources here.
        /// </summary>
        public override void DisposeManagedResources() {
			
          if (_managedResource != null) {
            _managedResource.Dispose();
            _managedResource = null;
          }

            base.DisposeManagedResources();
        }
    
        /// <summary>
        /// Dispose all unmanaged resources here.
        /// </summary>
        public overrides void DisposeUnmanagedResources() {
    
        }
    
        #endregion

              
    }
}