﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Build", "CA1307:The behavior of 'string.EndsWith(string)' could vary based on the current user's locale settings. Replace this call in 'NuGet.Credentials.CredentialService.TryGetLastKnownGoodCredentialsFromCache(System.Uri, bool, out System.Net.ICredentials)' with a call to 'string.EndsWith(string, System.StringComparison)'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.CredentialService.TryGetLastKnownGoodCredentialsFromCache(System.Uri,System.Boolean,System.Net.ICredentials@)~System.Boolean")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'Task<CredentialResponse> PluginCredentialProvider.GetAsync(Uri uri, IWebProxy proxy, CredentialRequestType type, string message, bool isRetry, bool nonInteractive, CancellationToken cancellationToken)', validate parameter 'uri' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginCredentialProvider.GetAsync(System.Uri,System.Net.IWebProxy,NuGet.Configuration.CredentialRequestType,System.String,System.Boolean,System.Boolean,System.Threading.CancellationToken)~System.Threading.Tasks.Task{NuGet.Credentials.CredentialResponse}")]
[assembly: SuppressMessage("Build", "CA1304:The behavior of 'string.ToLower()' could vary based on the current user's locale settings. Replace this call in 'PluginCredentialProvider.GetPluginResponse(PluginCredentialRequest, CancellationToken)' with a call to 'string.ToLower(CultureInfo)'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginCredentialProvider.GetPluginResponse(NuGet.Credentials.PluginCredentialRequest,System.Threading.CancellationToken)~NuGet.Credentials.PluginCredentialResponse")]
[assembly: SuppressMessage("Build", "CA1822:Member PassVerbosityFlag does not access instance data and can be marked as static (Shared in VisualBasic)", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginCredentialProvider.PassVerbosityFlag(NuGet.Credentials.PluginCredentialRequest)~System.Boolean")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'PluginException PluginException.Create(string path, Exception inner)', validate parameter 'inner' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.Create(System.String,System.Exception)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object, object)' could vary based on the current user's locale settings. Replace this call in 'PluginException.Create(string, Exception)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.Create(System.String,System.Exception)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object, object)' could vary based on the current user's locale settings. Replace this call in 'PluginException.CreateAbortMessage(string, string)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.CreateAbortMessage(System.String,System.String)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, params object[])' could vary based on the current user's locale settings. Replace this call in 'PluginException.CreateInvalidResponseExceptionMessage(string, PluginCredentialResponseExitCode, PluginCredentialResponse)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.CreateInvalidResponseExceptionMessage(System.String,NuGet.Credentials.PluginCredentialResponseExitCode,NuGet.Credentials.PluginCredentialResponse)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'PluginException PluginException.CreateInvalidResponseExceptionMessage(string path, PluginCredentialResponseExitCode status, PluginCredentialResponse response)', validate parameter 'response' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.CreateInvalidResponseExceptionMessage(System.String,NuGet.Credentials.PluginCredentialResponseExitCode,NuGet.Credentials.PluginCredentialResponse)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object)' could vary based on the current user's locale settings. Replace this call in 'PluginException.CreateNotStartedMessage(string)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.CreateNotStartedMessage(System.String)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object, object)' could vary based on the current user's locale settings. Replace this call in 'PluginException.CreatePathNotFoundMessage(string, string)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.CreatePathNotFoundMessage(System.String,System.String)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object, object)' could vary based on the current user's locale settings. Replace this call in 'PluginException.CreateTimeoutMessage(string, int)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginException.CreateTimeoutMessage(System.String,System.Int32)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object, object)' could vary based on the current user's locale settings. Replace this call in 'PluginUnexpectedStatusException.CreateUnexpectedStatusMessage(string, PluginCredentialResponseExitCode)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.PluginUnexpectedStatusException.CreateUnexpectedStatusMessage(System.String,NuGet.Credentials.PluginCredentialResponseExitCode)~NuGet.Credentials.PluginException")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'Task<CredentialResponse> SecurePluginCredentialProvider.GetAsync(Uri uri, IWebProxy proxy, CredentialRequestType type, string message, bool isRetry, bool nonInteractive, CancellationToken cancellationToken)', validate parameter 'uri' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGet.Credentials.SecurePluginCredentialProvider.GetAsync(System.Uri,System.Net.IWebProxy,NuGet.Configuration.CredentialRequestType,System.String,System.Boolean,System.Boolean,System.Threading.CancellationToken)~System.Threading.Tasks.Task{NuGet.Credentials.CredentialResponse}")]
[assembly: SuppressMessage("Build", "CA1056:Change the type of property PluginCredentialRequest.Uri from string to System.Uri.", Justification = "<Pending>", Scope = "member", Target = "~P:NuGet.Credentials.PluginCredentialRequest.Uri")]
[assembly: SuppressMessage("Build", "CA2227:Change 'AuthTypes' to be read-only by removing the property setter.", Justification = "<Pending>", Scope = "member", Target = "~P:NuGet.Credentials.PluginCredentialResponse.AuthTypes")]
[assembly: SuppressMessage("Build", "CA1052:Type 'CredentialsConstants' is a static holder type but is neither static nor NotInheritable", Justification = "<Pending>", Scope = "type", Target = "~T:NuGet.Credentials.CredentialsConstants")]
[assembly: SuppressMessage("Build", "CA1052:Type 'DefaultCredentialServiceUtility' is a static holder type but is neither static nor NotInheritable", Justification = "<Pending>", Scope = "type", Target = "~T:NuGet.Credentials.DefaultCredentialServiceUtility")]
[assembly: SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object, object)' could vary based on the current user's locale settings. Replace this call in 'PluginException.CreateUnreadableResponseExceptionMessage(string, PluginCredentialResponseExitCode)' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "type", Target = "~T:NuGet.Credentials.PluginException")]
