﻿//-----------------------------------------------------------------------
// <copyright file="ICloudFileStream.cs" company="Microsoft">
//    Copyright 2013 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.Azure.Storage.File
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class CloudFileStream : Stream
    {
#if SYNC
        /// <summary>
        /// Clears all buffers for this stream, causes any buffered data to be written to the underlying file, and commits the file.
        /// </summary>
        public abstract void Commit();
#endif

#if !(NETCORE || WINDOWS_RT)
        /// <summary>
        /// Begins an asynchronous commit operation.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the commit is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous commit request from other requests.</param>
        /// <returns>An <c>ICancellableAsyncResult</c> that represents the asynchronous commit, which could still be pending.</returns>
        public abstract ICancellableAsyncResult BeginCommit(AsyncCallback callback, object state);

        /// <summary>
        /// Waits for the pending asynchronous commit to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public abstract void EndCommit(IAsyncResult asyncResult);

        /// <summary>
        /// Begins an asynchronous flush operation.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the flush is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous flush request from other requests.</param>
        /// <returns>An <c>ICancellableAsyncResult</c> that represents the asynchronous flush, which could still be pending.</returns>
        public abstract ICancellableAsyncResult BeginFlush(AsyncCallback callback, object state);

        /// <summary>
        /// Waits for the pending asynchronous flush to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public abstract void EndFlush(IAsyncResult asyncResult);
#endif //Netcore
        /// <summary>
        /// Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying file, and commits the file.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents an asynchronous action.</returns>
        public abstract Task CommitAsync();
    }
}
