// MetadataTable.cs
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

namespace Tiny.Decompiler.Metadata
{
    //# Defines an enum identifying the meta-data tables present in a managed executable.
    //# Reference: ECMA-335 Spec, 5th Edition, Partion II, �� 22.2-22.39
    enum MetadataTable : byte
    {
        Assembly = 0x20,
        AssemblyOS = 0x22,
        AssemblyProcessor = 0x21,
        AssemblyRef = 0x23,
        AssemblyRefOS = 0x25,
        AssemblyRefProcessor = 0x24,
        ClassLayout = 0x0F,
        Constant = 0x0B,
        CustomAttribute = 0x0C,
        DeclSecurity = 0x0E,
        EventMap = 0x12,
        Event = 0x14,
        ExportedType = 0x27,
        Field = 0x04,
        FieldLayout = 0x10,
        FieldMarshal = 0x0D,
        FieldRVA = 0x1D,
        File = 0x26,
        GenericParam = 0x2A,
        GenericParamConstraint = 0x2C,
        ImplMap = 0x1C,
        InterfaceImpl = 0x09,
        ManifestResource = 0x28,
        MemberRef = 0x0A,
        MethodDef = 0x06,
        MethodImpl = 0x19,
        MethodSemantics = 0x18,
        MethodSpec = 0x2B,
        Module = 0x00,
        ModuleRef = 0x1A,
        NestedClass = 0x29,
        Param = 0x08,
        Property = 0x17,
        PropertyMap = 0x15,
        StandAloneSig = 0x11,
        TypeDef = 0x02,
        TypeRef = 0x01,
        TypeSpec = 0x1B
    }
}