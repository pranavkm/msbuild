﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Build.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Build.Tasks.ResourceHandling
{
    internal class TypeConverterByteArrayResource : IResource
    {
        public string Name { get; }
        public string TypeName { get; }
        public string OriginatingFile { get; }
        public byte[] Bytes { get; }

        public TypeConverterByteArrayResource(string name, string typeName, byte[] bytes, string originatingFile)
        {
            Name = name;
            TypeName = typeName;
            Bytes = bytes;
            OriginatingFile = originatingFile;
        }

        public void AddTo(IResourceWriter writer)
        {
            if (writer is PreserializedResourceWriter preserializedResourceWriter)
            {
                preserializedResourceWriter.AddTypeConverterResource(Name, Bytes, TypeName);
            }
            else
            {
                throw new PreserializedResourceWriterRequiredException();
            }
        }
    }
}