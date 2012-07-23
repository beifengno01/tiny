﻿// MethodImplyRow.cs
//  
// Author:
//     Scott Wisniewski <scott@scottdw2.com>
//  
// Copyright (c) 2012 Scott Wisniewski
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//  
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//  
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Runtime.InteropServices;

namespace Tiny.Metadata.Layout
{
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct MethodImplRow
    {
        public OneBasedIndex GetClass(PEFile peFile)
        {
            peFile.CheckNotNull("peFile");
            fixed (MethodImplRow* pThis = &this) {
                if (MetadataTable.TypeDef.IndexSize(peFile) == 2) {
                    return new OneBasedIndex(*(ushort*) pThis);
                }
                return new OneBasedIndex(*(uint*) pThis);
            }
        }

        public MethodDefOrRef GetImplementingMethod(PEFile peFile)
        {
            peFile.CheckNotNull("peFile");
            fixed (MethodImplRow* pThis = &this) {
                var pImplementingMethod = (byte*) pThis + MetadataTable.TypeDef.IndexSize(peFile);
                if (CodedIndex.MethodDefOrRef.IndexSize(peFile) == 2) {
                    return new MethodDefOrRef(new OneBasedIndex(*(ushort*) pImplementingMethod));
                }
                return new MethodDefOrRef(new OneBasedIndex(*(uint*) pImplementingMethod));
            }
        }

        public MethodDefOrRef GetImplementedMethod(PEFile peFile)
        {
            peFile.CheckNotNull("peFile");
            fixed (MethodImplRow* pThis = &this) {
                var pImplementedMethod = 
                    (byte*) pThis 
                    + MetadataTable.TypeDef.IndexSize(peFile) 
                    + CodedIndex.MethodDefOrRef.IndexSize(peFile);

                if (CodedIndex.MethodDefOrRef.IndexSize(peFile) == 2) {
                    return new MethodDefOrRef(new OneBasedIndex(*(ushort*) pImplementedMethod));
                }
                return new MethodDefOrRef(new OneBasedIndex(*(uint*) pImplementedMethod));
            }
        }
    }
}