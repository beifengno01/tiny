using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

#if !NETFX_35
namespace BclExtras.Collections { 
static partial class Enumerable {public static float Sum(this IEnumerable<float> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
float sum = 0;
foreach ( var cur in e ) { sum+= cur; }
return sum;
}
public static double Sum(this IEnumerable<double> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
double sum = 0;
foreach ( var cur in e ) { sum+= cur; }
return sum;
}
public static int Sum(this IEnumerable<int> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
int sum = 0;
foreach ( var cur in e ) { sum+= cur; }
return sum;
}
public static long Sum(this IEnumerable<long> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
long sum = 0;
foreach ( var cur in e ) { sum+= cur; }
return sum;
}public static float Max(this IEnumerable<float> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var max = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current > max) { max = enumerator.Current; }
}
return max;
} }
public static double Max(this IEnumerable<double> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var max = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current > max) { max = enumerator.Current; }
}
return max;
} }
public static int Max(this IEnumerable<int> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var max = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current > max) { max = enumerator.Current; }
}
return max;
} }
public static long Max(this IEnumerable<long> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var max = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current > max) { max = enumerator.Current; }
}
return max;
} }public static float Min(this IEnumerable<float> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var min = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current < min) { min = enumerator.Current; }
}
return min;
} }
public static double Min(this IEnumerable<double> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var min = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current < min) { min = enumerator.Current; }
}
return min;
} }
public static int Min(this IEnumerable<int> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var min = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current < min) { min = enumerator.Current; }
}
return min;
} }
public static long Min(this IEnumerable<long> e) { 
if ( e == null ) { throw new ArgumentNullException("e"); }
using ( var enumerator = e.GetEnumerator() ) {
if ( !enumerator.MoveNext() ) {throw EnumerableExtra.CreateEmpty(); }
var min = enumerator.Current; 
while ( enumerator.MoveNext() ) {
if ( enumerator.Current < min) { min = enumerator.Current; }
}
return min;
} }public static float Average(this IEnumerable<float> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
float sum = 0;
long count = 0L;
foreach ( var cur in e ) { sum += cur; count++;}
return (float)(count > 0 ? (sum/count) : 0);
}
public static double Average(this IEnumerable<double> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
double sum = 0;
long count = 0L;
foreach ( var cur in e ) { sum += cur; count++;}
return (double)(count > 0 ? (sum/count) : 0);
}
public static int Average(this IEnumerable<int> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
long sum = 0;
long count = 0L;
foreach ( var cur in e ) { sum += cur; count++;}
return (int)(count > 0 ? (sum/count) : 0);
}
public static long Average(this IEnumerable<long> e) {
if ( e == null ) { throw new ArgumentNullException("e"); }
long sum = 0;
long count = 0L;
foreach ( var cur in e ) { sum += cur; count++;}
return (long)(count > 0 ? (sum/count) : 0);
}} }
#endif

