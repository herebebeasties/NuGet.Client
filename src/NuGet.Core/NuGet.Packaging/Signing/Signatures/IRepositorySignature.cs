// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if IS_SIGNING_SUPPORTED
using System;
using System.Collections.Generic;
#endif

namespace NuGet.Packaging.Signing
{
    public interface IRepositorySignature : ISignature
    {
#if IS_SIGNING_SUPPORTED
        Uri V3ServiceIndexUrl { get; }

        IReadOnlyList<string> PackageOwners { get; }
#endif
    }
}
