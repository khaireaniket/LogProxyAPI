﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogProxyAPI.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LogProxyAPI.Tests.TestData", typeof(TestData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;records&quot;: [
        ///        {
        ///            &quot;id&quot;: &quot;recCR2LP7wZVioc5H&quot;,
        ///            &quot;fields&quot;: {
        ///                &quot;id&quot;: &quot;1&quot;,
        ///                &quot;Summary&quot;: &quot;Event OrgCreated successfully&quot;,
        ///                &quot;Message&quot;: &quot;Domain event organization created with aggregate id 111&quot;,
        ///                &quot;receivedAt&quot;: &quot;2021-01-01T00:38:00.000Z&quot;
        ///            },
        ///            &quot;createdTime&quot;: &quot;2021-01-13T23:37:41.000Z&quot;
        ///        },
        ///        {
        ///            &quot;id&quot;: &quot;recQIRdD3ViazuK0i&quot;,
        ///            &quot;fields&quot;: {
        ///                &quot;id&quot;:  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AirTableGetResponse {
            get {
                return ResourceManager.GetString("AirTableGetResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///    &quot;records&quot;: [
        ///        {
        ///            &quot;id&quot;: &quot;recOQLFQ6W3hWiC1a&quot;,
        ///            &quot;fields&quot;: {
        ///                &quot;id&quot;: &quot;2662&quot;,
        ///                &quot;Summary&quot;: &quot;Event OrgCreated successfully&quot;,
        ///                &quot;Message&quot;: &quot;Domain event organization created with aggregate id 111&quot;,
        ///                &quot;receivedAt&quot;: &quot;2021-02-06T17:43:13.154Z&quot;
        ///            },
        ///            &quot;createdTime&quot;: &quot;2021-02-06T17:43:18.000Z&quot;
        ///        },
        ///        {
        ///            &quot;id&quot;: &quot;recX5bUuJt599jhVi&quot;,
        ///            &quot;fields&quot;: {
        ///                &quot;id [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AirTablePostResponse {
            get {
                return ResourceManager.GetString("AirTablePostResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;logRequest&quot;: [
        ///    {
        ///      &quot;title&quot;: &quot;Event OrgCreated successfully&quot;,
        ///      &quot;text&quot;: &quot;Domain event organization created with aggregate id 111&quot;
        ///    },
        ///    {
        ///      &quot;title&quot;: &quot;Event OrgUpdated successfully&quot;,
        ///      &quot;text&quot;: &quot;Domain event organization updated with aggregate id 111&quot;
        ///    }
        ///  ]
        ///}.
        /// </summary>
        internal static string CreateLogRequest {
            get {
                return ResourceManager.GetString("CreateLogRequest", resourceCulture);
            }
        }
    }
}
