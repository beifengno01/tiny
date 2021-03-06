// 
// Util.cs
//  
// Author:
//       Scott Wisniewski <scott@scottdw2.com>
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tiny.Collections;
using Tiny.Metadata.Layout;

namespace Tiny
{
    public static class Util
    {
        public static IReadOnlyDictionary<K,V> AsReadOnly<K, V>(this IDictionary<K,V> d)
        {
            d.CheckNotNull("d");
            return new ReadOnlyDictionary<K, V>(d.CheckNotNull("d"));
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
        {
            var ret = new HashSet<T>();
            items.ForEach(x=>ret.Add(x));
            return ret;
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            items.CheckNotNull("items");
            action.CheckNotNull("action");

            foreach (var item in items) {
                action(item);
            }
        }

        public static uint Pad(this uint length, uint pad)
        {
            return checked(((pad - (length%pad))%pad) + length);
        }

        public static ulong Pad(this ulong length, ulong pad)
        {
            return checked(((pad - (length % pad)) % pad) + length);
        }

        public static IntPtr Pad(this IntPtr length, IntPtr pad)
        {
            return (IntPtr) Pad((ulong) length, (ulong) pad);
        }

        public static int BitCount(this ulong value)
        {
            //# This code is a little complex, but it is really fast. Ideally we would just use popcnt, but it's not
            //# available to us from C#.
            //#
            //# See the following for references:
            //# 1. http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSet64
            //# 2. http://www.necessaryandsufficient.net/2009/04/optimising-bit-counting-using-iterative-data-driven-development/
            //# 3. http://en.wikipedia.org/wiki/Hamming_weight
            //# 4. http://www-cs-faculty.stanford.edu/~knuth/fasc1a.ps.gz
            const ulong m1 = 0x5555555555555555UL;
            const ulong m2 = 0x3333333333333333UL;
            const ulong m4 = 0x0F0F0F0F0F0F0F0FUL;

            value -= ((value >> 1) & m1);
            value = ((value >> 2) & m2) + (value & m2);
            value = (value + (value >> 4)) & m4;
            return (int)((value * 0x0101010101010101UL) >> 56);
        }

        public static void Times(this uint n, Action action)
        {
            for (var i = 0; i < n; ++i) {
                action();
            }
        }

        public static void Print<T>(
            this IEnumerable<T> items,
            StringBuilder builder,
            String seperator
        )
        {
            Print(items, builder, seperator, null, null,(v, b) => b.Append(v));
        }

        public static void Print<T>(
            this IEnumerable<T> items,
            StringBuilder builder,
            String seperator,
            String prefix,
            String suffix
        )
        {
            Print(items, builder, seperator, prefix, suffix, (v, b) => b.Append(v));
        }

        public static void Print<T>(
            this IEnumerable<T> items,
            StringBuilder builder,
            String seperator,
            String prefix,
            String suffix,
            Action<T, StringBuilder> formatter
        )
        {
            seperator = seperator ?? "";
            prefix = prefix ?? "";
            suffix = suffix ?? "";

            builder.Append(prefix);
            var first = true;
            foreach (var item in items) {
                if (first) {
                    first = false;
                }
                else {
                    builder.Append(seperator);
                }
                formatter(item, builder);
            }
            builder.Append(suffix);
        }

        public static void Print<T>(
            this IEnumerable<T> items,
            StringBuilder builder,
            String seperator,
            Action<T, StringBuilder> formatter
        )
        {
            Print(items, builder, seperator, null, null, formatter);
        }

        internal static ZeroBasedIndex ToZB(this int value)
        {
            return new ZeroBasedIndex(value);
        }

        internal static ISubList<T> SubList<T>(this IReadOnlyList<T> list, int startIndex)
        {
            return new SubList<T>(list, startIndex);
        }

        internal static ISubList<T> SubList<T>(this IReadOnlyList<T> list, int startIndex, int length)
        {
            return new SubList<T>(list, startIndex, length);
        }

        internal static ISubList<T> Expand<T>(this ISubList<T> list, int increment)
        {
            return new SubList<T>(list.Wrapped, list.StartIndex, list.Count + increment.CheckGTE(0, "increment"));
        }

        public static Action<T> Then<T>(this Action<T> first, Action<T> second)
        {
            if (first == null) {
                return second;
            }
            if (second == null) {
                return first;
            }
            return x => {
                first(x);
                second(x);
            };
        }

        public static Action<T1, T2> Then<T1, T2>(this Action<T1, T2> first, Action<T1, T2> second) {
            if (first == null) {
                return second;
            }
            if (second == null) {
                return first;
            }
            return (x,y) => {
                first(x, y);
                second(x, y);
            };
        }

        public static Action<T> After<T>(this Action<T> second, Action<T> first)
        {
            return first.Then(second);
        }

        public static Action<T1, T2> After<T1, T2>(this Action<T1, T2> second, Action<T1, T2> first)
        {
            return first.Then(second);
        }

        public static uint ReadLittleEndianUInt(this IReadOnlyList<byte> bytes)
        {
            return 
                (uint) bytes[0] 
                | ((uint) bytes[1] << 8) 
                | ((uint) bytes[2] << 16) 
                | ((uint) bytes[3] << 24);
        }

        public static int ReadLittleEndianInt(this IReadOnlyList<byte> bytes)
        {
            return (int) ReadLittleEndianUInt(bytes);
        }

        public static unsafe float ReadLittleEndianSingle(this IReadOnlyList<byte> bytes)
        {
            var v = ReadLittleEndianUInt(bytes);
            return *(float*) &v;
        }

        public static unsafe double ReadLittleEndianDouble(this IReadOnlyList<byte> bytes)
        {
            var v = ReadLittleEndianULong(bytes);
            return *(double*)&v;
        }

        public static ulong ReadLittleEndianULong(this IReadOnlyList<byte> bytes)
        {
            return
                (ulong) bytes[0]
                | ((ulong) bytes[1] << 8)
                | ((ulong) bytes[2] << 16)
                | ((ulong) bytes[3] << 24)
                | ((ulong) bytes[4] << 32)
                | ((ulong) bytes[5] << 40)
                | ((ulong) bytes[6] << 48)
                | ((ulong) bytes[7] << 56);
        } 

        public static long ReadLittleEndianLong(this IReadOnlyList<byte> bytes)
        {
            return (long) ReadLittleEndianULong(bytes);
        }

        public static ushort ReadLittleEndianUShort(this IReadOnlyList<byte> bytes)
        {
            return (ushort)(bytes[0] | (bytes[1] << 8));
        }

        public static string Escape(this String s)
        {
            throw new NotImplementedException();
        }

        public static int LeastUpperBound<T>(this IReadOnlyList<T> list, T value, Comparer<T>  comparer)
        {
            return LeastUpperBound(list, x => x, value, comparer);
        }

        public static int LeastUpperBound<T>(this IReadOnlyList<T> list, T value)
        {
            return LeastUpperBound(list, x => x, value);
        }

        public static int LeastUpperBound<T,R>(this IReadOnlyList<T> list, Func<T,R> selector, R value)
        {
            return LeastUpperBound(list, selector, value, Comparer<R>.Default);
        }

        public static int LeastUpperBound<T,R>(
            this IReadOnlyList<T> list,
            Func<T,R> selector,
            R value,
            Comparer<R> comparer
        )
        {
            list.CheckNotNull("list");
            selector.CheckNotNull("selector");

            if (list.Count == 0) {
                return 1;
            }
            var min = 0;
            var max = list.Count - 1;
            var last = max;
            
            while (min <= last && max != min) {
                var mid = (max - min) / 2 + min;
                var comp = comparer.Compare(value, selector(list[mid]));
                if (comp < 0) {
                    max = mid;
                }
                else {
                    min = mid + 1;
                }

            }

            if (min > last) {
                return last + 1;
            }
            if (max < last || comparer.Compare(value, selector(list[max])) < 0) {
                return max;
            }
            return last + 1;
        }

        public static int GreatestLowerBound<T,R>(
            this IReadOnlyList<T> list,
            Func<T,R> selector,
            R value,
            Comparer<R> comparer
        )
        {
            list.CheckNotNull("list");
            selector.CheckNotNull("selector");

            if (list.Count == 0) {
                return -1;
            }
            var min = 0;
            var max = list.Count - 1;

            while (max >= 0 && max != min) {
                var mid = ((max - min) + 1)/2 + min;
                var comp = comparer.Compare(value, selector(list[mid]));
                if (comp <= 0) {
                    max = min - 1;
                }
                else {
                    min = mid;
                }
            }

            if (max < 0) {
                return -1;
            }

            if (min > 0 || comparer.Compare(value, selector(list[min])) > 0) {
                return min;
            }

            return -1;
        }
    }
}

